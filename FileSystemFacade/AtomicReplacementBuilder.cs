using System;
using FileSystemFacade.Primitives;

namespace FileSystemFacade
{
    /// <summary>
    /// A Builder for temporarily replacing the file system. This class is intended to make testing easier.
    /// </summary>
    public interface IAtomicReplacementBuilder
    {
        /// <summary>
        /// Allows for the factory that builds IFileStream objects to be temporarily replaced.
        /// </summary>
        /// <param name="factory">The IFileStream Factory to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with the IFileStreamFactory configured to be replaced.</returns>
        IAtomicReplacementBuilder FileStream(IFileStreamFactory factory);
        /// <summary>
        /// Allows for the factory that builds IFileSystemWatcher objects to be replaced.
        /// </summary>
        /// <param name="factory">The IFileSystemWatcher Factory to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with the IFileWatcherFactory configured to be replaced.</returns>
        IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherFactory factory);
        /// <summary>
        /// Allows for the factory that builds IFileInfo objects to be temporarily replaced.
        /// </summary>
        /// <param name="factory">The IFileInfo Factory to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with IFileInfoFactory configured to be replaced.</returns>
        IAtomicReplacementBuilder FileInfo(IFileInfoFactory factory);
        /// <summary>
        /// Allows for the factory that builds IDirectoryInfo objects to be replaced.
        /// </summary>
        /// <param name="factory">The IDirectoryInfo Factory to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with IDirectoryInfoFactory configured to be replaced.</returns>
        IAtomicReplacementBuilder DirectoryInfo(IDirectoryInfoFactory factory);
        /// <summary>
        /// Allows for the factory that builds IDriveInfo objects to be replaced.
        /// </summary>
        /// <param name="factory">The IDriveInfo Factory to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with IDiveInfoFactory configured to be replaced.</returns>
        IAtomicReplacementBuilder DriveInfo(IDriveInfoFactory factory);
        /// <summary>
        /// Configures IDrives to be replaced.
        /// </summary>
        /// <param name="newDrives">The IDrives to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with IDrives configured to be replaced.</returns>
        IAtomicReplacementBuilder Drives(IDrives newDrives);
        /// <summary>
        /// Configures IDirectory to be replaced.
        /// </summary>
        /// <param name="newDirectory">The IDirectory to use when 'Use' is called.</param>
        /// <returns>The current instance of the builder with IDirectory configured to be replaced.</returns>
        IAtomicReplacementBuilder Directory(IDirectory newDirectory);
        /// <summary>
        /// Configures IFile to be replaced.
        /// </summary>
        /// <param name="newFile">The IFile to use when 'Use' is called.</param>
        /// <returns></returns>
        IAtomicReplacementBuilder File(IFile newFile);
        /// <summary>
        /// Takes an action, and calls it with a specially configured instance of IAtomicFileSystem where any item configured to be replaced is replaced. This allows testing of the use of the file system. NOTE: When 'Use' exits, the IAtomicFileSystem reverts to using the real file system. If captured during this time, when use exits, it will have no lasting effect of replacing the underlying file system.
        /// </summary>
        /// <param name="doer">An action to call with the replaced file system.</param>
        void Use(Action<IAtomicFileSystem> doer);
    }

    internal class AtomicAtomicReplacementBuilder : IAtomicReplacementBuilder
    {
        private IFileStreamFactory fileStreamFactory = new FileStreamFactory();
        private IFilesSystemWatcherFactory filesSystemWatcherFactory = new FilesSystemWatcherFactory();
        private IFileInfoFactory fileInfoFactory = new FileInfoFactory();
        private IDirectoryInfoFactory directoryInfoFactory = new DirectoryInfoFactory();
        private IDriveInfoFactory driveInfoFactory = new DriveInfoFactory();
        private IDrives drives = new Drives();
        private IDirectory directory = new Directory();
        private IFile file = new File();
        
        public IAtomicReplacementBuilder FileStream(IFileStreamFactory factory)
        {
            fileStreamFactory = factory;
            return this;
        }

        public IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherFactory factory)
        {
            filesSystemWatcherFactory = factory;
            return this;
        }

        public IAtomicReplacementBuilder FileInfo(IFileInfoFactory factory)
        {
            fileInfoFactory = factory;
            return this;
        }

        public IAtomicReplacementBuilder DirectoryInfo(IDirectoryInfoFactory factory)
        {
            directoryInfoFactory = factory;
            return this;
        }

        public IAtomicReplacementBuilder DriveInfo(IDriveInfoFactory factory)
        {
            driveInfoFactory = factory;
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
            using (atomic.ReplaceInternals(fileStreamFactory, filesSystemWatcherFactory, driveInfoFactory, directoryInfoFactory, fileInfoFactory, drives, directory, file))
            {
                doer(atomic);
            }
        }
    }
}