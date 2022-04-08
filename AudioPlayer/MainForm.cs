using NAudio.Wave;
using System.Text.RegularExpressions;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private string _songFolderPath = @"D:/";

        IAudioManager<Song> audioManager;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;

        private bool threadPause = true;
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

            SongsList.SelectedIndex = audioManager.Index;
        }
        private void TimeUpdate()
        {
            SongProgressBar.Value = (int)audioFile.CurrentTime.TotalSeconds;
            CurrentTimeLabel.Text = audioFile.CurrentTime.ToString(@"hh\:mm\:ss");
        }
        private void ThreadUpdatePlayback()
        {
            while (true)
            {
                if (!threadPause)
                {
                    try
                    {
                        Invoke(TimeUpdate, new object[] { });
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
                Thread.Sleep(1000);
            }
        }
        private void Init()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Volume = 1f;
                VolumeBar.Value = 100;
            }
            if (audioManager == null)
            {
                audioManager = new AudioManager(new List<Song>());    
            }

            Thread thread = new Thread(ThreadUpdatePlayback);
            thread.Start();

            SongsList.Items.Clear();
            FindMusic();

            SongsList.Items.AddRange(audioManager.GetSongList().Select(x => x.Name).ToArray());
            SetNextSong(audioManager.GetNextSong());
        }
        private void FindMusic()
        {
            audioManager.GetSongList().Clear();
            var dir = Directory.GetFiles(_songFolderPath, "*.mp3");
            foreach (var file in dir)
            {
                var song = new Song(file.Split('.')[0], file);
                //TODO: Naming for song
                audioManager.AddSong(song);
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
            if (song == null) return;
            try
            {
                outputDevice?.Stop();

                audioFile = new AudioFileReader(song.Path);

                SongTotalTime = audioFile.TotalTime.Seconds + audioFile.TotalTime.Minutes * 60;
                ResetScreen();

                outputDevice?.Init(audioFile);

                if (PlayButton.Text == "Stop")
                {
                    outputDevice?.Play();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(song.Path + " - Не найдена");
                Init();
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
            if(outputDevice == null) return;
            if (PlayButton.Text == "Play")
            {
                threadPause = false;
                outputDevice?.Play();
                PlayButton.Text = "Stop";
            }
            else
            {
                threadPause = true;
                outputDevice?.Stop();
                PlayButton.Text = "Play";
            }

        }
        private void MixSongButton_Click(object sender, EventArgs e)
        {
            audioManager.ShuffleSongs();
            SongsList.Items.Clear();
            SongsList.Items.AddRange(audioManager.GetSongList().ToArray());
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
        private void ListBox_DoubleCLick(object sender, EventArgs e)
        {
            SetNextSong(audioManager.GetSongByIndex(SongsList.SelectedIndex));
        }
        private void FileButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                _songFolderPath = folderBrowserDialog1.SelectedPath;
                Init();
            }
            
        }
    }
}