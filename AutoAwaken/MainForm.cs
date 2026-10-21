using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace AutoAwaken
{
    public partial class MainForm : Form
    {
        // Global hotkeys (they work even when this window is not focused)
        const int HOTKEY_CAPTURE_CURSOR = 1; // F4
        const int HOTKEY_START_STOP = 2;     // F5
        const int VK_F4 = 0x73;
        const int VK_F5 = 0x74;

        // After this many OCR reads with no new text, we assume the game is stuck
        // and click the Perin button.
        const int STUCK_LIMIT = 10;

        private readonly Timer cursorTimer = new Timer { Interval = 1000 }; // shows the mouse position
        private readonly Timer clickTimer = new Timer();                    // clicks the awaken button
        private readonly Timer ocrTimer = new Timer { Interval = 200 };     // reads the stats from the screen
        private readonly Timer perinKeyTimer = new Timer();                 // presses the "0" key

        private ScreenReader? screenReader;
        private Rectangle captureArea;
        private bool isRunning = false;
        private bool isReading = false;

        private string lastText = "";
        private int sameTextCount = 0;

        public MainForm()
        {
            InitializeComponent();

            cursorTimer.Tick += (s, e) => ShowCursorPosition();
            clickTimer.Tick += (s, e) => ClickAwakenButton();
            ocrTimer.Tick += (s, e) => ReadAndCheckStats();
            perinKeyTimer.Tick += (s, e) => PressZeroKey();

            cursorTimer.Start();
        }

        // ───────────────────────── Window and hotkeys ─────────────────────────

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Win32.UseDarkTitleBar(Handle);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboMode.SelectedIndex = 0;
            Win32.RegisterHotKey(Handle, HOTKEY_CAPTURE_CURSOR, 0, VK_F4);
            Win32.RegisterHotKey(Handle, HOTKEY_START_STOP, 0, VK_F5);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Win32.UnregisterHotKey(Handle, HOTKEY_CAPTURE_CURSOR);
            Win32.UnregisterHotKey(Handle, HOTKEY_START_STOP);
            base.OnFormClosing(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32.WM_HOTKEY)
            {
                int hotkey = m.WParam.ToInt32();
                if (hotkey == HOTKEY_CAPTURE_CURSOR) CaptureCursorPosition();
                if (hotkey == HOTKEY_START_STOP) ToggleStartStop();
            }
            base.WndProc(ref m);
        }

        // ───────────────────────── Buttons ─────────────────────────

        private void btnStart_Click(object sender, EventArgs e) => ToggleStartStop();

        private void btnStop_Click(object sender, EventArgs e) => Stop();

        private void btnTrackCursor_Click(object sender, EventArgs e) => cursorTimer.Start();

        private void btnStopTracking_Click(object sender, EventArgs e) => cursorTimer.Stop();

        private void btnCaptureArea_Click(object sender, EventArgs e)
        {
            using var selector = new AreaSelectorForm();
            if (selector.ShowDialog() != DialogResult.OK) return;

            captureArea = selector.SelectedArea;
            txtAreaX.Text = captureArea.X.ToString();
            txtAreaY.Text = captureArea.Y.ToString();
            txtAreaW.Text = captureArea.Width.ToString();
            txtAreaH.Text = captureArea.Height.ToString();
        }

        // ───────────────────────── Cursor position ─────────────────────────

        private void ShowCursorPosition()
        {
            txtClickX.Text = Cursor.Position.X.ToString();
            txtClickY.Text = Cursor.Position.Y.ToString();
        }

        /// <summary>F4: saves the mouse position as the click target and flashes the boxes white.</summary>
        private void CaptureCursorPosition()
        {
            ShowCursorPosition();

            SetClickBoxColors(Color.White, Color.Black);

            var flashTimer = new Timer { Interval = 500 };
            flashTimer.Tick += (s, e) =>
            {
                SetClickBoxColors(Theme.Input, Theme.Text);
                flashTimer.Dispose();
            };
            flashTimer.Start();
        }

        private void SetClickBoxColors(Color back, Color text)
        {
            txtClickX.BackColor = back;
            txtClickY.BackColor = back;
            txtClickX.ForeColor = text;
            txtClickY.ForeColor = text;
        }

        // ───────────────────────── Start / Stop ─────────────────────────

        private void ToggleStartStop()
        {
            if (isRunning)
                Stop();
            else
                Start();
        }

        private void Start()
        {
            try
            {
                screenReader ??= new ScreenReader();
            }
            catch (Exception ex)
            {
                string tessDataFolder = Path.Combine(Application.StartupPath, "tessdata");
                MessageBox.Show($"Error starting: {ex.Message}\n\nOCR data folder: {tessDataFolder}\n" +
                                "Make sure this folder exists and contains eng.traineddata.");
                return;
            }

            if (!int.TryParse(txtAreaX.Text, out int x) ||
                !int.TryParse(txtAreaY.Text, out int y) ||
                !int.TryParse(txtAreaW.Text, out int width) ||
                !int.TryParse(txtAreaH.Text, out int height))
            {
                MessageBox.Show("Invalid capture area values.");
                return;
            }
            captureArea = new Rectangle(x, y, width, height);

            if (!double.TryParse(txtClickInterval.Text, out double clickSeconds) || clickSeconds <= 0)
            {
                MessageBox.Show("Invalid click interval.");
                return;
            }
            clickTimer.Interval = (int)(clickSeconds * 1000);

            if (chkAutoPerin.Checked && int.TryParse(txtPerinInterval.Text, out int perinSeconds) && perinSeconds > 0)
            {
                perinKeyTimer.Interval = perinSeconds * 1000;
                perinKeyTimer.Start();
                Console.WriteLine($"Auto press 0 started, every {perinSeconds} seconds.");
            }

            clickTimer.Start();
            ocrTimer.Start();
            isRunning = true;

            btnStart.Text = "Running...";
            btnStart.BackColor = Theme.RunningButton;
            btnStart.ForeColor = Theme.Text;
        }

        private void Stop()
        {
            clickTimer.Stop();
            ocrTimer.Stop();
            perinKeyTimer.Stop();
            isRunning = false;

            btnStart.Text = "Start";
            btnStart.BackColor = Theme.StartButton;
            btnStart.ForeColor = Color.Black;
        }

        /// <summary>A good roll was found: stop, ring the alarm and show a message until OK is pressed.</summary>
        private void StopWithAlarm(string message)
        {
            Stop();

            using var alarm = new SoundPlayer("alarm.wav");
            alarm.PlayLooping();

            MessageBox.Show(message, "Confirm Stop", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); // DefaultDesktopOnly forces the box on top

            alarm.Stop();
            Console.WriteLine($"[DEBUG] Timers stopped: {message}");
        }

        // ───────────────────────── Timer actions ─────────────────────────

        private void ClickAwakenButton()
        {
            if (int.TryParse(txtClickX.Text, out int x) && int.TryParse(txtClickY.Text, out int y))
            {
                Win32.ClickAt(x, y);
            }
        }

        private void PressZeroKey()
        {
            SendKeys.SendWait("0");
            Console.WriteLine("SendKeys pressed 0");
        }

        /// <summary>Clicks the Perin position 5 times. Used when the screen seems stuck.</summary>
        private void ClickPerin()
        {
            if (!int.TryParse(txtPerinX.Text, out int x)) return;
            if (!int.TryParse(txtPerinY.Text, out int y)) return;

            Thread.Sleep(100);
            for (int i = 0; i < 5; i++)
            {
                Win32.ClickAt(x, y);
            }

            sameTextCount = 0;
        }

        private void ReadAndCheckStats()
        {
            // Skip this tick if the previous read is still running
            if (isReading) return;
            isReading = true;

            try
            {
                string text = screenReader!.ReadText(captureArea);
                Console.WriteLine($"[DEBUG] OCR normalizedText: '{text}'");

                // Watch for a stuck screen: the same text (or no text) over and over
                if (text == lastText) sameTextCount++;
                else sameTextCount = 0;
                if (string.IsNullOrWhiteSpace(text)) sameTextCount++;
                lastText = text;

                if (sameTextCount >= STUCK_LIMIT)
                {
                    ClickPerin();
                }

                // Fewer than 3 lines means the stats window is not fully read yet
                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length < 3)
                {
                    Console.WriteLine("[DEBUG] OCR returned fewer than 3 lines → continue");
                    return;
                }

                AddToLog(text);

                List<string> wantedStats = GetCheckedStats();
                string? mode = comboMode.SelectedItem?.ToString();
                int statCount = (int)numStatCount.Value;

                Console.WriteLine($"[DEBUG] Keywords selected: {string.Join(", ", wantedStats)}");
                Console.WriteLine($"[DEBUG] Mode selected: {mode}");
                Console.WriteLine($"[DEBUG] Required count: {statCount}");

                CheckResult result = StatChecker.Check(text, wantedStats, mode, statCount, chkSemiPerf.Checked);
                if (result.IsGoodRoll)
                {
                    StopWithAlarm(result.Message);
                    HighlightInLog(result.MatchedStats);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] OCR processing failed: {ex.Message}");
            }
            finally
            {
                isReading = false;
            }
        }

        // ───────────────────────── Helpers ─────────────────────────

        private List<string> GetCheckedStats()
        {
            return cardOptions.Controls.OfType<CheckBox>()
                .Where(box => box.Checked)
                .Select(box => box.Text)
                .ToList();
        }

        private void AddToLog(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        /// <summary>Marks every occurrence of the given stats in the log (bold, black on white).</summary>
        private void HighlightInLog(List<string> stats)
        {
            foreach (string stat in stats)
            {
                string cleanStat = System.Text.RegularExpressions.Regex.Replace(stat, @"\s+", " ").Trim();

                int index = 0;
                while ((index = txtLog.Find(cleanStat, index, RichTextBoxFinds.None)) != -1)
                {
                    txtLog.SelectionStart = index;
                    txtLog.SelectionLength = cleanStat.Length;
                    txtLog.SelectionColor = Color.Black;
                    txtLog.SelectionBackColor = Color.White;
                    txtLog.SelectionFont = new Font(txtLog.Font, FontStyle.Bold);
                    index += cleanStat.Length;
                }
            }
        }
    }
}
