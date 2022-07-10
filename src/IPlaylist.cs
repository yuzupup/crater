using System.Collections.Generic;

namespace Crater
{
    /// <summary>
    /// Represents an ordered collection of songs 
    /// </summary>
    /// <typeparam name="TSong"></typeparam>
    public interface IPlaylist
    {
        /// <summary>
        /// The name of this playlist 
        /// </summary>
        /// <value></value>
        string Name { get; set; }

        /// <summary>
        /// Saves the pending changes to this playlist to disk 
        /// </summary>
        void WriteChanges();
    }

    /// <summary>
    /// Represents an ordered collection of songs 
    /// </summary>
    /// <typeparam name="TSong"></typeparam>
    public interface IPlaylist<TSong> : IPlaylist, IList<TSong> where TSong : ISong
    {
    }
}