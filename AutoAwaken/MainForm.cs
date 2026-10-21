using System.Diagnostics;
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

        // If the captured text stays the same (or empty) this long, we assume the game is stuck
        // and click the Perin position a few times to get it going again.
        static readonly TimeSpan STUCK_TIME = TimeSpan.FromSeconds(10);
        const int STUCK_CLICK_COUNT = 10;
        const int STUCK_CLICK_DELAY_MS = 50;

        // The log is cleared when it gets longer than this, so adding to it stays fast
        const int MAX_LOG_LENGTH = 50_000;

        private readonly Timer cursorTimer = new Timer { Interval = 1000 }; // shows the mouse position
        private readonly Timer clickTimer = new Timer();                    // clicks the awaken button
        private readonly Timer ocrTimer = new Timer { Interval = 50 };      // reads the stats from the screen (a new read starts as soon as the last one ends)
        private readonly Timer perinKeyTimer = new Timer();                 // presses the "0" key

        private ScreenReader? screenReader;
        private Rectangle captureArea;
        private bool isRunning = false;
        private bool isReading = false;

        private string lastText = "";
        private readonly Stopwatch sameTextTime = new Stopwatch(); // how long the text has not changed

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

            lastText = "";
            sameTextTime.Restart();

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
            Win32.PressKey(Win32.VK_0);
            Console.WriteLine("Pressed 0");
        }

        /// <summary>Clicks the Perin position several times, with a short pause so the game sees every click. Used when the screen seems stuck.</summary>
        private async Task ClickPerinWhenStuck()
        {
            if (!int.TryParse(txtPerinX.Text, out int x) || !int.TryParse(txtPerinY.Text, out int y))
            {
                Console.WriteLine("[ERROR] Invalid Perin X/Y, cannot click Perin");
                return;
            }

            Console.WriteLine($"[DEBUG] Text unchanged for {STUCK_TIME.TotalSeconds}s → clicking Perin ({x}, {y}) x{STUCK_CLICK_COUNT}");
            // Pause the awaken clicks so they don't move the mouse away in between
            clickTimer.Stop();
            try
            {
                for (int i = 0; i < STUCK_CLICK_COUNT; i++)
                {
                    if (!isRunning) return;
                    Win32.ClickAt(x, y);
                    await Task.Delay(STUCK_CLICK_DELAY_MS);
                }
            }
            finally
            {
                if (isRunning) clickTimer.Start();
            }
        }

        private async void ReadAndCheckStats()
        {
            // Skip this tick if the previous read is still running
            if (isReading) return;
            isReading = true;

            try
            {
                // Run the OCR on a background thread so the window (and the log) never freezes
                ScreenReader reader = screenReader!;
                Rectangle area = captureArea;
                string text = await Task.Run(() => reader.ReadText(area));

                // Stopped while the OCR was running: ignore this result
                if (!isRunning) return;

                Console.WriteLine($"[DEBUG] OCR normalizedText: '{text}'");

                // Watch for a stuck screen: the same text (or no text) for too long
                bool isNewText = text != lastText;
                if (isNewText && !string.IsNullOrWhiteSpace(text)) sameTextTime.Restart();
                lastText = text;

                if (sameTextTime.Elapsed >= STUCK_TIME)
                {
                    await ClickPerinWhenStuck();
                    sameTextTime.Restart();
                }

                // Same roll as last time: already logged and checked
                if (!isNewText) return;

                // Fewer than 3 lines means the stats window is not fully read yet
                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length < 3)
                {
                    Console.WriteLine("[DEBUG] OCR returned fewer than 3 lines → continue");
                    return;
                }

                int logStart = AddToLog(text);

                List<string> wantedStats = GetCheckedStats();
                string? mode = comboMode.SelectedItem?.ToString();
                int statCount = (int)numStatCount.Value;

                Console.WriteLine($"[DEBUG] Keywords selected: {string.Join(", ", wantedStats)}");
                Console.WriteLine($"[DEBUG] Mode selected: {mode}");
                Console.WriteLine($"[DEBUG] Required count: {statCount}");

                CheckResult result = StatChecker.Check(text, wantedStats, mode, statCount, chkSemiPerf.Checked);
                if (result.IsGoodRoll)
                {
                    // Highlight first, so the stats are visible while the alarm box is open
                    HighlightInLog(result.MatchedStats, logStart);
                    StopWithAlarm(result.Message);
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

        /// <summary>Adds text to the log and returns where it starts. Old lines are trimmed so the log stays fast.</summary>
        private int AddToLog(string text)
        {
            if (txtLog.TextLength > MAX_LOG_LENGTH)
            {
                txtLog.Clear();
            }

            int start = txtLog.TextLength;
            txtLog.AppendText(text + Environment.NewLine);
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
            return start;
        }

        /// <summary>Marks every occurrence of the given stats in the log from <paramref name="startIndex"/> on (bold, black on white).</summary>
        private void HighlightInLog(List<string> stats, int startIndex)
        {
            foreach (string stat in stats)
            {
                string cleanStat = System.Text.RegularExpressions.Regex.Replace(stat, @"\s+", " ").Trim();

                int index = startIndex;
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
