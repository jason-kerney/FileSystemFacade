using System;
using System.Runtime.Serialization;

namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Provides the interface class for both IFileInfo and IDirectoryInfo objects.
    /// </summary>
    public interface IFileSystemInfo
    {
        /// <summary>
        /// Gets or sets the attributes for the current file or directory.
        /// </summary>
        System.IO.FileAttributes Attributes { get; set; }
        /// <summary>
        /// Gets or sets the creation time of the current file or directory.
        /// </summary>
        DateTime CreationTime { get; set; }
        /// <summary>
        /// Gets or sets the creation time, in coordinated universal time (UTC), of the current file or directory.
        /// </summary>
        DateTime CreationTimeUtc { get; set; }
        /// <summary>
        /// Gets a value indicating whether the file or directory exists.
        /// </summary>
        bool Exists { get; }
        /// <summary>
        /// Gets the extension part of the file name, including the leading dot . even if it is the entire file name, or an empty string if no extension is present.
        /// </summary>
        string Extension { get; }
        /// <summary>
        /// Gets the full path of the directory or file.
        /// </summary>
        string FullName { get; }
        /// <summary>
        /// Gets or sets the time the current file or directory was last accessed.
        /// </summary>
        DateTime LastAccessTime { get; set; }
        /// <summary>
        /// Gets or sets the time, in coordinated universal time (UTC), that the current file or directory was last accessed.
        /// </summary>
        DateTime LastAccessTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the time when the current file or directory was last written to.
        /// </summary>
        DateTime LastWriteTime { get; set; }
        /// <summary>
        /// Gets or sets the time, in coordinated universal time (UTC), when the current file or directory was last written to.
        /// </summary>
        DateTime LastWriteTimeUtc { get; set; }
        /// <summary>
        /// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Deletes a file or directory.
        /// </summary>
        void Delete ();
        /// <summary>
        /// Sets the SerializationInfo object with the file name and additional exception information.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        void GetObjectData (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
        /// <summary>
        /// Refreshes the state of the object.
        /// </summary>
        void Refresh ();
    }

    internal class FileSystemInfo : IFileSystemInfo
    {
        private readonly System.IO.FileSystemInfo fileSystemInfo;

        public FileSystemInfo(System.IO.FileSystemInfo fileSystemInfo)
        {
            this.fileSystemInfo = fileSystemInfo;
        }
        
        public System.IO.FileAttributes Attributes
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
