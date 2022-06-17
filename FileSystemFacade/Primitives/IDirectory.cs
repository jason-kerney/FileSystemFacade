using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemFacade.Primitives
{
    public interface IDirectory
    {
        IDirectoryInfo CreateDirectory (string path);
        void Delete (string path);
        void Delete (string path, bool recursive);
        IEnumerable<string> EnumerateDirectories (string path);
        IEnumerable<string> EnumerateDirectories (string path, string searchPattern);
        IEnumerable<string> EnumerateDirectories (string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IEnumerable<string> EnumerateDirectories (string path, string searchPattern, System.IO.SearchOption searchOption);
        IEnumerable<string> EnumerateFiles (string path, string searchPattern, System.IO.SearchOption searchOption);
        IEnumerable<string> EnumerateFiles (string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IEnumerable<string> EnumerateFiles (string path);
        IEnumerable<string> EnumerateFiles (string path, string searchPattern);
        IEnumerable<string> EnumerateFileSystemEntries (string path);
        IEnumerable<string> EnumerateFileSystemEntries (string path, string searchPattern);
        IEnumerable<string> EnumerateFileSystemEntries (string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        IEnumerable<string> EnumerateFileSystemEntries (string path, string searchPattern, System.IO.SearchOption searchOption);
        bool Exists (string? path);
        DateTime GetCreationTime (string path);
        DateTime GetCreationTimeUtc (string path);
        string GetCurrentDirectory ();
        string[] GetDirectories (string path, string searchPattern, System.IO.SearchOption searchOption);
        string[] GetDirectories (string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        string[] GetDirectories (string path);
        string[] GetDirectories (string path, string searchPattern);
        string GetDirectoryRoot (string path);
        string[] GetFiles (string path);
        string[] GetFiles (string path, string searchPattern);
        string[] GetFiles (string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        string[] GetFiles (string path, string searchPattern, System.IO.SearchOption searchOption);
        string[] GetFileSystemEntries (string path);
        string[] GetFileSystemEntries (string path, string searchPattern);
        string[] GetFileSystemEntries (string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
        string[] GetFileSystemEntries (string path, string searchPattern, System.IO.SearchOption searchOption);
        DateTime GetLastAccessTime (string path);
        DateTime GetLastAccessTimeUtc (string path);
        DateTime GetLastWriteTime (string path);
        DateTime GetLastWriteTimeUtc (string path);
        string[] GetLogicalDrives ();
        IDirectoryInfo? GetParent (string path);
        void Move (string sourceDirName, string destDirName);
        void SetCreationTime (string path, DateTime creationTime);
        void SetCreationTimeUtc (string path, DateTime creationTimeUtc);
        void SetCurrentDirectory (string path);
        void SetLastAccessTime (string path, DateTime lastAccessTime);
        void SetLastAccessTimeUtc (string path, DateTime lastAccessTimeUtc);
        void SetLastWriteTime (string path, DateTime lastWriteTime);
        void SetLastWriteTimeUtc (string path, DateTime lastWriteTimeUtc);
    }

    internal class Directory : IDirectory
    {
        public IDirectoryInfo CreateDirectory(string path)
        {
            return new DirectoryInfo(System.IO.Directory.CreateDirectory(path));
        }

        public void Delete(string path)
        {
            System.IO.Directory.Delete(path);
        }

        public void Delete(string path, bool recursive)
        {
            System.IO.Directory.Delete(path, recursive);
        }

        public IEnumerable<string> EnumerateDirectories(string path)
        {
            return System.IO.Directory.EnumerateDirectories(path);
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            return System.IO.Directory.EnumerateDirectories(path, searchPattern);
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.EnumerateDirectories(path, searchPattern, enumerationOptions);
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return System.IO.Directory.EnumerateDirectories(path, searchPattern, searchOption);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return System.IO.Directory.EnumerateFiles(path, searchPattern, searchOption);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.EnumerateFiles(path, searchPattern, enumerationOptions);
        }

        public IEnumerable<string> EnumerateFiles(string path)
        {
            return System.IO.Directory.EnumerateFiles(path);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return System.IO.Directory.EnumerateFiles(path, searchPattern);
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            return System.IO.Directory.EnumerateFileSystemEntries(path);
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern)
        {
            return System.IO.Directory.EnumerateFileSystemEntries(path, searchPattern);
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return System.IO.Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);
        }

        public bool Exists(string? path)
        {
            return System.IO.Directory.Exists(path);
        }

        public DateTime GetCreationTime(string path)
        {
            return System.IO.Directory.GetCreationTime(path);
        }

        public DateTime GetCreationTimeUtc(string path)
        {
            return System.IO.Directory.GetCreationTimeUtc(path);
        }

        public string GetCurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return System.IO.Directory.GetDirectories(path, searchPattern, searchOption);
        }

        public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.GetDirectories(path, searchPattern, enumerationOptions);
        }

        public string[] GetDirectories(string path)
        {
            return System.IO.Directory.GetDirectories(path);
        }

        public string[] GetDirectories(string path, string searchPattern)
        {
            return System.IO.Directory.GetDirectories(path, searchPattern);
        }

        public string GetDirectoryRoot(string path)
        {
            return System.IO.Directory.GetDirectoryRoot(path);
        }

        public string[] GetFiles(string path)
        {
            return System.IO.Directory.GetFiles(path);
        }

        public string[] GetFiles(string path, string searchPattern)
        {
            return System.IO.Directory.GetFiles(path, searchPattern);
        }

        public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.GetFiles(path, searchPattern, enumerationOptions);
        }

        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return System.IO.Directory.GetFiles(path, searchPattern, searchOption);
        }

        public string[] GetFileSystemEntries(string path)
        {
            return System.IO.Directory.GetFileSystemEntries(path);
        }

        public string[] GetFileSystemEntries(string path, string searchPattern)
        {
            return System.IO.Directory.GetFileSystemEntries(path, searchPattern);
        }

        public string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.GetFileSystemEntries(path, searchPattern, enumerationOptions);
        }

        public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return System.IO.Directory.GetFileSystemEntries(path, searchPattern, searchOption);
        }

        public DateTime GetLastAccessTime(string path)
        {
            return System.IO.Directory.GetLastAccessTime(path);
        }

        public DateTime GetLastAccessTimeUtc(string path)
        {
            return System.IO.Directory.GetLastAccessTimeUtc(path);
        }

        public DateTime GetLastWriteTime(string path)
        {
            return System.IO.Directory.GetLastWriteTime(path);
        }

        public DateTime GetLastWriteTimeUtc(string path)
        {
            return System.IO.Directory.GetLastWriteTimeUtc(path);
        }

        public string[] GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives();
        }

        public IDirectoryInfo? GetParent(string path)
        {
            var parent = System.IO.Directory.GetParent(path);
            return parent == null ? null : new DirectoryInfo(parent);
        }

        public void Move(string sourceDirName, string destDirName)
        {
            System.IO.Directory.Move(sourceDirName, destDirName);
        }

        public void SetCreationTime(string path, DateTime creationTime)
        {
            System.IO.Directory.SetCreationTime(path, creationTime);
        }

        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            System.IO.Directory.SetCreationTimeUtc(path, creationTimeUtc);
        }

        public void SetCurrentDirectory(string path)
        {
            System.IO.Directory.SetCurrentDirectory(path);
        }

        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            System.IO.Directory.SetLastAccessTime(path, lastAccessTime);
        }

        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            System.IO.Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
        }

        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            System.IO.Directory.SetLastWriteTime(path, lastWriteTime);
        }

        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            System.IO.Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
        }
    }
}