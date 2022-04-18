using NAudio.Wave;
using System.Text.RegularExpressions;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace AudioPlayer
{
    public partial class MainPage : Form
    {
        Player _player;
        public MainPage()
        {
            InitializeComponent();

            initialize();
        }
        private void initialize()
        {
            try
            {
                _player = new Player();
                _player.SongChanged += onSongChanged;
                _player.Init();
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }

            timer1.Interval = 1000;
            timer1.Tick += timeUpdate;
            timer1.Start();

            VolumeSongBar.Value = (int)(_player.Volume * 100);
            SongsList.Items.AddRange(_player.GetSongsList().Select(s => s.Name).ToArray());

            VolumeSongBar.Scroll += VolumeSongBarScroll;
            SongProgressBar.Scroll += SongProgressBarScroll;
            SongsList.MouseDoubleClick += onSongsListDoubleClicked;
            MixSongButton.Click += onMixClicked;
            NextSongButton.Click += onNextClicked;
            PrevSongButton.Click += onPrevClicked;
            PlaySongButton.Click += onPlayClicked;
        }

        private void timeUpdate(object? sender,EventArgs e)
        {
            SongProgressBar.Value = (int)_player.CurrentTime.TotalSeconds;
            CurrentTimeSong.Text = _player.CurrentTime.ToString(@"hh\:mm\:ss");
        }

        private void VolumeSongBarScroll(object? sender, EventArgs e)
        {
            _player.Volume = (float)VolumeSongBar.Value / 100;
            Volume.Text = VolumeSongBar.Value.ToString();
        }

        private void SongProgressBarScroll(object? sender, EventArgs e)
        {
            _player.CurrentTime = TimeSpan.FromSeconds(SongProgressBar.Value);
        }

        private void onPlayClicked(object? sender, EventArgs e)
        {
            if(PlaySongButton.Text == "Play")
            {
                PlaySongButton.Text = "Stop";
                _player.Play();
                return;
            }
            if (PlaySongButton.Text == "Stop")
            {
                PlaySongButton.Text = "Play";
                _player.Stop();
                return;
            }
        }

        private void onSongsListDoubleClicked(object? sender, MouseEventArgs e)
        {
            _player.SetSongByIndex(SongsList.SelectedIndex);
        }

        private void onMixClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onNextClicked(object? sender, EventArgs e)
        {
            _player.SetNextSong();
        }

        private void onPrevClicked(object? sender, EventArgs e)
        {
            _player.SetPrevSong();
        }

        /// <summary>
        /// Refresh data on form
        /// </summary>
        private void onSongChanged(object? sender,EventArgs e)
        {
            SongName.Text = _player.CurrentSongName;
            SongProgressBar.Maximum = _player.TotalTime.Seconds + _player.TotalTime.Minutes * 60;
            SongProgressBar.Value = 0;
            CurrentTimeSong.Text = _player.CurrentTime.ToString(@"hh\:mm\:ss");
            TotalTimeSong.Text = _player.TotalTime.ToString(@"hh\:mm\:ss");


        }

    }

}