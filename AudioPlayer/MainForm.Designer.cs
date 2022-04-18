namespace AudioPlayer
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            this.PlaySongButton = new System.Windows.Forms.Button();
            this.PrevSongButton = new System.Windows.Forms.Button();
            this.NextSongButton = new System.Windows.Forms.Button();
            this.MixSongButton = new System.Windows.Forms.Button();
            this.SongProgressBar = new System.Windows.Forms.TrackBar();
            this.SongsList = new System.Windows.Forms.ListBox();
            this.VolumeSongBar = new System.Windows.Forms.TrackBar();
            this.Volume = new System.Windows.Forms.Label();
            this.SongName = new System.Windows.Forms.Label();
            this.CurrentTimeSong = new System.Windows.Forms.Label();
            this.TotalTimeSong = new System.Windows.Forms.Label();
            this.FileButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SongProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSongBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaySongButton
            // 
            this.PlaySongButton.Location = new System.Drawing.Point(54, 12);
            this.PlaySongButton.Name = "PlaySongButton";
            this.PlaySongButton.Size = new System.Drawing.Size(105, 23);
            this.PlaySongButton.TabIndex = 0;
            this.PlaySongButton.Text = "Play";
            this.PlaySongButton.UseVisualStyleBackColor = true;
            // 
            // PrevSongButton
            // 
            this.PrevSongButton.Location = new System.Drawing.Point(12, 12);
            this.PrevSongButton.Name = "PrevSongButton";
            this.PrevSongButton.Size = new System.Drawing.Size(36, 23);
            this.PrevSongButton.TabIndex = 1;
            this.PrevSongButton.Text = "<<";
            this.PrevSongButton.UseVisualStyleBackColor = true;
            // 
            // NextSongButton
            // 
            this.NextSongButton.Location = new System.Drawing.Point(165, 12);
            this.NextSongButton.Name = "NextSongButton";
            this.NextSongButton.Size = new System.Drawing.Size(36, 23);
            this.NextSongButton.TabIndex = 2;
            this.NextSongButton.Text = ">>";
            this.NextSongButton.UseVisualStyleBackColor = true;
            // 
            // MixSongButton
            // 
            this.MixSongButton.Location = new System.Drawing.Point(207, 12);
            this.MixSongButton.Name = "MixSongButton";
            this.MixSongButton.Size = new System.Drawing.Size(35, 23);
            this.MixSongButton.TabIndex = 3;
            this.MixSongButton.Text = "Mix";
            this.MixSongButton.UseVisualStyleBackColor = true;
            // 
            // SongProgressBar
            // 
            this.SongProgressBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.SongProgressBar.Location = new System.Drawing.Point(54, 41);
            this.SongProgressBar.Name = "SongProgressBar";
            this.SongProgressBar.Size = new System.Drawing.Size(147, 45);
            this.SongProgressBar.TabIndex = 4;
            this.SongProgressBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // SongsList
            // 
            this.SongsList.FormattingEnabled = true;
            this.SongsList.ItemHeight = 15;
            this.SongsList.Location = new System.Drawing.Point(12, 64);
            this.SongsList.Name = "SongsList";
            this.SongsList.Size = new System.Drawing.Size(230, 169);
            this.SongsList.TabIndex = 5;
            // 
            // VolumeSongBar
            // 
            this.VolumeSongBar.LargeChange = 1;
            this.VolumeSongBar.Location = new System.Drawing.Point(248, 12);
            this.VolumeSongBar.Maximum = 100;
            this.VolumeSongBar.Name = "VolumeSongBar";
            this.VolumeSongBar.Size = new System.Drawing.Size(106, 45);
            this.VolumeSongBar.TabIndex = 6;
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
            // SongName
            // 
            this.SongName.AutoSize = true;
            this.SongName.Location = new System.Drawing.Point(248, 64);
            this.SongName.Name = "SongName";
            this.SongName.Size = new System.Drawing.Size(106, 15);
            this.SongName.TabIndex = 8;
            this.SongName.Text = "CurrentSongName";
            // 
            // CurrentTimeSong
            // 
            this.CurrentTimeSong.AutoSize = true;
            this.CurrentTimeSong.Location = new System.Drawing.Point(12, 42);
            this.CurrentTimeSong.Name = "CurrentTimeSong";
            this.CurrentTimeSong.Size = new System.Drawing.Size(49, 15);
            this.CurrentTimeSong.TabIndex = 10;
            this.CurrentTimeSong.Text = "00:00:00";
            // 
            // TotalTimeSong
            // 
            this.TotalTimeSong.AutoSize = true;
            this.TotalTimeSong.Location = new System.Drawing.Point(193, 42);
            this.TotalTimeSong.Name = "TotalTimeSong";
            this.TotalTimeSong.Size = new System.Drawing.Size(49, 15);
            this.TotalTimeSong.TabIndex = 11;
            this.TotalTimeSong.Text = "00:00:00";
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(12, 231);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(230, 23);
            this.FileButton.TabIndex = 12;
            this.FileButton.Text = "Open files directory";
            this.FileButton.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 266);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.TotalTimeSong);
            this.Controls.Add(this.CurrentTimeSong);
            this.Controls.Add(this.SongName);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.VolumeSongBar);
            this.Controls.Add(this.SongsList);
            this.Controls.Add(this.SongProgressBar);
            this.Controls.Add(this.MixSongButton);
            this.Controls.Add(this.NextSongButton);
            this.Controls.Add(this.PrevSongButton);
            this.Controls.Add(this.PlaySongButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainPage";
            this.Text = "AudioPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.SongProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSongBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PlaySongButton;
        private Button PrevSongButton;
        private Button NextSongButton;
        private Button MixSongButton;
        private TrackBar SongProgressBar;
        private ListBox SongsList;
        private TrackBar VolumeSongBar;
        private Label Volume;
        private Label SongName;
        private Label CurrentTimeSong;
        private Label TotalTimeSong;
        private OpenFileDialog openFile;
        private Button FileButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}