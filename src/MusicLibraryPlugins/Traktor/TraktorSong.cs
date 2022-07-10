namespace Crater.MusicLibraryPlugins.Traktor
{
    public class TraktorSong : ISong
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public string SingleLineDisplayName => $"{Artist} - {Title}";

        public TraktorSong(string title, string artist) 
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString() => $"{Artist} - {Title}";
    }
}