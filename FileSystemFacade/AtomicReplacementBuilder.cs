using System;
using FileSystemFacade.Primitives;

namespace FileSystemFacade
{
    public interface IAtomicReplacementBuilder
    {
        IAtomicReplacementBuilder FileStream(IFileStreamBuilder builder);
        IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherBuilder builder);
        IAtomicReplacementBuilder FileInfo(IFileInfoBuilder builder);
        IAtomicReplacementBuilder DirectoryInfo(IDirectoryInfoBuilder builder);
        IAtomicReplacementBuilder DriveInfo(IDriveInfoBuilder builder);
        IAtomicReplacementBuilder Drives(IDrives newDrives);
        IAtomicReplacementBuilder Directory(IDirectory newDirectory);
        IAtomicReplacementBuilder File(IFile newFile);
        void Use(Action<IAtomicFileSystem> doer);
    }

    internal class AtomicAtomicReplacementBuilder : IAtomicReplacementBuilder
    {
        private IFileStreamBuilder fileStreamBuilder = new FileStreamBuilder();
        private IFilesSystemWatcherBuilder filesSystemWatcherBuilder = new FilesSystemWatcherBuilder();
        private IFileInfoBuilder fileInfoBuilder = new FileInfoBuilder();
        private IDirectoryInfoBuilder directoryInfoBuilder = new DirectoryInfoBuilder();
        private IDriveInfoBuilder driveInfoBuilder = new DriveInfoBuilder();
        private IDrives drives = new Drives();
        private IDirectory directory = new Directory();
        private IFile file = new File();
        
        public IAtomicReplacementBuilder FileStream(IFileStreamBuilder builder)
        {
            fileStreamBuilder = builder;
            return this;
        }

        public IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherBuilder builder)
        {
            filesSystemWatcherBuilder = builder;
            return this;
        }

        public IAtomicReplacementBuilder FileInfo(IFileInfoBuilder builder)
        {
            fileInfoBuilder = builder;
            return this;
        }

        public IAtomicReplacementBuilder DirectoryInfo(IDirectoryInfoBuilder builder)
        {
            directoryInfoBuilder = builder;
            return this;
        }

        public IAtomicReplacementBuilder DriveInfo(IDriveInfoBuilder builder)
        {
            driveInfoBuilder = builder;
            return this;
        }

        public IAtomicReplacementBuilder Drives(IDrives newDrives)
        {
            drives = newDrives;
            return this;
        }

        public IAtomicReplacementBuilder File(IFile newFile)
        {
            file = newFile;
            return this;
        }

        public IAtomicReplacementBuilder Directory(IDirectory newDirectory)
        {
            directory = newDirectory;
            return this;
        }

        public void Use(Action<IAtomicFileSystem> doer)
        {
            var atomic = new FileSystemAtom();
            using (atomic.ReplaceInternals(fileStreamBuilder, filesSystemWatcherBuilder, driveInfoBuilder, directoryInfoBuilder, fileInfoBuilder, drives, directory, file))
            {
                doer(atomic);
            }
        }
    }
}