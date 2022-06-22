using System;
using FileSystemFacade.Primitives;

namespace FileSystemFacade
{
    /// <summary>
    /// Represents a way to interact with the file system through atomic actions.
    /// </summary>
    public interface IAtomicFileSystem
    {
        /// <summary>
        /// Replace builds an IAtomicReplacementBuilder to allow for the testing of code that takes an Atomic File System.
        /// </summary>
        IAtomicReplacementBuilder Replace { get; }
        
        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies additional file options.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize, System.IO.FileOptions options);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <param name="useAsync">Specifies whether to use asynchronous I/O or synchronous I/O. However, note that the underlying operating system might not support asynchronous I/O, so when specifying true, the handle might be opened synchronously depending on the platform. When opened asynchronously, the BeginRead(Byte[], Int32, Int32, AsyncCallback, Object) and BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object) methods perform better on large reads or writes, but they might be much slower for small reads or writes. If the application is designed to take advantage of asynchronous I/O, set the useAsync parameter to true. Using asynchronous I/O correctly can speed up applications by as much as a factor of 10, but using it without redesigning the application for asynchronous I/O can decrease performance by as much as a factor of 10.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize, bool useAsync);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IDriveInfo specified by the drive name.
        /// </summary>
        /// <param name="driveName">A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.</param>
        /// <returns>An atomic action allowing the interaction with a IDriveInfo specified by the drive name.</returns>
        IAtomicActions<IDriveInfo> DriveInfo(string driveName);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IDirectoryInfo specified by the path.
        /// </summary>
        /// <param name="path">A string specifying the path on which to create the IDirectoryInfo.</param>
        /// <returns>An atomic action allowing the interaction with a IDirectoryInfo specified by the path.</returns>
        IAtomicActions<IDirectoryInfo> DirectoryInfo(string path);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileInfo specified by the file name.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.</param>
        /// <returns>An atomic action allowing the interaction with a IFileInfo specified by the file name.</returns>
        IAtomicActions<IFileInfo> FileInfo(string fileName);
        
        /// <summary>
        /// Returns an atomic action allowing the interaction with a IDrives.
        /// </summary>
        IAtomicActions<IDrives> Drives { get; }

        /// <summary>
        /// Returns an atomic action allowing the interaction with IDirectory.
        /// </summary>
        IAtomicActions<IDirectory> Directory { get; }

        /// <summary>
        /// Returns an atomic action allowing the interaction with IFile.
        /// </summary>
        IAtomicActions<IFile> File { get; }
    }

    /// <summary>
    /// Represents a File System with factories to interact with objects, or direct access objects that replace the .Net static types.
    /// </summary>
    public class FileSystemAtom : IAtomicFileSystem
    {
        private IFileStreamFactory fileStreamFactory;
        private IFilesSystemWatcherFactory filesSystemWatcherFactory;
        private IFileInfoFactory fileInfoFactory;
        private IDirectoryInfoFactory directoryInfoFactory;
        private IFile file;
        private IFilesSystemWatcherFactory systemWatcherFactory;
        private IDirectory directory;
        private IDriveInfoFactory driveInfoFactory;
        private IDrives drives;

        /// <summary>
        /// Instantiates a new FileSystemAtom
        /// </summary>
        public FileSystemAtom() : this(new FileStreamFactory(), new FilesSystemWatcherFactory(), new DriveInfoFactory(), new DirectoryInfoFactory(), new FileInfoFactory(), new Drives(), new Directory(), new File())
        {
        }

        private FileSystemAtom(IFileStreamFactory fileStreamFactory,
            IFilesSystemWatcherFactory systemWatcherFactory,
            IDriveInfoFactory driveInfoFactory,
            IDirectoryInfoFactory directoryInfoFactory, IFileInfoFactory fileInfoFactory,
            IDrives drives, IDirectory directory,
            IFile file)
        {
            this.fileStreamFactory = fileStreamFactory;
            this.systemWatcherFactory = systemWatcherFactory;
            this.fileInfoFactory = fileInfoFactory;
            this.directoryInfoFactory = directoryInfoFactory;
            this.file = file;
            this.directory = directory;
            this.driveInfoFactory = driveInfoFactory;
            this.drives = drives;
        }

        /// <summary>
        /// Returns a builder that allow parts of the file system to be replaced temporarily.
        /// </summary>
        public IAtomicReplacementBuilder Replace { get; } = new AtomicAtomicReplacementBuilder();

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies additional file options.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize,
            System.IO.FileOptions options)
        {
            return new AtomicActions<IFileStream>(() =>
                fileStreamFactory.GetFileStream(path, mode, access, share, bufferSize, options));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize)
        {
            return new AtomicActions<IFileStream>(() =>
                fileStreamFactory.GetFileStream(path, mode, access, share, bufferSize));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share)
        {
            return new AtomicActions<IFileStream>(() => fileStreamFactory.GetFileStream(path, mode, access, share));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <param name="useAsync">Specifies whether to use asynchronous I/O or synchronous I/O. However, note that the underlying operating system might not support asynchronous I/O, so when specifying true, the handle might be opened synchronously depending on the platform. When opened asynchronously, the BeginRead(Byte[], Int32, Int32, AsyncCallback, Object) and BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object) methods perform better on large reads or writes, but they might be much slower for small reads or writes. If the application is designed to take advantage of asynchronous I/O, set the useAsync parameter to true. Using asynchronous I/O correctly can speed up applications by as much as a factor of 10, but using it without redesigning the application for asynchronous I/O can decrease performance by as much as a factor of 10.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share,
            int bufferSize, bool useAsync)
        {
            return new AtomicActions<IFileStream>(() =>
                fileStreamFactory.GetFileStream(path, mode, access, share, bufferSize, useAsync));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileStream specified by the parameters. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <returns>An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.</returns>
        public IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access)
        {
            return new AtomicActions<IFileStream>(() => fileStreamFactory.GetFileStream(path, mode, access));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IDriveInfo specified by the drive name.
        /// </summary>
        /// <param name="driveName">A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.</param>
        /// <returns>An atomic action allowing the interaction with a IDriveInfo specified by the drive name.</returns>
        public IAtomicActions<IDriveInfo> DriveInfo(string driveName)
        {
            return new AtomicPassThrough<IDriveInfo>(() => driveInfoFactory.DriveInfo(driveName));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IFileInfo specified by the file name.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.</param>
        /// <returns>An atomic action allowing the interaction with a IFileInfo specified by the file name.</returns>
        public IAtomicActions<IFileInfo> FileInfo(string fileName)
        {
            return new AtomicPassThrough<IFileInfo>(() => fileInfoFactory.GetFileInfo(fileName));
        }

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IDrives.
        /// </summary>
        public IAtomicActions<IDrives> Drives => new AtomicPassThrough<IDrives>(() => drives);
        
        /// <summary>
        /// Returns an atomic action allowing the interaction with IDirectory.
        /// </summary>
        public IAtomicActions<IDirectory> Directory => new AtomicPassThrough<IDirectory>(() => directory);
        
        /// <summary>
        /// Returns an atomic action allowing the interaction with IFile.
        /// </summary>
        public IAtomicActions<IFile> File => new AtomicPassThrough<IFile>(() => file);

        /// <summary>
        /// Returns an atomic action allowing the interaction with a IDirectoryInfo specified by the path.
        /// </summary>
        /// <param name="path">A string specifying the path on which to create the IDirectoryInfo.</param>
        /// <returns>An atomic action allowing the interaction with a IDirectoryInfo specified by the path.</returns>
        public IAtomicActions<IDirectoryInfo> DirectoryInfo(string path)
        {
            return new AtomicPassThrough<IDirectoryInfo>(() => directoryInfoFactory.GetDirectoryInfo(path));
        }
        
        internal IDisposable ReplaceInternals(IFileStreamFactory newFileStreamFactory,
            IFilesSystemWatcherFactory newSystemWatcherFactory,
            IDriveInfoFactory newDriveInfoFactory,
            IDirectoryInfoFactory newDirectoryInfoFactory, IFileInfoFactory newFileInfoFactory,
            IDrives newDrives, IDirectory newDirectory, IFile newFile)
        {
            var holdFileStream = fileStreamFactory;
            var holdWatcher = systemWatcherFactory;
            
            var holdDriveInfo = driveInfoFactory;
            var holdDirectoryInfo = directoryInfoFactory;
            var holdFileInfo = fileInfoFactory;
            
            var holdDirectory = directory;
            var holdDrives = drives;
            var holdFile = file;
            
            fileStreamFactory = newFileStreamFactory;
            systemWatcherFactory = newSystemWatcherFactory;
            
            driveInfoFactory = newDriveInfoFactory;
            fileInfoFactory = newFileInfoFactory;
            directoryInfoFactory = newDirectoryInfoFactory;
            
            drives = newDrives;
            directory = newDirectory;
            file = newFile;

            return new DisposableAction(() =>
            {
                fileStreamFactory = holdFileStream;
                systemWatcherFactory = holdWatcher;
                
                driveInfoFactory = holdDriveInfo;
                directoryInfoFactory = holdDirectoryInfo;
                fileInfoFactory = holdFileInfo;

                drives = holdDrives;
                directory = holdDirectory;
                file = holdFile;
            });
        }
    }
}