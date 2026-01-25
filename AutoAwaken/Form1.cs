using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tesseract;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Timer = System.Windows.Forms.Timer;

namespace AutoAwaken
{
    public partial class Form1 : Form
    {
        private Timer ocrTimer = new Timer();
        private TesseractEngine engine;
        private Rectangle captureArea;
        private bool isRunning = false;
        Timer clickTimer = new Timer();
        Timer cursorTimer = new Timer();
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [StructLayout(LayoutKind.Sequential)] struct POINT { public int X; public int Y; }
        [DllImport("user32.dll")] static extern bool GetCursorPos(out POINT lpPoint);

        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x04;


        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int WM_HOTKEY = 0x0312;
        const int HOTKEY_CURSOR = 1;   // ID for F4
        const int VK_F4 = 0x73;        // Virtual key code for F4
        const int HOTKEY_STARTSTOP = 2; // ID for F5
        const int VK_F5 = 0x74;         // Virtual key code for F5

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public Form1()
        {
            InitializeComponent();

            cursorTimer.Interval = 1000; // update every 200 ms
            cursorTimer.Tick += CursorTimer_Tick;
            cursorTimer.Start(); // start tracking immediately

            clickTimer.Interval = 1000; // click every 500 ms clickTimer.Tick += ClickTimer_Tick;
            clickTimer.Tick += ClickTimer_Tick;
            // 🔴 You forgot this part:
            ocrTimer.Interval = 500; // 
            ocrTimer.Tick += OcrTimer_Tick;
        }
       

        private void CursorTimer_Tick(object sender, EventArgs e)
        {
            POINT p;
            if (GetCursorPos(out p))
            {
                txtX.Text = p.X.ToString();
                txtY.Text = p.Y.ToString();
            }
        }



        private void FocusTargetWindow()
        {
            // Replace with the exact title of the external app window
            IntPtr hWnd = FindWindow(null, "Notepad");
            if (hWnd != IntPtr.Zero)
            {
                SetForegroundWindow(hWnd);
            }
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_CURSOR);
            UnregisterHotKey(this.Handle, HOTKEY_STARTSTOP);
            base.OnFormClosing(e);
        }

        private void CaptureCursorPosition()
        {
            POINT p;
            if (GetCursorPos(out p))
            {
                txtX.Text = p.X.ToString();
                txtY.Text = p.Y.ToString();

                // Flash background to indicate capture
                txtX.BackColor = Color.Yellow;
                txtY.BackColor = Color.Yellow;

                var timer = new Timer();
                timer.Interval = 500; // half a second
                timer.Tick += (s, e) =>
                {
                    txtX.BackColor = SystemColors.Window;
                    txtY.BackColor = SystemColors.Window;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }
        private void ToggleClicking()
        {
            if (!clickTimer.Enabled)
                clickTimer.Start();
            else
                clickTimer.Stop();
        }

        private void ToggleStartStop()
        {
            if (!isRunning)
            {
                if (engine == null)
                {
                    engine = new TesseractEngine(
                        Path.Combine(Application.StartupPath, "tessdata"),
                        "eng",
                        EngineMode.TesseractOnly
                    );
                }

                captureArea = new Rectangle(
                    int.Parse(txtAreaX.Text),
                    int.Parse(txtAreaY.Text),
                    int.Parse(txtAreaW.Text),
                    int.Parse(txtAreaH.Text)
                );

                // Set intervals
                clickTimer.Interval = (int)(double.Parse(txtTime.Text) * 1000);
              
                ocrTimer.Interval = 100;  // OCR every 1 second

                // Start both timers
                clickTimer.Start();
                ocrTimer.Start();
                isRunning = true;

                btnStart.Text = "Running...";
                btnStart.BackColor = Color.LightGreen;
            }
            else
            {
                clickTimer.Stop();
                ocrTimer.Stop();
                isRunning = false;

                btnStart.Text = "Start";
                btnStart.BackColor = SystemColors.Control;
            }
        }



        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                if (id == HOTKEY_CURSOR)
                {
                    CaptureCursorPosition();
                }
                else if (id == HOTKEY_STARTSTOP)
                {
                    ToggleStartStop();
                }
            }
            base.WndProc(ref m);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            comboMode.SelectedIndex = 0;
            RegisterHotKey(this.Handle, HOTKEY_CURSOR, 0, VK_F4);
            RegisterHotKey(this.Handle, HOTKEY_STARTSTOP, 0, VK_F5);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
        private bool _ocrBusy = false;

        private List<string> GetCheckedKeywords()
        {
            return this.Controls.OfType<System.Windows.Forms.CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => cb.Text)
                .ToList();
        }


        private void OcrTimer_Tick(object sender, EventArgs e)
        {
            if (_ocrBusy) return;
            _ocrBusy = true;

            try
            {
                using Bitmap bmp = PreprocessForOcr(captureArea);
                string text = ReadTextFromImage(bmp);

                txtLog.AppendText(text + Environment.NewLine);

                var keywords = GetCheckedKeywords();
                int requiredCount = (int)numericUpDown1.Value;

                string mode = comboMode.SelectedItem?.ToString();

                if (mode == "Mix")
                {
                    // AW mode: mixed allowed, count all matches
                    int matchCount = 0;
                    foreach (string keyword in keywords)
                    {
                        matchCount += Regex.Matches(text, Regex.Escape(keyword), RegexOptions.IgnoreCase).Count;
                    }

                    if (matchCount >= requiredCount)
                    {
                        StopTimers("AW mode matched " + matchCount + " keyword(s). Stopped.");
                    }
                }
                else if (mode == "Strict")
                {
                    // AS mode: must be same keyword repeated
                    foreach (string keyword in keywords)
                    {
                        int count = Regex.Matches(text, Regex.Escape(keyword), RegexOptions.IgnoreCase).Count;
                        if (count >= requiredCount)
                        {
                            StopTimers("AS mode matched " + count + "x '" + keyword + "'. Stopped.");
                            break;
                        }
                    }
                }
            }
            finally
            {
                _ocrBusy = false;
            }
        }

        private void StopTimers(string message)
        {
            clickTimer.Stop();
            ocrTimer.Stop();
            isRunning = false;
            MessageBox.Show(message);
        }





        private Bitmap PreprocessForOcr(Rectangle area)
        {
            // Capture the screen area
            Bitmap bmp = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(bmp))
                g.CopyFromScreen(area.Location, Point.Empty, area.Size);

            // Scale up for better OCR (2x)
            Bitmap scaled = new Bitmap(bmp, bmp.Width * 2, bmp.Height * 2);

            // Convert to grayscale
            for (int y = 0; y < scaled.Height; y++)
            {
                for (int x = 0; x < scaled.Width; x++)
                {
                    Color pixel = scaled.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    scaled.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            bmp.Dispose();
            return scaled;
        }



        private Bitmap CaptureScreenArea(Rectangle area)
        {
            Bitmap bmp = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(bmp))
                g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            return bmp;
        }

        private string ReadTextFromImage(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                using (var pix = Pix.LoadFromMemory(ms.ToArray()))
                using (var page = engine.Process(pix))
                {
                    return page.GetText();
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public int type;
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        const int INPUT_MOUSE = 0;


        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            PerformClick();
        }

 

        private void PerformClick()
        {
            // Get target coordinates from your textboxes (or fixed values)
            int clickX = int.Parse(txtX.Text);
            int clickY = int.Parse(txtY.Text);

            // Move cursor to target position
            SetCursorPos(clickX, clickY);

            // Simulate left mouse click
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickX, clickY, 0, 0);

        
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            ToggleStartStop();
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            clickTimer.Stop();
            ocrTimer.Stop();
            isRunning = false;
        }
        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            if (captureArea != Rectangle.Empty)
            {
                // Scale down to fit panel
                float scaleX = (float)previewPanel.Width / Screen.PrimaryScreen.Bounds.Width;
                float scaleY = (float)previewPanel.Height / Screen.PrimaryScreen.Bounds.Height;

                Rectangle scaled = new Rectangle(
                    (int)(captureArea.X * scaleX),
                    (int)(captureArea.Y * scaleY),
                    (int)(captureArea.Width * scaleX),
                    (int)(captureArea.Height * scaleY)
                );

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, scaled);
                }
            }
        }

        private void btnSelectArea_Click(object sender, EventArgs e)
        {
            using (var selector = new AreaSelectorForm())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    captureArea = selector.SelectedArea;

                    txtAreaX.Text = captureArea.X.ToString();
                    txtAreaY.Text = captureArea.Y.ToString();
                    txtAreaW.Text = captureArea.Width.ToString();
                    txtAreaH.Text = captureArea.Height.ToString();

                    // Trigger redraw of preview
                    previewPanel.Invalidate();
                }
            }
        }

        private void btnTrackCoords_Click(object sender, EventArgs e)
        {
            cursorTimer.Start();
        }

        private void btnLockCoords_Click(object sender, EventArgs e)
        {
            cursorTimer.Stop();
        }
    }
}
