namespace AudioPlayer
{
    internal class SongManager : ISongManager
    {
        public List<Song> Songs;
        private int index
        {
            get 
            {
                if (index >= Songs.Count) index = 0;
                if (index < 0) index = Songs.Count - 1;
                return index;
            }
            set { index = value; }
        }
        public SongManager(List<Song> songs)
        {
            Songs = songs;
            index = 0;
        }
        public void AddSong(Song _song)
        {
            if(_song != null)
                Songs.Add(_song);
        }

        public Song GetNextSong()
        {
            return Songs[index++];
        }
        public Song GetPrevSong()
        {
            return Songs[index--];
        }

        public void RemoveSong(int _index)
        {
            
        }

        public void ShuffleSongs()
        {
            Songs.Shuffle();
            index = 0;
        }
    }
}
