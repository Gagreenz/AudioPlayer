namespace AudioPlayer
{
    internal class AudioManager : IAudioManager<Song>
    {
        public List<Song> Songs;
        private int _index;
        public int Index
        {
            get
            {
                if (_index >= Songs.Count) _index = 0;
                if (_index < 0) _index = Songs.Count - 1;
                return _index;
            }
            private set
            {
                _index = value;
            }
        }

        public AudioManager(List<Song> songs)
        {
            Songs = songs;
            Index = 0;
        }
        public void AddSong(Song song)
        {
            if (song != null)
                Songs.Add(song);
        }

        public Song GetNextSong()
        {
            if(Songs.Count == 0) return null;
            Index++;
            return Songs[Index];
        }
        public Song GetPrevSong()
        {
            if (Songs.Count == 0) return null;
            Index--;
            return Songs[Index];
        }

        public void RemoveSong(int index)
        {
            throw new NotImplementedException();
        }

        public void ShuffleSongs()
        {
            throw new NotImplementedException();
        }

        public List<Song> GetSongList()
        {
            return Songs;
        }

        public Song GetSongByIndex(int index)
        {
            Index = index;
            return Songs[Index];
        }
    }
}
