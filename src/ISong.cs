namespace Crater
{
    /// <summary>
    /// Represents a song in some collection
    /// </summary>
    public interface ISong
    {
        string Title { get; set; }
        string Artist { get; set; }
        string SingleLineDisplayName { get; }
    }
}