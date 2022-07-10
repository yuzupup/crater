using System.Threading.Tasks;

namespace Crater
{
    /// <summary>
    /// Represents something capable of loading a music library into this application 
    /// </summary>
    public interface IMusicLibrarySource
    {
        /// <summary>
        /// Imports the library this source is configured to import 
        /// </summary>
        /// <returns>A music library</returns>
        Task<IMusicLibrary> ImportLibraryAsync();
    }
}