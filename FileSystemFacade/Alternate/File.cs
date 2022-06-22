﻿using System;
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
            var original = new StaticFileReplacement(FileStreamBuilder, FileInfoFactory, Obj);

            FileStreamBuilder = replacement.FileStream;
            FileInfoFactory = replacement.FileInfo;
            Obj = replacement.File;

            return new DisposableAction(() =>
            {
                FileStreamBuilder = original.FileStream;
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
            return new StaticFileReplacementBuilder(FileStreamBuilder, FileInfoFactory, Obj);
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
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        public static void AppendAllLines(string path, IEnumerable<string> contents) =>
            Obj.AppendAllLines(path, contents);

        public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding) =>
            Obj.AppendAllLines(path, contents, encoding);

        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default) =>
            Obj.AppendAllLinesAsync(path, contents, cancellationToken);

        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.AppendAllLinesAsync(path, contents, encoding, cancellationToken);

        public static void AppendAllText(string path, string? contents) => Obj.AppendAllText(path, contents);

        public static void AppendAllText(string path, string? contents, Encoding encoding) =>
            Obj.AppendAllText(path, contents, encoding);

        public static Task AppendAllTextAsync(string path, string? contents,
            CancellationToken cancellationToken = default) => Obj.AppendAllTextAsync(path, contents, cancellationToken);

        public static Task AppendAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.AppendAllTextAsync(path, contents, encoding, cancellationToken);

        public static System.IO.StreamWriter AppendText(string path) => Obj.AppendText(path);

        public static void Copy(string sourceFileName, string destFileName) => Obj.Copy(sourceFileName, destFileName);

        public static void Copy(string sourceFileName, string destFileName, bool overwrite) =>
            Obj.Copy(sourceFileName, destFileName, overwrite);

        public static IFileStream Create(string path) => Obj.Create(path);

        public static IFileStream Create(string path, int bufferSize) => Obj.Create(path, bufferSize);

        public static IFileStream Create(string path, int bufferSize, System.IO.FileOptions options) =>
            Obj.Create(path, bufferSize, options);

        public static System.IO.StreamWriter CreateText(string path) => Obj.CreateText(path);

        public static void Delete(string path) => Obj.Delete(path);

        public static bool Exists(string? path) => Obj.Exists(path);

        public static System.IO.FileAttributes GetAttributes(string path) => Obj.GetAttributes(path);

        public static DateTime GetCreationTime(string path) => Obj.GetCreationTime(path);

        public static DateTime GetCreationTimeUtc(string path) => Obj.GetCreationTimeUtc(path);

        public static DateTime GetLastAccessTime(string path) => Obj.GetLastAccessTime(path);

        public static DateTime GetLastAccessTimeUtc(string path) => Obj.GetLastAccessTimeUtc(path);

        public static DateTime GetLastWriteTime(string path) => Obj.GetLastWriteTime(path);

        public static DateTime GetLastWriteTimeUtc(string path) => Obj.GetLastWriteTimeUtc(path);

        public static void Move(string sourceFileName, string destFileName) => Obj.Move(sourceFileName, destFileName);

        public static void Move(string sourceFileName, string destFileName, bool overwrite) =>
            Obj.Move(sourceFileName, destFileName, overwrite);

        public static IFileStream Open(string path, System.IO.FileMode mode) => Obj.Open(path, mode);

        public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access) =>
            Obj.Open(path, mode, access);

        public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access,
            System.IO.FileShare share) => Obj.Open(path, mode, access, share);

        public static IFileStream OpenRead(string path) => Obj.OpenRead(path);

        public static System.IO.StreamReader OpenText(string path) => Obj.OpenText(path);

        public static IFileStream OpenWrite(string path) => Obj.OpenWrite(path);

        public static byte[] ReadAllBytes(string path) => Obj.ReadAllBytes(path);

        public static Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default) =>
            Obj.ReadAllBytesAsync(path, cancellationToken);

        public static string[] ReadAllLines(string path) => Obj.ReadAllLines(path);

        public static string[] ReadAllLines(string path, Encoding encoding) => Obj.ReadAllLines(path, encoding);

        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default) =>
            Obj.ReadAllLinesAsync(path, cancellationToken);

        public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding,
            CancellationToken cancellationToken = default) => Obj.ReadAllLinesAsync(path, encoding, cancellationToken);

        public static string ReadAllText(string path, Encoding encoding) => Obj.ReadAllText(path, encoding);

        public static string ReadAllText(string path) => Obj.ReadAllText(path);

        public static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default) =>
            Obj.ReadAllTextAsync(path, cancellationToken);

        public static Task<string> ReadAllTextAsync(string path, Encoding encoding,
            CancellationToken cancellationToken = default) => Obj.ReadAllTextAsync(path, encoding, cancellationToken);

        public static IEnumerable<string> ReadLines(string path) => Obj.ReadLines(path);

        public static IEnumerable<string> ReadLines(string path, Encoding encoding) => Obj.ReadLines(path, encoding);

        public static void
            Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName) =>
            Obj.Replace(sourceFileName, destinationFileName, destinationBackupFileName);

        public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName,
            bool ignoreMetadataErrors) => Obj.Replace(sourceFileName, destinationFileName, destinationBackupFileName,
            ignoreMetadataErrors);

        public static void SetAttributes(string path, System.IO.FileAttributes fileAttributes) =>
            Obj.SetAttributes(path, fileAttributes);

        public static void SetCreationTime(string path, DateTime creationTime) =>
            Obj.SetCreationTime(path, creationTime);

        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc) =>
            Obj.SetCreationTimeUtc(path, creationTimeUtc);

        public static void SetLastAccessTime(string path, DateTime lastAccessTime) =>
            Obj.SetLastAccessTime(path, lastAccessTime);

        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) =>
            Obj.SetLastAccessTimeUtc(path, lastAccessTimeUtc);

        public static void SetLastWriteTime(string path, DateTime lastWriteTime) =>
            Obj.SetLastWriteTime(path, lastWriteTime);

        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) =>
            Obj.SetLastWriteTimeUtc(path, lastWriteTimeUtc);

        public static void WriteAllBytes(string path, byte[] bytes) => Obj.WriteAllBytes(path, bytes);

        public static Task
            WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default) =>
            Obj.WriteAllBytesAsync(path, bytes, cancellationToken);

        public static void WriteAllLines(string path, string[] contents, Encoding encoding) =>
            Obj.WriteAllLines(path, contents, encoding);

        public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding) =>
            Obj.WriteAllLines(path, contents, encoding);

        public static void WriteAllLines(string path, IEnumerable<string> contents) =>
            Obj.WriteAllLines(path, contents);

        public static void WriteAllLines(string path, string[] contents) => Obj.WriteAllLines(path, contents);

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents,
            CancellationToken cancellationToken = default) => Obj.WriteAllLinesAsync(path, contents, cancellationToken);

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.WriteAllLinesAsync(path, contents, encoding, cancellationToken);

        public static void WriteAllText(string path, string? contents) => Obj.WriteAllText(path, contents);

        public static void WriteAllText(string path, string? contents, Encoding encoding) =>
            Obj.WriteAllText(path, contents, encoding);

        public static Task WriteAllTextAsync(string path, string? contents,
            CancellationToken cancellationToken = default) => Obj.WriteAllTextAsync(path, contents, cancellationToken);

        public static Task WriteAllTextAsync(string path, string? contents, Encoding encoding,
            CancellationToken cancellationToken = default) =>
            Obj.WriteAllTextAsync(path, contents, encoding, cancellationToken);
        
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static void Decrypt(string path) => Obj.Decrypt(path);

        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static void Encrypt(string path) => Obj.Encrypt(path);
    }
}