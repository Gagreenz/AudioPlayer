using NAudio.Wave;
namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private string _songFolderPath = @"D:/";

        AudioManager audioManager;
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
            audioManager = new AudioManager(new List<Song>());
            FindMusic();

            SetNextSong(audioManager.GetNextSong());

            VolumeBar.Value = 100;
        }

        private void FindMusic()
        {
            var dir = Directory.GetFiles(_songFolderPath, "*.mp3");
            foreach (var file in dir)
            {
                //TODO: Naming for song
                audioManager.AddSong(new Song(file, file));
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
                        SetNextSong(audioManager.GetNextSong());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void SetNextSong(Song song)
        {
            outputDevice?.Stop();

            audioFile = new AudioFileReader(song.Path);
            ResetScreen();

            SongTotalTime = audioFile.TotalTime.Seconds + audioFile.TotalTime.Minutes * 60;

            outputDevice?.Init(audioFile);

            if (PlayButton.Text == "Stop")
            {
                outputDevice?.Play();
            }
        }
        private void NextSongButton_Click(object sender, EventArgs e)
        {
            SetNextSong(audioManager.GetNextSong());
        }
        private void PrevSongButton_Click(object sender, EventArgs e)
        {
            SetNextSong(audioManager.GetPrevSong());
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
        private void MixSongButton_Click(object sender, EventArgs e)
        {
            audioManager.ShuffleSongs();
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