namespace AudioPlayer
{
    internal interface IAudioManager
    {
        public void AddSong(Song song);
        public void RemoveSong(int index);
        public void ShuffleSongs();
        public Song GetNextSong();
        public Song GetPrevSong();
    }
}