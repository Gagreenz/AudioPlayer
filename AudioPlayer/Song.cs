namespace AudioPlayer
{
    internal class Song
    {
        public string Name { get; set; }
        public string Path { get; set; }
        /// <summary>
        ///  In future
        /// </summary>
        public Image SongImage { get; set; }
        public Song(string name,string path)
        {
            Name = name;
            Path = path;
        }
    }
}