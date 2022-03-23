namespace AudioPlayer
{
    internal interface ISongManager
    {
        public void AddSong(Song _song);
        public void RemoveSong(int _index);
        public void ShuffleSongs();
        public Song GetNextSong();
        public Song GetPrevSong();
    }
}