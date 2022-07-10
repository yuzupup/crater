using System.Collections;
using System.Collections.Generic;

namespace Crater.MusicLibraryPlugins.Traktor
{
    public class TraktorPlaylist : List<TraktorSong>, IPlaylist<TraktorSong>
    {
        public string Name { get; set; }

        public TraktorPlaylist(string name)
        {
            Name = name;
        }

        public void WriteChanges()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() => Name;
    }
}