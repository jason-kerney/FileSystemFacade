using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// This is to replace the System.IO.File object. Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of IFileStream objects.
    /// It is preferable to use the Atomic File System. This should only be used when you are creating long file items that live longer then a single method.
    /// </summary>
    public static class File
    {
        /// <summary>
        /// Puts the static File object into replacement mode. This is used to allow testing. It changes the way the static File class behaves.
        /// WARNING: the static File's behavior will be changed until dispose is called on the returned value.
        /// </summary>
        /// <param name="replacement">Configures how the underlying class behaves.</param>
        /// <returns>
        /// An IDisposable that when disposed returns the static File class to its default behavior.
        /// WARNING: the static File's behavior will be changed until dispose is called on the returned value.
        /// </returns>
        public static IDisposable Replace(IStaticFileReplacement replacement)
        {
            var original = new StaticFileReplacement(FileStreamFactory, FileInfoFactory, Obj);

            FileStreamFactory = replacement.FileStream;
            FileInfoFactory = replacement.FileInfo;
            Obj = replacement.File;

            return new DisposableAction(() =>
            {
                FileStreamFactory = original.FileStream;
                FileInfoFactory = original.FileInfo;
                Obj = original.File;
            });
        }

        /// <summary>
        /// Is used to aid in the building of the configuration object used in the 'Replace' method.
        /// This is only used to facilitate testing.
        /// </summary>
        /// <returns>A builder that allows for the replacement of only items that need to be replaced to enable testing.</returns>
        public static IStaticFileReplacementBuilder BuildReplacement()
        {
            return new StaticFileReplacementBuilder(FileStreamFactory, FileInfoFactory, Obj);
        }

        private static IFile Obj { get; set; } = new Primitives.File();

        /// <summary>
        /// Returns a factory that enables the creation of IFileInfo objects.
        /// </summary>
        public static IFileInfoFactory FileInfoFactory { get; private set; } = new FileInfoFactory();

        /// <summary>
        /// Returns a factory that enables the creation of IFileStream objects.
        /// </summary>
        public static IFileStreamFactory? FileStreamFactory { get; private set; } = new FileStreamFactory();

        /// <summary>
        /// Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        public static void AppendAllLines(string path, IEnumerable<string> contents) =>
            Obj.AppendAllLines(path, contents);

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding) =>
            Obj.AppendAllLines(path, contents, encoding);

        /// <summary>
        /// Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default) =>
            Obj.AppendAllLinesAsync(path, contents, cancellationToken);

        /// <summary>
        /// Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.AppendAllLinesAsync(path, contents, encoding, cancellationToken);

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        public static void AppendAllText(string path, string? contents) => Obj.AppendAllText(path, contents);

        /// <summary>
        /// Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static void AppendAllText(string path, string? contents, Encoding encoding) =>
            Obj.AppendAllText(path, contents, encoding);

        /// <summary>
        /// Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        public static Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default) => Obj.AppendAllTextAsync(path, contents, cancellationToken);

        /// <summary>
        /// Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous append operation.</returns>
        public static Task AppendAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.AppendAllTextAsync(path, contents, encoding, cancellationToken);

        /// <summary>
        /// Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist.
        /// </summary>
        /// <param name="path">The path to the file to append to.</param>
        /// <returns>A stream writer that appends UTF-8 encoded text to the specified file or to a new file.</returns>
        public static System.IO.StreamWriter AppendText(string path) => Obj.AppendText(path);

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        public static void Copy(string sourceFileName, string destFileName) => Obj.Copy(sourceFileName, destFileName);

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        public static void Copy(string sourceFileName, string destFileName, bool overwrite) =>
            Obj.Copy(sourceFileName, destFileName, overwrite);

        /// <summary>
        /// Creates or overwrites a file in the specified path.
        /// </summary>
        /// <param name="path">The path and name of the file to create.</param>
        /// <returns>A FileStream that provides read/write access to the file specified in path.</returns>
        public static IFileStream Create(string path) => Obj.Create(path);

        /// <summary>
        /// The path and name of the file to create.
        /// </summary>
        /// <param name="path">The number of bytes buffered for reads and writes to the file.</param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file.</param>
        /// <returns>A FileStream with the specified buffer size that provides read/write access to the file specified in path.</returns>
        public static IFileStream Create(string path, int bufferSize) => Obj.Create(path, bufferSize);

        /// <summary>
        /// Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to create or overwrite the file.
        /// </summary>
        /// <param name="path">The path and name of the file to create.</param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file.</param>
        /// <param name="options">One of the FileOptions values that describes how to create or overwrite the file.</param>
        /// <returns>A new file with the specified buffer size.</returns>
        public static IFileStream Create(string path, int bufferSize, System.IO.FileOptions options) =>
            Obj.Create(path, bufferSize, options);

        /// <summary>
        /// Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.
        /// </summary>
        /// <param name="path">The file to be opened for writing.</param>
        /// <returns>A StreamWriter that writes to the specified file using UTF-8 encoding.</returns>
        public static System.IO.StreamWriter CreateText(string path) => Obj.CreateText(path);

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        public static void Delete(string path) => Obj.Delete(path);

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="path">The file to check.</param>
        /// <returns>true if the caller has the required permissions and path contains the name of an existing file; otherwise, false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.</returns>
        public static bool Exists(string? path) => Obj.Exists(path);

        /// <summary>
        /// Gets the FileAttributes of the file on the path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The FileAttributes of the file on the path.</returns>
        public static System.IO.FileAttributes GetAttributes(string path) => Obj.GetAttributes(path);

        /// <summary>
        /// Returns the creation date and time of the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain creation date and time information.</param>
        /// <returns>A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in local time.</returns>
        public static DateTime GetCreationTime(string path) => Obj.GetCreationTime(path);

        /// <summary>
        /// Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain creation date and time information.</param>
        /// <returns>A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in UTC time.</returns>
        public static DateTime GetCreationTimeUtc(string path) => Obj.GetCreationTimeUtc(path);

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
        /// Moves a specified file to a new location, providing the option to specify a new file name.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destFileName">The new path and name for the file.</param>
        public static void Move(string sourceFileName, string destFileName) => Obj.Move(sourceFileName, destFileName);

        /// <summary>
        /// Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destFileName">The new path and name for the file.</param>
        /// <param name="overwrite">true to overwrite the destination file if it already exists; false otherwise.</param>
        public static void Move(string sourceFileName, string destFileName, bool overwrite) =>
            Obj.Move(sourceFileName, destFileName, overwrite);

        /// <summary>
        /// Opens a FileStream on the specified path with read/write access with no sharing.
        /// </summary>
        /// <param name="path">The file to open.</param>
        /// <param name="mode">A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.</param>
        /// <returns>A FileStream opened in the specified mode and path, with read/write access and not shared.</returns>
        public static IFileStream Open(string path, System.IO.FileMode mode) => Obj.Open(path, mode);

        /// <summary>
        /// Opens a FileStream on the specified path, with the specified mode and access with no sharing.
        /// </summary>
        /// <param name="path">The file to open.</param>
        /// <param name="mode">A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.</param>
        /// <param name="access">A FileAccess value that specifies the operations that can be performed on the file.</param>
        /// <returns>An unshared FileStream that provides access to the specified file, with the specified mode and access.</returns>
        public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access) =>
            Obj.Open(path, mode, access);

        /// <summary>
        /// Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.
        /// </summary>
        /// <param name="path">The file to open.</param>
        /// <param name="mode">A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.</param>
        /// <param name="access">A FileAccess value that specifies the operations that can be performed on the file.</param>
        /// <param name="share">A FileShare value specifying the type of access other threads have to the file.</param>
        /// <returns>A FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</returns>
        public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share) => Obj.Open(path, mode, access, share);

        /// <summary>
        /// Opens an existing file for reading.
        /// </summary>
        /// <param name="path">The file to be opened for reading.</param>
        /// <returns>A read-only FileStream on the specified path.</returns>
        public static IFileStream OpenRead(string path) => Obj.OpenRead(path);

        /// <summary>
        /// Opens an existing UTF-8 encoded text file for reading. 
        /// </summary>
        /// <param name="path">The file to be opened for reading.</param>
        /// <returns>A StreamReader on the specified path.</returns>
        public static System.IO.StreamReader OpenText(string path) => Obj.OpenText(path);

        /// <summary>
        /// Opens an existing file or creates a new file for writing.
        /// </summary>
        /// <param name="path">The file to be opened for writing.</param>
        /// <returns>An unshared FileStream object on the specified path with Write access.</returns>
        public static IFileStream OpenWrite(string path) => Obj.OpenWrite(path);

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public static byte[] ReadAllBytes(string path) => Obj.ReadAllBytes(path);

        /// <summary>
        /// Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation, which wraps the byte array containing the contents of the file.</returns>
        public static Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default) =>
            Obj.ReadAllBytesAsync(path, cancellationToken);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public static string[] ReadAllLines(string path) => Obj.ReadAllLines(path);

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public static string[] ReadAllLines(string path, Encoding encoding) => Obj.ReadAllLines(path, encoding);

        /// <summary>
        /// Asynchronously opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.</returns>
        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default) =>
            Obj.ReadAllLinesAsync(path, cancellationToken);

        /// <summary>
        /// Asynchronously opens a text file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.</returns>
        public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default) => Obj.ReadAllLinesAsync(path, encoding, cancellationToken);

        /// <summary>
        ///Opens a file, reads all text in the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string containing all text in the file.</returns>
        public static string ReadAllText(string path, Encoding encoding) => Obj.ReadAllText(path, encoding);

        /// <summary>
        /// Opens a text file, reads all the text in the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all the text in the file.</returns>
        public static string ReadAllText(string path) => Obj.ReadAllText(path);

        /// <summary>
        /// Asynchronously opens a text file, reads all the text in the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation, which wraps the string containing all text in the file.</returns>
        public static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default) =>
            Obj.ReadAllTextAsync(path, cancellationToken);

        /// <summary>
        /// Asynchronously opens a text file, reads all text in the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous read operation, which wraps the string containing all text in the file.</returns>
        public static Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default) => Obj.ReadAllTextAsync(path, encoding, cancellationToken);

        /// <summary>
        /// Reads the lines of a file.
        /// </summary>
        /// <param name="path">The file to read.</param>
        /// <returns>All the lines of the file, or the lines that are the result of a query.</returns>
        public static IEnumerable<string> ReadLines(string path) => Obj.ReadLines(path);

        /// <summary>
        /// Read the lines of a file that has a specified encoding.
        /// </summary>
        /// <param name="path">The file to read.</param>
        /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
        /// <returns>All the lines of the file, or the lines that are the result of a query.</returns>
        public static IEnumerable<string> ReadLines(string path, Encoding encoding) => Obj.ReadLines(path, encoding);

        /// <summary>
        /// Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file.
        /// </summary>
        /// <param name="sourceFileName">The name of a file that replaces the file specified by destinationFileName.</param>
        /// <param name="destinationFileName">The name of the file being replaced.</param>
        /// <param name="destinationBackupFileName">The name of the backup file.</param>
        public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName) =>
            Obj.Replace(sourceFileName, destinationFileName, destinationBackupFileName);

        /// <summary>
        /// Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file and optionally ignores merge errors.
        /// </summary>
        /// <param name="sourceFileName">The name of a file that replaces the file specified by destinationFileName.</param>
        /// <param name="destinationFileName">The name of the file being replaced.</param>
        /// <param name="destinationBackupFileName">The name of the backup file.</param>
        /// <param name="ignoreMetadataErrors">true to ignore merge errors (such as attributes and access control lists (ACLs)) from the replaced file to the replacement file; otherwise, false.</param>
        public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName,
            bool ignoreMetadataErrors) => Obj.Replace(sourceFileName, destinationFileName, destinationBackupFileName,
            ignoreMetadataErrors);

        /// <summary>
        /// Sets the specified FileAttributes of the file on the specified path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="fileAttributes">A bitwise combination of the enumeration values.</param>
        public static void SetAttributes(string path, System.IO.FileAttributes fileAttributes) =>
            Obj.SetAttributes(path, fileAttributes);

        /// <summary>
        /// Sets the date and time the file was created.
        /// </summary>
        /// <param name="path">The file for which to set the creation date and time information.</param>
        /// <param name="creationTime">A DateTime containing the value to set for the creation date and time of path. This value is expressed in local time.</param>
        public static void SetCreationTime(string path, DateTime creationTime) =>
            Obj.SetCreationTime(path, creationTime);

        /// <summary>
        /// Sets the date and time, in coordinated universal time (UTC), that the file was created.
        /// </summary>
        /// <param name="path">The file for which to set the creation date and time information.</param>
        /// <param name="creationTimeUtc">A DateTime containing the value to set for the creation date and time of path. This value is expressed in UTC time.</param>
        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc) =>
            Obj.SetCreationTimeUtc(path, creationTimeUtc);

        /// <summary>
        /// Sets the date and time the specified file was last accessed.
        /// </summary>
        /// <param name="path">The file for which to set the access date and time information.</param>
        /// <param name="lastAccessTime">A DateTime containing the value to set for the last access date and time of path. This value is expressed in local time.</param>
        public static void SetLastAccessTime(string path, DateTime lastAccessTime) =>
            Obj.SetLastAccessTime(path, lastAccessTime);

        /// <summary>
        /// Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.
        /// </summary>
        /// <param name="path">The file for which to set the access date and time information.</param>
        /// <param name="lastAccessTimeUtc">A DateTime containing the value to set for the last access date and time of path. This value is expressed in UTC time.</param>
        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) =>
            Obj.SetLastAccessTimeUtc(path, lastAccessTimeUtc);

        /// <summary>
        /// Sets the date and time that the specified file was last written to.
        /// </summary>
        /// <param name="path">The file for which to set the date and time information.</param>
        /// <param name="lastWriteTime">A DateTime containing the value to set for the last write date and time of path. This value is expressed in local time.</param>
        public static void SetLastWriteTime(string path, DateTime lastWriteTime) =>
            Obj.SetLastWriteTime(path, lastWriteTime);

        /// <summary>
        /// Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.
        /// </summary>
        /// <param name="path">The file for which to set the date and time information.</param>
        /// <param name="lastWriteTimeUtc">A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.</param>
        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) =>
            Obj.SetLastWriteTimeUtc(path, lastWriteTimeUtc);

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        public static void WriteAllBytes(string path, byte[] bytes) => Obj.WriteAllBytes(path, bytes);

        /// <summary>
        /// Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public static Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default) =>
            Obj.WriteAllBytesAsync(path, bytes, cancellationToken);

        /// <summary>
        /// Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string array to write to the file.</param>
        /// <param name="encoding">An Encoding object that represents the character encoding applied to the string array.</param>
        public static void WriteAllLines(string path, string[] contents, Encoding encoding) =>
            Obj.WriteAllLines(path, contents, encoding);

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding) =>
            Obj.WriteAllLines(path, contents, encoding);

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        public static void WriteAllLines(string path, IEnumerable<string> contents) =>
            Obj.WriteAllLines(path, contents);

        /// <summary>
        /// Creates a new file, write the specified string array to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string array to write to the file.</param>
        public static void WriteAllLines(string path, string[] contents) => Obj.WriteAllLines(path, contents);

        /// <summary>
        /// Asynchronously creates a new file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default) => Obj.WriteAllLinesAsync(path, contents, cancellationToken);

        /// <summary>
        /// Asynchronously creates a new file, write the specified lines to the file by using the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.WriteAllLinesAsync(path, contents, encoding, cancellationToken);

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        public static void WriteAllText(string path, string? contents) => Obj.WriteAllText(path, contents);

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        public static void WriteAllText(string path, string? contents, Encoding encoding) =>
            Obj.WriteAllText(path, contents, encoding);

        /// <summary>
        /// Asynchronously creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public static Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default) => Obj.WriteAllTextAsync(path, contents, cancellationToken);

        /// <summary>
        /// Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public static Task WriteAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.WriteAllTextAsync(path, contents, encoding, cancellationToken);
        
        /// <summary>
        /// Decrypts a file that was encrypted by the current account using the Encrypt(String) method.
        /// </summary>
        /// <param name="path">A path that describes a file to decrypt.</param>
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static void Decrypt(string path) => Obj.Decrypt(path);

        /// <summary>
        /// Encrypts a file so that only the account used to encrypt the file can decrypt it.
        /// </summary>
        /// <param name="path">A path that describes a file to encrypt.</param>
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static void Encrypt(string path) => Obj.Encrypt(path);
    }
}