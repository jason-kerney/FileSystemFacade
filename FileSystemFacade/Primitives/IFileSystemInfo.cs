using System;
using System.IO;
using System.Runtime.Serialization;

namespace FileSystemFacade.Primitives
{
    public interface IFileSystemInfo
    {
        FileAttributes Attributes { get; set; }
        DateTime CreationTime { get; set; }
        DateTime CreationTimeUtc { get; set; }
        bool Exists { get; }
        string Extension { get; }
        string FullName { get; }
        DateTime LastAccessTime { get; set; }
        DateTime LastAccessTimeUtc { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastWriteTimeUtc { get; set; }
        string Name { get; }
        
        void Delete ();
        void GetObjectData (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
        void Refresh ();
    }

    internal class FileSystemInfo : IFileSystemInfo
    {
        private readonly System.IO.FileSystemInfo fileSystemInfo;

        public FileSystemInfo(System.IO.FileSystemInfo fileSystemInfo)
        {
            this.fileSystemInfo = fileSystemInfo;
        }

        public FileAttributes Attributes
        {
            get => fileSystemInfo.Attributes;
            set => fileSystemInfo.Attributes = value;
        }
        
        public DateTime CreationTime
        {
            get => fileSystemInfo.CreationTime;
            set => fileSystemInfo.CreationTime = value;
        }
        
        public DateTime CreationTimeUtc
        {
            get => fileSystemInfo.CreationTimeUtc;
            set => fileSystemInfo.CreationTimeUtc = value;
        }

        public bool Exists => fileSystemInfo.Exists;
        public string Extension => fileSystemInfo.Extension;
        public string FullName => fileSystemInfo.FullName;
        
        public DateTime LastAccessTime
        {
            get => fileSystemInfo.LastAccessTime;
            set => fileSystemInfo.LastAccessTime = value;
        }
        
        public DateTime LastAccessTimeUtc
        {
            get => fileSystemInfo.LastAccessTimeUtc;
            set => fileSystemInfo.LastAccessTimeUtc = value;
        }
        
        public DateTime LastWriteTime
        {
            get => fileSystemInfo.LastWriteTime;
            set => fileSystemInfo.LastWriteTime = value;
        }
        
        public DateTime LastWriteTimeUtc
        {
            get => fileSystemInfo.LastWriteTimeUtc;
            set => fileSystemInfo.LastWriteTimeUtc = value;
        }

        public string Name => fileSystemInfo.Name;
        
        public void Delete()
        {
            fileSystemInfo.Delete();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            fileSystemInfo.GetObjectData(info, context);
        }

        public void Refresh()
        {
            fileSystemInfo.Refresh();
        }
    }
}
