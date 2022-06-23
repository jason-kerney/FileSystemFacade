using System;
using System.Collections.Generic;
using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// Exposes static methods for creating, moving, and enumerating through directories and subdirectories. This class cannot be inherited.
    /// It is preferable to use the Atomic File System. This should only be used when you are creating long file items that live longer then a single method.
    /// </summary>
    public static class Directory
    {
        /// <summary>
        /// Returns a factory to build IDirectoryInfo objects.
        /// </summary>
        public static IDirectoryInfoFactory DirectoryInfo { get; private set; } = new DirectoryInfoFactory();
        
        /// <summary>
        /// Returns a factory to build IFileSystemWatcher objects
        /// </summary>
        public static IFileSystemWatcherFactory FileSystemWatcher { get; private set; } = new FileSystemWatcherFactory();
        
        private static IDirectory Obj { get; set; } = new Primitives.Directory();

        /// <summary>
        /// Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <param name="path">The directory to create.</param>
        /// <returns>An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.</returns>
        public static IDirectoryInfo CreateDirectory(string path) => Obj.CreateDirectory(path);

        /// <summary>
        /// Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
        public static void Delete(string path) => Obj.Delete(path);

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
        /// </summary>
        /// <param name="path">The name of the directory to remove.</param>
        /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false.</param>
        public static void Delete(string path, bool recursive) => Obj.Delete(path, recursive);

        /// <summary>
        /// Puts the static Directory class in replacement mode. This allows for the temporary replacement of how the Directory class works.
        /// This enables testing.
        /// WARNING: This allows changing of how the system works until the returned object is disposed.
        /// </summary>
        /// <param name="replacement">The configuration of how the Directory static class will function until the returned object is disposed.</param>
        /// <returns>
        /// An IDisposable that when disposed will ensure that the Directory static class will return to default behaviors.
        /// WARNING: This allows changing of how the system works until the returned object is disposed.
        /// </returns>
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
        
        /// <summary>
        /// Returns a builder that helps build the object that determines how the Directory static class works when in replacement mode.
        /// This method facilitates testing.
        /// </summary>
        /// <returns>A builder that make building the configuration object used by the 'Replace' method easier.</returns>
        public static IStaticDirectoryReplacementBuilder BuildReplacement()
        {
            return new StaticDirectoryReplacementBuilder(DirectoryInfo, Obj, FileSystemWatcher);
        }

        /// <summary>
        /// Returns an enumerable collection of directory full names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public static IEnumerable<string> EnumerateDirectories(string path) => Obj.EnumerateDirectories(path);

        /// <summary>
        /// Returns an enumerable collection of directory full names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern.</returns>
        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern) =>
            Obj.EnumerateDirectories(path, searchPattern);

        /// <summary>
        /// Returns an enumerable collection of the directory full names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern and enumeration options.</returns>
        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.EnumerateDirectories(path, searchPattern, enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of directory full names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern and search option.</returns>
        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.SearchOption searchOption) => Obj.EnumerateDirectories(path, searchPattern, searchOption);

        /// <summary>
        /// Returns an enumerable collection of full file names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and search option.</returns>
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.SearchOption searchOption) => Obj.EnumerateFiles(path, searchPattern, searchOption);

        /// <summary>
        /// Returns an enumerable collection of full file names that match a search pattern and enumeration options in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and enumeration options.</returns>
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.EnumerateFiles(path, searchPattern, enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of full file names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public static IEnumerable<string> EnumerateFiles(string path) => Obj.EnumerateFiles(path);

        /// <summary>
        /// Returns an enumerable collection of full file names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern.</returns>
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern) =>
            Obj.EnumerateFiles(path, searchPattern);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path.</returns>
        public static IEnumerable<string> EnumerateFileSystemEntries(string path) =>
            Obj.EnumerateFileSystemEntries(path);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern.</returns>
        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern) =>
            Obj.EnumerateFileSystemEntries(path, searchPattern);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern and enumeration options in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path, that match the specified search pattern and the specified enumeration options.</returns>
        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.SearchOption searchOption) => Obj.EnumerateFileSystemEntries(path, searchPattern, searchOption);

        /// <summary>
        /// Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>true if path refers to an existing directory; false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.</returns>
        public static bool Exists(string? path) => Obj.Exists(path);

        /// <summary>
        /// Gets the creation date and time of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>A structure that is set to the creation date and time for the specified directory. This value is expressed in local time.</returns>
        public static DateTime GetCreationTime(string path) => Obj.GetCreationTime(path);

        /// <summary>
        /// Gets the current working directory of the application.
        /// </summary>
        /// <returns>A string that contains the absolute path of the current working directory, and does not end with a backslash (\).</returns>
        public static DateTime GetCreationTimeUtc(string path) => Obj.GetCreationTimeUtc(path);

        /// <summary>
        /// Gets the current working directory of the application.
        /// </summary>
        /// <returns>A string that contains the absolute path of the current working directory, and does not end with a backslash (\).</returns>
        public static string GetCurrentDirectory() => Obj.GetCurrentDirectory();

        /// <summary>
        /// Returns the names of the subdirectories (including their paths) that match the specified search pattern in the specified directory, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.</param>
        /// <returns>An array of the full names (including paths) of the subdirectories that match the specified criteria, or an empty array if no directories are found.</returns>
        public static string[] GetDirectories(string path, string searchPattern, System.IO.SearchOption searchOption) =>
            Obj.GetDirectories(path, searchPattern, searchOption);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) that match the specified search pattern and enumeration options in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of the full names (including paths) of the subdirectories that match the search pattern and enumeration options in the specified directory, or an empty array if no directories are found.</returns>
        public static string[] GetDirectories(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions) =>
            Obj.GetDirectories(path, searchPattern, enumerationOptions);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An array of the full names (including paths) of subdirectories in the specified path, or an empty array if no directories are found.</returns>
        public static string[] GetDirectories(string path) => Obj.GetDirectories(path);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) that match the specified search pattern in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of the full names (including paths) of the subdirectories that match the search pattern in the specified directory, or an empty array if no directories are found.</returns>
        public static string[] GetDirectories(string path, string searchPattern) =>
            Obj.GetDirectories(path, searchPattern);

        /// <summary>
        /// Returns the volume information, root information, or both for the specified path.
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>A string that contains the volume information, root information, or both for the specified path.</returns>
        public static string GetDirectoryRoot(string path) => Obj.GetDirectoryRoot(path);

        /// <summary>
        /// Returns the names of files (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory, or an empty array if no files are found.</returns>
        public static string[] GetFiles(string path) => Obj.GetFiles(path);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search pattern in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory that match the specified search pattern, or an empty array if no files are found.</returns>
        public static string[] GetFiles(string path, string searchPattern) => Obj.GetFiles(path, searchPattern);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search pattern and enumeration options in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory that match the specified search pattern and enumeration options, or an empty array if no files are found.</returns>
        public static string[] GetFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions) => Obj.GetFiles(path, searchPattern, enumerationOptions);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search pattern in the specified directory, using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory that match the specified search pattern and option, or an empty array if no files are found.</returns>
        public static string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption) =>
            Obj.GetFiles(path, searchPattern, searchOption);

        /// <summary>
        /// Returns the names of all files and subdirectories in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An array of the names of files and subdirectories in the specified directory, or an empty array if no files or subdirectories are found.</returns>
        public static string[] GetFileSystemEntries(string path) => Obj.GetFileSystemEntries(path);

        /// <summary>
        /// Returns an array of file names and directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of file and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.</returns>
        public static string[] GetFileSystemEntries(string path, string searchPattern) =>
            Obj.GetFileSystemEntries(path, searchPattern);

        /// <summary>
        /// Returns an array of file names and directory names that match a search pattern and enumeration options in a specified path. 
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of file names and directory names that match the specified search pattern and enumeration options, or an empty array if no files or directories are found.</returns>
        public static string[] GetFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions) =>
            Obj.GetFileSystemEntries(path, searchPattern, enumerationOptions);

        /// <summary>
        /// Returns an array of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An array of file the file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.</returns>
        public static string[] GetFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption) => Obj.GetFileSystemEntries(path, searchPattern, searchOption);

        /// <summary>
        /// Returns the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.</returns>
        public static DateTime GetLastAccessTime(string path) => Obj.GetLastAccessTime(path);

        /// <summary>
        /// Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.</returns>
        public static DateTime GetLastAccessTimeUtc(string path) => Obj.GetLastAccessTimeUtc(path);

        /// <summary>
        /// Returns the date and time the specified file or directory was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain write date and time information.</param>
        /// <returns>A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in local time.</returns>
        public static DateTime GetLastWriteTime(string path) => Obj.GetLastWriteTime(path);

        /// <summary>
        /// Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain write date and time information.</param>
        /// <returns>A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in UTC time.</returns>
        public static DateTime GetLastWriteTimeUtc(string path) => Obj.GetLastWriteTimeUtc(path);

        /// <summary>
        /// Retrieves the names of the logical drives on this computer in the form "<drive letter>:\".
        /// </summary>
        /// <returns>The logical drives on this computer.</returns>
        public static string[] GetLogicalDrives() => Obj.GetLogicalDrives();

        /// <summary>
        /// Retrieves the parent directory of the specified path, including both absolute and relative paths.
        /// </summary>
        /// <param name="path">The path for which to retrieve the parent directory.</param>
        /// <returns>The parent directory, or null if path is the root directory, including the root of a UNC server or share name.</returns>
        public static IDirectoryInfo? GetParent(string path) => Obj.GetParent(path);

        /// <summary>
        /// Moves a file or a directory and its contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the file or directory to move.</param>
        /// <param name="destDirName">The path to the new location for sourceDirName or its contents. If sourceDirName is a file, then destDirName must also be a file name.</param>
        public static void Move(string sourceDirName, string destDirName) => Obj.Move(sourceDirName, destDirName);

        /// <summary>
        /// Sets the creation date and time for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTime">The date and time the file or directory was last written to. This value is expressed in local time.</param>
        public static void SetCreationTime(string path, DateTime creationTime) =>
            Obj.SetCreationTime(path, creationTime);

        /// <summary>
        /// Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTimeUtc">The date and time the directory or file was created. This value is expressed in local time.</param>
        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc) =>
            Obj.SetCreationTimeUtc(path, creationTimeUtc);

        /// <summary>
        /// Sets the application's current working directory to the specified directory.
        /// </summary>
        /// <param name="path">The path to which the current working directory is set.</param>
        public static void SetCurrentDirectory(string path) => Obj.SetCurrentDirectory(path);

        /// <summary>
        /// Sets the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTime">An object that contains the value to set for the access date and time of path. This value is expressed in local time.</param>
        public static void SetLastAccessTime(string path, DateTime lastAccessTime) =>
            Obj.SetLastAccessTime(path, lastAccessTime);

        /// <summary>
        /// Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTimeUtc">An object that contains the value to set for the access date and time of path. This value is expressed in UTC time.</param>
        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) =>
            Obj.SetLastAccessTimeUtc(path, lastAccessTimeUtc);

        /// <summary>
        /// Sets the date and time a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTime">The date and time the directory was last written to. This value is expressed in local time.</param>
        public static void SetLastWriteTime(string path, DateTime lastWriteTime) =>
            Obj.SetLastWriteTime(path, lastWriteTime);

        /// <summary>
        /// Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.
        /// </summary>
        /// <param name="path">The file for which to set the date and time information.</param>
        /// <param name="lastWriteTimeUtc">A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.</param>
        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) =>
            Obj.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
    }
}