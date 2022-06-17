using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    public interface IStaticDirectoryReplacement
    {
        IFilesSystemWatcherBuilder FileSystemWatcher { get; }
        IDirectoryInfoBuilder DirectorInfo { get; }
        IDirectory Directory { get; }
    }

    public interface IStaticDirectoryReplacementBuilder
    {
        IStaticDirectoryReplacementBuilder ReplaceDirectoryInfo(IDirectoryInfoBuilder builder);
        IStaticDirectoryReplacementBuilder ReplaceDirectory(IDirectory newDirectory);
        IStaticDirectoryReplacementBuilder ReplaceFileSystemWatcher(IFilesSystemWatcherBuilder builder);

        IStaticDirectoryReplacement Build();
    }

    internal class StaticDirectoryReplacement: IStaticDirectoryReplacement
    {
        public StaticDirectoryReplacement(IDirectoryInfoBuilder directorInfo, IDirectory directory, IFilesSystemWatcherBuilder fileSystemWatcher)
        {
            DirectorInfo = directorInfo;
            Directory = directory;
            FileSystemWatcher = fileSystemWatcher;
        }

        public IFilesSystemWatcherBuilder FileSystemWatcher { get; }
        public IDirectoryInfoBuilder DirectorInfo { get; }
        public IDirectory Directory { get; }
    }

    internal class StaticDirectoryReplacementBuilder: IStaticDirectoryReplacementBuilder
    {
        public StaticDirectoryReplacementBuilder(IDirectoryInfoBuilder directoryInfo, IDirectory directory, IFilesSystemWatcherBuilder filesSystemWatcher)
        {
            DirectoryInfo = directoryInfo;
            Directory = directory;
            FilesSystemWatcher = filesSystemWatcher;
        }

        private IDirectoryInfoBuilder DirectoryInfo { get; set; }
        private IDirectory Directory { get; set;  }
        private IFilesSystemWatcherBuilder FilesSystemWatcher { get; set; }
        
        public IStaticDirectoryReplacementBuilder ReplaceDirectoryInfo(IDirectoryInfoBuilder builder)
        {
            DirectoryInfo = builder;
            return this;
        }

        public IStaticDirectoryReplacementBuilder ReplaceDirectory(IDirectory newDirectory)
        {
            Directory = newDirectory;
            return this;
        }

        public IStaticDirectoryReplacementBuilder ReplaceFileSystemWatcher(IFilesSystemWatcherBuilder builder)
        {
            FilesSystemWatcher = builder;
            return this;
        }

        public IStaticDirectoryReplacement Build()
        {
            return new StaticDirectoryReplacement(DirectoryInfo, Directory, FilesSystemWatcher);
        }
    }
}