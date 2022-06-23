using System;
using System.Collections.Generic;

namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Exposes methods for creating, moving, and enumerating through directories and subdirectories without the need for an object representing those things.
    /// </summary>
    public interface IDirectory
    {
        /// <summary>
        /// Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <param name="path">The directory to create.</param>
        /// <returns>An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.</returns>
        IDirectoryInfo CreateDirectory(string path);

        /// <summary>
        /// Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
        void Delete(string path);

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
        /// </summary>
        /// <param name="path">The name of the directory to remove.</param>
        /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false.</param>
        void Delete(string path, bool recursive);

        /// <summary>
        /// Returns an enumerable collection of directory full names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        IEnumerable<string> EnumerateDirectories(string path);

        /// <summary>
        /// Returns an enumerable collection of directory full names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern.</returns>
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern);

        /// <summary>
        /// Returns an enumerable collection of the directory full names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern and enumeration options.</returns>
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of directory full names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern and search option.</returns>
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns an enumerable collection of full file names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and search option.</returns>
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns an enumerable collection of full file names that match a search pattern and enumeration options in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and enumeration options.</returns>
        IEnumerable<string> EnumerateFiles(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of full file names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        IEnumerable<string> EnumerateFiles(string path);

        /// <summary>
        /// Returns an enumerable collection of full file names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern.</returns>
        IEnumerable<string> EnumerateFiles(string path, string searchPattern);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path.</returns>
        IEnumerable<string> EnumerateFileSystemEntries(string path);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern.</returns>
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern and enumeration options in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path, that match the specified search pattern and the specified enumeration options.</returns>
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.SearchOption searchOption);

        /// <summary>
        /// Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>true if path refers to an existing directory; false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.</returns>
        bool Exists(string? path);

        /// <summary>
        /// Gets the creation date and time of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>A structure that is set to the creation date and time for the specified directory. This value is expressed in local time.</returns>
        DateTime GetCreationTime(string path);

        /// <summary>
        /// Gets the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>A structure that is set to the creation date and time for the specified directory. This value is expressed in UTC time.</returns>
        DateTime GetCreationTimeUtc(string path);

        /// <summary>
        /// Gets the current working directory of the application.
        /// </summary>
        /// <returns>A string that contains the absolute path of the current working directory, and does not end with a backslash (\).</returns>
        string GetCurrentDirectory();

        /// <summary>
        /// Returns the names of the subdirectories (including their paths) that match the specified search pattern in the specified directory, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.</param>
        /// <returns>An array of the full names (including paths) of the subdirectories that match the specified criteria, or an empty array if no directories are found.</returns>
        string[] GetDirectories(string path, string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) that match the specified search pattern and enumeration options in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of the full names (including paths) of the subdirectories that match the search pattern and enumeration options in the specified directory, or an empty array if no directories are found.</returns>
        string[] GetDirectories(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An array of the full names (including paths) of subdirectories in the specified path, or an empty array if no directories are found.</returns>
        string[] GetDirectories(string path);

        /// <summary>
        /// Returns the names of subdirectories (including their paths) that match the specified search pattern in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of the full names (including paths) of the subdirectories that match the search pattern in the specified directory, or an empty array if no directories are found.</returns>
        string[] GetDirectories(string path, string searchPattern);

        /// <summary>
        /// Returns the volume information, root information, or both for the specified path.
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>A string that contains the volume information, root information, or both for the specified path.</returns>
        string GetDirectoryRoot(string path);

        /// <summary>
        /// Returns the names of files (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory, or an empty array if no files are found.</returns>
        string[] GetFiles(string path);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search pattern in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory that match the specified search pattern, or an empty array if no files are found.</returns>
        string[] GetFiles(string path, string searchPattern);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search pattern and enumeration options in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory that match the specified search pattern and enumeration options, or an empty array if no files are found.</returns>
        string[] GetFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search pattern in the specified directory, using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.</param>
        /// <returns>An array of the full names (including paths) for the files in the specified directory that match the specified search pattern and option, or an empty array if no files are found.</returns>
        string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// Returns the names of all files and subdirectories in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>An array of the names of files and subdirectories in the specified directory, or an empty array if no files or subdirectories are found.</returns>
        string[] GetFileSystemEntries(string path);

        /// <summary>
        /// Returns an array of file names and directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of file and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <returns>An array of file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.</returns>
        string[] GetFileSystemEntries(string path, string searchPattern);

        /// <summary>
        /// Returns an array of file names and directory names that match a search pattern and enumeration options in a specified path. 
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.</param>
        /// <param name="enumerationOptions">An object that describes the search and enumeration configuration to use.</param>
        /// <returns>An array of file names and directory names that match the specified search pattern and enumeration options, or an empty array if no files or directories are found.</returns>
        string[] GetFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions);

        /// <summary>
        /// Returns an array of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">The search string to match against the names of files and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <returns>An array of file the file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.</returns>
        string[] GetFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption);

        /// <summary>
        /// public static DateTime GetLastAccessTime (string path);
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>A structure that is set to the date and time the specified file or directory was last accessed. This value is expressed in local time.</returns>
        DateTime GetLastAccessTime(string path);

        /// <summary>
        /// Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>A structure that is set to the date and time the specified file or directory was last accessed. This value is expressed in UTC time.</returns>
        DateTime GetLastAccessTimeUtc(string path);

        /// <summary>
        /// Returns the date and time the specified file or directory was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain modification date and time information.</param>
        /// <returns>A structure that is set to the date and time the specified file or directory was last written to. This value is expressed in local time.</returns>
        DateTime GetLastWriteTime(string path);

        /// <summary>
        /// Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain modification date and time information.</param>
        /// <returns>A structure that is set to the date and time the specified file or directory was last written to. This value is expressed in UTC time.</returns>
        DateTime GetLastWriteTimeUtc(string path);

        /// <summary>
        /// Retrieves the names of the logical drives on this computer in the form "<drive letter>:\".
        /// </summary>
        /// <returns>The logical drives on this computer.</returns>
        string[] GetLogicalDrives();

        /// <summary>
        /// Retrieves the parent directory of the specified path, including both absolute and relative paths.
        /// </summary>
        /// <param name="path">The path for which to retrieve the parent directory.</param>
        /// <returns>The parent directory, or null if path is the root directory, including the root of a UNC server or share name.</returns>
        IDirectoryInfo? GetParent(string path);

        /// <summary>
        /// Moves a file or a directory and its contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the file or directory to move.</param>
        /// <param name="destDirName">The path to the new location for sourceDirName or its contents. If sourceDirName is a file, then destDirName must also be a file name.</param>
        void Move(string sourceDirName, string destDirName);

        /// <summary>
        /// Sets the creation date and time for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTime">The date and time the file or directory was last written to. This value is expressed in local time.</param>
        void SetCreationTime(string path, DateTime creationTime);

        /// <summary>
        /// Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTimeUtc">The date and time the directory or file was created. This value is expressed in local time.</param>
        void SetCreationTimeUtc(string path, DateTime creationTimeUtc);

        /// <summary>
        /// Sets the application's current working directory to the specified directory.
        /// </summary>
        /// <param name="path">The path to which the current working directory is set.</param>
        void SetCurrentDirectory(string path);

        /// <summary>
        /// Sets the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTime">An object that contains the value to set for the access date and time of path. This value is expressed in local time.</param>
        void SetLastAccessTime(string path, DateTime lastAccessTime);

        /// <summary>
        /// Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTimeUtc">An object that contains the value to set for the access date and time of path. This value is expressed in UTC time.</param>
        void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);

        /// <summary>
        /// Sets the date and time a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTime">The date and time the directory was last written to. This value is expressed in local time.</param>
        void SetLastWriteTime(string path, DateTime lastWriteTime);

        /// <summary>
        /// Sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTimeUtc">The date and time the directory was last written to. This value is expressed in UTC time.</param>
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
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

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.EnumerateDirectories(path, searchPattern, enumerationOptions);
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern,
            System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.EnumerateDirectories(path, searchPattern, searchOption);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern,
            System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.EnumerateFiles(path, searchPattern, searchOption);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions)
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

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            System.IO.SearchOption searchOption)
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

        public string[] GetDirectories(string path, string searchPattern, System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.GetDirectories(path, searchPattern, searchOption);
        }

        public string[] GetDirectories(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions)
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

        public string[] GetFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.GetFiles(path, searchPattern, enumerationOptions);
        }

        public string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption)
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

        public string[] GetFileSystemEntries(string path, string searchPattern,
            System.IO.EnumerationOptions enumerationOptions)
        {
            return System.IO.Directory.GetFileSystemEntries(path, searchPattern, enumerationOptions);
        }

        public string[] GetFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption)
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