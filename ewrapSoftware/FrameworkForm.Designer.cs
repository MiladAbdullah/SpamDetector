namespace ewrapSoftware
{
    partial class FrameworkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameworkForm));
            this.algorithmGroupBox = new System.Windows.Forms.GroupBox();
            this.algorithmRadio5 = new System.Windows.Forms.RadioButton();
            this.algorithmRadio4 = new System.Windows.Forms.RadioButton();
            this.algorithmRadio3 = new System.Windows.Forms.RadioButton();
            this.algorithmRadio2 = new System.Windows.Forms.RadioButton();
            this.algorithmRadio1 = new System.Windows.Forms.RadioButton();
            this.algorithmRadio0 = new System.Windows.Forms.RadioButton();
            this.filesBox = new System.Windows.Forms.GroupBox();
            this.phraseNumber = new System.Windows.Forms.NumericUpDown();
            this.hamNumber = new System.Windows.Forms.NumericUpDown();
            this.spamNumber = new System.Windows.Forms.NumericUpDown();
            this.hamLabel = new System.Windows.Forms.TextBox();
            this.spamLabel = new System.Windows.Forms.TextBox();
            this.phraseLabel = new System.Windows.Forms.TextBox();
            this.phraseFile = new System.Windows.Forms.TextBox();
            this.openPhrases = new System.Windows.Forms.Button();
            this.datasetFolder = new System.Windows.Forms.TextBox();
            this.openDataset = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.spamRecallBox = new System.Windows.Forms.TextBox();
            this.spamPrecision = new System.Windows.Forms.TextBox();
            this.falsePBox = new System.Windows.Forms.TextBox();
            this.falseNbox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.accurecyBox = new System.Windows.Forms.TextBox();
            this.runBtm = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.configurationBox = new System.Windows.Forms.GroupBox();
            this.saveFile = new System.Windows.Forms.CheckBox();
            this.loadText = new System.Windows.Forms.TextBox();
            this.browseBTM = new System.Windows.Forms.Button();
            this.thresholdValue = new System.Windows.Forms.NumericUpDown();
            this.threshold = new System.Windows.Forms.CheckBox();
            this.theTimer = new System.Windows.Forms.Timer(this.components);
            this.wordListBox = new System.Windows.Forms.GroupBox();
            this.deleteBTM = new System.Windows.Forms.Button();
            this.wordList = new System.Windows.Forms.ListBox();
            this.algorithmGroupBox.SuspendLayout();
            this.filesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phraseNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hamNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spamNumber)).BeginInit();
            this.resultBox.SuspendLayout();
            this.configurationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).BeginInit();
            this.wordListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // algorithmGroupBox
            // 
            this.algorithmGroupBox.Controls.Add(this.algorithmRadio5);
            this.algorithmGroupBox.Controls.Add(this.algorithmRadio4);
            this.algorithmGroupBox.Controls.Add(this.algorithmRadio3);
            this.algorithmGroupBox.Controls.Add(this.algorithmRadio2);
            this.algorithmGroupBox.Controls.Add(this.algorithmRadio1);
            this.algorithmGroupBox.Controls.Add(this.algorithmRadio0);
            this.algorithmGroupBox.Location = new System.Drawing.Point(13, 13);
            this.algorithmGroupBox.Name = "algorithmGroupBox";
            this.algorithmGroupBox.Size = new System.Drawing.Size(130, 159);
            this.algorithmGroupBox.TabIndex = 0;
            this.algorithmGroupBox.TabStop = false;
            this.algorithmGroupBox.Text = "Algorithms";
            // 
            // algorithmRadio5
            // 
            this.algorithmRadio5.AutoSize = true;
            this.algorithmRadio5.Location = new System.Drawing.Point(16, 134);
            this.algorithmRadio5.Name = "algorithmRadio5";
            this.algorithmRadio5.Size = new System.Drawing.Size(28, 17);
            this.algorithmRadio5.TabIndex = 5;
            this.algorithmRadio5.TabStop = true;
            this.algorithmRadio5.Text = " ";
            this.algorithmRadio5.UseVisualStyleBackColor = true;
            this.algorithmRadio5.CheckedChanged += new System.EventHandler(this.algorithmChange);
            // 
            // algorithmRadio4
            // 
            this.algorithmRadio4.AutoSize = true;
            this.algorithmRadio4.Location = new System.Drawing.Point(16, 111);
            this.algorithmRadio4.Name = "algorithmRadio4";
            this.algorithmRadio4.Size = new System.Drawing.Size(28, 17);
            this.algorithmRadio4.TabIndex = 4;
            this.algorithmRadio4.TabStop = true;
            this.algorithmRadio4.Text = " ";
            this.algorithmRadio4.UseVisualStyleBackColor = true;
            this.algorithmRadio4.CheckedChanged += new System.EventHandler(this.algorithmChange);
            // 
            // algorithmRadio3
            // 
            this.algorithmRadio3.AutoSize = true;
            this.algorithmRadio3.Location = new System.Drawing.Point(16, 88);
            this.algorithmRadio3.Name = "algorithmRadio3";
            this.algorithmRadio3.Size = new System.Drawing.Size(28, 17);
            this.algorithmRadio3.TabIndex = 3;
            this.algorithmRadio3.TabStop = true;
            this.algorithmRadio3.Text = " ";
            this.algorithmRadio3.UseVisualStyleBackColor = true;
            this.algorithmRadio3.CheckedChanged += new System.EventHandler(this.algorithmChange);
            // 
            // algorithmRadio2
            // 
            this.algorithmRadio2.AutoSize = true;
            this.algorithmRadio2.Location = new System.Drawing.Point(16, 65);
            this.algorithmRadio2.Name = "algorithmRadio2";
            this.algorithmRadio2.Size = new System.Drawing.Size(28, 17);
            this.algorithmRadio2.TabIndex = 2;
            this.algorithmRadio2.TabStop = true;
            this.algorithmRadio2.Text = " ";
            this.algorithmRadio2.UseVisualStyleBackColor = true;
            this.algorithmRadio2.CheckedChanged += new System.EventHandler(this.algorithmChange);
            // 
            // algorithmRadio1
            // 
            this.algorithmRadio1.AutoSize = true;
            this.algorithmRadio1.Location = new System.Drawing.Point(16, 42);
            this.algorithmRadio1.Name = "algorithmRadio1";
            this.algorithmRadio1.Size = new System.Drawing.Size(28, 17);
            this.algorithmRadio1.TabIndex = 1;
            this.algorithmRadio1.TabStop = true;
            this.algorithmRadio1.Text = " ";
            this.algorithmRadio1.UseVisualStyleBackColor = true;
            this.algorithmRadio1.CheckedChanged += new System.EventHandler(this.algorithmChange);
            // 
            // algorithmRadio0
            // 
            this.algorithmRadio0.AutoSize = true;
            this.algorithmRadio0.Location = new System.Drawing.Point(16, 19);
            this.algorithmRadio0.Name = "algorithmRadio0";
            this.algorithmRadio0.Size = new System.Drawing.Size(28, 17);
            this.algorithmRadio0.TabIndex = 0;
            this.algorithmRadio0.TabStop = true;
            this.algorithmRadio0.Text = " ";
            this.algorithmRadio0.UseVisualStyleBackColor = true;
            this.algorithmRadio0.CheckedChanged += new System.EventHandler(this.algorithmChange);
            // 
            // filesBox
            // 
            this.filesBox.Controls.Add(this.phraseNumber);
            this.filesBox.Controls.Add(this.hamNumber);
            this.filesBox.Controls.Add(this.spamNumber);
            this.filesBox.Controls.Add(this.hamLabel);
            this.filesBox.Controls.Add(this.spamLabel);
            this.filesBox.Controls.Add(this.phraseLabel);
            this.filesBox.Controls.Add(this.phraseFile);
            this.filesBox.Controls.Add(this.openPhrases);
            this.filesBox.Controls.Add(this.datasetFolder);
            this.filesBox.Controls.Add(this.openDataset);
            this.filesBox.Location = new System.Drawing.Point(149, 13);
            this.filesBox.Name = "filesBox";
            this.filesBox.Size = new System.Drawing.Size(422, 159);
            this.filesBox.TabIndex = 1;
            this.filesBox.TabStop = false;
            this.filesBox.Text = "Data";
            // 
            // phraseNumber
            // 
            this.phraseNumber.Enabled = false;
            this.phraseNumber.Location = new System.Drawing.Point(342, 133);
            this.phraseNumber.Name = "phraseNumber";
            this.phraseNumber.Size = new System.Drawing.Size(74, 20);
            this.phraseNumber.TabIndex = 9;
            this.phraseNumber.ValueChanged += new System.EventHandler(this.phraseNumber_ValueChanged);
            // 
            // hamNumber
            // 
            this.hamNumber.Enabled = false;
            this.hamNumber.Location = new System.Drawing.Point(342, 74);
            this.hamNumber.Name = "hamNumber";
            this.hamNumber.Size = new System.Drawing.Size(74, 20);
            this.hamNumber.TabIndex = 8;
            // 
            // spamNumber
            // 
            this.spamNumber.Enabled = false;
            this.spamNumber.Location = new System.Drawing.Point(342, 47);
            this.spamNumber.Name = "spamNumber";
            this.spamNumber.Size = new System.Drawing.Size(74, 20);
            this.spamNumber.TabIndex = 7;
            // 
            // hamLabel
            // 
            this.hamLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hamLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hamLabel.Enabled = false;
            this.hamLabel.Location = new System.Drawing.Point(6, 74);
            this.hamLabel.Name = "hamLabel";
            this.hamLabel.Size = new System.Drawing.Size(329, 20);
            this.hamLabel.TabIndex = 6;
            this.hamLabel.Text = "Currently there is no HAM email has been loaded.";
            // 
            // spamLabel
            // 
            this.spamLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spamLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spamLabel.Enabled = false;
            this.spamLabel.Location = new System.Drawing.Point(6, 48);
            this.spamLabel.Name = "spamLabel";
            this.spamLabel.Size = new System.Drawing.Size(329, 20);
            this.spamLabel.TabIndex = 5;
            this.spamLabel.Text = "Currently there is no SPAM email has been loaded.";
            // 
            // phraseLabel
            // 
            this.phraseLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.phraseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phraseLabel.Enabled = false;
            this.phraseLabel.Location = new System.Drawing.Point(6, 133);
            this.phraseLabel.Name = "phraseLabel";
            this.phraseLabel.Size = new System.Drawing.Size(329, 20);
            this.phraseLabel.TabIndex = 4;
            this.phraseLabel.Text = "Currently there is no SPAM phrases has been loaded.";
            // 
            // phraseFile
            // 
            this.phraseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.phraseFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phraseFile.Enabled = false;
            this.phraseFile.Location = new System.Drawing.Point(6, 106);
            this.phraseFile.Name = "phraseFile";
            this.phraseFile.Size = new System.Drawing.Size(299, 20);
            this.phraseFile.TabIndex = 3;
            this.phraseFile.Text = "Load a list of SPAM phrases in XLS or CSV ";
            // 
            // openPhrases
            // 
            this.openPhrases.Location = new System.Drawing.Point(311, 106);
            this.openPhrases.Name = "openPhrases";
            this.openPhrases.Size = new System.Drawing.Size(105, 23);
            this.openPhrases.TabIndex = 2;
            this.openPhrases.Text = "Load Phrases";
            this.openPhrases.UseVisualStyleBackColor = true;
            this.openPhrases.Click += new System.EventHandler(this.openPhrases_Click);
            // 
            // datasetFolder
            // 
            this.datasetFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.datasetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datasetFolder.Enabled = false;
            this.datasetFolder.Location = new System.Drawing.Point(6, 20);
            this.datasetFolder.Name = "datasetFolder";
            this.datasetFolder.Size = new System.Drawing.Size(299, 20);
            this.datasetFolder.TabIndex = 1;
            this.datasetFolder.Text = "Open a Folder containing ham and spam folders";
            // 
            // openDataset
            // 
            this.openDataset.Location = new System.Drawing.Point(311, 20);
            this.openDataset.Name = "openDataset";
            this.openDataset.Size = new System.Drawing.Size(105, 23);
            this.openDataset.TabIndex = 0;
            this.openDataset.Text = "Load Data Set";
            this.openDataset.UseVisualStyleBackColor = true;
            this.openDataset.Click += new System.EventHandler(this.openDataset_Click);
            // 
            // resultBox
            // 
            this.resultBox.Controls.Add(this.spamRecallBox);
            this.resultBox.Controls.Add(this.spamPrecision);
            this.resultBox.Controls.Add(this.falsePBox);
            this.resultBox.Controls.Add(this.falseNbox);
            this.resultBox.Controls.Add(this.timeBox);
            this.resultBox.Controls.Add(this.accurecyBox);
            this.resultBox.Location = new System.Drawing.Point(13, 315);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(320, 99);
            this.resultBox.TabIndex = 2;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Results";
            // 
            // spamRecallBox
            // 
            this.spamRecallBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spamRecallBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spamRecallBox.Enabled = false;
            this.spamRecallBox.Location = new System.Drawing.Point(166, 45);
            this.spamRecallBox.Name = "spamRecallBox";
            this.spamRecallBox.Size = new System.Drawing.Size(148, 20);
            this.spamRecallBox.TabIndex = 22;
            this.spamRecallBox.Text = "Spam Recall:";
            // 
            // spamPrecision
            // 
            this.spamPrecision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spamPrecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spamPrecision.Enabled = false;
            this.spamPrecision.Location = new System.Drawing.Point(166, 71);
            this.spamPrecision.Name = "spamPrecision";
            this.spamPrecision.Size = new System.Drawing.Size(148, 20);
            this.spamPrecision.TabIndex = 21;
            this.spamPrecision.Text = "Spam Precision:";
            // 
            // falsePBox
            // 
            this.falsePBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.falsePBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.falsePBox.Enabled = false;
            this.falsePBox.Location = new System.Drawing.Point(12, 45);
            this.falsePBox.Name = "falsePBox";
            this.falsePBox.Size = new System.Drawing.Size(148, 20);
            this.falsePBox.TabIndex = 20;
            this.falsePBox.Text = "False Positive Rate:";
            // 
            // falseNbox
            // 
            this.falseNbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.falseNbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.falseNbox.Enabled = false;
            this.falseNbox.Location = new System.Drawing.Point(12, 71);
            this.falseNbox.Name = "falseNbox";
            this.falseNbox.Size = new System.Drawing.Size(148, 20);
            this.falseNbox.TabIndex = 19;
            this.falseNbox.Text = "False Negative Rate:";
            // 
            // timeBox
            // 
            this.timeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.timeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeBox.Enabled = false;
            this.timeBox.Location = new System.Drawing.Point(166, 19);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(148, 20);
            this.timeBox.TabIndex = 17;
            this.timeBox.Text = "Total Time:";
            // 
            // accurecyBox
            // 
            this.accurecyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.accurecyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accurecyBox.Enabled = false;
            this.accurecyBox.Location = new System.Drawing.Point(13, 19);
            this.accurecyBox.Name = "accurecyBox";
            this.accurecyBox.Size = new System.Drawing.Size(148, 20);
            this.accurecyBox.TabIndex = 15;
            this.accurecyBox.Text = "Accuracy";
            // 
            // runBtm
            // 
            this.runBtm.Location = new System.Drawing.Point(244, 92);
            this.runBtm.Name = "runBtm";
            this.runBtm.Size = new System.Drawing.Size(69, 23);
            this.runBtm.TabIndex = 10;
            this.runBtm.Text = "Run";
            this.runBtm.UseVisualStyleBackColor = true;
            this.runBtm.Click += new System.EventHandler(this.runBtm_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 92);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(226, 23);
            this.progressBar.TabIndex = 12;
            // 
            // configurationBox
            // 
            this.configurationBox.Controls.Add(this.saveFile);
            this.configurationBox.Controls.Add(this.loadText);
            this.configurationBox.Controls.Add(this.browseBTM);
            this.configurationBox.Controls.Add(this.thresholdValue);
            this.configurationBox.Controls.Add(this.threshold);
            this.configurationBox.Controls.Add(this.runBtm);
            this.configurationBox.Controls.Add(this.progressBar);
            this.configurationBox.Location = new System.Drawing.Point(13, 178);
            this.configurationBox.Name = "configurationBox";
            this.configurationBox.Size = new System.Drawing.Size(320, 131);
            this.configurationBox.TabIndex = 3;
            this.configurationBox.TabStop = false;
            this.configurationBox.Text = "Configurations";
            // 
            // saveFile
            // 
            this.saveFile.AutoSize = true;
            this.saveFile.Checked = true;
            this.saveFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveFile.Location = new System.Drawing.Point(16, 43);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(120, 17);
            this.saveFile.TabIndex = 25;
            this.saveFile.Text = "Save results in a file";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.CheckedChanged += new System.EventHandler(this.saveFile_CheckedChanged);
            // 
            // loadText
            // 
            this.loadText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.loadText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadText.Enabled = false;
            this.loadText.Location = new System.Drawing.Point(16, 66);
            this.loadText.Name = "loadText";
            this.loadText.Size = new System.Drawing.Size(222, 20);
            this.loadText.TabIndex = 27;
            this.loadText.Text = "Browse a CSV file so the reult is logged to";
            // 
            // browseBTM
            // 
            this.browseBTM.Location = new System.Drawing.Point(244, 63);
            this.browseBTM.Name = "browseBTM";
            this.browseBTM.Size = new System.Drawing.Size(69, 23);
            this.browseBTM.TabIndex = 26;
            this.browseBTM.Text = "Browse";
            this.browseBTM.UseVisualStyleBackColor = true;
            this.browseBTM.Click += new System.EventHandler(this.browseBTM_Click);
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(144, 17);
            this.thresholdValue.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(59, 20);
            this.thresholdValue.TabIndex = 10;
            this.thresholdValue.Value = new decimal(new int[] {
            67,
            0,
            0,
            0});
            // 
            // threshold
            // 
            this.threshold.AutoSize = true;
            this.threshold.Checked = true;
            this.threshold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.threshold.Location = new System.Drawing.Point(16, 20);
            this.threshold.Name = "threshold";
            this.threshold.Size = new System.Drawing.Size(97, 17);
            this.threshold.TabIndex = 2;
            this.threshold.Text = "Threshold 0-99";
            this.threshold.UseVisualStyleBackColor = true;
            this.threshold.CheckedChanged += new System.EventHandler(this.threshold_CheckedChanged);
            // 
            // wordListBox
            // 
            this.wordListBox.Controls.Add(this.deleteBTM);
            this.wordListBox.Controls.Add(this.wordList);
            this.wordListBox.Location = new System.Drawing.Point(339, 178);
            this.wordListBox.Name = "wordListBox";
            this.wordListBox.Size = new System.Drawing.Size(232, 236);
            this.wordListBox.TabIndex = 4;
            this.wordListBox.TabStop = false;
            this.wordListBox.Text = "Phrase List";
            // 
            // deleteBTM
            // 
            this.deleteBTM.Enabled = false;
            this.deleteBTM.Location = new System.Drawing.Point(160, 208);
            this.deleteBTM.Name = "deleteBTM";
            this.deleteBTM.Size = new System.Drawing.Size(66, 23);
            this.deleteBTM.TabIndex = 3;
            this.deleteBTM.Text = "Delete";
            this.deleteBTM.UseVisualStyleBackColor = true;
            this.deleteBTM.Click += new System.EventHandler(this.deleteBTM_Click);
            // 
            // wordList
            // 
            this.wordList.Enabled = false;
            this.wordList.FormattingEnabled = true;
            this.wordList.Location = new System.Drawing.Point(7, 20);
            this.wordList.Name = "wordList";
            this.wordList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.wordList.Size = new System.Drawing.Size(222, 186);
            this.wordList.TabIndex = 0;
            // 
            // FrameworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 425);
            this.Controls.Add(this.wordListBox);
            this.Controls.Add(this.configurationBox);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.filesBox);
            this.Controls.Add(this.algorithmGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrameworkForm";
            this.Text = "The Spam ALgorithm Testing System";
            this.algorithmGroupBox.ResumeLayout(false);
            this.algorithmGroupBox.PerformLayout();
            this.filesBox.ResumeLayout(false);
            this.filesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phraseNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hamNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spamNumber)).EndInit();
            this.resultBox.ResumeLayout(false);
            this.resultBox.PerformLayout();
            this.configurationBox.ResumeLayout(false);
            this.configurationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).EndInit();
            this.wordListBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox algorithmGroupBox;
        private System.Windows.Forms.GroupBox filesBox;
        private System.Windows.Forms.GroupBox resultBox;
        private System.Windows.Forms.GroupBox configurationBox;
        private System.Windows.Forms.RadioButton algorithmRadio5;
        private System.Windows.Forms.RadioButton algorithmRadio4;
        private System.Windows.Forms.RadioButton algorithmRadio3;
        private System.Windows.Forms.RadioButton algorithmRadio2;
        private System.Windows.Forms.RadioButton algorithmRadio1;
        private System.Windows.Forms.RadioButton algorithmRadio0;
        private System.Windows.Forms.NumericUpDown phraseNumber;
        private System.Windows.Forms.NumericUpDown hamNumber;
        private System.Windows.Forms.NumericUpDown spamNumber;
        private System.Windows.Forms.TextBox hamLabel;
        private System.Windows.Forms.TextBox spamLabel;
        private System.Windows.Forms.TextBox phraseLabel;
        private System.Windows.Forms.TextBox phraseFile;
        private System.Windows.Forms.Button openPhrases;
        private System.Windows.Forms.TextBox datasetFolder;
        private System.Windows.Forms.Button openDataset;
        private System.Windows.Forms.NumericUpDown thresholdValue;
        private System.Windows.Forms.Button runBtm;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer theTimer;
        private System.Windows.Forms.TextBox spamRecallBox;
        private System.Windows.Forms.TextBox spamPrecision;
        private System.Windows.Forms.TextBox falsePBox;
        private System.Windows.Forms.TextBox falseNbox;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.TextBox accurecyBox;
        private System.Windows.Forms.GroupBox wordListBox;
        private System.Windows.Forms.Button deleteBTM;
        private System.Windows.Forms.ListBox wordList;
        private System.Windows.Forms.CheckBox threshold;
        private System.Windows.Forms.CheckBox saveFile;
        private System.Windows.Forms.TextBox loadText;
        private System.Windows.Forms.Button browseBTM;
    }
}