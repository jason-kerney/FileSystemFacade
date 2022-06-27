namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// A factory to build IFileStream objects
    /// </summary>
    public interface IFileStreamFactory
    {
        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies additional file options.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.</returns>
        IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, System.IO.FileOptions options);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.</returns>
        IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.</returns>
        IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <param name="useAsync">Specifies whether to use asynchronous I/O or synchronous I/O. However, note that the underlying operating system might not support asynchronous I/O, so when specifying true, the handle might be opened synchronously depending on the platform. When opened asynchronously, the BeginRead(Byte[], Int32, Int32, AsyncCallback, Object) and BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object) methods perform better on large reads or writes, but they might be much slower for small reads or writes. If the application is designed to take advantage of asynchronous I/O, set the useAsync parameter to true. Using asynchronous I/O correctly can speed up applications by as much as a factor of 10, but using it without redesigning the application for asynchronous I/O can decrease performance by as much as a factor of 10.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.</returns>
        IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, bool useAsync);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, and read/write permission.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, and read/write permission.</returns>
        IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access);
    }

    internal class FileStreamFactory : IFileStreamFactory
    {
        public IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize,
            System.IO.FileOptions options)
        {
            return new FileStream(path, mode, access, share, bufferSize, options);
        }

        public IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize)
        {
            return new FileStream(path, mode, access, share, bufferSize);
        }

        public IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share)
        {
            return new FileStream(path, mode, access, share);
        }

        public IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, bool useAsync)
        {
            return new FileStream(path, mode, access, share, bufferSize, useAsync);
        }

        public IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access)
        {
            return new FileStream(path, mode, access);
        }
    }
}