using System;
using System.Threading.Tasks;
using System.Xml;

namespace Crater.MusicLibraryPlugins.Traktor
{
    public class TraktorCollectionParser : IMusicLibrarySource
    {
        public string PathToFile { get; init; }

        private XmlDocument _Document = new XmlDocument();
        private TraktorMusicLibrary _Library = new TraktorMusicLibrary();
        private XmlNode _NMLNode;

        public TraktorCollectionParser(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public async Task<IMusicLibrary> ImportLibraryAsync()
        {
            _Document.Load(PathToFile);
            _NMLNode = _Document.SelectSingleNode("NML") ?? throw new FormatException("File provided did not contain an NML node at the root level. Are you sure this is a Traktor library file?");
            ParseSongs();
            ParsePlaylists();
            return _Library;
        }

        private void ParseSongs()
        {
            XmlNode? collectionNode = _NMLNode.SelectSingleNode("COLLECTION");
            if(collectionNode == null)
            {
                throw new FormatException("File provided did not contain a COLLECTION node at the root level. Are you sure this is a Traktor library file?");
            }

            XmlNodeList? entries = collectionNode.SelectNodes("ENTRY");
            if(entries == null)
            {
                throw new FormatException("Collection contained no entries. Did Traktor export an empty library?");
            }

            foreach(XmlNode entry in entries)
            {
                XmlAttributeCollection attributes = entry.Attributes ?? throw new FormatException($"Track entry had no attributes! { entry.InnerXml }");  
                XmlAttribute titleAttribute = entry.Attributes["TITLE"] ?? throw new FormatException($"Collection entry was missing a TITLE attribute. {entry.InnerXml}");
                XmlAttribute? artistAttribute = entry.Attributes["ARTIST"];

                string title = titleAttribute.Value;
                string artist = artistAttribute?.Value ?? "";
                TraktorSong song = new TraktorSong(title, artist);
                _Library.AddSong(song);
            }
        }

        private void ParsePlaylists()
        {
            XmlNode playlistsNode = _NMLNode.SelectSingleNode("PLAYLISTS") ?? throw new FormatException("Provided collection had no PLAYLISTS node!");

            XmlNodeList? playlists = playlistsNode.SelectNodes("//NODE[@TYPE = \"PLAYLIST\"]") ?? throw new FormatException("Provided collection had no playlists?");
            foreach(XmlNode playlist in playlists)
            {
                XmlAttributeCollection attributes = playlist.Attributes ?? throw new FormatException($"Track entry had no attributes! { playlist.InnerXml }");  
                XmlAttribute nameAttribute = playlist.Attributes["NAME"] ?? throw new FormatException($"Collection entry was missing a TITLE attribute. {playlist.InnerXml}");

                string name = nameAttribute?.Value ?? "";

                TraktorPlaylist traktorPlaylist = new TraktorPlaylist(name);
                _Library.AddPlaylist(traktorPlaylist);
            }
        }
    }
}
