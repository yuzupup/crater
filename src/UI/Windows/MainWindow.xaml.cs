using System.Windows;
using Crater.UI.Controls;
using Crater.MusicLibraryPlugins.Traktor;
using System.Threading.Tasks;

namespace Crater.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FilteredList Playlists { get; private set; }
        public FilteredList Songs { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            TraktorCollectionParser parser = new TraktorCollectionParser(@"H:\MyDocs\Programming Projects\Crater\ExampleTraktorCollection.nml");
            Task<IMusicLibrary> task = parser.ImportLibraryAsync();
            IMusicLibrary library = task.Result;
            
            Playlists = (FilteredList) FindName("PlaylistsList");
            Songs = (FilteredList) FindName("SongsList");

            foreach(IPlaylist playlist in library.Playlists)
            {
                Playlists.Add(playlist);
            }

            foreach(ISong song in library.Songs)
            {
                Songs.Add(song);
            } 
        }
    }
}
