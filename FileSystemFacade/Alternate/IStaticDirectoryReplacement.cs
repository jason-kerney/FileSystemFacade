using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// A class that configures what directory objects to use when the static file system is put into replacement mode. This object makes testing easier.
    /// </summary>
    public interface IStaticDirectoryReplacement
    {
        /// <summary>
        /// The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.
        /// </summary>
        IFileSystemWatcherFactory FileSystemWatcher { get; }
        /// <summary>
        /// The IDirectoryInfoFactory to use when the static file system is put into replacement mode.
        /// </summary>
        IDirectoryInfoFactory DirectorInfo { get; }
        /// <summary>
        /// The IDirectory to use when the static file system is put into replacement mode.
        /// </summary>
        IDirectory Directory { get; }
    }

    internal class StaticDirectoryReplacement: IStaticDirectoryReplacement
    {
        public StaticDirectoryReplacement(IDirectoryInfoFactory directorInfo, IDirectory directory, IFileSystemWatcherFactory fileSystemWatcher)
        {
            DirectorInfo = directorInfo;
            Directory = directory;
            FileSystemWatcher = fileSystemWatcher;
        }

        public IFileSystemWatcherFactory FileSystemWatcher { get; }
        public IDirectoryInfoFactory DirectorInfo { get; }
        public IDirectory Directory { get; }
    }
}