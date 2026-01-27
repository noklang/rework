
namespace AutoAwaken
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtX = new TextBox();
            txtY = new TextBox();
            txtAreaY = new TextBox();
            txtAreaX = new TextBox();
            txtAreaH = new TextBox();
            txtAreaW = new TextBox();
            txtLog = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnSelectArea = new Button();
            btnTrackCoords = new Button();
            btnLockCoords = new Button();
            previewPanel = new Panel();
            comboKeywords = new ComboBox();
            boxInt = new CheckBox();
            boxSta = new CheckBox();
            boxStr = new CheckBox();
            boxCrit = new CheckBox();
            boxAspeed = new CheckBox();
            boxSpeed = new CheckBox();
            boxDex = new CheckBox();
            boxIcd = new CheckBox();
            boxFp = new CheckBox();
            boxMp = new CheckBox();
            boxHp = new CheckBox();
            boxDct = new CheckBox();
            boxDef = new CheckBox();
            boxAttack = new CheckBox();
            toolStrip1 = new ToolStrip();
            toolStripComboBox1 = new ToolStripComboBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            txtTime = new TextBox();
            label5 = new Label();
            comboMode = new ComboBox();
            label6 = new Label();
            checkBox1 = new CheckBox();
            chkPerin = new CheckBox();
            txtPerin = new TextBox();
            label7 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // txtX
            // 
            txtX.Location = new Point(220, 21);
            txtX.Name = "txtX";
            txtX.Size = new Size(100, 23);
            txtX.TabIndex = 0;
            txtX.Text = "0";
            // 
            // txtY
            // 
            txtY.Location = new Point(326, 21);
            txtY.Name = "txtY";
            txtY.Size = new Size(100, 23);
            txtY.TabIndex = 1;
            txtY.Text = "0";
            // 
            // txtAreaY
            // 
            txtAreaY.Location = new Point(245, 26);
            txtAreaY.Name = "txtAreaY";
            txtAreaY.Size = new Size(100, 23);
            txtAreaY.TabIndex = 3;
            txtAreaY.Text = "0";
            txtAreaY.TextChanged += textBox1_TextChanged;
            // 
            // txtAreaX
            // 
            txtAreaX.Location = new Point(139, 27);
            txtAreaX.Name = "txtAreaX";
            txtAreaX.Size = new Size(100, 23);
            txtAreaX.TabIndex = 2;
            txtAreaX.Text = "0";
            // 
            // txtAreaH
            // 
            txtAreaH.Location = new Point(457, 26);
            txtAreaH.Name = "txtAreaH";
            txtAreaH.Size = new Size(100, 23);
            txtAreaH.TabIndex = 5;
            txtAreaH.Text = "0";
            // 
            // txtAreaW
            // 
            txtAreaW.Location = new Point(351, 26);
            txtAreaW.Name = "txtAreaW";
            txtAreaW.Size = new Size(100, 23);
            txtAreaW.TabIndex = 4;
            txtAreaW.Text = "0";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(49, 455);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(557, 313);
            txtLog.TabIndex = 6;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(433, 425);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 8;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(514, 425);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 10;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click_1;
            // 
            // btnSelectArea
            // 
            btnSelectArea.Location = new Point(58, 27);
            btnSelectArea.Name = "btnSelectArea";
            btnSelectArea.Size = new Size(75, 23);
            btnSelectArea.TabIndex = 11;
            btnSelectArea.Text = "Capture Area";
            btnSelectArea.UseVisualStyleBackColor = true;
            btnSelectArea.Click += btnSelectArea_Click;
            // 
            // btnTrackCoords
            // 
            btnTrackCoords.Location = new Point(41, 20);
            btnTrackCoords.Name = "btnTrackCoords";
            btnTrackCoords.Size = new Size(75, 23);
            btnTrackCoords.TabIndex = 13;
            btnTrackCoords.Text = "Start(F4)";
            btnTrackCoords.UseVisualStyleBackColor = true;
            btnTrackCoords.Click += btnTrackCoords_Click;
            // 
            // btnLockCoords
            // 
            btnLockCoords.Location = new Point(122, 21);
            btnLockCoords.Name = "btnLockCoords";
            btnLockCoords.Size = new Size(75, 23);
            btnLockCoords.TabIndex = 14;
            btnLockCoords.Text = "Stop";
            btnLockCoords.UseVisualStyleBackColor = true;
            btnLockCoords.Click += btnLockCoords_Click;
            // 
            // previewPanel
            // 
            previewPanel.BorderStyle = BorderStyle.FixedSingle;
            previewPanel.Location = new Point(732, 273);
            previewPanel.Name = "previewPanel";
            previewPanel.Size = new Size(300, 200);
            previewPanel.TabIndex = 12;
            // 
            // comboKeywords
            // 
            comboKeywords.FormattingEnabled = true;
            comboKeywords.Location = new Point(732, 215);
            comboKeywords.Name = "comboKeywords";
            comboKeywords.Size = new Size(121, 23);
            comboKeywords.TabIndex = 7;
            // 
            // boxInt
            // 
            boxInt.AutoSize = true;
            boxInt.Location = new Point(12, 35);
            boxInt.Name = "boxInt";
            boxInt.Size = new Size(68, 19);
            boxInt.TabIndex = 15;
            boxInt.Text = "INT +28";
            boxInt.UseVisualStyleBackColor = true;
            // 
            // boxSta
            // 
            boxSta.AutoSize = true;
            boxSta.Location = new Point(12, 54);
            boxSta.Name = "boxSta";
            boxSta.Size = new Size(69, 19);
            boxSta.TabIndex = 16;
            boxSta.Text = "STA +28";
            boxSta.UseVisualStyleBackColor = true;
            // 
            // boxStr
            // 
            boxStr.AutoSize = true;
            boxStr.Location = new Point(12, 73);
            boxStr.Name = "boxStr";
            boxStr.Size = new Size(69, 19);
            boxStr.TabIndex = 17;
            boxStr.Text = "STR +28";
            boxStr.UseVisualStyleBackColor = true;
            // 
            // boxCrit
            // 
            boxCrit.AutoSize = true;
            boxCrit.Location = new Point(98, 73);
            boxCrit.Name = "boxCrit";
            boxCrit.Size = new Size(121, 19);
            boxCrit.TabIndex = 20;
            boxCrit.Text = "Crit Chance +10%";
            boxCrit.UseVisualStyleBackColor = true;
            // 
            // boxAspeed
            // 
            boxAspeed.AutoSize = true;
            boxAspeed.Location = new Point(98, 54);
            boxAspeed.Name = "boxAspeed";
            boxAspeed.Size = new Size(128, 19);
            boxAspeed.TabIndex = 19;
            boxAspeed.Text = "Attack Speed +19%";
            boxAspeed.UseVisualStyleBackColor = true;
            // 
            // boxSpeed
            // 
            boxSpeed.AutoSize = true;
            boxSpeed.Location = new Point(98, 35);
            boxSpeed.Name = "boxSpeed";
            boxSpeed.Size = new Size(91, 19);
            boxSpeed.TabIndex = 18;
            boxSpeed.Text = "Speed +10%";
            boxSpeed.UseVisualStyleBackColor = true;
            // 
            // boxDex
            // 
            boxDex.AutoSize = true;
            boxDex.Location = new Point(12, 92);
            boxDex.Name = "boxDex";
            boxDex.Size = new Size(70, 19);
            boxDex.TabIndex = 21;
            boxDex.Text = "DEX +28";
            boxDex.UseVisualStyleBackColor = true;
            // 
            // boxIcd
            // 
            boxIcd.AutoSize = true;
            boxIcd.Location = new Point(98, 92);
            boxIcd.Name = "boxIcd";
            boxIcd.Size = new Size(196, 19);
            boxIcd.TabIndex = 22;
            boxIcd.Text = "Increased Critical Damage +19%";
            boxIcd.UseVisualStyleBackColor = true;
            // 
            // boxFp
            // 
            boxFp.AutoSize = true;
            boxFp.Location = new Point(293, 73);
            boxFp.Name = "boxFp";
            boxFp.Size = new Size(96, 19);
            boxFp.TabIndex = 25;
            boxFp.Text = "Max. FP +500";
            boxFp.UseVisualStyleBackColor = true;
            // 
            // boxMp
            // 
            boxMp.AutoSize = true;
            boxMp.Location = new Point(293, 54);
            boxMp.Name = "boxMp";
            boxMp.Size = new Size(101, 19);
            boxMp.TabIndex = 24;
            boxMp.Text = "Max. MP +500";
            boxMp.UseVisualStyleBackColor = true;
            // 
            // boxHp
            // 
            boxHp.AutoSize = true;
            boxHp.Location = new Point(293, 35);
            boxHp.Name = "boxHp";
            boxHp.Size = new Size(99, 19);
            boxHp.TabIndex = 23;
            boxHp.Text = "Max. HP +500";
            boxHp.UseVisualStyleBackColor = true;
            // 
            // boxDct
            // 
            boxDct.AutoSize = true;
            boxDct.Location = new Point(426, 73);
            boxDct.Name = "boxDct";
            boxDct.Size = new Size(186, 19);
            boxDct.TabIndex = 29;
            boxDct.Text = "Decreased Casting Time +10%";
            boxDct.UseVisualStyleBackColor = true;
            // 
            // boxDef
            // 
            boxDef.AutoSize = true;
            boxDef.Location = new Point(426, 54);
            boxDef.Name = "boxDef";
            boxDef.Size = new Size(75, 19);
            boxDef.TabIndex = 28;
            boxDef.Text = "DEF +140";
            boxDef.UseVisualStyleBackColor = true;
            // 
            // boxAttack
            // 
            boxAttack.AutoSize = true;
            boxAttack.Location = new Point(426, 35);
            boxAttack.Name = "boxAttack";
            boxAttack.Size = new Size(89, 19);
            boxAttack.TabIndex = 27;
            boxAttack.Text = "Attack +140";
            boxAttack.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(656, 25);
            toolStrip1.TabIndex = 30;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Items.AddRange(new object[] { "W/S/S", "Helmet", "Boots", "Gloves" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 25);
            toolStripComboBox1.Text = "Choose";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(103, 393);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(57, 23);
            numericUpDown1.TabIndex = 31;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 395);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 32;
            label1.Text = "Stat Count: ";
            // 
            // txtTime
            // 
            txtTime.Location = new Point(19, 17);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(44, 23);
            txtTime.TabIndex = 36;
            txtTime.Text = "0.8";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 20);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 37;
            label5.Text = "sec.";
            // 
            // comboMode
            // 
            comboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMode.FormattingEnabled = true;
            comboMode.Items.AddRange(new object[] { "Strict", "Mix" });
            comboMode.Location = new Point(103, 426);
            comboMode.Name = "comboMode";
            comboMode.Size = new Size(121, 23);
            comboMode.TabIndex = 38;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 429);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 39;
            label6.Text = "Mode:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(98, 113);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 19);
            checkBox1.TabIndex = 40;
            checkBox1.Text = "Increased Critical Damage +17%";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkPerin
            // 
            chkPerin.AutoSize = true;
            chkPerin.Location = new Point(6, 22);
            chkPerin.Name = "chkPerin";
            chkPerin.Size = new Size(69, 19);
            chkPerin.TabIndex = 41;
            chkPerin.Text = "Activate";
            chkPerin.UseVisualStyleBackColor = true;
            // 
            // txtPerin
            // 
            txtPerin.Location = new Point(96, 18);
            txtPerin.Name = "txtPerin";
            txtPerin.Size = new Size(43, 23);
            txtPerin.TabIndex = 42;
            txtPerin.Text = "62";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(145, 21);
            label7.Name = "label7";
            label7.Size = new Size(27, 15);
            label7.TabIndex = 43;
            label7.Text = "sec.";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTime);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(21, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(114, 46);
            groupBox1.TabIndex = 44;
            groupBox1.TabStop = false;
            groupBox1.Text = "Click Timer";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(chkPerin);
            groupBox2.Controls.Add(txtPerin);
            groupBox2.Location = new Point(275, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 52);
            groupBox2.TabIndex = 45;
            groupBox2.TabStop = false;
            groupBox2.Text = "Auto Press Perin";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(boxSpeed);
            groupBox3.Controls.Add(boxInt);
            groupBox3.Controls.Add(boxSta);
            groupBox3.Controls.Add(boxStr);
            groupBox3.Controls.Add(boxAspeed);
            groupBox3.Controls.Add(boxCrit);
            groupBox3.Controls.Add(boxDex);
            groupBox3.Controls.Add(boxIcd);
            groupBox3.Controls.Add(boxDct);
            groupBox3.Controls.Add(boxHp);
            groupBox3.Controls.Add(boxDef);
            groupBox3.Controls.Add(boxMp);
            groupBox3.Controls.Add(boxAttack);
            groupBox3.Controls.Add(boxFp);
            groupBox3.Location = new Point(21, 215);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(616, 163);
            groupBox3.TabIndex = 46;
            groupBox3.TabStop = false;
            groupBox3.Text = "Option";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtAreaX);
            groupBox4.Controls.Add(txtAreaY);
            groupBox4.Controls.Add(txtAreaW);
            groupBox4.Controls.Add(txtAreaH);
            groupBox4.Controls.Add(btnSelectArea);
            groupBox4.Location = new Point(21, 141);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(616, 68);
            groupBox4.TabIndex = 47;
            groupBox4.TabStop = false;
            groupBox4.Text = "Area Capture";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnTrackCoords);
            groupBox5.Controls.Add(txtX);
            groupBox5.Controls.Add(txtY);
            groupBox5.Controls.Add(btnLockCoords);
            groupBox5.Location = new Point(21, 86);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(454, 49);
            groupBox5.TabIndex = 48;
            groupBox5.TabStop = false;
            groupBox5.Text = "Cursor Capture";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 780);
            Controls.Add(groupBox5);
            Controls.Add(label6);
            Controls.Add(comboMode);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(toolStrip1);
            Controls.Add(previewPanel);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(comboKeywords);
            Controls.Add(txtLog);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Name = "Form1";
            Text = "AutoAwake V1.2 - YnaMocha";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox txtX;
        private TextBox txtY;
        private TextBox txtAreaY;
        private TextBox txtAreaX;
        private TextBox txtAreaH;
        private TextBox txtAreaW;
        private TextBox txtLog;
        private Button btnStart;
        private Button btnStop;
        private Button btnSelectArea;
        private Button btnTrackCoords;
        private Button btnLockCoords;
        private Panel previewPanel;
        private ComboBox comboKeywords;
        private CheckBox boxInt;
        private CheckBox boxSta;
        private CheckBox boxStr;
        private CheckBox boxCrit;
        private CheckBox boxAspeed;
        private CheckBox boxSpeed;
        private CheckBox boxDex;
        private CheckBox boxIcd;
        private CheckBox checkBox9;
        private CheckBox boxFp;
        private CheckBox boxMp;
        private CheckBox boxHp;
        private CheckBox boxDct;
        private CheckBox boxDef;
        private CheckBox boxAttack;
        private ToolStrip toolStrip1;
        private ToolStripComboBox toolStripComboBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private TextBox txtTime;
        private Label label5;
        private ComboBox comboMode;
        private Label label6;
        private CheckBox checkBox1;
        private CheckBox chkPerin;
        private TextBox txtPerin;
        private Label label7;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
    }
}
