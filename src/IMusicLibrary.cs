using System.Collections.Generic;

namespace Crater
{
    public interface IMusicLibrary
    {
        IReadOnlyList<IPlaylist> Playlists { get; }
        IReadOnlyList<ISong> Songs { get; }

        void AddPlaylist(IPlaylist playlist);
        void AddSong(ISong song);

        /// <summary>
        /// Saves the pending changes to the music collection to disk 
        /// </summary>
        void WriteChanges();
    } 
}