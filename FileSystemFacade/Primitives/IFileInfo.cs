using System;
using System.IO;
using System.Runtime.Serialization;

namespace FileSystemFacade.Primitives
{
    public interface IFileInfo: IFileSystemInfo
    {
        public IDirectoryInfo? Directory { get; }
        string? DirectoryName { get; }
        bool IsReadOnly { get; set; }
        public long Length { get; }
        
        System.IO.StreamWriter AppendText ();
        IFileInfo CopyTo (string destFileName);
        IFileInfo CopyTo (string destFileName, bool overwrite);
        IFileStream Create ();
        System.IO.StreamWriter CreateText ();
        
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Decrypt ();
        
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Encrypt ();
        
        void MoveTo (string destFileName);
        void MoveTo (string destFileName, bool overwrite);
        IFileStream Open (System.IO.FileMode mode);
        IFileStream Open (System.IO.FileMode mode, System.IO.FileAccess access);
        IFileStream Open (System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
        IFileStream OpenWrite ();
        IFileInfo Replace (string destinationFileName, string? destinationBackupFileName);
        IFileInfo Replace (string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
    }

    public interface IFileInfoBuilder
    {
        IFileInfo GetFileInfo(string fileName);
    }

    internal class FileInfoBuilder : IFileInfoBuilder
    {
        public IFileInfo GetFileInfo(string fileName)
        {
            return new FileInfo(fileName);
        }
    }

    public class FileInfo: IFileInfo
    {
        private readonly System.IO.FileInfo fileInfo;

        internal FileInfo(System.IO.FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }
        
        internal FileInfo (string fileName) : this(new System.IO.FileInfo(fileName)) { }
        
        public FileAttributes Attributes
        {
            get => fileInfo.Attributes;
            set => fileInfo.Attributes = value;
        }
        
        public DateTime CreationTime
        {
            get => fileInfo.CreationTime;
            set => fileInfo.CreationTime = value;
        }
        
        public DateTime CreationTimeUtc
        {
            get => fileInfo.CreationTimeUtc;
            set => fileInfo.CreationTimeUtc = value;
        }

        public bool Exists => fileInfo.Exists;
        public string Extension => fileInfo.Extension;
        public string FullName => fileInfo.FullName;
        
        public DateTime LastAccessTime
        {
            get => fileInfo.LastAccessTime;
            set => fileInfo.LastAccessTime = value;
        }
        
        public DateTime LastAccessTimeUtc
        {
            get => fileInfo.LastAccessTimeUtc;
            set => fileInfo.LastAccessTimeUtc = value;
        }
        
        public DateTime LastWriteTime
        {
            get => fileInfo.LastWriteTime;
            set => fileInfo.LastWriteTime = value;
        }

        public DateTime LastWriteTimeUtc
        {
            get => fileInfo.LastWriteTimeUtc;
            set => fileInfo.LastWriteTimeUtc = value;
        }

        public string Name => fileInfo.Name;
        
        public void Delete()
        {
            fileInfo.Delete();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            fileInfo.GetObjectData(info, context);
        }

        public void Refresh()
        {
            fileInfo.Refresh();
        }
        
        public IDirectoryInfo? Directory => new DirectoryInfo(fileInfo.Directory);

        public string? DirectoryName => fileInfo.DirectoryName;
        
        public bool IsReadOnly
        {
            get => fileInfo.IsReadOnly;
            set => fileInfo.IsReadOnly = value;
        }

        public long Length => fileInfo.Length;
        
        public StreamWriter AppendText()
        {
            return fileInfo.AppendText();
        }

        public IFileInfo CopyTo(string destFileName)
        {
            return new FileInfo(fileInfo.CopyTo(destFileName));
        }

        public IFileInfo CopyTo(string destFileName, bool overwrite)
        {
            return new FileInfo(fileInfo.CopyTo(destFileName, overwrite));
        }

        public IFileStream Create()
        {
            return new FileStream(fileInfo.Create());
        }

        public StreamWriter CreateText()
        {
            return fileInfo.CreateText();
        }

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public void Decrypt()
        {
            fileInfo.Decrypt();
        }

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public void Encrypt()
        {
            fileInfo.Encrypt();
        }

        public void MoveTo(string destFileName)
        {
            fileInfo.MoveTo(destFileName);
        }

        public void MoveTo(string destFileName, bool overwrite)
        {
            fileInfo.MoveTo(destFileName, overwrite);
        }

        public IFileStream Open(FileMode mode)
        {
            return new FileStream(fileInfo.Open(mode));
        }

        public IFileStream Open(FileMode mode, FileAccess access)
        {
            return new FileStream(fileInfo.Open(mode, access));
        }

        public IFileStream Open(FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(fileInfo.Open(mode, access, share));
        }

        public IFileStream OpenWrite()
        {
            return new FileStream(fileInfo.OpenWrite());
        }

        public IFileInfo Replace(string destinationFileName, string? destinationBackupFileName)
        {
            return new FileInfo(fileInfo.Replace(destinationFileName, destinationBackupFileName));
        }

        public IFileInfo Replace(string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors)
        {
            return new FileInfo(fileInfo.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
        }

        public override string ToString()
        {
            return fileInfo.ToString();
        }
    }
}