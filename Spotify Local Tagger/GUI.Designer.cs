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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.credentialsLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.webPageLabel = new System.Windows.Forms.Label();
            this.loginCredsButton = new System.Windows.Forms.Button();
            this.loginWebButton = new System.Windows.Forms.Button();
            this.logoImageBox = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.localListView = new System.Windows.Forms.ListView();
            this.spotifyMusicGroupBox = new System.Windows.Forms.GroupBox();
            this.playlistNotUserLabel = new System.Windows.Forms.Label();
            this.spotifyMusicsListView = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playlistsGroupBox = new System.Windows.Forms.GroupBox();
            this.playlistsListBox = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.countryLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.followersLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoImageBox)).BeginInit();
            this.loginPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.spotifyMusicGroupBox.SuspendLayout();
            this.playlistsGroupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // credentialsLabel
            // 
            this.credentialsLabel.AutoSize = true;
            this.credentialsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.credentialsLabel.Location = new System.Drawing.Point(398, 218);
            this.credentialsLabel.Name = "credentialsLabel";
            this.credentialsLabel.Size = new System.Drawing.Size(109, 13);
            this.credentialsLabel.TabIndex = 0;
            this.credentialsLabel.Text = "Login with credentials";
            // 
            // loginTextBox
            // 
            this.loginTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.loginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginTextBox.Location = new System.Drawing.Point(473, 243);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(215, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Location = new System.Drawing.Point(473, 279);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(215, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // webPageLabel
            // 
            this.webPageLabel.AutoSize = true;
            this.webPageLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.webPageLabel.Location = new System.Drawing.Point(398, 352);
            this.webPageLabel.Name = "webPageLabel";
            this.webPageLabel.Size = new System.Drawing.Size(133, 13);
            this.webPageLabel.TabIndex = 3;
            this.webPageLabel.Text = "Login on Spotify web page";
            // 
            // loginCredsButton
            // 
            this.loginCredsButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.loginCredsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginCredsButton.Location = new System.Drawing.Point(473, 315);
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
            this.loginWebButton.Location = new System.Drawing.Point(473, 381);
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
            this.logoImageBox.Location = new System.Drawing.Point(218, 221);
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
            this.loginLabel.Location = new System.Drawing.Point(414, 243);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 7;
            this.loginLabel.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(414, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Password";
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.Transparent;
            this.loginPanel.Controls.Add(this.logoImageBox);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.credentialsLabel);
            this.loginPanel.Controls.Add(this.loginLabel);
            this.loginPanel.Controls.Add(this.loginTextBox);
            this.loginPanel.Controls.Add(this.passwordTextBox);
            this.loginPanel.Controls.Add(this.loginWebButton);
            this.loginPanel.Controls.Add(this.webPageLabel);
            this.loginPanel.Controls.Add(this.loginCredsButton);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(910, 643);
            this.loginPanel.TabIndex = 9;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.spotifyMusicGroupBox);
            this.mainPanel.Controls.Add(this.playlistsGroupBox);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(910, 643);
            this.mainPanel.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.folderTextBox);
            this.groupBox1.Controls.Add(this.localListView);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(455, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 366);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local musics in xxx";
            // 
            // browseButton
            // 
            this.browseButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.browseButton.Location = new System.Drawing.Point(353, 14);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(97, 20);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // folderTextBox
            // 
            this.folderTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.folderTextBox.Location = new System.Drawing.Point(4, 14);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(343, 20);
            this.folderTextBox.TabIndex = 1;
            // 
            // localListView
            // 
            this.localListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.localListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.localListView.Location = new System.Drawing.Point(0, 40);
            this.localListView.Name = "localListView";
            this.localListView.Size = new System.Drawing.Size(450, 317);
            this.localListView.TabIndex = 0;
            this.localListView.TileSize = new System.Drawing.Size(270, 30);
            this.localListView.UseCompatibleStateImageBehavior = false;
            this.localListView.View = System.Windows.Forms.View.Tile;
            // 
            // spotifyMusicGroupBox
            // 
            this.spotifyMusicGroupBox.Controls.Add(this.playlistNotUserLabel);
            this.spotifyMusicGroupBox.Controls.Add(this.spotifyMusicsListView);
            this.spotifyMusicGroupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.spotifyMusicGroupBox.Location = new System.Drawing.Point(3, 254);
            this.spotifyMusicGroupBox.Name = "spotifyMusicGroupBox";
            this.spotifyMusicGroupBox.Size = new System.Drawing.Size(450, 366);
            this.spotifyMusicGroupBox.TabIndex = 11;
            this.spotifyMusicGroupBox.TabStop = false;
            this.spotifyMusicGroupBox.Text = "Spotify musics in xxx";
            // 
            // playlistNotUserLabel
            // 
            this.playlistNotUserLabel.AutoSize = true;
            this.playlistNotUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlistNotUserLabel.ForeColor = System.Drawing.Color.Red;
            this.playlistNotUserLabel.Location = new System.Drawing.Point(0, 17);
            this.playlistNotUserLabel.Name = "playlistNotUserLabel";
            this.playlistNotUserLabel.Size = new System.Drawing.Size(29, 13);
            this.playlistNotUserLabel.TabIndex = 1;
            this.playlistNotUserLabel.Text = "Error";
            // 
            // spotifyMusicsListView
            // 
            this.spotifyMusicsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.spotifyMusicsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Artist,
            this.Album});
            this.spotifyMusicsListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spotifyMusicsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.spotifyMusicsListView.Location = new System.Drawing.Point(0, 40);
            this.spotifyMusicsListView.Name = "spotifyMusicsListView";
            this.spotifyMusicsListView.Size = new System.Drawing.Size(450, 317);
            this.spotifyMusicsListView.TabIndex = 0;
            this.spotifyMusicsListView.TileSize = new System.Drawing.Size(270, 30);
            this.spotifyMusicsListView.UseCompatibleStateImageBehavior = false;
            this.spotifyMusicsListView.View = System.Windows.Forms.View.Tile;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // Album
            // 
            this.Album.Text = "Album";
            this.Album.Width = 64;
            // 
            // playlistsGroupBox
            // 
            this.playlistsGroupBox.Controls.Add(this.playlistsListBox);
            this.playlistsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playlistsGroupBox.Location = new System.Drawing.Point(3, 68);
            this.playlistsGroupBox.Name = "playlistsGroupBox";
            this.playlistsGroupBox.Size = new System.Drawing.Size(902, 180);
            this.playlistsGroupBox.TabIndex = 10;
            this.playlistsGroupBox.TabStop = false;
            this.playlistsGroupBox.Text = "Playlists";
            // 
            // playlistsListBox
            // 
            this.playlistsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.playlistsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playlistsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlistsListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.playlistsListBox.FormattingEnabled = true;
            this.playlistsListBox.HorizontalScrollbar = true;
            this.playlistsListBox.ItemHeight = 16;
            this.playlistsListBox.Items.AddRange(new object[] {
            "Rock",
            "Metal",
            "Classique",
            "Ariana Grande",
            "Snoop Dogg Intégrale",
            "Golden 60\'s",
            "Rock n\' Roll",
            "Ballades",
            "Chanson Française"});
            this.playlistsListBox.Location = new System.Drawing.Point(0, 18);
            this.playlistsListBox.Name = "playlistsListBox";
            this.playlistsListBox.Size = new System.Drawing.Size(902, 162);
            this.playlistsListBox.TabIndex = 0;
            this.playlistsListBox.SelectedIndexChanged += new System.EventHandler(this.playlistsListBox_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Controls.Add(this.countryLabel);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.followersLabel);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.nameLabel);
            this.panel3.Controls.Add(this.profilePictureBox);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(204, 59);
            this.panel3.TabIndex = 9;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.countryLabel.Location = new System.Drawing.Point(124, 40);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(49, 13);
            this.countryLabel.TabIndex = 5;
            this.countryLabel.Text = "Yakoutie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(60, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Country:";
            // 
            // followersLabel
            // 
            this.followersLabel.AutoSize = true;
            this.followersLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.followersLabel.Location = new System.Drawing.Point(124, 26);
            this.followersLabel.Name = "followersLabel";
            this.followersLabel.Size = new System.Drawing.Size(25, 13);
            this.followersLabel.TabIndex = 3;
            this.followersLabel.Text = "999";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(60, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Followers: ";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.nameLabel.Location = new System.Drawing.Point(60, 10);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "John Smith";
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.Location = new System.Drawing.Point(0, 0);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(53, 59);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.ClientSize = new System.Drawing.Size(910, 643);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.loginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spotify Local Tagger - By Adrien Pitz";
            ((System.ComponentModel.ISupportInitialize)(this.logoImageBox)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.spotifyMusicGroupBox.ResumeLayout(false);
            this.spotifyMusicGroupBox.PerformLayout();
            this.playlistsGroupBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox profilePictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label followersLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox playlistsGroupBox;
        private System.Windows.Forms.ListBox playlistsListBox;
        private System.Windows.Forms.GroupBox spotifyMusicGroupBox;
        private System.Windows.Forms.ListView spotifyMusicsListView;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView localListView;
        private System.Windows.Forms.Label playlistNotUserLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox folderTextBox;
    }
}

