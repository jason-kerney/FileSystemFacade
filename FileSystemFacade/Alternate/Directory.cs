using System;
using System.Collections.Generic;
using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    public static class Directory
    {
        public static IDirectoryInfoFactory DirectoryInfo { get; private set; } = new DirectoryInfoFactory();
        public static IFilesSystemWatcherFactory FileSystemWatcher { get; private set; } = new FilesSystemWatcherFactory();
        private static IDirectory Obj { get; set; } = new Primitives.Directory();

        public static IDirectoryInfo CreateDirectory(string path) => Obj.CreateDirectory(path);

        public static void Delete(string path) => Obj.Delete(path);

        public static void Delete(string path, bool recursive) => Obj.Delete(path, recursive);

        public static IDisposable Replace(IStaticDirectoryReplacement replacement)
        {
            var original = new StaticDirectoryReplacement(DirectoryInfo, Obj, FileSystemWatcher);

            DirectoryInfo = replacement.DirectorInfo;
            Obj = replacement.Directory;
            FileSystemWatcher = replacement.FileSystemWatcher;

            return new DisposableAction(() =>
            {
                DirectoryInfo = original.DirectorInfo;
                Obj = original.Directory;
                FileSystemWatcher = original.FileSystemWatcher;
            });
        }

        public static IStaticDirectoryReplacementBuilder BuildReplacement()
        {
            return new StaticDirectoryReplacementBuilder(DirectoryInfo, Obj, FileSystemWatcher);
        }

        public static IEnumerable<string> EnumerateDirectories(string path) => Obj.EnumerateDirectories(path);

        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern) =>
            Obj.EnumerateDirectories(path, searchPattern);

        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.EnumerateDirectories(path, searchPattern, enumerationOptions);

        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.SearchOption searchOption) => Obj.EnumerateDirectories(path, searchPattern, searchOption);

        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern,
            System.IO.SearchOption searchOption) => Obj.EnumerateFiles(path, searchPattern, searchOption);

        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.EnumerateFiles(path, searchPattern, enumerationOptions);

        public static IEnumerable<string> EnumerateFiles(string path) => Obj.EnumerateFiles(path);

        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern) =>
            Obj.EnumerateFiles(path, searchPattern);

        public static IEnumerable<string> EnumerateFileSystemEntries(string path) =>
            Obj.EnumerateFileSystemEntries(path);

        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern) =>
            Obj.EnumerateFileSystemEntries(path, searchPattern);

        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);

        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.SearchOption searchOption) => Obj.EnumerateFileSystemEntries(path, searchPattern, searchOption);

        public static bool Exists(string? path) => Obj.Exists(path);

        public static DateTime GetCreationTime(string path) => Obj.GetCreationTime(path);

        public static DateTime GetCreationTimeUtc(string path) => Obj.GetCreationTimeUtc(path);

        public static string GetCurrentDirectory() => Obj.GetCurrentDirectory();

        public static string[] GetDirectories(string path, string searchPattern, System.IO.SearchOption searchOption) =>
            Obj.GetDirectories(path, searchPattern, searchOption);

        public static string[] GetDirectories(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.GetDirectories(path, searchPattern, enumerationOptions);

        public static string[] GetDirectories(string path) => Obj.GetDirectories(path);

        public static string[] GetDirectories(string path, string searchPattern) =>
            Obj.GetDirectories(path, searchPattern);

        public static string GetDirectoryRoot(string path) => Obj.GetDirectoryRoot(path);

        public static string[] GetFiles(string path) => Obj.GetFiles(path);

        public static string[] GetFiles(string path, string searchPattern) => Obj.GetFiles(path, searchPattern);

        public static string[] GetFiles(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) => Obj.GetFiles(path, searchPattern, enumerationOptions);

        public static string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption) =>
            Obj.GetFiles(path, searchPattern, searchOption);

        public static string[] GetFileSystemEntries(string path) => Obj.GetFileSystemEntries(path);

        public static string[] GetFileSystemEntries(string path, string searchPattern) =>
            Obj.GetFileSystemEntries(path, searchPattern);

        public static string[] GetFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.GetFileSystemEntries(path, searchPattern, enumerationOptions);

        public static string[] GetFileSystemEntries(string path, string searchPattern,
            System.IO.SearchOption searchOption) => Obj.GetFileSystemEntries(path, searchPattern, searchOption);

        public static DateTime GetLastAccessTime(string path) => Obj.GetLastAccessTime(path);

        public static DateTime GetLastAccessTimeUtc(string path) => Obj.GetLastAccessTimeUtc(path);

        public static DateTime GetLastWriteTime(string path) => Obj.GetLastWriteTime(path);

        public static DateTime GetLastWriteTimeUtc(string path) => Obj.GetLastWriteTimeUtc(path);

        public static string[] GetLogicalDrives() => Obj.GetLogicalDrives();

        public static IDirectoryInfo? GetParent(string path) => Obj.GetParent(path);

        public static void Move(string sourceDirName, string destDirName) => Obj.Move(sourceDirName, destDirName);

        public static void SetCreationTime(string path, DateTime creationTime) =>
            Obj.SetCreationTime(path, creationTime);

        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc) =>
            Obj.SetCreationTimeUtc(path, creationTimeUtc);

        public static void SetCurrentDirectory(string path) => Obj.SetCurrentDirectory(path);

        public static void SetLastAccessTime(string path, DateTime lastAccessTime) =>
            Obj.SetLastAccessTime(path, lastAccessTime);

        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) =>
            Obj.SetLastAccessTimeUtc(path, lastAccessTimeUtc);

        public static void SetLastWriteTime(string path, DateTime lastWriteTime) =>
            Obj.SetLastWriteTime(path, lastWriteTime);

        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) =>
            Obj.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
    }
}