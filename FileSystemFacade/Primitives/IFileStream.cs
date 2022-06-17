using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace FileSystemFacade.Primitives
{
    public interface IFileStream : IDisposable, IAsyncDisposable
    {
        Stream Stream { get; }
        bool CanRead { get; }
        bool CanSeek { get; }
        bool CanTimeout { get; }
        bool CanWrite { get; }
        bool IsAsync { get; }
        long Length { get; }
        string Name { get; }
        long Position { get; set; }
        int ReadTimeout { get; set; }
        SafeFileHandle SafeFileHandle { get; }
        int WriteTimeout { get; set; }
        
        IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
        IAsyncResult BeginWrite (byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
        void Close ();
        void CopyTo (Stream destination);
        void CopyTo(IFileStream destination);
        void CopyTo (Stream destination, int bufferSize);
        void CopyTo(IFileStream destination, int bufferSize);
        Task CopyToAsync (Stream destination, int bufferSize, CancellationToken cancellationToken);
        Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken);
        Task CopyToAsync (Stream destination, CancellationToken cancellationToken);
        Task CopyToAsync (IFileStream destination, CancellationToken cancellationToken);
        Task CopyToAsync (Stream destination, int bufferSize);
        Task CopyToAsync (IFileStream destination, int bufferSize);
        Task CopyToAsync (Stream destination);
        Task CopyToAsync (IFileStream destination);
        int EndRead (IAsyncResult asyncResult);
        void EndWrite (IAsyncResult asyncResult);
        void Flush ();
        void Flush (bool flushToDisk);
        Task FlushAsync ();
        Task FlushAsync (CancellationToken cancellationToken);
        
        [System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
        void Lock (long position, long length);
        int Read (byte[] buffer, int offset, int count);
        int Read (Span<byte> buffer);
        ValueTask<int> ReadAsync (Memory<byte> buffer, CancellationToken cancellationToken = default);
        Task<int> ReadAsync (byte[] buffer, int offset, int count);
        Task<int> ReadAsync (byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        int ReadByte ();
        long Seek (long offset, SeekOrigin origin);
        void SetLength (long value);
        
        [System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
        [System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
        void Unlock (long position, long length);
        void Write (byte[] buffer, int offset, int count);
        void Write (ReadOnlySpan<byte> buffer);
        ValueTask WriteAsync (ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
        Task WriteAsync (byte[] buffer, int offset, int count);
        void WriteByte (byte value);
    }

    public interface IFileStreamBuilder
    {
        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize, FileOptions options);

        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize);

        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share);

        IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share,
            int bufferSize, bool useAsync);

        IFileStream GetFileStream(string path, FileMode mode, FileAccess access);
    }

    internal class FileStreamBuilder : IFileStreamBuilder
    {
        public IFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize,
            FileOptions options)
        {
            return new FileStream(path, mode, access, share, bufferSize);
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

    public class FileStream : MarshalByRefObject, IFileStream
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