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
        Player player;
        public MainPage()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            player = new Player();
            ScreenRefresh();
            SongsList.Items.AddRange(player.GetSongsList().
                    Select(x => x.Name).ToArray());

            timer1.Interval = 1000;
            timer1.Tick += TimeUpdate;
            timer1.Start();
        }
        private void TimeUpdate(object? sender,EventArgs e)
        {
            SongProgressBar.Value = (int)player.CurrentTime.TotalSeconds;
            CurrentTimeLabel.Text = player.CurrentTime.ToString(@"hh\:mm\:ss");
        }
        private void ScreenRefresh()
        {
            VolumeBar.Value = (int)(player.Volume * 100);

            TotalTimeLabel.Text = player.TotalTime.ToString(@"hh\:mm\:ss");
            var totalTime = player.TotalTime.Minutes * 60 + player.TotalTime.Seconds;
            SongProgressBar.Maximum = totalTime;
            SongProgressBar.Value = 0;

            //SongsList.SelectedIndex = 0;
        }
        private void NextSongButton_Click(object sender, EventArgs e)
        {
            player.SetNextSong();
            ScreenRefresh();
        }
        private void PrevSongButton_Click(object sender, EventArgs e)
        {
            player.SetPrevSong();
            ScreenRefresh();
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (PlayButton.Text == "Play")
            {
                PlayButton.Text = "Stop";
                player.Play();
            }
            else if (PlayButton.Text == "Stop")
            {
                PlayButton.Text = "Play";
                player.Stop();
            }
        }
        private void MixSongButton_Click(object sender, EventArgs e)
        {

        }
        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            player.Volume = ((float)VolumeBar.Value / 100);
            Volume.Text = VolumeBar.Value.ToString();
        }
        private void SongProgressBar_Scroll(object sender, EventArgs e)
        {
            player.CurrentTime = TimeSpan.FromSeconds(SongProgressBar.Value);
        }
        private void FileButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                player.SetNewFolder(folderBrowserDialog1.SelectedPath);
                SongsList.Items.Clear();
                SongsList.Items.AddRange(player.GetSongsList().
                    Select(x => x.Name).ToArray());
            }
        }
        private void SongsList_DoubleClicked(object sender, EventArgs e)
        {

        }
    }
       
}