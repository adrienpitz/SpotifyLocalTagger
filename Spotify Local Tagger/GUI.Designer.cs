namespace Spotify_Local_Tagger
{
    partial class GUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.credentialsLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.webPageLabel = new System.Windows.Forms.Label();
            this.loginCredsButton = new System.Windows.Forms.Button();
            this.loginWebButton = new System.Windows.Forms.Button();
            this.logoImageBox = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // credentialsLabel
            // 
            this.credentialsLabel.AutoSize = true;
            this.credentialsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.credentialsLabel.Location = new System.Drawing.Point(496, 199);
            this.credentialsLabel.Name = "credentialsLabel";
            this.credentialsLabel.Size = new System.Drawing.Size(109, 13);
            this.credentialsLabel.TabIndex = 0;
            this.credentialsLabel.Text = "Login with credentials";
            // 
            // loginTextBox
            // 
            this.loginTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.loginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginTextBox.Location = new System.Drawing.Point(571, 224);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(215, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Location = new System.Drawing.Point(571, 260);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(215, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // webPageLabel
            // 
            this.webPageLabel.AutoSize = true;
            this.webPageLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.webPageLabel.Location = new System.Drawing.Point(496, 333);
            this.webPageLabel.Name = "webPageLabel";
            this.webPageLabel.Size = new System.Drawing.Size(133, 13);
            this.webPageLabel.TabIndex = 3;
            this.webPageLabel.Text = "Login on Spotify web page";
            // 
            // loginCredsButton
            // 
            this.loginCredsButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.loginCredsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginCredsButton.Location = new System.Drawing.Point(571, 296);
            this.loginCredsButton.Name = "loginCredsButton";
            this.loginCredsButton.Size = new System.Drawing.Size(215, 23);
            this.loginCredsButton.TabIndex = 4;
            this.loginCredsButton.Text = "Login";
            this.loginCredsButton.UseVisualStyleBackColor = false;
            this.loginCredsButton.Click += new System.EventHandler(this.loginCredsButton_Click);
            // 
            // loginWebButton
            // 
            this.loginWebButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(242)))), ((int)(((byte)(156)))));
            this.loginWebButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginWebButton.Location = new System.Drawing.Point(571, 362);
            this.loginWebButton.Name = "loginWebButton";
            this.loginWebButton.Size = new System.Drawing.Size(215, 23);
            this.loginWebButton.TabIndex = 5;
            this.loginWebButton.Text = "Open and connect";
            this.loginWebButton.UseVisualStyleBackColor = false;
            this.loginWebButton.Click += new System.EventHandler(this.loginWebButton_Click);
            // 
            // logoImageBox
            // 
            this.logoImageBox.BackColor = System.Drawing.Color.Transparent;
            this.logoImageBox.Image = ((System.Drawing.Image)(resources.GetObject("logoImageBox.Image")));
            this.logoImageBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("logoImageBox.InitialImage")));
            this.logoImageBox.Location = new System.Drawing.Point(316, 202);
            this.logoImageBox.Name = "logoImageBox";
            this.logoImageBox.Size = new System.Drawing.Size(174, 183);
            this.logoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoImageBox.TabIndex = 6;
            this.logoImageBox.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loginLabel.Location = new System.Drawing.Point(512, 224);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 7;
            this.loginLabel.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(512, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Password";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.logoImageBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.credentialsLabel);
            this.panel1.Controls.Add(this.loginLabel);
            this.panel1.Controls.Add(this.loginTextBox);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.loginWebButton);
            this.panel1.Controls.Add(this.webPageLabel);
            this.panel1.Controls.Add(this.loginCredsButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 599);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1122, 599);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Controls.Add(this.profilePictureBox);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(204, 59);
            this.panel3.TabIndex = 9;
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.Location = new System.Drawing.Point(3, 0);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(50, 59);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePictureBox.TabIndex = 0;
            this.profilePictureBox.TabStop = false;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1122, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spotify Local Tagger";
            ((System.ComponentModel.ISupportInitialize)(this.logoImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label credentialsLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label webPageLabel;
        private System.Windows.Forms.Button loginCredsButton;
        private System.Windows.Forms.Button loginWebButton;
        private System.Windows.Forms.PictureBox logoImageBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox profilePictureBox;
    }
}

