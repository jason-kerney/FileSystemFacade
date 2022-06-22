using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Exposes methods for creating, moving, and enumerating through directories and subdirectories.
    /// </summary>
    public interface IDirectoryInfo : IFileSystemInfo
    {
        /// <summary>
        /// Gets the parent directory of a specified subdirectory.
        /// </summary>
        IDirectoryInfo? Parent { get; }
        /// <summary>
        /// Gets the root portion of the directory.
        /// </summary>
        IDirectoryInfo Root { get; }

        /// <summary>
        /// Creates a directory.
        /// </summary>
        void Create();
        /// <summary>
        /// Creates a subdirectory or subdirectories on the specified path. The specified path can be relative to this instance of the DirectoryInfo class.
        /// </summary>
        /// <param name="path">The specified path. This cannot be a different disk volume or Universal Naming Convention (UNC) name.</param>
        /// <returns>The last directory specified in path.</returns>
        IDirectoryInfo CreateSubdirectory(string path);
        /// <summary>
        /// Deletes this instance of a DirectoryInfo, specifying whether to delete subdirectories and files.
        /// </summary>
        /// <param name="recursive">true to delete this directory, its subdirectories, and all files; otherwise, false.</param>
        void Delete(bool recursive);
        /// <summary>
        /// Returns an enumerable collection of directory information that matches a specified search pattern and search subdirectory option.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of directories that matches searchPattern and searchOption.</returns>
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns an enumerable collection of directory information that matches the specified search pattern and enumeration options.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of directories that matches searchPattern and enumerationOptions.</returns>
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of directory information in the current directory.
        /// </summary>
        /// <returns>An enumerable collection of directories in the current directory.</returns>
        IEnumerable<IDirectoryInfo> EnumerateDirectories();
        
        /// <summary>
        /// Returns an enumerable collection of directory information that matches a specified search pattern.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of directories that matches searchPattern.</returns>
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern);
        
        /// <summary>
        /// Returns an enumerable collection of file information in the current directory.
        /// </summary>
        /// <returns>An enumerable collection of the files in the current directory.</returns>
        IEnumerable<IFileInfo> EnumerateFiles();
        
        /// <summary>
        /// Returns an enumerable collection of file information that matches a search pattern. 
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of files that matches searchPattern.</returns>
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern);
        
        /// <summary>
        /// Returns an enumerable collection of file information that matches the specified search pattern and enumeration options.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of files that matches searchPattern and enumerationOptions.</returns>
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        
        /// <summary>
        /// Returns an enumerable collection of file information that matches a specified search pattern and search subdirectory option.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of files that matches searchPattern and searchOption.</returns>
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns an enumerable collection of file system information that matches a specified search pattern and search subdirectory option.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns></returns>
        IEnumerable<IFileSystemInfo>
            EnumerateFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns an enumerable collection of file system information in the current directory.
        /// </summary>
        /// <returns>An enumerable collection of file system information in the current directory.</returns>
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();
        
        /// <summary>
        /// Returns an enumerable collection of file system information that matches a specified search pattern.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of file system information objects that matches searchPattern.</returns>
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern);

        /// <summary>
        /// Returns an enumerable collection of file system information that matches the specified search pattern and enumeration options.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of file system information objects that matches searchPattern and enumerationOptions.</returns>
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns the subdirectories of the current directory.
        /// </summary>
        /// <returns>An array of IDirectoryInfo objects.</returns>
        IDirectoryInfo[] GetDirectories();
        
        /// <summary>
        /// Returns an array of directories in the current IDirectoryInfo matching the given search criteria.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of type IDirectoryInfo matching searchPattern.</returns>
        IDirectoryInfo[] GetDirectories(string searchPattern);
        
        /// <summary>
        /// Returns an array of directories in the current IDirectoryInfo matching the specified search pattern and enumeration options.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of type IDirectoryInfo matching searchPattern and enumerationOptions.</returns>
        IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        
        /// <summary>
        /// Returns an array of directories in the current IDirectoryInfo matching the given search criteria and using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns></returns>
        IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption);
        
        /// <summary>
        /// Returns a file list from the current directory matching the specified search pattern and enumeration options.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of IFileInfo objects that match searchPattern and enumerationOptions.</returns>
        IFileInfo[] GetFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns a file list from the current directory matching the given search pattern and using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>An array of type IFileInfo.</returns>
        IFileInfo[] GetFiles(string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns a file list from the current directory.
        /// </summary>
        /// <returns>An array of type IFileInfo.</returns>
        IFileInfo[] GetFiles();
        
        /// <summary>
        /// Returns a file list from the current directory matching the given search pattern.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of type IFileInfo.</returns>
        IFileInfo[] GetFiles(string searchPattern);
        
        /// <summary>
        /// Returns an array of IFileSystemInfo entries representing all the files and subdirectories in a directory.
        /// </summary>
        /// <returns>An array of IFileSystemInfo entries.</returns>
        IFileSystemInfo[] GetFileSystemInfos();
        
        /// <summary>
        /// Retrieves an array of IFileSystemInfo objects representing the files and subdirectories that match the specified search criteria.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories and files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of IFileSystemInfo objects matching the search criteria.</returns>
        IFileSystemInfo[] GetFileSystemInfos(string searchPattern);
        
        /// <summary>
        /// Retrieves an array of IFileSystemInfo objects representing the files and subdirectories that match the specified search pattern and enumeration options.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories and files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of IFileSystemInfo objects matching searchPattern and enumerationOptions.</returns>
        IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        
        /// <summary>
        /// Retrieves an array of IFileSystemInfo objects that represent the files and subdirectories matching the specified search criteria.
        /// </summary>
        /// <param name="searchPattern">The search string to match against the names of directories and files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An array of file system entries that match the search criteria.</returns>
        IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption);
        void MoveTo(string destDirName);
    }

    /// <summary>
    /// A factory for building IDirectoryInfo objects
    /// </summary>
    public interface IDirectoryInfoFactory
    {
        /// <summary>
        /// Creates a new instance of the IDirectoryInfo interface on the specified path.
        /// </summary>
        /// <param name="path">A string specifying the path on which to create the IDirectoryInfo.</param>
        /// <returns>A new instance of the IDirectoryInfo interface on the specified path.</returns>
        IDirectoryInfo GetDirectoryInfo(string path);
    }

    internal class DirectoryInfoFactory : IDirectoryInfoFactory
    {
        public IDirectoryInfo GetDirectoryInfo(string path)
        {
            return new DirectoryInfo(path);
        }
    }

    internal sealed class DirectoryInfo : FileSystemInfo, IDirectoryInfo
    {
        private readonly System.IO.DirectoryInfo directoryInfo;

        internal DirectoryInfo(System.IO.DirectoryInfo directoryInfo): base(directoryInfo)
        {
            this.directoryInfo = directoryInfo;
        }
        
        internal DirectoryInfo (string path) : this(new System.IO.DirectoryInfo(path)) {}

        public override string ToString()
        {
            return directoryInfo.ToString();
        }

        public IDirectoryInfo Parent => directoryInfo.Parent == null ? null : new DirectoryInfo(directoryInfo.Parent);
        public IDirectoryInfo Root => new DirectoryInfo(directoryInfo.Root);
        public void Create()
        {
            directoryInfo.Create();
        }

        public IDirectoryInfo CreateSubdirectory(string path)
        {
            return new DirectoryInfo(directoryInfo.CreateSubdirectory(path));
        }

        public void Delete(bool recursive)
        {
            directoryInfo.Delete(recursive);
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, System.IO.SearchOption searchOption)
        {
            return 
                from directory in directoryInfo.EnumerateDirectories(searchPattern, searchOption)
                select new DirectoryInfo(directory);
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return
                from directory in directoryInfo.EnumerateDirectories(searchPattern, enumerationOptions)
                select new DirectoryInfo(directory);
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            return
                from directory in directoryInfo.EnumerateDirectories()
                select new DirectoryInfo(directory);
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern)
        {
            return
                from directory in directoryInfo.EnumerateDirectories()
                select new DirectoryInfo(directory);

        }

        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            return
                from file in directoryInfo.EnumerateFiles()
                select new FileInfo(file);
        }

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern)
        {
            return
                from file in directoryInfo.EnumerateFiles(searchPattern)
                select new FileInfo(file);
        }

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return
                from file in directoryInfo.EnumerateFiles(searchPattern, enumerationOptions)
                select new FileInfo(file);
        }

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.SearchOption searchOption)
        {
            return
                from file in directoryInfo.EnumerateFiles(searchPattern, searchOption)
                select new FileInfo(file);
        }

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption)
        {
            return
                from fileSystem in directoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption)
                select new FileSystemInfo(fileSystem);
        }

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos()
        {
            return
                from fileSystem in directoryInfo.EnumerateFileSystemInfos()
                select new FileSystemInfo(fileSystem);
        }

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
        {
            return
                from fileSystem in directoryInfo.EnumerateFileSystemInfos(searchPattern)
                select new FileSystemInfo(fileSystem);
        }

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return
                from fileSystem in directoryInfo.EnumerateFileSystemInfos(searchPattern, enumerationOptions)
                select new FileSystemInfo(fileSystem);
        }

        public IDirectoryInfo[] GetDirectories()
        {
            return (
                from directory in directoryInfo.GetDirectories()
                select (IDirectoryInfo)new DirectoryInfo(directory)
            ).ToArray();
        }

        public IDirectoryInfo[] GetDirectories(string searchPattern)
        {
            return (
                from directory in directoryInfo.GetDirectories(searchPattern)
                select (IDirectoryInfo)new DirectoryInfo(directory)
            ).ToArray();
        }

        public IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return (
                from directory in directoryInfo.GetDirectories(searchPattern, enumerationOptions)
                select (IDirectoryInfo)new DirectoryInfo(directory)
            ).ToArray();
        }

        public IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption)
        {
            return (
                from directory in directoryInfo.GetDirectories(searchPattern, searchOption)
                select (IDirectoryInfo)new DirectoryInfo(directory)
            ).ToArray();
        }

        public IFileInfo[] GetFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return (
                from file in directoryInfo.GetFiles(searchPattern, enumerationOptions)
                select (IFileInfo)new FileInfo(file)
            ).ToArray();
        }

        public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            return (
                from file in directoryInfo.GetFiles(searchPattern, searchOption)
                select (IFileInfo)new FileInfo(file)
            ).ToArray();
        }

        public IFileInfo[] GetFiles()
        {
            return (
                from file in directoryInfo.GetFiles()
                select (IFileInfo)new FileInfo(file)
            ).ToArray();
        }

        public IFileInfo[] GetFiles(string searchPattern)
        {
            return (
                from file in directoryInfo.GetFiles(searchPattern)
                select (IFileInfo)new FileInfo(file)
            ).ToArray();
        }

        public IFileSystemInfo[] GetFileSystemInfos()
        {
            return (
                from file in directoryInfo.GetFileSystemInfos()
                select (IFileSystemInfo)new FileSystemInfo(file)
            ).ToArray();
        }

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern)
        {
            return (
                from file in directoryInfo.GetFileSystemInfos(searchPattern)
                select (IFileSystemInfo)new FileSystemInfo(file)
            ).ToArray();
        }

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return (
                from file in directoryInfo.GetFileSystemInfos(searchPattern, enumerationOptions)
                select (IFileSystemInfo)new FileSystemInfo(file)
            ).ToArray();
        }

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption)
        {
            return (
                from file in directoryInfo.GetFileSystemInfos(searchPattern, searchOption)
                select (IFileSystemInfo)new FileSystemInfo(file)
            ).ToArray();
        }

        public void MoveTo(string destDirName)
        {
            directoryInfo.MoveTo(destDirName);
        }
    }
}