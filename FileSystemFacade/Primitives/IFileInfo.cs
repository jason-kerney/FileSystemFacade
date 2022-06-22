
namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Provides properties and instance methods for the creation, copying, deletion, moving, and opening of files, and aids in the creation of IFileStream objects.
    /// </summary>
    public interface IFileInfo: IFileSystemInfo
    {
        /// <summary>
        /// Gets an instance of the parent directory.
        /// </summary>
        public IDirectoryInfo? Directory { get; }
        /// <summary>
        /// Gets a string representing the directory's full path.
        /// </summary>
        string? DirectoryName { get; }
        /// <summary>
        /// Gets or sets a value that determines if the current file is read only.
        /// </summary>
        bool IsReadOnly { get; set; }
        /// <summary>
        /// Gets the size, in bytes, of the current file.
        /// </summary>
        public long Length { get; }
        
        /// <summary>
        /// Creates a StreamWriter that appends text to the file represented by this instance of the FileInfo.
        /// </summary>
        /// <returns>A new StreamWriter.</returns>
        System.IO.StreamWriter AppendText ();
        /// <summary>
        /// Copies an existing file to a new file, disallowing the overwriting of an existing file.
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param>
        /// <returns>A new file with a fully qualified path.</returns>
        IFileInfo CopyTo (string destFileName);
        /// <summary>
        /// Copies an existing file to a new file, allowing the overwriting of an existing file.
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param>
        /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false.</param>
        /// <returns>A new file, or an overwrite of an existing file if overwrite is true. If the file exists and overwrite is false, an IOException is thrown.</returns>
        IFileInfo CopyTo (string destFileName, bool overwrite);
        /// <summary>
        /// Creates a file.
        /// </summary>
        /// <returns>A new file.</returns>
        IFileStream Create ();
        /// <summary>
        /// Creates a StreamWriter that writes a new text file.
        /// </summary>
        /// <returns>A new StreamWriter.</returns>
        System.IO.StreamWriter CreateText ();
        
        /// <summary>
        /// Decrypts a file that was encrypted by the current account using the Encrypt() method.
        /// </summary>
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Decrypt ();
        
        /// <summary>
        /// Encrypts a file so that only the account used to encrypt the file can decrypt it.
        /// </summary>
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        void Encrypt ();
        
        /// <summary>
        /// Moves a specified file to a new location, providing the option to specify a new file name.
        /// </summary>
        /// <param name="destFileName">The path to move the file to, which can specify a different file name.</param>
        void MoveTo (string destFileName);
        /// <summary>
        /// Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.
        /// </summary>
        /// <param name="destFileName">The path to move the file to, which can specify a different file name.</param>
        /// <param name="overwrite">true to overwrite the destination file if it already exists; false otherwise.</param>
        void MoveTo (string destFileName, bool overwrite);
        /// <summary>
        /// Opens a file in the specified mode.
        /// </summary>
        /// <param name="mode">A FileMode constant specifying the mode (for example, Open or Append) in which to open the file.</param>
        /// <returns>A file opened in the specified mode, with read/write access and unshared.</returns>
        IFileStream Open (System.IO.FileMode mode);
        /// <summary>
        /// Opens a file in the specified mode with read, write, or read/write access.
        /// </summary>
        /// <param name="mode">A FileMode constant specifying the mode (for example, Open or Append) in which to open the file.</param>
        /// <param name="access">A FileAccess constant specifying whether to open the file with Read, Write, or ReadWrite file access.</param>
        /// <returns>A FileStream object opened in the specified mode and access, and unshared.</returns>
        IFileStream Open (System.IO.FileMode mode, System.IO.FileAccess access);
        /// <summary>
        /// Opens a file in the specified mode with read, write, or read/write access and the specified sharing option.
        /// </summary>
        /// <param name="mode">A FileMode constant specifying the mode (for example, Open or Append) in which to open the file.</param>
        /// <param name="access">A FileAccess constant specifying whether to open the file with Read, Write, or ReadWrite file access.</param>
        /// <param name="share">A FileShare constant specifying the type of access other FileStream objects have to this file.</param>
        /// <returns>A FileStream object opened with the specified mode, access, and sharing options.</returns>
        IFileStream Open (System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
        /// <summary>
        /// Creates a read-only FileStream.
        /// </summary>
        /// <returns>A new read-only FileStream object.</returns>
        IFileStream OpenRead ();
        /// <summary>
        /// Creates a StreamReader with UTF8 encoding that reads from an existing text file.
        /// </summary>
        /// <returns>A new StreamReader with UTF8 encoding.</returns>
        System.IO.StreamReader OpenText ();
        /// <summary>
        /// Creates a write-only FileStream.
        /// </summary>
        /// <returns>A write-only unshared FileStream object for a new or existing file.</returns>
        IFileStream OpenWrite ();
        /// <summary>
        /// Replaces the contents of a specified file with the file described by the current FileInfo object, deleting the original file, and creating a backup of the replaced file.
        /// </summary>
        /// <param name="destinationFileName">The name of a file to replace with the current file.</param>
        /// <param name="destinationBackupFileName">The name of a file with which to create a backup of the file described by the destFileName parameter.</param>
        /// <returns>A FileInfo object that encapsulates information about the file described by the destFileName parameter.</returns>
        IFileInfo Replace (string destinationFileName, string? destinationBackupFileName);
        /// <summary>
        /// Replaces the contents of a specified file with the file described by the current FileInfo object, deleting the original file, and creating a backup of the replaced file. Also specifies whether to ignore merge errors.
        /// </summary>
        /// <param name="destinationFileName">The name of a file to replace with the current file.</param>
        /// <param name="destinationBackupFileName">The name of a file with which to create a backup of the file described by the destFileName parameter.</param>
        /// <param name="ignoreMetadataErrors">true to ignore merge errors (such as attributes and ACLs) from the replaced file to the replacement file; otherwise false.</param>
        /// <returns></returns>
        IFileInfo Replace (string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
    }

    /// <summary>
    /// A factory to build IFileInfo Objects
    /// </summary>
    public interface IFileInfoFactory
    {
        /// <summary>
        /// Creates a new instance of the FileInfo class, which acts as a wrapper for a file path.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.</param>
        /// <returns>A new instance of the FileInfo class, which acts as a wrapper for a file path.</returns>
        IFileInfo GetFileInfo(string fileName);
    }

    internal class FileInfoFactory : IFileInfoFactory
    {
        public IFileInfo GetFileInfo(string fileName)
        {
            return new FileInfo(fileName);
        }
    }

    internal sealed class FileInfo: FileSystemInfo, IFileInfo
    {
        private readonly System.IO.FileInfo fileInfo;

        internal FileInfo(System.IO.FileInfo fileInfo) : base(fileInfo)
        {
            this.fileInfo = fileInfo;
        }
        
        internal FileInfo (string fileName) : this(new System.IO.FileInfo(fileName)) { }
        
        public IDirectoryInfo? Directory => new DirectoryInfo(fileInfo.Directory);

        public string? DirectoryName => fileInfo.DirectoryName;
        
        public bool IsReadOnly
        {
            get => fileInfo.IsReadOnly;
            set => fileInfo.IsReadOnly = value;
        }

        public long Length => fileInfo.Length;
        
        public System.IO.StreamWriter AppendText()
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

        public System.IO.StreamWriter CreateText()
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

        public IFileStream Open(System.IO.FileMode mode)
        {
            return new FileStream(fileInfo.Open(mode));
        }

        public IFileStream Open(System.IO.FileMode mode, System.IO.FileAccess access)
        {
            return new FileStream(fileInfo.Open(mode, access));
        }

        public IFileStream Open(System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share)
        {
            return new FileStream(fileInfo.Open(mode, access, share));
        }

        public IFileStream OpenRead()
        {
            return new FileStream(fileInfo.OpenRead());
        }

        public System.IO.StreamReader OpenText()
        {
            return fileInfo.OpenText();
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