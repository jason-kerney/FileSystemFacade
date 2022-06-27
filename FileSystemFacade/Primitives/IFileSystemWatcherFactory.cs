namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// A factory to build IFileSystemWatcher objects
    /// </summary>
    public interface IFileSystemWatcherFactory
    {
        /// <summary>
        /// Creates a new instance of the FileSystemWatcher class.
        /// </summary>
        /// <returns>A  new instance of the FileSystemWatcher class.</returns>
        IFileSystemWatcher GetFileSystemWatcher();
        /// <summary>
        /// Creates a new instance of the FileSystemWatcher class, given the specified directory to monitor.
        /// </summary>
        /// <param name="path">The directory to monitor, in standard or Universal Naming Convention (UNC) notation.</param>
        /// <returns>A new instance of the FileSystemWatcher class, given the specified directory to monitor.</returns>
        IFileSystemWatcher GetFileSystemWatcher(string path);
        /// <summary>
        /// Creates a new instance of the FileSystemWatcher class, given the specified directory and type of files to monitor.
        /// </summary>
        /// <param name="path">The directory to monitor, in standard or Universal Naming Convention (UNC) notation.</param>
        /// <param name="filter">The type of files to watch. For example, "*.txt" watches for changes to all text files.</param>
        /// <returns>A new instance of the FileSystemWatcher class, given the specified directory and type of files to monitor.</returns>
        IFileSystemWatcher GetFileSystemWatcher(string path, string filter);
    }

    internal class FileSystemWatcherFactory : IFileSystemWatcherFactory
    {
        /// <summary>
        /// Creates a new instance of the FileSystemWatcher class.
        /// </summary>
        /// <returns>A  new instance of the FileSystemWatcher class.</returns>
        public IFileSystemWatcher GetFileSystemWatcher() => new FileSystemWatcher();

        /// <summary>
        /// Creates a new instance of the FileSystemWatcher class, given the specified directory to monitor.
        /// </summary>
        /// <param name="path">he directory to monitor, in standard or Universal Naming Convention (UNC) notation.</param>
        /// <returns>A new instance of the FileSystemWatcher class, given the specified directory to monitor.</returns>
        public IFileSystemWatcher GetFileSystemWatcher(string path) => new FileSystemWatcher(path);

        /// <summary>
        /// Creates a new instance of the FileSystemWatcher class, given the specified directory and type of files to monitor.
        /// </summary>
        /// <param name="path">The directory to monitor, in standard or Universal Naming Convention (UNC) notation.</param>
        /// <param name="filter">The type of files to watch. For example, "*.txt" watches for changes to all text files.</param>
        /// <returns>A  new instance of the FileSystemWatcher class, given the specified directory and type of files to monitor.</returns>
        public IFileSystemWatcher GetFileSystemWatcher(string path, string filter) => new FileSystemWatcher(path, filter);
    }
}