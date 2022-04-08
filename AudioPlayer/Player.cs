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
        public double CurrentTime
        {
            get
            {
                if (audioFile != null) return audioFile.CurrentTime.TotalSeconds;
                return -1;
            }
        }
        public double TotalTime
        {
            get
            {
                if (audioFile != null) return audioFile.TotalTime.Seconds + audioFile.TotalTime.Minutes * 60; ;
                return -1;
            }
        }

        private IAudioManager<Song> audioManager;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
       
        public Player()
        {
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackStopped;

            audioManager = new AudioManager(new List<Song>());
        }
        public void SetNextSong()
        {
            SetSong(audioManager.GetNextSong());
        }
        public void SetPrevSong()
        {
            SetSong(audioManager.GetPrevSong());
        }
        private void SetSong(Song song)
        {
            if (song == null) return;
            try
            {
                outputDevice.Stop();

                audioFile = new AudioFileReader(song.Path);

                outputDevice.Init(audioFile);
            }
            catch (Exception ex)
            {
                //refresh?
            }
        }
        public void FindSongsByPath(string SongsFolderPath)
        {
            audioManager.GetSongList().Clear();
            var directory = Directory.GetFiles(SongsFolderPath, "*.*").
                Where(x => x.EndsWith(".mp3") || x.EndsWith(".wav") || x.EndsWith(".mp4"));
            foreach (var path in directory)
            {
                var song = new Song(path.Split('.')[0], path);
                audioManager.AddSong(song);
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
