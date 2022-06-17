using System;
using FileSystemFacade.Primitives;

namespace FileSystemFacade
{
    public interface IAtomicFileSystem
    {
        IAtomicReplacementBuilder Replace { get; }
        
        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize, System.IO.FileOptions options);

        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize);

        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);

        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize, bool useAsync);

        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access);

        IAtomicActions<IDriveInfo> DriveInfo(string path);

        IAtomicActions<IDirectoryInfo> DirectoryInfo(string path);

        IAtomicActions<IFileInfo> FileInfo(string fileName);
        
        IDrives Drives { get; }
        
        IDirectory Directory { get; }
        
        IFile File { get; }
    }

    public class FileSystemAtom : IAtomicFileSystem
    {
        private IFileStreamBuilder fileStreamBuilder;
        private IFilesSystemWatcherBuilder filesSystemWatcherBuilder;
        private IFileInfoBuilder fileInfoBuilder;
        private IDirectoryInfoBuilder directoryInfoBuilder;
        private IFile file;
        private IFilesSystemWatcherBuilder systemWatcherBuilder;
        private IDirectory directory;
        private IDriveInfoBuilder driveInfoBuilder;
        private IDrives drives;

        public FileSystemAtom() : this(new FileStreamBuilder(), new FilesSystemWatcherBuilder(), new DriveInfoBuilder(), new DirectoryInfoBuilder(), new FileInfoBuilder(), new Drives(), new Directory(), new File())
        {
        }

        private FileSystemAtom(IFileStreamBuilder fileStreamBuilder,
            IFilesSystemWatcherBuilder systemWatcherBuilder,
            IDriveInfoBuilder driveInfoBuilder,
            IDirectoryInfoBuilder directoryInfoBuilder, IFileInfoBuilder fileInfoBuilder,
            IDrives drives, IDirectory directory,
            IFile file)
        {
            this.fileStreamBuilder = fileStreamBuilder;
            this.systemWatcherBuilder = systemWatcherBuilder;
            this.fileInfoBuilder = fileInfoBuilder;
            this.directoryInfoBuilder = directoryInfoBuilder;
            this.file = file;
            this.directory = directory;
            this.driveInfoBuilder = driveInfoBuilder;
            this.drives = drives;
        }

        public IAtomicReplacementBuilder Replace { get; } = new AtomicAtomicReplacementBuilder();

        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize,
            System.IO.FileOptions options)
        {
            return new AtomicActions<IFileStream>(() =>
                fileStreamBuilder.GetFileStream(path, mode, access, share, bufferSize, options));
        }

        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize)
        {
            return new AtomicActions<IFileStream>(() =>
                fileStreamBuilder.GetFileStream(path, mode, access, share, bufferSize));
        }

        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share)
        {
            return new AtomicActions<IFileStream>(() => fileStreamBuilder.GetFileStream(path, mode, access, share));
        }

        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize, bool useAsync)
        {
            return new AtomicActions<IFileStream>(() =>
                fileStreamBuilder.GetFileStream(path, mode, access, share, bufferSize, useAsync));
        }

        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access)
        {
            return new AtomicActions<IFileStream>(() => fileStreamBuilder.GetFileStream(path, mode, access));
        }

        public IAtomicActions<IDriveInfo> DriveInfo(string path)
        {
            return new AtomicPassThrough<IDriveInfo>(() => driveInfoBuilder.DriveInfo(path));
        }

        public IAtomicActions<IFileInfo> FileInfo(string fileName)
        {
            return new AtomicPassThrough<IFileInfo>(() => fileInfoBuilder.GetFileInfo(fileName));
        }

        public IDrives Drives => drives;
        public IDirectory Directory => directory;

        public IAtomicActions<IDirectoryInfo> DirectoryInfo(string path)
        {
            return new AtomicPassThrough<IDirectoryInfo>(() => directoryInfoBuilder.GetDirectoryInfo(path));
        }

        public IFile File => file;

        internal IDisposable ReplaceInternals(IFileStreamBuilder newFileStreamBuilder,
            IFilesSystemWatcherBuilder newSystemWatcherBuilder,
            IDriveInfoBuilder newDriveInfoBuilder,
            IDirectoryInfoBuilder newDirectoryInfoBuilder, IFileInfoBuilder newFileInfoBuilder,
            IDrives newDrives, IDirectory newDirectory, IFile newFile)
        {
            var holdFileStream = fileStreamBuilder;
            var holdWatcher = systemWatcherBuilder;
            
            var holdDriveInfo = driveInfoBuilder;
            var holdDirectoryInfo = directoryInfoBuilder;
            var holdFileInfo = fileInfoBuilder;
            
            var holdDirectory = directory;
            var holdDrives = drives;
            var holdFile = file;
            
            fileStreamBuilder = newFileStreamBuilder;
            systemWatcherBuilder = newSystemWatcherBuilder;
            
            driveInfoBuilder = newDriveInfoBuilder;
            fileInfoBuilder = newFileInfoBuilder;
            directoryInfoBuilder = newDirectoryInfoBuilder;
            
            drives = newDrives;
            directory = newDirectory;
            file = newFile;

            return new DisposableAction(() =>
            {
                fileStreamBuilder = holdFileStream;
                systemWatcherBuilder = holdWatcher;
                
                driveInfoBuilder = holdDriveInfo;
                directoryInfoBuilder = holdDirectoryInfo;
                fileInfoBuilder = holdFileInfo;

                drives = holdDrives;
                directory = holdDirectory;
                file = holdFile;
            });
        }
    }
}