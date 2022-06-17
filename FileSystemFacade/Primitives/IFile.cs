using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystemFacade.Primitives
{
    public interface IFile
    {
        void AppendAllLines(string path, IEnumerable<string> contents);
        void AppendAllLines (string path, IEnumerable<string> contents, Encoding encoding);
        Task AppendAllLinesAsync (string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
        Task AppendAllLinesAsync (string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
        void AppendAllText (string path, string? contents);
        void AppendAllText (string path, string? contents, Encoding encoding);
        Task AppendAllTextAsync (string path, string? contents, CancellationToken cancellationToken = default);
        Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
        System.IO.StreamWriter AppendText (string path);
        void Copy (string sourceFileName, string destFileName);
        void Copy (string sourceFileName, string destFileName, bool overwrite);
        IFileStream Create (string path);
        IFileStream Create (string path, int bufferSize);
        IFileStream Create (string path, int bufferSize, System.IO.FileOptions options);
        System.IO.StreamWriter CreateText (string path);
        void Delete (string path);
        bool Exists (string? path);
        System.IO.FileAttributes GetAttributes (string path);
        DateTime GetCreationTime (string path);
        DateTime GetCreationTimeUtc (string path);
        DateTime GetLastAccessTime (string path);
        DateTime GetLastAccessTimeUtc (string path);
        DateTime GetLastWriteTime (string path);
        DateTime GetLastWriteTimeUtc (string path);
        void Move (string sourceFileName, string destFileName);
        void Move (string sourceFileName, string destFileName, bool overwrite);
        IFileStream Open (string path, System.IO.FileMode mode);
        IFileStream Open (string path, System.IO.FileMode mode, System.IO.FileAccess access);
        IFileStream Open (string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
        IFileStream OpenRead (string path);
        System.IO.StreamReader OpenText (string path);
        IFileStream OpenWrite (string path);
        byte[] ReadAllBytes (string path);
        Task<byte[]> ReadAllBytesAsync (string path, CancellationToken cancellationToken = default);
        string[] ReadAllLines (string path);
        string[] ReadAllLines (string path, Encoding encoding);
        Task<string[]> ReadAllLinesAsync (string path, CancellationToken cancellationToken = default);
        Task<string[]> ReadAllLinesAsync (string path, Encoding encoding, CancellationToken cancellationToken = default);
        string ReadAllText (string path, Encoding encoding);
        string ReadAllText (string path);
        Task<string> ReadAllTextAsync (string path, CancellationToken cancellationToken = default);
        Task<string> ReadAllTextAsync (string path, Encoding encoding, CancellationToken cancellationToken = default);
        IEnumerable<string> ReadLines (string path);
        IEnumerable<string> ReadLines (string path, Encoding encoding);
        void Replace (string sourceFileName, string destinationFileName, string? destinationBackupFileName);
        void Replace (string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
        void SetAttributes (string path, System.IO.FileAttributes fileAttributes);
        void SetCreationTime (string path, DateTime creationTime);
        void SetCreationTimeUtc (string path, DateTime creationTimeUtc);
        void SetLastAccessTime (string path, DateTime lastAccessTime);
        void SetLastAccessTimeUtc (string path, DateTime lastAccessTimeUtc);
        void SetLastWriteTime (string path, DateTime lastWriteTime);
        void SetLastWriteTimeUtc (string path, DateTime lastWriteTimeUtc);
        void WriteAllBytes (string path, byte[] bytes);
        Task WriteAllBytesAsync (string path, byte[] bytes, CancellationToken cancellationToken = default);
        void WriteAllLines (string path, string[] contents, Encoding encoding);
        void WriteAllLines (string path, IEnumerable<string> contents, Encoding encoding);
        void WriteAllLines (string path, IEnumerable<string> contents);
        void WriteAllLines (string path, string[] contents);
        Task WriteAllLinesAsync (string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
        Task WriteAllLinesAsync (string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
        void WriteAllText (string path, string? contents);
        void WriteAllText (string path, string? contents, Encoding encoding);
        Task WriteAllTextAsync (string path, string? contents, CancellationToken cancellationToken = default);
        Task WriteAllTextAsync (string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
        
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Decrypt (string path);
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Encrypt (string path);
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

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
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

        public StreamWriter AppendText(string path)
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

        public IFileStream Create(string path, int bufferSize, FileOptions options)
        {
            return new FileStream(System.IO.File.Create(path, bufferSize, options));
        }

        public StreamWriter CreateText(string path)
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

        public FileAttributes GetAttributes(string path)
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

        public IFileStream Open(string path, FileMode mode)
        {
            return new FileStream(System.IO.File.Open(path, mode));
        }

        public IFileStream Open(string path, FileMode mode, FileAccess access)
        {
            return new FileStream(System.IO.File.Open(path, mode, access));
        }

        public IFileStream Open(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(System.IO.File.Open(path, mode, access, share));
        }

        public IFileStream OpenRead(string path)
        {
            return new FileStream(System.IO.File.OpenRead(path));
        }

        public StreamReader OpenText(string path)
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

        public Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
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

        public Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
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

        public void SetAttributes(string path, FileAttributes fileAttributes)
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

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
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

        public Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
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