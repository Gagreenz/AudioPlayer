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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.SongProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(42, 12);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            // 
            // PrevSongButton
            // 
            this.PrevSongButton.Location = new System.Drawing.Point(12, 12);
            this.PrevSongButton.Name = "PrevSongButton";
            this.PrevSongButton.Size = new System.Drawing.Size(24, 23);
            this.PrevSongButton.TabIndex = 1;
            this.PrevSongButton.Text = "<";
            this.PrevSongButton.UseVisualStyleBackColor = true;
            // 
            // NextSongButton
            // 
            this.NextSongButton.Location = new System.Drawing.Point(123, 12);
            this.NextSongButton.Name = "NextSongButton";
            this.NextSongButton.Size = new System.Drawing.Size(24, 23);
            this.NextSongButton.TabIndex = 2;
            this.NextSongButton.Text = ">";
            this.NextSongButton.UseVisualStyleBackColor = true;
            // 
            // MixSongButton
            // 
            this.MixSongButton.Location = new System.Drawing.Point(153, 12);
            this.MixSongButton.Name = "MixSongButton";
            this.MixSongButton.Size = new System.Drawing.Size(35, 23);
            this.MixSongButton.TabIndex = 3;
            this.MixSongButton.Text = "Mix";
            this.MixSongButton.UseVisualStyleBackColor = true;
            // 
            // SongProgressBar
            // 
            this.SongProgressBar.Location = new System.Drawing.Point(12, 42);
            this.SongProgressBar.Name = "SongProgressBar";
            this.SongProgressBar.Size = new System.Drawing.Size(176, 45);
            this.SongProgressBar.TabIndex = 4;
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(194, 12);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 266);
            this.Controls.Add(this.trackBar1);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private TrackBar trackBar1;
    }
}