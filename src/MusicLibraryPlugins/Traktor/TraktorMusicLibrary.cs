using System;
using System.Collections.Generic;

namespace Crater.MusicLibraryPlugins.Traktor
{
    public class TraktorMusicLibrary : IMusicLibrary
    {   
        public IReadOnlyList<IPlaylist> Playlists => _Playlists;
        public IReadOnlyList<ISong> Songs => _Songs;

        private List<TraktorPlaylist> _Playlists = new List<TraktorPlaylist>();
        private List<TraktorSong> _Songs = new List<TraktorSong>();

        public void WriteChanges()
        {
            throw new System.NotImplementedException();
        }

        public void AddPlaylist(IPlaylist playlist)
        {
            if(playlist is TraktorPlaylist traktorPlaylist)
            {
                _Playlists.Add(traktorPlaylist);
                return;
            }

            throw new ArgumentException($"Traktor libraries do not currently support adding songs of type {playlist.GetType()}");
        }

        public void AddSong(ISong song)
        {
            if(song is TraktorSong traktorSong)
            {
                _Songs.Add(traktorSong);
                return;
            }

            throw new ArgumentException($"Traktor libraries do not currently support adding songs of type {song.GetType()}");
        }
    }
}