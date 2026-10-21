namespace AutoAwaken
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblItemType = new Label();
            comboItemType = new ComboBox();
            cardClickTimer = new Panel();
            lblClickTimerTitle = new Label();
            lblClickEvery = new Label();
            txtClickInterval = new TextBox();
            lblClickSec = new Label();
            cardPerin = new Panel();
            lblPerinTitle = new Label();
            chkAutoPerin = new CheckBox();
            txtPerinInterval = new TextBox();
            lblPerinSec = new Label();
            lblPerinX = new Label();
            txtPerinX = new TextBox();
            lblPerinY = new Label();
            txtPerinY = new TextBox();
            cardCursor = new Panel();
            lblCursorTitle = new Label();
            btnTrackCursor = new Button();
            btnStopTracking = new Button();
            lblClickXCaption = new Label();
            txtClickX = new TextBox();
            lblClickYCaption = new Label();
            txtClickY = new TextBox();
            cardArea = new Panel();
            lblAreaTitle = new Label();
            btnCaptureArea = new Button();
            lblAreaXCaption = new Label();
            txtAreaX = new TextBox();
            lblAreaYCaption = new Label();
            txtAreaY = new TextBox();
            lblAreaWCaption = new Label();
            txtAreaW = new TextBox();
            lblAreaHCaption = new Label();
            txtAreaH = new TextBox();
            cardOptions = new Panel();
            lblOptionsTitle = new Label();
            chkInt = new CheckBox();
            chkSta = new CheckBox();
            chkStr = new CheckBox();
            chkDex = new CheckBox();
            chkSpeed = new CheckBox();
            chkAttackSpeed = new CheckBox();
            chkCritChance = new CheckBox();
            chkCritDamage19 = new CheckBox();
            chkCritDamage17 = new CheckBox();
            chkCastingTime = new CheckBox();
            chkHp = new CheckBox();
            chkMp = new CheckBox();
            chkFp = new CheckBox();
            chkAttack = new CheckBox();
            chkDef = new CheckBox();
            cardRun = new Panel();
            lblStatCount = new Label();
            numStatCount = new NumericUpDown();
            lblMode = new Label();
            comboMode = new ComboBox();
            chkSemiPerf = new CheckBox();
            btnStart = new Button();
            btnStop = new Button();
            lblLog = new Label();
            lblMatchCount = new Label();
            txtLog = new RichTextBox();
            pnlHeader.SuspendLayout();
            cardClickTimer.SuspendLayout();
            cardPerin.SuspendLayout();
            cardCursor.SuspendLayout();
            cardArea.SuspendLayout();
            cardOptions.SuspendLayout();
            cardRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStatCount).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblItemType);
            pnlHeader.Controls.Add(comboItemType);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(680, 52);
            pnlHeader.TabIndex = 8;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(240, 240, 240);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Settings";
            //
            // lblItemType
            //
            lblItemType.AutoSize = true;
            lblItemType.ForeColor = Color.FromArgb(150, 150, 150);
            lblItemType.Location = new Point(440, 18);
            lblItemType.Name = "lblItemType";
            lblItemType.Text = "Item";
            //
            // comboItemType
            //
            comboItemType.BackColor = Color.FromArgb(42, 42, 42);
            comboItemType.FlatStyle = FlatStyle.Flat;
            comboItemType.ForeColor = Color.FromArgb(240, 240, 240);
            comboItemType.Items.AddRange(new object[] { "W/S/S", "Helmet", "Boots", "Gloves" });
            comboItemType.Location = new Point(480, 14);
            comboItemType.Name = "comboItemType";
            comboItemType.Size = new Size(184, 23);
            comboItemType.TabIndex = 0;
            comboItemType.Text = "Choose";
            //
            // cardClickTimer
            //
            cardClickTimer.BackColor = Color.FromArgb(30, 30, 30);
            cardClickTimer.Controls.Add(lblClickTimerTitle);
            cardClickTimer.Controls.Add(lblClickEvery);
            cardClickTimer.Controls.Add(txtClickInterval);
            cardClickTimer.Controls.Add(lblClickSec);
            cardClickTimer.Location = new Point(16, 64);
            cardClickTimer.Name = "cardClickTimer";
            cardClickTimer.Size = new Size(200, 96);
            cardClickTimer.TabIndex = 1;
            //
            // lblClickTimerTitle
            //
            lblClickTimerTitle.AutoSize = true;
            lblClickTimerTitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClickTimerTitle.ForeColor = Color.FromArgb(150, 150, 150);
            lblClickTimerTitle.Location = new Point(12, 10);
            lblClickTimerTitle.Name = "lblClickTimerTitle";
            lblClickTimerTitle.Text = "CLICK TIMER";
            //
            // lblClickEvery
            //
            lblClickEvery.AutoSize = true;
            lblClickEvery.Location = new Point(12, 48);
            lblClickEvery.Name = "lblClickEvery";
            lblClickEvery.Text = "Every";
            //
            // txtClickInterval
            //
            txtClickInterval.BackColor = Color.FromArgb(42, 42, 42);
            txtClickInterval.BorderStyle = BorderStyle.FixedSingle;
            txtClickInterval.ForeColor = Color.FromArgb(240, 240, 240);
            txtClickInterval.Location = new Point(56, 45);
            txtClickInterval.Name = "txtClickInterval";
            txtClickInterval.Size = new Size(60, 23);
            txtClickInterval.TabIndex = 0;
            txtClickInterval.Text = "0.8";
            //
            // lblClickSec
            //
            lblClickSec.AutoSize = true;
            lblClickSec.ForeColor = Color.FromArgb(150, 150, 150);
            lblClickSec.Location = new Point(122, 48);
            lblClickSec.Name = "lblClickSec";
            lblClickSec.Text = "sec.";
            //
            // cardPerin
            //
            cardPerin.BackColor = Color.FromArgb(30, 30, 30);
            cardPerin.Controls.Add(lblPerinTitle);
            cardPerin.Controls.Add(chkAutoPerin);
            cardPerin.Controls.Add(txtPerinInterval);
            cardPerin.Controls.Add(lblPerinSec);
            cardPerin.Controls.Add(lblPerinX);
            cardPerin.Controls.Add(txtPerinX);
            cardPerin.Controls.Add(lblPerinY);
            cardPerin.Controls.Add(txtPerinY);
            cardPerin.Location = new Point(228, 64);
            cardPerin.Name = "cardPerin";
            cardPerin.Size = new Size(436, 96);
            cardPerin.TabIndex = 2;
            //
            // lblPerinTitle
            //
            lblPerinTitle.AutoSize = true;
            lblPerinTitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPerinTitle.ForeColor = Color.FromArgb(150, 150, 150);
            lblPerinTitle.Location = new Point(12, 10);
            lblPerinTitle.Name = "lblPerinTitle";
            lblPerinTitle.Text = "AUTO PRESS PERIN";
            //
            // chkAutoPerin
            //
            chkAutoPerin.AutoSize = true;
            chkAutoPerin.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkAutoPerin.FlatStyle = FlatStyle.Flat;
            chkAutoPerin.Location = new Point(12, 47);
            chkAutoPerin.Name = "chkAutoPerin";
            chkAutoPerin.TabIndex = 0;
            chkAutoPerin.Text = "Activate";
            //
            // txtPerinInterval
            //
            txtPerinInterval.BackColor = Color.FromArgb(42, 42, 42);
            txtPerinInterval.BorderStyle = BorderStyle.FixedSingle;
            txtPerinInterval.ForeColor = Color.FromArgb(240, 240, 240);
            txtPerinInterval.Location = new Point(96, 45);
            txtPerinInterval.Name = "txtPerinInterval";
            txtPerinInterval.Size = new Size(50, 23);
            txtPerinInterval.TabIndex = 1;
            txtPerinInterval.Text = "62";
            //
            // lblPerinSec
            //
            lblPerinSec.AutoSize = true;
            lblPerinSec.ForeColor = Color.FromArgb(150, 150, 150);
            lblPerinSec.Location = new Point(152, 48);
            lblPerinSec.Name = "lblPerinSec";
            lblPerinSec.Text = "sec.";
            //
            // lblPerinX
            //
            lblPerinX.AutoSize = true;
            lblPerinX.ForeColor = Color.FromArgb(150, 150, 150);
            lblPerinX.Location = new Point(206, 48);
            lblPerinX.Name = "lblPerinX";
            lblPerinX.Text = "X";
            //
            // txtPerinX
            //
            txtPerinX.BackColor = Color.FromArgb(42, 42, 42);
            txtPerinX.BorderStyle = BorderStyle.FixedSingle;
            txtPerinX.ForeColor = Color.FromArgb(240, 240, 240);
            txtPerinX.Location = new Point(222, 45);
            txtPerinX.Name = "txtPerinX";
            txtPerinX.Size = new Size(84, 23);
            txtPerinX.TabIndex = 2;
            txtPerinX.Text = "0";
            //
            // lblPerinY
            //
            lblPerinY.AutoSize = true;
            lblPerinY.ForeColor = Color.FromArgb(150, 150, 150);
            lblPerinY.Location = new Point(318, 48);
            lblPerinY.Name = "lblPerinY";
            lblPerinY.Text = "Y";
            //
            // txtPerinY
            //
            txtPerinY.BackColor = Color.FromArgb(42, 42, 42);
            txtPerinY.BorderStyle = BorderStyle.FixedSingle;
            txtPerinY.ForeColor = Color.FromArgb(240, 240, 240);
            txtPerinY.Location = new Point(334, 45);
            txtPerinY.Name = "txtPerinY";
            txtPerinY.Size = new Size(84, 23);
            txtPerinY.TabIndex = 3;
            txtPerinY.Text = "0";
            //
            // cardCursor
            //
            cardCursor.BackColor = Color.FromArgb(30, 30, 30);
            cardCursor.Controls.Add(lblCursorTitle);
            cardCursor.Controls.Add(btnTrackCursor);
            cardCursor.Controls.Add(btnStopTracking);
            cardCursor.Controls.Add(lblClickXCaption);
            cardCursor.Controls.Add(txtClickX);
            cardCursor.Controls.Add(lblClickYCaption);
            cardCursor.Controls.Add(txtClickY);
            cardCursor.Location = new Point(16, 172);
            cardCursor.Name = "cardCursor";
            cardCursor.Size = new Size(648, 80);
            cardCursor.TabIndex = 3;
            //
            // lblCursorTitle
            //
            lblCursorTitle.AutoSize = true;
            lblCursorTitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCursorTitle.ForeColor = Color.FromArgb(150, 150, 150);
            lblCursorTitle.Location = new Point(12, 10);
            lblCursorTitle.Name = "lblCursorTitle";
            lblCursorTitle.Text = "CURSOR CAPTURE";
            //
            // btnTrackCursor
            //
            btnTrackCursor.BackColor = Color.FromArgb(42, 42, 42);
            btnTrackCursor.Cursor = Cursors.Hand;
            btnTrackCursor.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnTrackCursor.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            btnTrackCursor.FlatStyle = FlatStyle.Flat;
            btnTrackCursor.Location = new Point(12, 36);
            btnTrackCursor.Name = "btnTrackCursor";
            btnTrackCursor.Size = new Size(96, 30);
            btnTrackCursor.TabIndex = 0;
            btnTrackCursor.Text = "Start (F4)";
            btnTrackCursor.UseVisualStyleBackColor = false;
            btnTrackCursor.Click += btnTrackCursor_Click;
            //
            // btnStopTracking
            //
            btnStopTracking.BackColor = Color.FromArgb(42, 42, 42);
            btnStopTracking.Cursor = Cursors.Hand;
            btnStopTracking.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnStopTracking.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            btnStopTracking.FlatStyle = FlatStyle.Flat;
            btnStopTracking.Location = new Point(114, 36);
            btnStopTracking.Name = "btnStopTracking";
            btnStopTracking.Size = new Size(96, 30);
            btnStopTracking.TabIndex = 1;
            btnStopTracking.Text = "Stop";
            btnStopTracking.UseVisualStyleBackColor = false;
            btnStopTracking.Click += btnStopTracking_Click;
            //
            // lblClickXCaption
            //
            lblClickXCaption.AutoSize = true;
            lblClickXCaption.ForeColor = Color.FromArgb(150, 150, 150);
            lblClickXCaption.Location = new Point(232, 43);
            lblClickXCaption.Name = "lblClickXCaption";
            lblClickXCaption.Text = "X";
            //
            // txtClickX
            //
            txtClickX.BackColor = Color.FromArgb(42, 42, 42);
            txtClickX.BorderStyle = BorderStyle.FixedSingle;
            txtClickX.ForeColor = Color.FromArgb(240, 240, 240);
            txtClickX.Location = new Point(248, 40);
            txtClickX.Name = "txtClickX";
            txtClickX.Size = new Size(90, 23);
            txtClickX.TabIndex = 2;
            txtClickX.Text = "0";
            //
            // lblClickYCaption
            //
            lblClickYCaption.AutoSize = true;
            lblClickYCaption.ForeColor = Color.FromArgb(150, 150, 150);
            lblClickYCaption.Location = new Point(352, 43);
            lblClickYCaption.Name = "lblClickYCaption";
            lblClickYCaption.Text = "Y";
            //
            // txtClickY
            //
            txtClickY.BackColor = Color.FromArgb(42, 42, 42);
            txtClickY.BorderStyle = BorderStyle.FixedSingle;
            txtClickY.ForeColor = Color.FromArgb(240, 240, 240);
            txtClickY.Location = new Point(368, 40);
            txtClickY.Name = "txtClickY";
            txtClickY.Size = new Size(90, 23);
            txtClickY.TabIndex = 3;
            txtClickY.Text = "0";
            //
            // cardArea
            //
            cardArea.BackColor = Color.FromArgb(30, 30, 30);
            cardArea.Controls.Add(lblAreaTitle);
            cardArea.Controls.Add(btnCaptureArea);
            cardArea.Controls.Add(lblAreaXCaption);
            cardArea.Controls.Add(txtAreaX);
            cardArea.Controls.Add(lblAreaYCaption);
            cardArea.Controls.Add(txtAreaY);
            cardArea.Controls.Add(lblAreaWCaption);
            cardArea.Controls.Add(txtAreaW);
            cardArea.Controls.Add(lblAreaHCaption);
            cardArea.Controls.Add(txtAreaH);
            cardArea.Location = new Point(16, 264);
            cardArea.Name = "cardArea";
            cardArea.Size = new Size(648, 80);
            cardArea.TabIndex = 4;
            //
            // lblAreaTitle
            //
            lblAreaTitle.AutoSize = true;
            lblAreaTitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAreaTitle.ForeColor = Color.FromArgb(150, 150, 150);
            lblAreaTitle.Location = new Point(12, 10);
            lblAreaTitle.Name = "lblAreaTitle";
            lblAreaTitle.Text = "AREA CAPTURE";
            //
            // btnCaptureArea
            //
            btnCaptureArea.BackColor = Color.FromArgb(42, 42, 42);
            btnCaptureArea.Cursor = Cursors.Hand;
            btnCaptureArea.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnCaptureArea.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            btnCaptureArea.FlatStyle = FlatStyle.Flat;
            btnCaptureArea.Location = new Point(12, 36);
            btnCaptureArea.Name = "btnCaptureArea";
            btnCaptureArea.Size = new Size(110, 30);
            btnCaptureArea.TabIndex = 0;
            btnCaptureArea.Text = "Capture Area";
            btnCaptureArea.UseVisualStyleBackColor = false;
            btnCaptureArea.Click += btnCaptureArea_Click;
            //
            // lblAreaXCaption
            //
            lblAreaXCaption.AutoSize = true;
            lblAreaXCaption.ForeColor = Color.FromArgb(150, 150, 150);
            lblAreaXCaption.Location = new Point(140, 43);
            lblAreaXCaption.Name = "lblAreaXCaption";
            lblAreaXCaption.Text = "X";
            //
            // txtAreaX
            //
            txtAreaX.BackColor = Color.FromArgb(42, 42, 42);
            txtAreaX.BorderStyle = BorderStyle.FixedSingle;
            txtAreaX.ForeColor = Color.FromArgb(240, 240, 240);
            txtAreaX.Location = new Point(156, 40);
            txtAreaX.Name = "txtAreaX";
            txtAreaX.Size = new Size(90, 23);
            txtAreaX.TabIndex = 1;
            txtAreaX.Text = "0";
            //
            // lblAreaYCaption
            //
            lblAreaYCaption.AutoSize = true;
            lblAreaYCaption.ForeColor = Color.FromArgb(150, 150, 150);
            lblAreaYCaption.Location = new Point(258, 43);
            lblAreaYCaption.Name = "lblAreaYCaption";
            lblAreaYCaption.Text = "Y";
            //
            // txtAreaY
            //
            txtAreaY.BackColor = Color.FromArgb(42, 42, 42);
            txtAreaY.BorderStyle = BorderStyle.FixedSingle;
            txtAreaY.ForeColor = Color.FromArgb(240, 240, 240);
            txtAreaY.Location = new Point(274, 40);
            txtAreaY.Name = "txtAreaY";
            txtAreaY.Size = new Size(90, 23);
            txtAreaY.TabIndex = 2;
            txtAreaY.Text = "0";
            //
            // lblAreaWCaption
            //
            lblAreaWCaption.AutoSize = true;
            lblAreaWCaption.ForeColor = Color.FromArgb(150, 150, 150);
            lblAreaWCaption.Location = new Point(376, 43);
            lblAreaWCaption.Name = "lblAreaWCaption";
            lblAreaWCaption.Text = "W";
            //
            // txtAreaW
            //
            txtAreaW.BackColor = Color.FromArgb(42, 42, 42);
            txtAreaW.BorderStyle = BorderStyle.FixedSingle;
            txtAreaW.ForeColor = Color.FromArgb(240, 240, 240);
            txtAreaW.Location = new Point(394, 40);
            txtAreaW.Name = "txtAreaW";
            txtAreaW.Size = new Size(90, 23);
            txtAreaW.TabIndex = 3;
            txtAreaW.Text = "0";
            //
            // lblAreaHCaption
            //
            lblAreaHCaption.AutoSize = true;
            lblAreaHCaption.ForeColor = Color.FromArgb(150, 150, 150);
            lblAreaHCaption.Location = new Point(496, 43);
            lblAreaHCaption.Name = "lblAreaHCaption";
            lblAreaHCaption.Text = "H";
            //
            // txtAreaH
            //
            txtAreaH.BackColor = Color.FromArgb(42, 42, 42);
            txtAreaH.BorderStyle = BorderStyle.FixedSingle;
            txtAreaH.ForeColor = Color.FromArgb(240, 240, 240);
            txtAreaH.Location = new Point(512, 40);
            txtAreaH.Name = "txtAreaH";
            txtAreaH.Size = new Size(90, 23);
            txtAreaH.TabIndex = 4;
            txtAreaH.Text = "0";
            //
            // cardOptions
            //
            cardOptions.BackColor = Color.FromArgb(30, 30, 30);
            cardOptions.Controls.Add(lblOptionsTitle);
            cardOptions.Controls.Add(chkInt);
            cardOptions.Controls.Add(chkSta);
            cardOptions.Controls.Add(chkStr);
            cardOptions.Controls.Add(chkDex);
            cardOptions.Controls.Add(chkSpeed);
            cardOptions.Controls.Add(chkAttackSpeed);
            cardOptions.Controls.Add(chkCritChance);
            cardOptions.Controls.Add(chkCritDamage19);
            cardOptions.Controls.Add(chkCritDamage17);
            cardOptions.Controls.Add(chkCastingTime);
            cardOptions.Controls.Add(chkHp);
            cardOptions.Controls.Add(chkMp);
            cardOptions.Controls.Add(chkFp);
            cardOptions.Controls.Add(chkAttack);
            cardOptions.Controls.Add(chkDef);
            cardOptions.Location = new Point(16, 356);
            cardOptions.Name = "cardOptions";
            cardOptions.Size = new Size(648, 180);
            cardOptions.TabIndex = 5;
            //
            // lblOptionsTitle
            //
            lblOptionsTitle.AutoSize = true;
            lblOptionsTitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOptionsTitle.ForeColor = Color.FromArgb(150, 150, 150);
            lblOptionsTitle.Location = new Point(12, 10);
            lblOptionsTitle.Name = "lblOptionsTitle";
            lblOptionsTitle.Text = "OPTION";
            //
            // chkInt
            //
            chkInt.AutoSize = true;
            chkInt.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkInt.FlatStyle = FlatStyle.Flat;
            chkInt.Location = new Point(12, 36);
            chkInt.Name = "chkInt";
            chkInt.TabIndex = 0;
            chkInt.Text = "INT +28";
            //
            // chkSta
            //
            chkSta.AutoSize = true;
            chkSta.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkSta.FlatStyle = FlatStyle.Flat;
            chkSta.Location = new Point(12, 62);
            chkSta.Name = "chkSta";
            chkSta.TabIndex = 1;
            chkSta.Text = "STA +28";
            //
            // chkStr
            //
            chkStr.AutoSize = true;
            chkStr.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkStr.FlatStyle = FlatStyle.Flat;
            chkStr.Location = new Point(12, 88);
            chkStr.Name = "chkStr";
            chkStr.TabIndex = 2;
            chkStr.Text = "STR +28";
            //
            // chkDex
            //
            chkDex.AutoSize = true;
            chkDex.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkDex.FlatStyle = FlatStyle.Flat;
            chkDex.Location = new Point(12, 114);
            chkDex.Name = "chkDex";
            chkDex.TabIndex = 3;
            chkDex.Text = "DEX +28";
            //
            // chkSpeed
            //
            chkSpeed.AutoSize = true;
            chkSpeed.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkSpeed.FlatStyle = FlatStyle.Flat;
            chkSpeed.Location = new Point(12, 140);
            chkSpeed.Name = "chkSpeed";
            chkSpeed.TabIndex = 4;
            chkSpeed.Text = "Speed +10%";
            //
            // chkAttackSpeed
            //
            chkAttackSpeed.AutoSize = true;
            chkAttackSpeed.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkAttackSpeed.FlatStyle = FlatStyle.Flat;
            chkAttackSpeed.Location = new Point(200, 36);
            chkAttackSpeed.Name = "chkAttackSpeed";
            chkAttackSpeed.TabIndex = 5;
            chkAttackSpeed.Text = "Attack Speed +19%";
            //
            // chkCritChance
            //
            chkCritChance.AutoSize = true;
            chkCritChance.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkCritChance.FlatStyle = FlatStyle.Flat;
            chkCritChance.Location = new Point(200, 62);
            chkCritChance.Name = "chkCritChance";
            chkCritChance.TabIndex = 6;
            chkCritChance.Text = "Crit Chance +10%";
            //
            // chkCritDamage19
            //
            chkCritDamage19.AutoSize = true;
            chkCritDamage19.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkCritDamage19.FlatStyle = FlatStyle.Flat;
            chkCritDamage19.Location = new Point(200, 88);
            chkCritDamage19.Name = "chkCritDamage19";
            chkCritDamage19.TabIndex = 7;
            chkCritDamage19.Text = "Increased Critical Damage +19%";
            //
            // chkCritDamage17
            //
            chkCritDamage17.AutoSize = true;
            chkCritDamage17.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkCritDamage17.FlatStyle = FlatStyle.Flat;
            chkCritDamage17.Location = new Point(200, 114);
            chkCritDamage17.Name = "chkCritDamage17";
            chkCritDamage17.TabIndex = 8;
            chkCritDamage17.Text = "Increased Critical Damage +17%";
            //
            // chkCastingTime
            //
            chkCastingTime.AutoSize = true;
            chkCastingTime.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkCastingTime.FlatStyle = FlatStyle.Flat;
            chkCastingTime.Location = new Point(200, 140);
            chkCastingTime.Name = "chkCastingTime";
            chkCastingTime.TabIndex = 9;
            chkCastingTime.Text = "Decreased Casting Time +10%";
            //
            // chkHp
            //
            chkHp.AutoSize = true;
            chkHp.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkHp.FlatStyle = FlatStyle.Flat;
            chkHp.Location = new Point(460, 36);
            chkHp.Name = "chkHp";
            chkHp.TabIndex = 10;
            chkHp.Text = "Max. HP +500";
            //
            // chkMp
            //
            chkMp.AutoSize = true;
            chkMp.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkMp.FlatStyle = FlatStyle.Flat;
            chkMp.Location = new Point(460, 62);
            chkMp.Name = "chkMp";
            chkMp.TabIndex = 11;
            chkMp.Text = "Max. MP +500";
            //
            // chkFp
            //
            chkFp.AutoSize = true;
            chkFp.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkFp.FlatStyle = FlatStyle.Flat;
            chkFp.Location = new Point(460, 88);
            chkFp.Name = "chkFp";
            chkFp.TabIndex = 12;
            chkFp.Text = "Max. FP +500";
            //
            // chkAttack
            //
            chkAttack.AutoSize = true;
            chkAttack.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkAttack.FlatStyle = FlatStyle.Flat;
            chkAttack.Location = new Point(460, 114);
            chkAttack.Name = "chkAttack";
            chkAttack.TabIndex = 13;
            chkAttack.Text = "Attack +140";
            //
            // chkDef
            //
            chkDef.AutoSize = true;
            chkDef.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkDef.FlatStyle = FlatStyle.Flat;
            chkDef.Location = new Point(460, 140);
            chkDef.Name = "chkDef";
            chkDef.TabIndex = 14;
            chkDef.Text = "DEF +140";
            //
            // cardRun
            //
            cardRun.BackColor = Color.FromArgb(30, 30, 30);
            cardRun.Controls.Add(lblStatCount);
            cardRun.Controls.Add(numStatCount);
            cardRun.Controls.Add(lblMode);
            cardRun.Controls.Add(comboMode);
            cardRun.Controls.Add(chkSemiPerf);
            cardRun.Controls.Add(btnStart);
            cardRun.Controls.Add(btnStop);
            cardRun.Location = new Point(16, 548);
            cardRun.Name = "cardRun";
            cardRun.Size = new Size(648, 64);
            cardRun.TabIndex = 6;
            //
            // lblStatCount
            //
            lblStatCount.AutoSize = true;
            lblStatCount.ForeColor = Color.FromArgb(150, 150, 150);
            lblStatCount.Location = new Point(12, 23);
            lblStatCount.Name = "lblStatCount";
            lblStatCount.Text = "Stat Count";
            //
            // numStatCount
            //
            numStatCount.BackColor = Color.FromArgb(42, 42, 42);
            numStatCount.BorderStyle = BorderStyle.FixedSingle;
            numStatCount.ForeColor = Color.FromArgb(240, 240, 240);
            numStatCount.Location = new Point(84, 20);
            numStatCount.Name = "numStatCount";
            numStatCount.Size = new Size(52, 23);
            numStatCount.TabIndex = 0;
            numStatCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            //
            // lblMode
            //
            lblMode.AutoSize = true;
            lblMode.ForeColor = Color.FromArgb(150, 150, 150);
            lblMode.Location = new Point(152, 23);
            lblMode.Name = "lblMode";
            lblMode.Text = "Mode";
            //
            // comboMode
            //
            comboMode.BackColor = Color.FromArgb(42, 42, 42);
            comboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMode.FlatStyle = FlatStyle.Flat;
            comboMode.ForeColor = Color.FromArgb(240, 240, 240);
            comboMode.Items.AddRange(new object[] { "Strict", "Mix", "Hybrid" });
            comboMode.Location = new Point(194, 19);
            comboMode.Name = "comboMode";
            comboMode.Size = new Size(96, 23);
            comboMode.TabIndex = 1;
            //
            // chkSemiPerf
            //
            chkSemiPerf.AutoSize = true;
            chkSemiPerf.Checked = true;
            chkSemiPerf.CheckState = CheckState.Checked;
            chkSemiPerf.FlatAppearance.BorderColor = Color.FromArgb(110, 110, 110);
            chkSemiPerf.FlatStyle = FlatStyle.Flat;
            chkSemiPerf.Location = new Point(308, 22);
            chkSemiPerf.Name = "chkSemiPerf";
            chkSemiPerf.TabIndex = 2;
            chkSemiPerf.Text = "With Semi Perfect";
            //
            // btnStart
            //
            btnStart.BackColor = Color.White;
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 215, 215);
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.Black;
            btnStart.Location = new Point(448, 14);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(92, 36);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            //
            // btnStop
            //
            btnStop.BackColor = Color.FromArgb(42, 42, 42);
            btnStop.Cursor = Cursors.Hand;
            btnStop.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnStop.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 58, 58);
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Location = new Point(546, 14);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 36);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            //
            // lblLog
            //
            lblLog.AutoSize = true;
            lblLog.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLog.ForeColor = Color.FromArgb(150, 150, 150);
            lblLog.Location = new Point(16, 626);
            lblLog.Name = "lblLog";
            lblLog.Text = "LOG";
            //
            // lblMatchCount
            //
            lblMatchCount.AutoSize = true;
            lblMatchCount.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMatchCount.ForeColor = Color.FromArgb(240, 240, 240);
            lblMatchCount.Location = new Point(52, 626);
            lblMatchCount.Name = "lblMatchCount";
            lblMatchCount.Text = "0";
            //
            // txtLog
            //
            txtLog.BackColor = Color.FromArgb(30, 30, 30);
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLog.ForeColor = Color.FromArgb(200, 200, 200);
            txtLog.Location = new Point(16, 648);
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(648, 196);
            txtLog.TabIndex = 7;
            txtLog.Text = "";
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(680, 860);
            Controls.Add(pnlHeader);
            Controls.Add(cardClickTimer);
            Controls.Add(cardPerin);
            Controls.Add(cardCursor);
            Controls.Add(cardArea);
            Controls.Add(cardOptions);
            Controls.Add(cardRun);
            Controls.Add(lblLog);
            Controls.Add(lblMatchCount);
            Controls.Add(txtLog);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(240, 240, 240);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Chrome.exe - Youtube(2)";
            Load += MainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            cardClickTimer.ResumeLayout(false);
            cardClickTimer.PerformLayout();
            cardPerin.ResumeLayout(false);
            cardPerin.PerformLayout();
            cardCursor.ResumeLayout(false);
            cardCursor.PerformLayout();
            cardArea.ResumeLayout(false);
            cardArea.PerformLayout();
            cardOptions.ResumeLayout(false);
            cardOptions.PerformLayout();
            cardRun.ResumeLayout(false);
            cardRun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStatCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Header
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblItemType;
        private ComboBox comboItemType;

        // Click Timer
        private Panel cardClickTimer;
        private Label lblClickTimerTitle;
        private Label lblClickEvery;
        private TextBox txtClickInterval;
        private Label lblClickSec;

        // Auto Press Perin
        private Panel cardPerin;
        private Label lblPerinTitle;
        private CheckBox chkAutoPerin;
        private TextBox txtPerinInterval;
        private Label lblPerinSec;
        private Label lblPerinX;
        private TextBox txtPerinX;
        private Label lblPerinY;
        private TextBox txtPerinY;

        // Cursor Capture (where to click)
        private Panel cardCursor;
        private Label lblCursorTitle;
        private Button btnTrackCursor;
        private Button btnStopTracking;
        private Label lblClickXCaption;
        private TextBox txtClickX;
        private Label lblClickYCaption;
        private TextBox txtClickY;

        // Area Capture (where to read the stats)
        private Panel cardArea;
        private Label lblAreaTitle;
        private Button btnCaptureArea;
        private Label lblAreaXCaption;
        private TextBox txtAreaX;
        private Label lblAreaYCaption;
        private TextBox txtAreaY;
        private Label lblAreaWCaption;
        private TextBox txtAreaW;
        private Label lblAreaHCaption;
        private TextBox txtAreaH;

        // Option (wanted stats)
        private Panel cardOptions;
        private Label lblOptionsTitle;
        private CheckBox chkInt;
        private CheckBox chkSta;
        private CheckBox chkStr;
        private CheckBox chkDex;
        private CheckBox chkSpeed;
        private CheckBox chkAttackSpeed;
        private CheckBox chkCritChance;
        private CheckBox chkCritDamage19;
        private CheckBox chkCritDamage17;
        private CheckBox chkCastingTime;
        private CheckBox chkHp;
        private CheckBox chkMp;
        private CheckBox chkFp;
        private CheckBox chkAttack;
        private CheckBox chkDef;

        // Settings and Start / Stop
        private Panel cardRun;
        private Label lblStatCount;
        private NumericUpDown numStatCount;
        private Label lblMode;
        private ComboBox comboMode;
        private CheckBox chkSemiPerf;
        private Button btnStart;
        private Button btnStop;

        // Log
        private Label lblLog;
        private Label lblMatchCount;
        private RichTextBox txtLog;
    }
}
