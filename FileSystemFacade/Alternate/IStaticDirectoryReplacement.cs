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
        /// Then IDirectory to use when the static file system is put into replacement mode.
        /// </summary>
        IDirectory Directory { get; }
    }

    /// <summary>
    /// This is a builder that helps setup the configuration of Directory objects to replace when the static file system is put into replacement mode. This object helps with testing.
    /// </summary>
    public interface IStaticDirectoryReplacementBuilder
    {
        /// <summary>
        /// Configures the IDirectoryInfoFactory to use when the static file system is put into replacement mode.
        /// </summary>
        /// <param name="factory">The IDirectoryInfoFactory to use when the static file system is put into replacement mode.</param>
        /// <returns>An instance of the builder with the IDirectoryInfo configured to be replaced when the static file system is put into replacement mode.</returns>
        IStaticDirectoryReplacementBuilder ReplaceDirectoryInfo(IDirectoryInfoFactory factory);
        
        /// <summary>
        /// Configures the IDirectory to use when the static file system is put into replacement mode.
        /// </summary>
        /// <param name="newDirectory">The IDirectory to use when the static file system is put into replacement mode.</param>
        /// <returns>An instance of the builder with the IDirectory configured to be replaced when the static file system is put into replacement mode.</returns>
        IStaticDirectoryReplacementBuilder ReplaceDirectory(IDirectory newDirectory);

        /// <summary>
        /// Configures the IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.
        /// </summary>
        /// <param name="factory">The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.</param>
        /// <returns>An instance of the builder with the IFilesSystemWatcherFactory configured to be replaced when the static file system is put into replacement mode.</returns>
        IStaticDirectoryReplacementBuilder ReplaceFileSystemWatcher(IFileSystemWatcherFactory factory);

        /// <summary>
        /// Builds the configuration object used when the static file system is put into replacement mode.
        /// </summary>
        /// <returns>The configuration object used when the static file system is put into replacement mode.</returns>
        IStaticDirectoryReplacement Build();
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

    internal class StaticDirectoryReplacementBuilder: IStaticDirectoryReplacementBuilder
    {
        public StaticDirectoryReplacementBuilder(IDirectoryInfoFactory directoryInfo, IDirectory directory, IFileSystemWatcherFactory fileSystemWatcher)
        {
            DirectoryInfo = directoryInfo;
            Directory = directory;
            FileSystemWatcher = fileSystemWatcher;
        }

        private IDirectoryInfoFactory DirectoryInfo { get; set; }
        private IDirectory Directory { get; set;  }
        private IFileSystemWatcherFactory FileSystemWatcher { get; set; }
        
        public IStaticDirectoryReplacementBuilder ReplaceDirectoryInfo(IDirectoryInfoFactory factory)
        {
            DirectoryInfo = factory;
            return this;
        }

        public IStaticDirectoryReplacementBuilder ReplaceDirectory(IDirectory newDirectory)
        {
            Directory = newDirectory;
            return this;
        }

        public IStaticDirectoryReplacementBuilder ReplaceFileSystemWatcher(IFileSystemWatcherFactory factory)
        {
            FileSystemWatcher = factory;
            return this;
        }

        public IStaticDirectoryReplacement Build()
        {
            return new StaticDirectoryReplacement(DirectoryInfo, Directory, FileSystemWatcher);
        }
    }
}