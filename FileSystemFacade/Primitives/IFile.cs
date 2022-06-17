using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystemFacade.Primitives
{
    public interface IFile
    {
        /// <summary>
        /// Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        void AppendAllLines(string path, IEnumerable<string> contents);

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);

        /// <summary>
        /// Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        Task AppendAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        void AppendAllText(string path, string? contents);

        /// <summary>
        /// Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        void AppendAllText(string path, string? contents, Encoding encoding);

        /// <summary>
        /// Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns></returns>
        Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        Task AppendAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist.
        /// </summary>
        /// <param name="path">The path to the file to append to.</param>
        /// <returns>A stream writer that appends UTF-8 encoded text to the specified file or to a new file.</returns>
        System.IO.StreamWriter AppendText(string path);

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        void Copy(string sourceFileName, string destFileName);
        
        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        void Copy(string sourceFileName, string destFileName, bool overwrite);
        
        /// <summary>
        /// Creates or overwrites a file in the specified path.
        /// </summary>
        /// <param name="path">The path and name of the file to create.</param>
        /// <returns>A FileStream that provides read/write access to the file specified in path.</returns>
        IFileStream Create(string path);
        
        /// <summary>
        /// The path and name of the file to create.
        /// </summary>
        /// <param name="path">The number of bytes buffered for reads and writes to the file.</param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file.</param>
        /// <returns>A FileStream with the specified buffer size that provides read/write access to the file specified in path.</returns>
        IFileStream Create(string path, int bufferSize);
        
        /// <summary>
        /// Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to create or overwrite the file.
        /// </summary>
        /// <param name="path">The path and name of the file to create.</param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file.</param>
        /// <param name="options">One of the FileOptions values that describes how to create or overwrite the file.</param>
        /// <returns>A new file with the specified buffer size.</returns>
        IFileStream Create(string path, int bufferSize, System.IO.FileOptions options);
        
        /// <summary>
        /// Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.
        /// </summary>
        /// <param name="path">The file to be opened for writing.</param>
        /// <returns>A StreamWriter that writes to the specified file using UTF-8 encoding.</returns>
        System.IO.StreamWriter CreateText(string path);
        
        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        void Delete(string path);
        
        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="path">The file to check.</param>
        /// <returns>true if the caller has the required permissions and path contains the name of an existing file; otherwise, false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.</returns>
        bool Exists(string? path);
        
        /// <summary>
        /// Gets the FileAttributes of the file on the path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The FileAttributes of the file on the path.</returns>
        System.IO.FileAttributes GetAttributes(string path);
        
        /// <summary>
        /// Returns the creation date and time of the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain creation date and time information.</param>
        /// <returns>A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in local time.</returns>
        DateTime GetCreationTime(string path);
        
        /// <summary>
        /// Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain creation date and time information.</param>
        /// <returns>A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in UTC time.</returns>
        DateTime GetCreationTimeUtc(string path);
        /// <summary>
        /// Returns the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.</returns>
        DateTime GetLastAccessTime(string path);
        
        /// <summary>
        /// Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.</returns>
        DateTime GetLastAccessTimeUtc(string path);
        
        
        DateTime GetLastWriteTime(string path);
        DateTime GetLastWriteTimeUtc(string path);
        void Move(string sourceFileName, string destFileName);
        void Move(string sourceFileName, string destFileName, bool overwrite);
        IFileStream Open(string path, System.IO.FileMode mode);
        IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access);
        IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
        IFileStream OpenRead(string path);
        System.IO.StreamReader OpenText(string path);
        IFileStream OpenWrite(string path);
        byte[] ReadAllBytes(string path);
        Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);
        string[] ReadAllLines(string path);
        string[] ReadAllLines(string path, Encoding encoding);
        Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);
        Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
        string ReadAllText(string path, Encoding encoding);
        string ReadAllText(string path);
        Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);
        Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
        IEnumerable<string> ReadLines(string path);
        IEnumerable<string> ReadLines(string path, Encoding encoding);
        void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName);

        void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName,
            bool ignoreMetadataErrors);

        void SetAttributes(string path, System.IO.FileAttributes fileAttributes);
        void SetCreationTime(string path, DateTime creationTime);
        void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
        void SetLastAccessTime(string path, DateTime lastAccessTime);
        void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
        void SetLastWriteTime(string path, DateTime lastWriteTime);
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
        void WriteAllBytes(string path, byte[] bytes);
        Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);
        void WriteAllLines(string path, string[] contents, Encoding encoding);
        void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
        void WriteAllLines(string path, IEnumerable<string> contents);
        void WriteAllLines(string path, string[] contents);

        Task WriteAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default);

        Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default);

        void WriteAllText(string path, string? contents);
        void WriteAllText(string path, string? contents, Encoding encoding);
        Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);

        Task WriteAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default);

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Decrypt(string path);

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Encrypt(string path);
    }

    internal class File : IFile
    {
        public void AppendAllLines(string path, IEnumerable<string> contents)
        {
            System.IO.File.AppendAllLines(path, contents);
        }

        public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            System.IO.File.AppendAllLines(path, contents, encoding);
        }

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.AppendAllLinesAsync(path, contents, cancellationToken);
        }

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.AppendAllLinesAsync(path, contents, encoding, cancellationToken);
        }

        public void AppendAllText(string path, string? contents)
        {
            System.IO.File.AppendAllText(path, contents);
        }

        public void AppendAllText(string path, string? contents, Encoding encoding)
        {
            System.IO.File.AppendAllText(path, contents, encoding);
        }

        public Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
            return System.IO.File.AppendAllTextAsync(path, contents, cancellationToken);
        }

        public Task AppendAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
        }

        public System.IO.StreamWriter AppendText(string path)
        {
            return System.IO.File.AppendText(path);
        }

        public void Copy(string sourceFileName, string destFileName)
        {
            System.IO.File.Copy(sourceFileName, destFileName);
        }

        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            System.IO.File.Copy(sourceFileName, destFileName, overwrite);
        }

        public IFileStream Create(string path)
        {
            return new FileStream(System.IO.File.Create(path));
        }

        public IFileStream Create(string path, int bufferSize)
        {
            return new FileStream(System.IO.File.Create(path, bufferSize));
        }

        public IFileStream Create(string path, int bufferSize, System.IO.FileOptions options)
        {
            return new FileStream(System.IO.File.Create(path, bufferSize, options));
        }

        public System.IO.StreamWriter CreateText(string path)
        {
            return System.IO.File.CreateText(path);
        }

        public void Delete(string path)
        {
            System.IO.File.Delete(path);
        }

        public bool Exists(string? path)
        {
            return System.IO.File.Exists(path);
        }

        public System.IO.FileAttributes GetAttributes(string path)
        {
            return System.IO.File.GetAttributes(path);
        }

        public DateTime GetCreationTime(string path)
        {
            return System.IO.File.GetCreationTime(path);
        }

        public DateTime GetCreationTimeUtc(string path)
        {
            return System.IO.File.GetCreationTimeUtc(path);
        }

        public DateTime GetLastAccessTime(string path)
        {
            return System.IO.File.GetLastAccessTime(path);
        }

        public DateTime GetLastAccessTimeUtc(string path)
        {
            return System.IO.File.GetLastAccessTimeUtc(path);
        }

        public DateTime GetLastWriteTime(string path)
        {
            return System.IO.File.GetLastWriteTime(path);
        }

        public DateTime GetLastWriteTimeUtc(string path)
        {
            return System.IO.File.GetLastWriteTimeUtc(path);
        }

        public void Move(string sourceFileName, string destFileName)
        {
            System.IO.File.Move(sourceFileName, destFileName);
        }

        public void Move(string sourceFileName, string destFileName, bool overwrite)
        {
            System.IO.File.Move(sourceFileName, destFileName, overwrite);
        }

        public IFileStream Open(string path, System.IO.FileMode mode)
        {
            return new FileStream(System.IO.File.Open(path, mode));
        }

        public IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access)
        {
            return new FileStream(System.IO.File.Open(path, mode, access));
        }

        public IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access,
            System.IO.FileShare share)
        {
            return new FileStream(System.IO.File.Open(path, mode, access, share));
        }

        public IFileStream OpenRead(string path)
        {
            return new FileStream(System.IO.File.OpenRead(path));
        }

        public System.IO.StreamReader OpenText(string path)
        {
            return System.IO.File.OpenText(path);
        }

        public IFileStream OpenWrite(string path)
        {
            return new FileStream(System.IO.File.OpenWrite(path));
        }

        public byte[] ReadAllBytes(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        public Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default)
        {
            return System.IO.File.ReadAllBytesAsync(path, cancellationToken);
        }

        public string[] ReadAllLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        public string[] ReadAllLines(string path, Encoding encoding)
        {
            return System.IO.File.ReadAllLines(path, encoding);
        }

        public Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default)
        {
            return System.IO.File.ReadAllLinesAsync(path, cancellationToken);
        }

        public Task<string[]> ReadAllLinesAsync(string path, Encoding encoding,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.ReadAllLinesAsync(path, encoding, cancellationToken);
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            return System.IO.File.ReadAllText(path, encoding);
        }

        public string ReadAllText(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default)
        {
            return System.IO.File.ReadAllTextAsync(path, cancellationToken);
        }

        public Task<string> ReadAllTextAsync(string path, Encoding encoding,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.ReadAllTextAsync(path, encoding, cancellationToken);
        }

        public IEnumerable<string> ReadLines(string path)
        {
            return System.IO.File.ReadLines(path);
        }

        public IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            return System.IO.File.ReadLines(path, encoding);
        }

        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName)
        {
            System.IO.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
        }

        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName,
            bool ignoreMetadataErrors)
        {
            System.IO.File.Replace(sourceFileName, destinationFileName, destinationFileName, ignoreMetadataErrors);
        }

        public void SetAttributes(string path, System.IO.FileAttributes fileAttributes)
        {
            System.IO.File.SetAttributes(path, fileAttributes);
        }

        public void SetCreationTime(string path, DateTime creationTime)
        {
            System.IO.File.SetCreationTime(path, creationTime);
        }

        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            System.IO.File.SetCreationTimeUtc(path, creationTimeUtc);
        }

        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            System.IO.File.SetLastAccessTime(path, lastAccessTime);
        }

        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            System.IO.File.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
        }

        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            System.IO.File.SetLastWriteTime(path, lastWriteTime);
        }

        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            System.IO.File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
        }

        public void WriteAllBytes(string path, byte[] bytes)
        {
            System.IO.File.WriteAllBytes(path, bytes);
        }

        public Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default)
        {
            return System.IO.File.WriteAllBytesAsync(path, bytes, cancellationToken);
        }

        public void WriteAllLines(string path, string[] contents, Encoding encoding)
        {
            System.IO.File.WriteAllLines(path, contents, encoding);
        }

        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            System.IO.File.WriteAllLines(path, contents, encoding);
        }

        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            System.IO.File.WriteAllLines(path, contents);
        }

        public void WriteAllLines(string path, string[] contents)
        {
            System.IO.File.WriteAllLines(path, contents);
        }

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.WriteAllLinesAsync(path, contents, cancellationToken);
        }

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.WriteAllLinesAsync(path, contents, encoding, cancellationToken);
        }

        public void WriteAllText(string path, string? contents)
        {
            System.IO.File.WriteAllText(path, contents);
        }

        public void WriteAllText(string path, string? contents, Encoding encoding)
        {
            System.IO.File.WriteAllText(path, contents, encoding);
        }

        public Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
            return System.IO.File.WriteAllTextAsync(path, contents, cancellationToken);
        }

        public Task WriteAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default)
        {
            return System.IO.File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
        }

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public void Decrypt(string path)
        {
            System.IO.File.Decrypt(path);
        }

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public void Encrypt(string path)
        {
            System.IO.File.Encrypt(path);
        }
    }
}