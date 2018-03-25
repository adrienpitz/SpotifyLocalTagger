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
            this.firstSentenceEntryLabel = new System.Windows.Forms.Label();
            this.numberUnmatchedLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.proceedButton1 = new System.Windows.Forms.Button();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.mergePanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // mergePanel
            // 
            this.mergePanel.BackColor = System.Drawing.Color.Transparent;
            this.mergePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergePanel.Location = new System.Drawing.Point(0, 0);
            this.mergePanel.Name = "mergePanel";
            this.mergePanel.Size = new System.Drawing.Size(784, 621);
            this.mergePanel.TabIndex = 1;
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
    }
}