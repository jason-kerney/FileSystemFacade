using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace FileSystemFacade.Primitives
{
    public interface IDirectoryInfo : IFileSystemInfo
    {
        IDirectoryInfo? Parent { get; }
        IDirectoryInfo Root { get; }

        void Create();
        IDirectoryInfo CreateSubdirectory(string path);
        void Delete(bool recursive);
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, System.IO.SearchOption searchOption);

        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        IEnumerable<IDirectoryInfo> EnumerateDirectories();
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern);
        IEnumerable<IFileInfo> EnumerateFiles();
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern);
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.SearchOption searchOption);

        IEnumerable<IFileSystemInfo>
            EnumerateFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption);

        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern);

        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        IDirectoryInfo[] GetDirectories();
        IDirectoryInfo[] GetDirectories(string searchPattern);
        IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption);
        IFileInfo[] GetFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IFileInfo[] GetFiles();
        IFileInfo[] GetFiles(string searchPattern);
        IFileSystemInfo[] GetFileSystemInfos();
        IFileSystemInfo[] GetFileSystemInfos(string searchPattern);
        IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption);
        void MoveTo(string destDirName);
    }

    public interface IDirectoryInfoBuilder
    {
        IDirectoryInfo GetDirectoryInfo(string path);
    }

    internal class DirectoryInfoBuilder : IDirectoryInfoBuilder
    {
        public IDirectoryInfo GetDirectoryInfo(string path)
        {
            return new DirectoryInfo(path);
        }
    }

    public class DirectoryInfo : IDirectoryInfo
    {
        private readonly System.IO.DirectoryInfo directoryInfo;

        internal DirectoryInfo(System.IO.DirectoryInfo directoryInfo)
        {
            this.directoryInfo = directoryInfo;
        }
        
        internal DirectoryInfo (string path) : this(new System.IO.DirectoryInfo(path)) {}

        public override string ToString()
        {
            return directoryInfo.ToString();
        }

        public FileAttributes Attributes
        {
            get => directoryInfo.Attributes;
            set => directoryInfo.Attributes = value;
        }
        
        public DateTime CreationTime
        {
            get => directoryInfo.CreationTime;
            set => directoryInfo.CreationTime = value;
        }
        
        public DateTime CreationTimeUtc
        {
            get => directoryInfo.CreationTimeUtc;
            set => directoryInfo.CreationTimeUtc = value;
        }

        public bool Exists => directoryInfo.Exists;
        public string Extension => directoryInfo.Extension;
        public string FullName => directoryInfo.FullName;
        
        public DateTime LastAccessTime
        {
            get => directoryInfo.LastAccessTime;
            set => directoryInfo.LastAccessTime = value;
        }
        
        public DateTime LastAccessTimeUtc
        {
            get => directoryInfo.LastAccessTimeUtc;
            set => directoryInfo.LastAccessTimeUtc = value;
        }
        
        public DateTime LastWriteTime
        {
            get => directoryInfo.LastWriteTime;
            set => directoryInfo.LastWriteTime = value;
        }
        
        public DateTime LastWriteTimeUtc
        {
            get => directoryInfo.LastWriteTimeUtc;
            set => directoryInfo.LastWriteTimeUtc = value;
        }

        public string Name => directoryInfo.Name;
        
        public void Delete()
        {
            directoryInfo.Delete();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            directoryInfo.GetObjectData(info, context);
        }

        public void Refresh()
        {
            directoryInfo.Refresh();
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

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            return 
                from directory in directoryInfo.EnumerateDirectories(searchPattern, searchOption)
                select new DirectoryInfo(directory);
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, EnumerationOptions enumerationOptions)
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

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return
                from file in directoryInfo.EnumerateFiles(searchPattern, enumerationOptions)
                select new FileInfo(file);
        }

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            return
                from file in directoryInfo.EnumerateFiles(searchPattern, searchOption)
                select new FileInfo(file);
        }

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
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

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions)
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

        public IDirectoryInfo[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return (
                from directory in directoryInfo.GetDirectories(searchPattern, enumerationOptions)
                select (IDirectoryInfo)new DirectoryInfo(directory)
            ).ToArray();
        }

        public IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            return (
                from directory in directoryInfo.GetDirectories(searchPattern, searchOption)
                select (IDirectoryInfo)new DirectoryInfo(directory)
            ).ToArray();
        }

        public IFileInfo[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return (
                from file in directoryInfo.GetFiles(searchPattern, enumerationOptions)
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

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return (
                from file in directoryInfo.GetFileSystemInfos(searchPattern, enumerationOptions)
                select (IFileSystemInfo)new FileSystemInfo(file)
            ).ToArray();
        }

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
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