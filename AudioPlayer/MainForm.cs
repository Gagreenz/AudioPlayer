using NAudio.Wave;
namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private string SongFolderPath = @"D:/";

        SongManager songManager;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;

        /// <summary>
        /// Count of seconds in the song
        /// </summary>
        private int SongTotalTime;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// New song is come we need to refresh screen info
        /// </summary>
        private void ResetScreen()
        {
            TotalTimeLabel.Text = audioFile.TotalTime.ToString(@"hh\:mm\:ss");
            SongProgressBar.Maximum = SongTotalTime;
            SongProgressBar.Value = 0;

            CurrentSongName.Text = audioFile.FileName;
        }
        private void Init()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Volume = 1f;
            }
            songManager = new SongManager(new List<Song>());
            FindMusic();

            NextSong();

            VolumeBar.Value = 100;
        }

        private void FindMusic()
        {
            var dir = Directory.GetFiles(SongFolderPath, "*.mp3");
            foreach (var file in dir)
            {
                //TODO: Naming for song
                songManager.AddSong(new Song(file, file));
                SongsList.Items.Add(file);
            }
        }

        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            try
            {
                if (audioFile != null)
                {
                    if (audioFile.CurrentTime.TotalSeconds >= SongTotalTime)
                    {
                        NextSong();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void NextSong()
        {
            outputDevice?.Stop();

            audioFile = new AudioFileReader(songManager.GetNextSong().Path);
            ResetScreen();

            outputDevice?.Init(audioFile);

            if (PlayButton.Text == "Stop")
            {
                outputDevice?.Play();
            }
        }
        private void PrevSong()
        {
            outputDevice?.Stop();

            audioFile = new AudioFileReader(songManager.GetPrevSong().Path);
            ResetScreen();

            outputDevice?.Init(audioFile);

            if (PlayButton.Text == "Stop")
            {
                outputDevice?.Play();
            }
        }

        private void PrevSongButton_Click(object sender, EventArgs e)
        {
            PrevSong();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (PlayButton.Text == "Play")
            {
                outputDevice?.Play();
                PlayButton.Text = "Stop";
            }
            else
            {
                outputDevice?.Stop();
                PlayButton.Text = "Play";
            }

        }

        private void NextSongButton_Click(object sender, EventArgs e)
        {
            NextSong();
        }

        private void MixSongButton_Click(object sender, EventArgs e)
        {
            songManager.ShuffleSongs();
        }

        private void SongProgressBar_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(SongProgressBar.Value);
            }
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            outputDevice.Volume = (float)VolumeBar.Value / 100;
            Volume.Text = VolumeBar.Value.ToString();
        }
    }
}