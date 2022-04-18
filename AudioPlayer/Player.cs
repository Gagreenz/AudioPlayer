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
        public event EventHandler<EventArgs> SongChanged;
        public TimeSpan CurrentTime
        {
            get
            {
                if (_audioFile != null) return _audioFile.CurrentTime;
                return new TimeSpan(0, 0, 0);
            }
            set
            {
                _audioFile.CurrentTime = value;
            }
        }
        public TimeSpan TotalTime
        {
            get
            {
                if (_audioFile != null) return _audioFile.TotalTime;
                return new TimeSpan(0, 0, 0);
            }
        }
        public string CurrentSongName
        {
            get
            {
                return _audioFile.FileName;
            }
        }
        public float Volume
        {
            get { return _outputDevice.Volume; }
            set { _outputDevice.Volume = value; }
        }
        private IAudioManager<Song> _audioManager;
        private AudioFileReader _audioFile;
        private WaveOutEvent _outputDevice;
        private string _songsFolder = @"D:\";
        public Player()
        {
            _outputDevice = new WaveOutEvent();
            _outputDevice.Volume = 1f;
            _outputDevice.PlaybackStopped += OnPlaybackStopped;

            _audioManager = new AudioManager(new List<Song>());
            FindSongsByPath();
        }
        public void Init()
        {
            SetSong(_audioManager.GetNextSong());
        }
        public void Play()
        {
            _outputDevice.Play();
        }
        public void Stop()
        {
            _outputDevice.Pause();
        }
        public void SetNextSong()
        {
            SetSong(_audioManager.GetNextSong());
        }
        public void SetPrevSong()
        {
            SetSong(_audioManager.GetPrevSong());
        }
        public void SetNewFolder(string path)
        {
            _songsFolder = path;
            FindSongsByPath();
        }
        public List<Song> GetSongsList()
        {
            return _audioManager.GetSongList();
        }
        public void SetSongByIndex(int index)
        {
            SetSong(_audioManager.GetSongByIndex(index));
        }
        private void FindSongsByPath()
        {
            _audioManager.GetSongList().Clear();
            var directory = Directory.GetFiles(_songsFolder, "*.*").
                Where(x => x.EndsWith(".mp3") || x.EndsWith(".wav") || x.EndsWith(".mp4"));
            foreach (var path in directory)
            {
                var song = new Song(path.Split('.')[0], path);
                _audioManager.AddSong(song);
            }
        }
        private void SetSong(Song song)
        {
            if (song == null) return;
            try
            {
                var state = _outputDevice.PlaybackState;
                _outputDevice.Stop();

                _audioFile = new AudioFileReader(song.Path);

                _outputDevice.Init(_audioFile);
               
                //TODO Fix Auto-start
                if (state == PlaybackState.Playing) _outputDevice.Play();
            }
            catch (Exception ex)
            {
                FindSongsByPath();
                //refresh?
            }
            SongChanged?.Invoke(this, EventArgs.Empty);
        }
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            try
            {
                if (_audioFile != null)
                {
                    if (CurrentTime >= TotalTime)
                    {
                        SetSong(_audioManager.GetNextSong());
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
            if (_audioFile != null)
            {
                _audioFile.Dispose();
            }
            if (_outputDevice != null)
            {
                _outputDevice.Dispose();
            }
        }
    }
}
