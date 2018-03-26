namespace Spotify_Local_Tagger
{
    partial class ManualMergingGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualMergingGUI));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.proceedButton1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.firstSentenceEntryLabel = new System.Windows.Forms.Label();
            this.numberUnmatchedLabel = new System.Windows.Forms.Label();
            this.mergePanel = new System.Windows.Forms.Panel();
            this.quitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.matchButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localListBox = new System.Windows.Forms.ListBox();
            this.spotifyListBox = new System.Windows.Forms.ListBox();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mergePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.cancelButton1);
            this.mainPanel.Controls.Add(this.proceedButton1);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(784, 621);
            this.mainPanel.TabIndex = 0;
            // 
            // cancelButton1
            // 
            this.cancelButton1.Location = new System.Drawing.Point(528, 586);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.Size = new System.Drawing.Size(114, 23);
            this.cancelButton1.TabIndex = 4;
            this.cancelButton1.Text = "Cancel";
            this.cancelButton1.UseVisualStyleBackColor = true;
            this.cancelButton1.Click += new System.EventHandler(this.cancelButton1_Click);
            // 
            // proceedButton1
            // 
            this.proceedButton1.Location = new System.Drawing.Point(658, 586);
            this.proceedButton1.Name = "proceedButton1";
            this.proceedButton1.Size = new System.Drawing.Size(114, 23);
            this.proceedButton1.TabIndex = 3;
            this.proceedButton1.Text = "Proceed";
            this.proceedButton1.UseVisualStyleBackColor = true;
            this.proceedButton1.Click += new System.EventHandler(this.proceedButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.firstSentenceEntryLabel);
            this.panel1.Controls.Add(this.numberUnmatchedLabel);
            this.panel1.Location = new System.Drawing.Point(41, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 227);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(241, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "of your local songs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstSentenceEntryLabel
            // 
            this.firstSentenceEntryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstSentenceEntryLabel.AutoSize = true;
            this.firstSentenceEntryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstSentenceEntryLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.firstSentenceEntryLabel.Location = new System.Drawing.Point(13, 58);
            this.firstSentenceEntryLabel.Name = "firstSentenceEntryLabel";
            this.firstSentenceEntryLabel.Size = new System.Drawing.Size(681, 29);
            this.firstSentenceEntryLabel.TabIndex = 0;
            this.firstSentenceEntryLabel.Text = "Oops... The Spotify Local Tagger couldn\'t find a match for";
            this.firstSentenceEntryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberUnmatchedLabel
            // 
            this.numberUnmatchedLabel.AutoSize = true;
            this.numberUnmatchedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberUnmatchedLabel.ForeColor = System.Drawing.Color.White;
            this.numberUnmatchedLabel.Location = new System.Drawing.Point(332, 102);
            this.numberUnmatchedLabel.Name = "numberUnmatchedLabel";
            this.numberUnmatchedLabel.Size = new System.Drawing.Size(52, 29);
            this.numberUnmatchedLabel.TabIndex = 1;
            this.numberUnmatchedLabel.Text = "666";
            // 
            // mergePanel
            // 
            this.mergePanel.BackColor = System.Drawing.Color.Transparent;
            this.mergePanel.Controls.Add(this.quitButton);
            this.mergePanel.Controls.Add(this.label2);
            this.mergePanel.Controls.Add(this.matchButton);
            this.mergePanel.Controls.Add(this.groupBox2);
            this.mergePanel.Controls.Add(this.groupBox1);
            this.mergePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergePanel.Location = new System.Drawing.Point(0, 0);
            this.mergePanel.Name = "mergePanel";
            this.mergePanel.Size = new System.Drawing.Size(784, 621);
            this.mergePanel.TabIndex = 1;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(658, 586);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(113, 23);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(9, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(499, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select the local song of your choice and its corresponding match in the Spotify s" +
    "ongs, then press \'Match\'";
            // 
            // matchButton
            // 
            this.matchButton.Location = new System.Drawing.Point(12, 543);
            this.matchButton.Name = "matchButton";
            this.matchButton.Size = new System.Drawing.Size(760, 23);
            this.matchButton.TabIndex = 2;
            this.matchButton.Text = "Match";
            this.matchButton.UseVisualStyleBackColor = true;
            this.matchButton.Click += new System.EventHandler(this.matchButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spotifyListBox);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(404, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 511);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unmatched Spotify Songs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localListBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 511);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unmatched local songs";
            // 
            // localListBox
            // 
            this.localListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.localListBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.localListBox.FormattingEnabled = true;
            this.localListBox.HorizontalScrollbar = true;
            this.localListBox.Location = new System.Drawing.Point(0, 20);
            this.localListBox.Name = "localListBox";
            this.localListBox.Size = new System.Drawing.Size(368, 485);
            this.localListBox.TabIndex = 0;
            // 
            // spotifyListBox
            // 
            this.spotifyListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.spotifyListBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.spotifyListBox.FormattingEnabled = true;
            this.spotifyListBox.HorizontalScrollbar = true;
            this.spotifyListBox.Location = new System.Drawing.Point(-1, 20);
            this.spotifyListBox.Name = "spotifyListBox";
            this.spotifyListBox.Size = new System.Drawing.Size(368, 485);
            this.spotifyListBox.TabIndex = 1;
            // 
            // ManualMergingGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Spotify_Local_Tagger.Properties.Resources.elegant_Geometric_Wallpaper_hd;
            this.ClientSize = new System.Drawing.Size(784, 621);
            this.Controls.Add(this.mergePanel);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManualMergingGUI";
            this.Text = "Spotify Local Tagger - Manual Merging";
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mergePanel.ResumeLayout(false);
            this.mergePanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button cancelButton1;
        private System.Windows.Forms.Button proceedButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label firstSentenceEntryLabel;
        private System.Windows.Forms.Label numberUnmatchedLabel;
        private System.Windows.Forms.Panel mergePanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button matchButton;
        private System.Windows.Forms.ListBox spotifyListBox;
        private System.Windows.Forms.ListBox localListBox;
    }
}