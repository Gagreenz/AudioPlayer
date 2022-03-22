namespace AudioPlayer
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.PrevSongButton = new System.Windows.Forms.Button();
            this.NextSongButton = new System.Windows.Forms.Button();
            this.MixSongButton = new System.Windows.Forms.Button();
            this.SongProgressBar = new System.Windows.Forms.TrackBar();
            this.SongsList = new System.Windows.Forms.ListBox();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.Volume = new System.Windows.Forms.Label();
            this.CurrentSongName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.TotalTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SongProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(54, 12);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(105, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PrevSongButton
            // 
            this.PrevSongButton.Location = new System.Drawing.Point(12, 12);
            this.PrevSongButton.Name = "PrevSongButton";
            this.PrevSongButton.Size = new System.Drawing.Size(36, 23);
            this.PrevSongButton.TabIndex = 1;
            this.PrevSongButton.Text = "<<";
            this.PrevSongButton.UseVisualStyleBackColor = true;
            this.PrevSongButton.Click += new System.EventHandler(this.PrevSongButton_Click);
            // 
            // NextSongButton
            // 
            this.NextSongButton.Location = new System.Drawing.Point(165, 12);
            this.NextSongButton.Name = "NextSongButton";
            this.NextSongButton.Size = new System.Drawing.Size(36, 23);
            this.NextSongButton.TabIndex = 2;
            this.NextSongButton.Text = ">>";
            this.NextSongButton.UseVisualStyleBackColor = true;
            this.NextSongButton.Click += new System.EventHandler(this.NextSongButton_Click);
            // 
            // MixSongButton
            // 
            this.MixSongButton.Location = new System.Drawing.Point(207, 12);
            this.MixSongButton.Name = "MixSongButton";
            this.MixSongButton.Size = new System.Drawing.Size(35, 23);
            this.MixSongButton.TabIndex = 3;
            this.MixSongButton.Text = "Mix";
            this.MixSongButton.UseVisualStyleBackColor = true;
            this.MixSongButton.Click += new System.EventHandler(this.MixSongButton_Click);
            // 
            // SongProgressBar
            // 
            this.SongProgressBar.Location = new System.Drawing.Point(54, 41);
            this.SongProgressBar.Name = "SongProgressBar";
            this.SongProgressBar.Size = new System.Drawing.Size(147, 45);
            this.SongProgressBar.TabIndex = 4;
            this.SongProgressBar.Scroll += new System.EventHandler(this.SongProgressBar_Scroll);
            // 
            // SongsList
            // 
            this.SongsList.FormattingEnabled = true;
            this.SongsList.ItemHeight = 15;
            this.SongsList.Location = new System.Drawing.Point(12, 79);
            this.SongsList.Name = "SongsList";
            this.SongsList.Size = new System.Drawing.Size(176, 169);
            this.SongsList.TabIndex = 5;
            // 
            // VolumeBar
            // 
            this.VolumeBar.LargeChange = 1;
            this.VolumeBar.Location = new System.Drawing.Point(248, 12);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(106, 45);
            this.VolumeBar.TabIndex = 6;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // Volume
            // 
            this.Volume.AutoSize = true;
            this.Volume.Location = new System.Drawing.Point(347, 16);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(25, 15);
            this.Volume.TabIndex = 7;
            this.Volume.Text = "100";
            // 
            // CurrentSongName
            // 
            this.CurrentSongName.AutoSize = true;
            this.CurrentSongName.Location = new System.Drawing.Point(248, 60);
            this.CurrentSongName.Name = "CurrentSongName";
            this.CurrentSongName.Size = new System.Drawing.Size(106, 15);
            this.CurrentSongName.TabIndex = 8;
            this.CurrentSongName.Text = "CurrentSongName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(248, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 169);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(12, 42);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(49, 15);
            this.CurrentTimeLabel.TabIndex = 10;
            this.CurrentTimeLabel.Text = "00:00:00";
            // 
            // TotalTimeLabel
            // 
            this.TotalTimeLabel.AutoSize = true;
            this.TotalTimeLabel.Location = new System.Drawing.Point(193, 42);
            this.TotalTimeLabel.Name = "TotalTimeLabel";
            this.TotalTimeLabel.Size = new System.Drawing.Size(49, 15);
            this.TotalTimeLabel.TabIndex = 11;
            this.TotalTimeLabel.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 266);
            this.Controls.Add(this.TotalTimeLabel);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CurrentSongName);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.SongsList);
            this.Controls.Add(this.SongProgressBar);
            this.Controls.Add(this.MixSongButton);
            this.Controls.Add(this.NextSongButton);
            this.Controls.Add(this.PrevSongButton);
            this.Controls.Add(this.PlayButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SongProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PlayButton;
        private Button PrevSongButton;
        private Button NextSongButton;
        private Button MixSongButton;
        private TrackBar SongProgressBar;
        private ListBox SongsList;
        private TrackBar VolumeBar;
        private Label Volume;
        private Label CurrentSongName;
        private PictureBox pictureBox1;
        private Label CurrentTimeLabel;
        private Label TotalTimeLabel;
    }
}