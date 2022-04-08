using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    internal class Player : IDisposable
    {
        public TimeSpan CurrentTime
        {
            get
            {
                if (audioFile != null) return audioFile.CurrentTime;
                return new TimeSpan(0,0,0);
            }
            set
            {
                audioFile.CurrentTime = value;
            }
        }
        public TimeSpan TotalTime
        {
            get
            {
                if (audioFile != null) return audioFile.TotalTime;
                return new TimeSpan(0, 0, 0);
            }
        }
        public float Volume
        {
            get { return outputDevice.Volume; }
            set { outputDevice.Volume = value; }
        }
        private IAudioManager<Song> audioManager;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        private string SongsFolder = @"D:\";
        public Player()
        {
            outputDevice = new WaveOutEvent();
            outputDevice.Volume = 1f;
            outputDevice.PlaybackStopped += OnPlaybackStopped;

            audioManager = new AudioManager(new List<Song>());
            FindSongsByPath();
            SetSong(audioManager.GetNextSong());
        }
        public void Play()
        {
            outputDevice.Play();
        }
        public void Stop()
        {
            outputDevice.Pause();
        }
        public void SetNextSong()
        {
            SetSong(audioManager.GetNextSong());
        }
        public void SetPrevSong()
        {
            SetSong(audioManager.GetPrevSong());
        }
        public void SetNewFolder(string path)
        {
            SongsFolder = path;
            FindSongsByPath();
        }
        public List<Song> GetSongsList()
        {
            return audioManager.GetSongList();
        }
        private void FindSongsByPath()
        {
            audioManager.GetSongList().Clear();
            var directory = Directory.GetFiles(SongsFolder, "*.*").
                Where(x => x.EndsWith(".mp3") || x.EndsWith(".wav") || x.EndsWith(".mp4"));
            foreach (var path in directory)
            {
                var song = new Song(path.Split('.')[0], path);
                audioManager.AddSong(song);
            }
        }
        private void SetSong(Song song)
        {
            if (song == null) return;
            try
            {
                var state = outputDevice.PlaybackState;
                outputDevice.Stop();

                audioFile = new AudioFileReader(song.Path);

                outputDevice.Init(audioFile);
                //TODO Fix Auto-start
                if (state == PlaybackState.Playing) outputDevice.Play();
            }
            catch (Exception ex)
            {
                FindSongsByPath();
                //refresh?
            }
        }
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            try
            {
                if (audioFile != null)
                {
                    if (CurrentTime >= TotalTime)
                    {
                        SetSong(audioManager.GetNextSong());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Dispose()
        {
            if (audioFile != null)
            {
                audioFile.Dispose();
            }
            if (outputDevice != null)
            {
                outputDevice.Dispose();
            }
        }
    }
}
