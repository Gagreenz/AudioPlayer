using NAudio.Wave;
namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private string SongFolderPath = @"D:/";
        private int SongsPtr;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        ////TODO: Maybe I need to create class with indexer and List<Song> Which can detect position and work with it
        private List<Song> songs;
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
            songs = new List<Song>();
            FindMusic();
            SongsPtr = 0;


            outputDevice.Init(getAudioFile());

            VolumeBar.Value = 100;
        }

        private void FindMusic()
        {
            var dir = Directory.GetFiles(SongFolderPath,"*.mp3");
            foreach (var file in dir)
            {
                //TODO: Naming for song
                songs.Add(new Song(file,file));
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
        private AudioFileReader getAudioFile()
        {
            if (audioFile != null) audioFile.Dispose();
            if (SongsPtr == songs.Count) SongsPtr = 0;

            audioFile = new AudioFileReader(songs[SongsPtr++].Path);
            SongTotalTime = audioFile.TotalTime.Seconds + audioFile.TotalTime.Minutes * 60;

            ResetScreen();

            return audioFile;
        }
        private void NextSong()
        {
            outputDevice?.Stop();
            outputDevice.Init(getAudioFile());

            if (PlayButton.Text == "Stop")
            {
                outputDevice?.Play();
            }
        }

        private void PrevSongButton_Click(object sender, EventArgs e)
        {
            if (SongsPtr == 1) SongsPtr = songs.Count - 1;
            else SongsPtr-= 2;
            NextSong();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if(PlayButton.Text == "Play")
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
            songs.Shuffle();
        }
        
        private void SongProgressBar_Scroll(object sender, EventArgs e)
        {

        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            outputDevice.Volume = (float)VolumeBar.Value / 100;
            Volume.Text = VolumeBar.Value.ToString();
        }
    }
}