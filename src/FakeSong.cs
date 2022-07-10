namespace Crater
{
    public class FakeSong : ISong
    {
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
        public string SingleLineDisplayName => $"{Artist} - {Title}";
        public override string ToString() => $"{Artist} - {Title}";
    }
}