using NAudio.Wave;
namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        private List<Song> songs;
        /// <summary>
        /// Count of seconds in the song
        /// </summary>
        private int SongTotalTime;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// New song is come we need to refresh screen info
        /// </summary>
        private void ResetScreen()
        {

        }
        private void Init()
        {
            if(outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            songs = new List<Song>();
        }

        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            try
            {
                if (audioFile != null)
                {
                    if(audioFile.CurrentTime.TotalSeconds >= SongTotalTime)
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
            throw new NotImplementedException();
        }

        private void PrevSongButton_Click(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

        }

        private void NextSongButton_Click(object sender, EventArgs e)
        {
            NextSong();
        }

        private void MixSongButton_Click(object sender, EventArgs e)
        {

        }

        private void SongProgressBar_Scroll(object sender, EventArgs e)
        {

        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}