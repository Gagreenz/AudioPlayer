namespace AudioPlayer
{
    internal class AudioManager : IAudioManager
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
            if(song != null)
                Songs.Add(song);
        }

        public Song GetNextSong()
        {
            Index++;
            return Songs[Index];
        }
        public Song GetPrevSong()
        {
            Index--;
            return Songs[Index];
        }

        public void RemoveSong(int _index)
        {
            
        }

        public void ShuffleSongs()
        {
            Songs.Shuffle();
            Index = 0;
        }
    }
}
