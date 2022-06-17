using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace FileSystemFacade.Primitives
{
    public interface IFileStream : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Gets the underlying stream.
        /// </summary>
        Stream Stream { get; }
        /// <summary>
        /// Gets a value that indicates whether the current stream supports reading.
        /// </summary>
        bool CanRead { get; }
        /// <summary>
        /// Gets a value that indicates whether the current stream supports seeking.
        /// </summary>
        bool CanSeek { get; }
        /// <summary>
        /// Gets a value that determines whether the current stream can time out.
        /// </summary>
        bool CanTimeout { get; }
        /// <summary>
        /// Gets a value that indicates whether the current stream supports writing.
        /// </summary>
        bool CanWrite { get; }
        /// <summary>
        /// Gets a value that indicates whether the FileStream was opened asynchronously or synchronously.
        /// </summary>
        bool IsAsync { get; }
        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        long Length { get; }
        /// <summary>
        /// Gets the absolute path of the file opened in the FileStream.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets or sets the current position of this stream.
        /// </summary>
        long Position { get; set; }
        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.
        /// </summary>
        int ReadTimeout { get; set; }
        /// <summary>
        /// Gets a SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.
        /// </summary>
        SafeFileHandle SafeFileHandle { get; }
        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.
        /// </summary>
        int WriteTimeout { get; set; }
        
        /// <summary>
        /// Begins an asynchronous read operation. Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.
        /// </summary>
        /// <param name="buffer">The buffer to read data into.</param>
        /// <param name="offset">The byte offset in array at which to begin reading.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="callback">The method to be called when the asynchronous read operation is completed</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>An object that references the asynchronous read.</returns>
        IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
        /// <summary>
        /// Begins an asynchronous write operation. Consider using WriteAsync(Byte[], Int32, Int32, CancellationToken) instead.
        /// </summary>
        /// <param name="buffer">The buffer containing data to write to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in array at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <param name="callback">The method to be called when the asynchronous write operation is completed.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
        /// <returns>An object that references the asynchronous write.</returns>
        IAsyncResult BeginWrite (byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
        /// <summary>
        /// Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream. Instead of calling this method, ensure that the stream is properly disposed.
        /// </summary>
        void Close ();
        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        void CopyTo (Stream destination);
        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        void CopyTo(IFileStream destination);
        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size of the buffer. This value must be greater than zero. The default size is 81920.</param>
        void CopyTo (Stream destination, int bufferSize);
        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size of the buffer. This value must be greater than zero. The default size is 81920.</param>
        void CopyTo(IFileStream destination, int bufferSize);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (Stream destination, int bufferSize, CancellationToken cancellationToken);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (Stream destination, CancellationToken cancellationToken);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (IFileStream destination, CancellationToken cancellationToken);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (Stream destination, int bufferSize);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (IFileStream destination, int bufferSize);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (Stream destination);
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync (IFileStream destination);
        /// <summary>
        /// Waits for the pending asynchronous read operation to complete. (Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.)
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to wait for.</param>
        /// <returns>The number of bytes read from the stream, between 0 and the number of bytes you requested. Streams only return 0 at the end of the stream, otherwise, they should block until at least 1 byte is available.</returns>
        int EndRead (IAsyncResult asyncResult);
        /// <summary>
        /// Ends an asynchronous write operation and blocks until the I/O operation is complete. (Consider using WriteAsync(Byte[], Int32, Int32, CancellationToken) instead.)
        /// </summary>
        /// <param name="asyncResult">The pending asynchronous I/O request.</param>
        void EndWrite (IAsyncResult asyncResult);
        /// <summary>
        /// Clears buffers for this stream and causes any buffered data to be written to the file.
        /// </summary>
        void Flush ();
        /// <summary>
        /// Clears buffers for this stream and causes any buffered data to be written to the file, and also clears all intermediate file buffers.
        /// </summary>
        /// <param name="flushToDisk">true to flush all intermediate file buffers; otherwise, false.</param>
        void Flush (bool flushToDisk);
        /// <summary>
        /// Asynchronously clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        Task FlushAsync ();
        /// <summary>
        /// Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors cancellation requests.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        Task FlushAsync (CancellationToken cancellationToken);
        
        /// <summary>
        /// Prevents other processes from reading from or writing to the FileStream.
        /// </summary>
        /// <param name="position">The beginning of the range to lock. The value of this parameter must be equal to or greater than zero (0).</param>
        /// <param name="length">The range to be locked.</param>
        [System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
        void Lock (long position, long length);
        /// <summary>
        /// Reads a block of bytes from the stream and writes the data in a given buffer.
        /// </summary>
        /// <param name="buffer">When this method returns, contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The byte offset in array at which the read bytes will be placed.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer. This might be less than the number of bytes requested if that number of bytes are not currently available, or zero if the end of the stream is reached.</returns>
        int Read (byte[] buffer, int offset, int count);
        /// <summary>
        /// Reads a sequence of bytes from the current file stream and advances the position within the file stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">A region of memory. When this method returns, the contents of this region are replaced by the bytes read from the current file stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes allocated in the buffer if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
        int Read (Span<byte> buffer);
        /// <summary>
        /// Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.
        /// </summary>
        /// <param name="buffer">The region of memory to write the data into.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation. The value of its Result property contains the total number of bytes read into the buffer. The result value can be less than the number of bytes allocated in the buffer if that many bytes are not currently available, or it can be 0 (zero) if the end of the stream has been reached.</returns>
        ValueTask<int> ReadAsync (Memory<byte> buffer, CancellationToken cancellationToken = default);
        /// <summary>
        /// Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">The buffer to write the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing data from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the stream has been reached.</returns>
        Task<int> ReadAsync (byte[] buffer, int offset, int count);
        /// <summary>
        /// Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.
        /// </summary>
        /// <param name="buffer">The buffer to write the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing data from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the stream has been reached.</returns>
        Task<int> ReadAsync (byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        /// <summary>
        /// Reads a byte from the file and advances the read position one byte.
        /// </summary>
        /// <returns>The byte, cast to an Int32, or -1 if the end of the stream has been reached.</returns>
        int ReadByte ();
        /// <summary>
        /// Sets the current position of this stream to the given value.
        /// </summary>
        /// <param name="offset">The point relative to origin from which to begin seeking.</param>
        /// <param name="origin">Specifies the beginning, the end, or the current position as a reference point for offset, using a value of type SeekOrigin.</param>
        /// <returns>The new position in the stream.</returns>
        long Seek (long offset, SeekOrigin origin);
        /// <summary>
        /// Sets the length of this stream to the given value.
        /// </summary>
        /// <param name="value">The new length of the stream.</param>
        void SetLength (long value);
        
        /// <summary>
        /// Allows access by other processes to all or part of a file that was previously locked.
        /// </summary>
        /// <param name="position">The beginning of the range to unlock.</param>
        /// <param name="length">The range to be unlocked.</param>
        [System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
        void Unlock (long position, long length);
        /// <summary>
        /// Writes a block of bytes to the file stream.
        /// </summary>
        /// <param name="buffer">The buffer containing data to write to the stream.</param>
        /// <param name="offset">The zero-based byte offset in array from which to begin copying bytes to the stream.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        void Write (byte[] buffer, int offset, int count);
        /// <summary>
        /// Writes a sequence of bytes from a read-only span to the current file stream and advances the current position within this file stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">A region of memory. This method copies the contents of this region to the current file stream.</param>
        void Write (ReadOnlySpan<byte> buffer);
        /// <summary>
        /// Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number of bytes written, and monitors cancellation requests.
        /// </summary>
        /// <param name="buffer">The region of memory to write data from.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        ValueTask WriteAsync (ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
        /// <summary>
        /// Asynchronously writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The zero-based byte offset in buffer from which to begin copying bytes to the stream.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteAsync (byte[] buffer, int offset, int count);
        /// <summary>
        /// Writes a byte to the current position in the file stream.
        /// </summary>
        /// <param name="value">A byte to write to the stream.</param>
        void WriteByte (byte value);
    }

    public interface IFileStreamBuilder
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
        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize, FileOptions options);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.</returns>
        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A bitwise combination of the enumeration values that determines how the file will be shared by processes.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.</returns>
        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share);

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
        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize, bool useAsync);

        /// <summary>
        /// Creates a new instance of the FileStream class with the specified path, creation mode, and read/write permission.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">One of the enumeration values that determines how to open or create the file.</param>
        /// <param name="access">A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <returns>A new instance of the FileStream class with the specified path, creation mode, and read/write permission.</returns>
        IFileStream GetFileStream(string path, FileMode mode, FileAccess access);
    }

    internal class FileStreamBuilder : IFileStreamBuilder
    {
        public IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize,
            FileOptions options)
        {
            return new FileStream(path, mode, access, share, bufferSize, options);
        }

        public IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
        {
            return new FileStream(path, mode, access, share, bufferSize);
        }

        public IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(path, mode, access, share);
        }

        public IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
        {
            return new FileStream(path, mode, access, share, bufferSize, useAsync);
        }

        public IFileStream GetFileStream(string path, FileMode mode, FileAccess access)
        {
            return new FileStream(path, mode, access);
        }
    }

    internal class FileStream : MarshalByRefObject, IFileStream
    {
        private readonly System.IO.FileStream stream;
        private bool disposed;

        ~FileStream()
        {
            this.Dispose();
        }

        internal FileStream(System.IO.FileStream stream)
        {
            this.stream = stream;
        }

        internal FileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize, FileOptions options): this(new System.IO.FileStream(path, mode, access, share, bufferSize, options)) { }

        internal FileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize) : this(new System.IO.FileStream(path, mode, access, share, bufferSize)) { }

        internal FileStream(string path, FileMode mode, FileAccess access, FileShare share) : this(new System.IO.FileStream(path, mode, access, share)) { }

        internal FileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize, bool useAsync) : this(new System.IO.FileStream(path, mode, access, share, bufferSize,
            useAsync)) { }
        
        internal FileStream (string path, FileMode mode, FileAccess access) : this(new System.IO.FileStream(path, mode, access)) { }
        
        internal FileStream (SafeFileHandle handle, FileAccess access, int bufferSize) : this(new System.IO.FileStream(handle, access, bufferSize)) { }
        
        internal FileStream (SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync) 
            : this(new System.IO.FileStream(handle, access, bufferSize, isAsync)) { }
        
        internal FileStream (string path, FileMode mode) : this(new System.IO.FileStream(path, mode)) { }

        public Stream Stream => stream;

        public void EndWrite(IAsyncResult asyncResult)
        {
            stream.EndWrite(asyncResult);
        }

        public void Flush()
        {
            stream.Flush();
        }

        public void Flush(bool flushToDisk)
        {
            stream.Flush(flushToDisk);
        }

        public Task FlushAsync()
        {
            return stream.FlushAsync();
        }

        public Task FlushAsync(CancellationToken cancellationToken)
        {
            return stream.FlushAsync(cancellationToken);
        }

        public void Lock(long position, long length)
        {
            stream.Lock(position, length);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }

        public int Read(Span<byte> buffer)
        {
            return stream.Read(buffer);
        }

        public ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            return stream.ReadAsync(buffer, cancellationToken);
        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            return stream.ReadAsync(buffer, offset, count);
        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return stream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public int ReadByte()
        {
            return stream.ReadByte();
        }

        public long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public void Unlock(long position, long length)
        {
            stream.Unlock(position, length);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }

        public void Write(ReadOnlySpan<byte> buffer)
        {
            stream.Write(buffer);
        }

        public ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            return stream.WriteAsync(buffer, cancellationToken);
        }

        public Task WriteAsync(byte[] buffer, int offset, int count)
        {
            return stream.WriteAsync(buffer, offset, count);
        }

        public void WriteByte(byte value)
        {
            stream.WriteByte(value);
        }

        public bool CanRead => stream.CanRead;
        public bool CanSeek => stream.CanSeek;
        public bool CanTimeout => stream.CanTimeout;
        public bool CanWrite => stream.CanWrite;
        public bool IsAsync => stream.IsAsync;
        public long Length => stream.Length;
        public string Name => stream.Name;

        public long Position
        {
            get => stream.Position;
            set => stream.Position = value;
        }

        public int ReadTimeout
        {
            get => stream.ReadTimeout;
            set => stream.ReadTimeout = value;
        }

        public SafeFileHandle SafeFileHandle => stream.SafeFileHandle;
        public int WriteTimeout { get; set; }
        public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return stream.BeginRead(buffer, offset, count, callback, state);
        }

        public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(buffer, offset, count, callback, state);
        }

        public void Close()
        {
            stream.Close();
        }

        public void CopyTo(Stream destination)
        {
            stream.CopyTo(destination);
        }

        public void CopyTo(IFileStream destination)
        {
            stream.CopyTo(destination.Stream);
        }

        public void CopyTo(Stream destination, int bufferSize)
        {
            stream.CopyTo(destination, bufferSize);
        }

        public void CopyTo(IFileStream destination, int bufferSize)
        {
            stream.CopyTo(destination.Stream, bufferSize);
        }

        public Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return stream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        public Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return stream.CopyToAsync(destination.Stream, bufferSize, cancellationToken);
        }

        public Task CopyToAsync(Stream destination, CancellationToken cancellationToken)
        {
            return stream.CopyToAsync(destination, cancellationToken);
        }

        public Task CopyToAsync(IFileStream destination, CancellationToken cancellationToken)
        {
            return stream.CopyToAsync(destination.Stream, cancellationToken);
        }

        public Task CopyToAsync(Stream destination, int bufferSize)
        {
            return stream.CopyToAsync(destination, bufferSize);
        }

        public Task CopyToAsync(IFileStream destination, int bufferSize)
        {
            return stream.CopyToAsync(destination.Stream, bufferSize);
        }

        public Task CopyToAsync(Stream destination)
        {
            return stream.CopyToAsync(destination);
        }

        public Task CopyToAsync(IFileStream destination)
        {
            return stream.CopyToAsync(destination.Stream);
        }

        public int EndRead(IAsyncResult asyncResult)
        {
            return stream.EndRead(asyncResult);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            
            if(disposing)
                stream.Dispose();

            disposed = true;
            
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await stream.DisposeAsync();
            
            Dispose(false);
            
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public override string ToString()
        {
            return stream.ToString();
        }
    }
}