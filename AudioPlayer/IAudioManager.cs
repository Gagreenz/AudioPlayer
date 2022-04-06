namespace AudioPlayer
{
    internal interface IAudioManager<T>
        where T : class
    {
        public void AddSong(T song);
        public void RemoveSong(int index);
        public void ShuffleSongs();
        public T GetSongByIndex(int index);
        public T GetNextSong();
        public T GetPrevSong();
        public List<T> GetSongList();
    }
}