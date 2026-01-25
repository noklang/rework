
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTime = new TextBox();
            label5 = new Label();
            comboMode = new ComboBox();
            label6 = new Label();
            checkBox1 = new CheckBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // txtX
            // 
            txtX.Location = new Point(300, 82);
            txtX.Name = "txtX";
            txtX.Size = new Size(100, 23);
            txtX.TabIndex = 0;
            txtX.Text = "0";
            // 
            // txtY
            // 
            txtY.Location = new Point(406, 82);
            txtY.Name = "txtY";
            txtY.Size = new Size(100, 23);
            txtY.TabIndex = 1;
            txtY.Text = "0";
            // 
            // txtAreaY
            // 
            txtAreaY.Location = new Point(301, 111);
            txtAreaY.Name = "txtAreaY";
            txtAreaY.Size = new Size(100, 23);
            txtAreaY.TabIndex = 3;
            txtAreaY.Text = "0";
            txtAreaY.TextChanged += textBox1_TextChanged;
            // 
            // txtAreaX
            // 
            txtAreaX.Location = new Point(195, 112);
            txtAreaX.Name = "txtAreaX";
            txtAreaX.Size = new Size(100, 23);
            txtAreaX.TabIndex = 2;
            txtAreaX.Text = "0";
            // 
            // txtAreaH
            // 
            txtAreaH.Location = new Point(513, 111);
            txtAreaH.Name = "txtAreaH";
            txtAreaH.Size = new Size(100, 23);
            txtAreaH.TabIndex = 5;
            txtAreaH.Text = "0";
            // 
            // txtAreaW
            // 
            txtAreaW.Location = new Point(407, 111);
            txtAreaW.Name = "txtAreaW";
            txtAreaW.Size = new Size(100, 23);
            txtAreaW.TabIndex = 4;
            txtAreaW.Text = "0";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(49, 325);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(557, 409);
            txtLog.TabIndex = 6;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(440, 285);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 8;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(537, 285);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 10;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click_1;
            // 
            // btnSelectArea
            // 
            btnSelectArea.Location = new Point(114, 112);
            btnSelectArea.Name = "btnSelectArea";
            btnSelectArea.Size = new Size(75, 23);
            btnSelectArea.TabIndex = 11;
            btnSelectArea.Text = "Capture Area";
            btnSelectArea.UseVisualStyleBackColor = true;
            btnSelectArea.Click += btnSelectArea_Click;
            // 
            // btnTrackCoords
            // 
            btnTrackCoords.Location = new Point(121, 81);
            btnTrackCoords.Name = "btnTrackCoords";
            btnTrackCoords.Size = new Size(75, 23);
            btnTrackCoords.TabIndex = 13;
            btnTrackCoords.Text = "Start(F4)";
            btnTrackCoords.UseVisualStyleBackColor = true;
            btnTrackCoords.Click += btnTrackCoords_Click;
            // 
            // btnLockCoords
            // 
            btnLockCoords.Location = new Point(202, 82);
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
            boxInt.Location = new Point(49, 222);
            boxInt.Name = "boxInt";
            boxInt.Size = new Size(68, 19);
            boxInt.TabIndex = 15;
            boxInt.Text = "INT +28";
            boxInt.UseVisualStyleBackColor = true;
            // 
            // boxSta
            // 
            boxSta.AutoSize = true;
            boxSta.Location = new Point(49, 241);
            boxSta.Name = "boxSta";
            boxSta.Size = new Size(69, 19);
            boxSta.TabIndex = 16;
            boxSta.Text = "STA +28";
            boxSta.UseVisualStyleBackColor = true;
            // 
            // boxStr
            // 
            boxStr.AutoSize = true;
            boxStr.Location = new Point(49, 260);
            boxStr.Name = "boxStr";
            boxStr.Size = new Size(69, 19);
            boxStr.TabIndex = 17;
            boxStr.Text = "STR +28";
            boxStr.UseVisualStyleBackColor = true;
            // 
            // boxCrit
            // 
            boxCrit.AutoSize = true;
            boxCrit.Location = new Point(135, 260);
            boxCrit.Name = "boxCrit";
            boxCrit.Size = new Size(121, 19);
            boxCrit.TabIndex = 20;
            boxCrit.Text = "Crit Chance +10%";
            boxCrit.UseVisualStyleBackColor = true;
            // 
            // boxAspeed
            // 
            boxAspeed.AutoSize = true;
            boxAspeed.Location = new Point(135, 241);
            boxAspeed.Name = "boxAspeed";
            boxAspeed.Size = new Size(128, 19);
            boxAspeed.TabIndex = 19;
            boxAspeed.Text = "Attack Speed +19%";
            boxAspeed.UseVisualStyleBackColor = true;
            // 
            // boxSpeed
            // 
            boxSpeed.AutoSize = true;
            boxSpeed.Location = new Point(135, 222);
            boxSpeed.Name = "boxSpeed";
            boxSpeed.Size = new Size(91, 19);
            boxSpeed.TabIndex = 18;
            boxSpeed.Text = "Speed +10%";
            boxSpeed.UseVisualStyleBackColor = true;
            // 
            // boxDex
            // 
            boxDex.AutoSize = true;
            boxDex.Location = new Point(49, 279);
            boxDex.Name = "boxDex";
            boxDex.Size = new Size(70, 19);
            boxDex.TabIndex = 21;
            boxDex.Text = "DEX +28";
            boxDex.UseVisualStyleBackColor = true;
            // 
            // boxIcd
            // 
            boxIcd.AutoSize = true;
            boxIcd.Location = new Point(135, 279);
            boxIcd.Name = "boxIcd";
            boxIcd.Size = new Size(196, 19);
            boxIcd.TabIndex = 22;
            boxIcd.Text = "Increased Critical Damage +19%";
            boxIcd.UseVisualStyleBackColor = true;
            // 
            // boxFp
            // 
            boxFp.AutoSize = true;
            boxFp.Location = new Point(330, 260);
            boxFp.Name = "boxFp";
            boxFp.Size = new Size(96, 19);
            boxFp.TabIndex = 25;
            boxFp.Text = "Max. FP +500";
            boxFp.UseVisualStyleBackColor = true;
            // 
            // boxMp
            // 
            boxMp.AutoSize = true;
            boxMp.Location = new Point(330, 241);
            boxMp.Name = "boxMp";
            boxMp.Size = new Size(101, 19);
            boxMp.TabIndex = 24;
            boxMp.Text = "Max. MP +500";
            boxMp.UseVisualStyleBackColor = true;
            // 
            // boxHp
            // 
            boxHp.AutoSize = true;
            boxHp.Location = new Point(330, 222);
            boxHp.Name = "boxHp";
            boxHp.Size = new Size(99, 19);
            boxHp.TabIndex = 23;
            boxHp.Text = "Max. HP +500";
            boxHp.UseVisualStyleBackColor = true;
            // 
            // boxDct
            // 
            boxDct.AutoSize = true;
            boxDct.Location = new Point(463, 260);
            boxDct.Name = "boxDct";
            boxDct.Size = new Size(186, 19);
            boxDct.TabIndex = 29;
            boxDct.Text = "Decreased Casting Time +10%";
            boxDct.UseVisualStyleBackColor = true;
            // 
            // boxDef
            // 
            boxDef.AutoSize = true;
            boxDef.Location = new Point(463, 241);
            boxDef.Name = "boxDef";
            boxDef.Size = new Size(75, 19);
            boxDef.TabIndex = 28;
            boxDef.Text = "DEF +140";
            boxDef.UseVisualStyleBackColor = true;
            // 
            // boxAttack
            // 
            boxAttack.AutoSize = true;
            boxAttack.Location = new Point(463, 222);
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
            toolStrip1.Size = new Size(663, 25);
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
            numericUpDown1.Location = new Point(172, 146);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(57, 23);
            numericUpDown1.TabIndex = 31;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 148);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 32;
            label1.Text = "Stat Count: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 85);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 33;
            label2.Text = "Cursor Capture:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 115);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 34;
            label3.Text = "Area Capture:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 48);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 35;
            label4.Text = "Timer Click:";
            // 
            // txtTime
            // 
            txtTime.Location = new Point(145, 42);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(44, 23);
            txtTime.TabIndex = 36;
            txtTime.Text = "0.8";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(195, 48);
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
            comboMode.Location = new Point(172, 179);
            comboMode.Name = "comboMode";
            comboMode.Size = new Size(121, 23);
            comboMode.TabIndex = 38;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(114, 182);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 39;
            label6.Text = "Mode:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(135, 300);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 19);
            checkBox1.TabIndex = 40;
            checkBox1.Text = "Increased Critical Damage +17%";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 780);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(comboMode);
            Controls.Add(label5);
            Controls.Add(txtTime);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(toolStrip1);
            Controls.Add(boxDct);
            Controls.Add(boxDef);
            Controls.Add(boxAttack);
            Controls.Add(boxFp);
            Controls.Add(boxMp);
            Controls.Add(boxHp);
            Controls.Add(boxIcd);
            Controls.Add(boxDex);
            Controls.Add(boxCrit);
            Controls.Add(boxAspeed);
            Controls.Add(boxSpeed);
            Controls.Add(boxStr);
            Controls.Add(boxSta);
            Controls.Add(boxInt);
            Controls.Add(btnLockCoords);
            Controls.Add(btnTrackCoords);
            Controls.Add(previewPanel);
            Controls.Add(btnSelectArea);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(comboKeywords);
            Controls.Add(txtLog);
            Controls.Add(txtAreaH);
            Controls.Add(txtAreaW);
            Controls.Add(txtAreaY);
            Controls.Add(txtAreaX);
            Controls.Add(txtY);
            Controls.Add(txtX);
            Name = "Form1";
            Text = "AutoAwake V1.1 - YnaMocha";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTime;
        private Label label5;
        private ComboBox comboMode;
        private Label label6;
        private CheckBox checkBox1;
    }
}
