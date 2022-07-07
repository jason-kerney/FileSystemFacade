<!--bl
(filemeta
    (title "File"))
/bl-->

### Summary

This is to replace the [System.IO.File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0) object. Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of IFileStream objects.

It is preferable to use the [Atomic File System](./structures.md#file-system-facades-primary-file-system-access). This should only be used when you are creating long file items that live longer then a single method.

```csharp
public static class File
```

### File

- [8.01 Replace Static File Sub System](#user-content-filereplacestaticfilesubsystem)
- [8.02 Build Replacement](#user-content-filebuildreplacement)
- [8.03 File Info Factory](#user-content-filefileinfofactory)
- [8.04 File Stream Factory](#user-content-filefilestreamfactory)
- [8.05 Append All Lines](#user-content-fileappendalllines)
- [8.06 Append All Lines Async](#user-content-fileappendalllinesasync)
- [8.07 Append All Text](#user-content-fileappendalltext)
- [8.08 Append All Text Async](#user-content-fileappendalltextasync)
- [8.09 Append Text](#user-content-fileappendtext)
- [8.10 Copy](#user-content-filecopy)
- [8.11 Create](#user-content-filecreate)
- [8.12 Create Text](#user-content-filecreatetext)
- [8.13 Delete](#user-content-filedelete)
- [8.13 Exists](#user-content-fileexists)
- [8.14 Get Attributes](#user-content-filegetattributes)
- [8.15 Get Creation Time](#user-content-filegetcreationtime)
- [8.16 Get Creation Time Utc](#user-content-filegetcreationtimeutc)
- [8.17 Get Last Access Time](#user-content-filegetlastaccesstime)
- [8.18 Get Last Access Time Utc](#user-content-filegetlastaccesstimeutc)
- [8.19 Get Last Write Time](#user-content-filegetlastwritetime)
- [8.20 Get Last Write Time Utc](#user-content-filegetlastwritetimeutc)
- [8.21 Move](#user-content-filemove)
- [8.22 Open](#user-content-fileopen)
- [8.23 Open Read](#user-content-fileopenread)
- [8.24 Open Text](#user-content-fileopentext)
- [8.25 Open Write](#user-content-fileopenwrite)
- [8.26 Read All Bytes](#user-content-filereadallbytes)
- [8.27 Read All Bytes Async](#user-content-filereadallbytesasync)
- [8.28 Read All Lines](#user-content-filereadalllines)
- [8.29 Read All Lines Async](#user-content-filereadalllinesasync)
- [8.30 Read All Text](#user-content-filereadalltext)
- [8.31 Read All Text Async](#user-content-filereadalltextasync)
- [8.32 Read Lines](#user-content-filereadlines)
- [8.33 Replace](#user-content-filereplace)
- [8.34 Set Attributes](#user-content-filesetattributes)
- [8.35 Set Creation Time](#user-content-filesetcreationtime)
- [8.36 Set Creation Time Utc](#user-content-filesetcreationtimeutc)
- [8.37 Set Last Access Time](#user-content-filesetlastaccesstime)
- [8.38 Set Last Access Time Utc](#user-content-filesetlastaccesstimeutc)
- [8.39 Set Last Write Time](#user-content-filesetlastwritetime)
- [8.40 Set Last Write Time Utc](#user-content-filesetlastwritetimeutc)
- [8.41 Write All Bytes](#user-content-filewriteallbytes)
- [8.42 Write All Bytes Async](#user-content-filewriteallbytesasync)
- [8.43 Write All Lines](#user-content-filewritealllines)
- [8.44 Write All Lines Async](#user-content-filewritealllinesasync)
- [8.45 Write All Text](#user-content-filewritealltext)
- [8.46 Write All Text Async](#user-content-filewritealltextasync)
- [8.47 Decrypt](#user-content-filedecrypt)
- [8.48 Encrypt](#user-content-fileencrypt)

<!--
#user-content-file
-->

### File.ReplaceStaticFileSubSystem

```csharp
public static IDisposable ReplaceStaticFileSubSystem(IStaticFileReplacement replacement);
```

Puts the static File object into replacement mode. This is used to allow testing. It changes the way the static File class behaves.

***WARNING:*** the static File's behavior will be changed until dispose is called on the returned value.

**replacement** [IStaticFileReplacement](#user-content-static-file-replacement)

Configures how the underlying class behaves.

**returns** [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0)

An IDisposable that when disposed returns the static File class to its default behavior.

***WARNING:*** the static File's behavior will be changed until dispose is called on the returned value.

### File.BuildReplacement

```csharp
public static IStaticFileReplacementBuilder BuildReplacement();
```

Is used to aid in the building of the configuration object used in the 'Replace' method.

This is only used to facilitate testing.

**returns** [IStaticFileReplacementBuilder](#user-content-static-file-replacement-builder)

A builder that allows for the replacement of only items that need to be replaced to enable testing.

### File.FileInfoFactory

```csharp
public static IFileInfoFactory FileInfoFactory { get; }
```

Returns a factory that enables the creation of IFileInfo objects.

**returns** [IFileInfoFactory](./documentation/structures/primitives/FileInfoFactory.md#file-info-factory)

A factory that enables the creation of IFileInfo objects.

### File.FileStreamFactory

```csharp
public static IFileStreamFactory? FileStreamFactory { get; }
```

Returns a factory that enables the creation of IFileStream objects.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IFileStreamFactory](./documentation/structures/primitives/FileStreamFactory.md#file-stream-factory)\>

A factory that enables the creation of IFileStream objects.

### File.AppendAllLines

| Signatures                                                                                                                  |
|-----------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalllines1">`public static void AppendAllLines(string, IEnumerable<string>);`</a>           |
| <a href="#user-content-fileappendalllines2">`public static void AppendAllLines(string, IEnumerable<string>, Encoding);`</a> |

---

<a id="user-content-fileappendalllines1"></a>
```csharp
public static void AppendAllLines(string path, IEnumerable<string> contents);
```

Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

---

<a id="user-content-fileappendalllines2"></a>
```csharp
public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
```

Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

### File.AppendAllLinesAsync

| Signatures                                                                                                                                               |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalllinesasync1">`public static Task AppendAllLinesAsync(string, IEnumerable<string>, CancellationToken);`</a>           |
| <a href="#user-content-fileappendalllinesasync2">`public static Task AppendAllLinesAsync(string, IEnumerable<string>, Encoding, CancellationToken);`</a> |

---

<a id="user-content-fileappendalllinesasync1"></a>
```csharp
public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
```

Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

---

<a id="user-content-fileappendalllinesasync2"></a>
```csharp
public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

### File.AppendAllText

| Signatures                                                                                                    |
|---------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalltext1">`public static void AppendAllText(string, string?);`</a>           |
| <a href="#user-content-fileappendalltext2">`public static void AppendAllText(string, string?, Encoding);`</a> |

---

<a id="user-content-fileappendalltext1"></a>
```csharp
public static void AppendAllText(string path, string? contents);
```

Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

---

<a id="user-content-fileappendalltext2"></a>
```csharp
public static void AppendAllText(string path, string? contents, Encoding encoding);
```

Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

### File.AppendAllTextAsync

| Signatures                                                                                                                                 |
|--------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalltextasync1">`public static Task AppendAllTextAsync(string, string?, CancellationToken);`</a>           |
| <a href="#user-content-fileappendalltextasync2">`public static Task AppendAllTextAsync(string, string?, Encoding, CancellationToken);`</a> |

---

<a id="user-content-fileappendalltextasync1"></a>
```csharp
public static Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
```

Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

---

<a id="user-content-fileappendalltextasync2"></a>
```csharp
public static Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

### File.AppendText

```csharp
public static System.IO.StreamWriter AppendText(string path);
```

Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file to append to.

**returns** [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

A stream writer that appends UTF-8 encoded text to the specified file or to a new file.

### File.Copy

| Signatures                                                                             |
|----------------------------------------------------------------------------------------|
| <a href="#user-content-filecopy1">`public static void Copy(string, string);`</a>       |
| <a href="#user-content-filecopy2">`public static void Copy(string, string, bool);`</a> |

---

<a id="user-content-filecopy1"></a>
```csharp
public static void Copy(string sourceFileName, string destFileName);
```

Copies an existing file to a new file. Overwriting a file of the same name is not allowed.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to copy.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the destination file. This cannot be a directory or an existing file.

---

<a id="user-content-filecopy2"></a>
```csharp
public static void Copy(string sourceFileName, string destFileName, bool overwrite);
```

Copies an existing file to a new file. Overwriting a file of the same name is allowed.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to copy.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the destination file. This cannot be a directory.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if the destination file can be overwritten; otherwise, false.

### File.Create

| Signatures                                                                                            |
|-------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filecreate1">`public static IFileStream Create(string);`</a>                   |
| <a href="#user-content-filecreate2">`public static IFileStream Create(string, int);`</a>              |
| <a href="#user-content-filecreate3">`public static IFileStream Create(string, int, FileOptions);`</a> |

---

<a id="user-content-filecreate1"></a>
```csharp
public static IFileStream Create(string path);
```

Creates or overwrites a file in the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path and name of the file to create.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream that provides read/write access to the file specified in path.

---

<a id="user-content-filecreate2"></a>
```csharp
public static IFileStream Create(string path, int bufferSize);
```

The path and name of the file to create.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream with the specified buffer size that provides read/write access to the file specified in path.

---

<a id="user-content-filecreate3"></a>
```csharp
public static IFileStream Create(string path, int bufferSize, System.IO.FileOptions options);
```

Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to create or overwrite the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path and name of the file to create.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

One of the FileOptions values that describes how to create or overwrite the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A new file with the specified buffer size.

### File.CreateText

```csharp
public static System.IO.StreamWriter CreateText(string path);
```

Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for writing.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A StreamWriter that writes to the specified file using UTF-8 encoding.

### File.Delete

```csharp
public static void Delete(string path);
```

Deletes the specified file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to be deleted. Wildcard characters are not supported.

### File.Exists

```csharp
public static bool Exists(string? path);
```

Determines whether the specified file exists.

**path** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The file to check.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if the caller has the required permissions and path contains the name of an existing file; otherwise, false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.

### File.GetAttributes

```csharp
public static System.IO.FileAttributes GetAttributes(string path);
```

Gets the FileAttributes of the file on the path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file.

**returns** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The FileAttributes of the file on the path.

### File.GetCreationTime

```csharp
public static DateTime GetCreationTime(string path);
```

Returns the creation date and time of the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain creation date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in local time.

### File.GetCreationTimeUtc

```csharp
public static DateTime GetCreationTimeUtc(string path);
```

Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain creation date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in UTC time.

### File.GetLastAccessTime

```csharp
public static DateTime GetLastAccessTime(string path);
```

Returns the date and time the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.

### File.GetLastAccessTimeUtc

```csharp
public static DateTime GetLastAccessTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.

### File.GetLastWriteTime

```csharp
public static DateTime GetLastWriteTime(string path);
```

Returns the date and time the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in local time.

### File.GetLastWriteTimeUtc

```csharp
public static DateTime GetLastWriteTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in UTC time.

### File.Move

| Signature                                                                              |
|----------------------------------------------------------------------------------------|
| <a href="#user-content-filemove1">`public static void Move(string, string);`</a>       |
| <a href="#user-content-filemove2">`public static void Move(string, string, bool);`</a> |

---

<a id="user-content-filemove1"></a>
```csharp
public static void Move(string sourceFileName, string destFileName);
```

Moves a specified file to a new location, providing the option to specify a new file name.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to move. Can include a relative or absolute path.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The new path and name for the file.

---

<a id="user-content-filemove2"></a>
```csharp
public static void Move(string sourceFileName, string destFileName, bool overwrite);
```

Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to move. Can include a relative or absolute path.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The new path and name for the file.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to overwrite the destination file if it already exists; false otherwise.

### File.Open

| Signatures                                                                                                       |
|------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileopen1">`public static IFileStream Open(string, FileMode);`</a>                        |
| <a href="#user-content-fileopen2">`public static IFileStream Open(string, FileMode, FileAccess);`</a>            |
| <a href="#user-content-fileopen3">`public static IFileStream Open(string, FileMode, FileAccess, FileShare);`</a> |

---

<a id="user-content-fileopen1"></a>
```csharp
public static IFileStream Open(string path, System.IO.FileMode mode);
```

Opens a FileStream on the specified path with read/write access with no sharing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream opened in the specified mode and path, with read/write access and not shared.

---

<a id="user-content-fileopen2"></a>
```csharp
public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access);
```

Opens a FileStream on the specified path, with the specified mode and access with no sharing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess value that specifies the operations that can be performed on the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

An unshared FileStream that provides access to the specified file, with the specified mode and access.

---

<a id="user-content-fileopen3"></a>
```csharp
public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess value that specifies the operations that can be performed on the file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A FileShare value specifying the type of access other threads have to the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.

### File.OpenRead

```csharp
public static IFileStream OpenRead(string path);
```

Opens an existing file for reading.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for reading.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A read-only FileStream on the specified path.

### File.OpenText

```csharp
public static System.IO.StreamReader OpenText(string path);
```

Opens an existing UTF-8 encoded text file for reading.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for reading.

**returns** [System.IO.StreamReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-6.0)

A StreamReader on the specified path.

### File.OpenWrite

```csharp
public static IFileStream OpenWrite(string path);
```

Opens an existing file or creates a new file for writing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for writing.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

An unshared FileStream object on the specified path with Write access.

### File.ReadAllBytes

```csharp
public static byte[] ReadAllBytes(string path);
```

Opens a binary file, reads the contents of the file into a byte array, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

A byte array containing the contents of the file.

### File.ReadAllBytesAsync

```csharp
public static Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the byte array containing the contents of the file.

### File.ReadAllLines

| Signatures                                                                                             |
|--------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalllines1">`public static string[] ReadAllLines(string);`</a>           |
| <a href="#user-content-filereadalllines2">`public static string[] ReadAllLines(string, Encoding);`</a> |

---

<a id="user-content-filereadalllines1"></a>
```csharp
public static string[] ReadAllLines(string path);
```

Opens a text file, reads all lines of the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string array containing all lines of the file.

---

<a id="user-content-filereadalllines2"></a>
```csharp
public static string[] ReadAllLines(string path, Encoding encoding);
```

Opens a file, reads all lines of the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string array containing all lines of the file.

### File.ReadAllLinesAsync

| Signatures                                                                                                                                |
|-------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalllinesasync1">`public static Task<string[]> ReadAllLinesAsync(string, CancellationToken);`</a>           |
| <a href="#user-content-filereadalllinesasync2">`public static Task<string[]> ReadAllLinesAsync(string, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filereadalllinesasync1"></a>
```csharp
public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all lines of the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.

---

<a id="user-content-filereadalllinesasync2"></a>
```csharp
public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all lines of the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.

### File.ReadAllText

| Signatures                                                                                         |
|----------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalltext1">`public static string ReadAllText(string, Encoding);`</a> |
| <a href="#user-content-filereadalltext2">`public static string ReadAllText(string);`</a>           |

---

<a id="user-content-filereadalltext1"></a>
```csharp
public static string ReadAllText(string path, Encoding encoding);
```

Opens a file, reads all text in the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string containing all text in the file.

---

<a id="user-content-filereadalltext2"></a>
```csharp
public static string ReadAllText(string path);
```

Opens a text file, reads all the text in the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string containing all the text in the file.

### File.ReadAllTextAsync

| Signatures                                                                                                                            |
|---------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalltextasync1">`public static Task<string> ReadAllTextAsync(string, CancellationToken);`</a>           |
| <a href="#user-content-filereadalltextasync2">`public static Task<string> ReadAllTextAsync(string, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filereadalltextasync1"></a>
```csharp
public static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all the text in the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A task that represents the asynchronous read operation, which wraps the string containing all text in the file.

---

<a id="user-content-filereadalltextasync2"></a>
```csharp
public static Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all text in the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A task that represents the asynchronous read operation, which wraps the string containing all text in the file.

### File.ReadLines

| Signatures                                                                                                  |
|-------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadlines1">`public static IEnumerable<string> ReadLines(string);`</a>           |
| <a href="#user-content-filereadlines2">`public static IEnumerable<string> ReadLines(string, Encoding);`</a> |

---

<a id="user-content-filereadlines1"></a>
```csharp
public static IEnumerable<string> ReadLines(string path);
```

Reads the lines of a file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to read.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

All the lines of the file, or the lines that are the result of a query.

---

<a id="user-content-filereadlines2"></a>
```csharp
public static IEnumerable<string> ReadLines(string path, Encoding encoding);
```

Read the lines of a file that has a specified encoding.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to read.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding that is applied to the contents of the file.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

All the lines of the file, or the lines that are the result of a query.

### File.Replace

| Signatures                                                                                            |
|-------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereplace1">`public static void Replace(string, string, string?);`</a>       |
| <a href="#user-content-filereplace2">`public static void Replace(string, string, string?, bool);`</a> |

---

<a id="user-content-filereplace1"></a>
```csharp
public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName);
```

Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file that replaces the file specified by destinationFileName.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file being replaced.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the backup file.

---

<a id="user-content-filereplace2"></a>
```csharp
public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
```

Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file and optionally ignores merge errors.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file that replaces the file specified by destinationFileName.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file being replaced.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the backup file.

**ignoreMetadataErrors** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to ignore merge errors (such as attributes and access control lists (ACLs)) from the replaced file to the replacement file; otherwise, false.

### File.SetAttributes

```csharp
public static void SetAttributes(string path, System.IO.FileAttributes fileAttributes);
```

Sets the specified FileAttributes of the file on the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file.

**fileAttributes** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

A bitwise combination of the enumeration values.

### File.SetCreationTime

```csharp
public static void SetCreationTime(string path, DateTime creationTime);
```

Sets the date and time the file was created.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the creation date and time information.

**creationTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the creation date and time of path. This value is expressed in local time.

### File.SetCreationTimeUtc

```csharp
public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the file was created.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the creation date and time information.

**creationTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the creation date and time of path. This value is expressed in UTC time.

### File.SetLastAccessTime

```csharp
public static void SetLastAccessTime(string path, DateTime lastAccessTime);
```

Sets the date and time the specified file was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the access date and time information.

**lastAccessTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last access date and time of path. This value is expressed in local time.

### File.SetLastAccessTimeUtc

```csharp
public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the access date and time information.

**lastAccessTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last access date and time of path. This value is expressed in UTC time.

### File.SetLastWriteTime

```csharp
public static void SetLastWriteTime(string path, DateTime lastWriteTime);
```

Sets the date and time that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in local time.

### File.SetLastWriteTimeUtc

```csharp
public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.

### File.WriteAllBytes

```csharp
public static void WriteAllBytes(string path, byte[] bytes);
```

Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**bytes** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The bytes to write to the file.

### File.WriteAllBytesAsync

```csharp
public static Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**bytes** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The bytes to write to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### File.WriteAllLines

| Signatures                                                                                                                |
|---------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealllines1">`public static void WriteAllLines(string, string[], Encoding);`</a>            |
| <a href="#user-content-filewritealllines2">`public static void WriteAllLines(string, IEnumerable<string>, Encoding);`</a> |
| <a href="#user-content-filewritealllines3">`public static void WriteAllLines(string, IEnumerable<string>);`</a>           |
| <a href="#user-content-filewritealllines4">`public static void WriteAllLines(string, string[]);`</a>                      |

---

<a id="user-content-filewritealllines1"></a>
```csharp
public static void WriteAllLines(string path, string[] contents, Encoding encoding);
```

Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string array to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

An Encoding object that represents the character encoding applied to the string array.

---

<a id="user-content-filewritealllines2"></a>
```csharp
public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
```

Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

---

<a id="user-content-filewritealllines3"></a>
```csharp
public static void WriteAllLines(string path, IEnumerable<string> contents);
```

Creates a new file, writes a collection of strings to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

---

<a id="user-content-filewritealllines4"></a>
```csharp
public static void WriteAllLines(string path, string[] contents);
```

Creates a new file, write the specified string array to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string array to write to the file.

### File.WriteAllLinesAsync

| Signatures                                                                                                                                             |
|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealllinesasync1">`public static Task WriteAllLinesAsync(string, IEnumerable<string>, CancellationToken);`</a>           |
| <a href="#user-content-filewritealllinesasync2">`public static Task WriteAllLinesAsync(string, IEnumerable<string>, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filewritealllinesasync1"></a>
```csharp
public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

---

<a id="user-content-filewritealllinesasync2"></a>
```csharp
public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, write the specified lines to the file by using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### File.WriteAllText

| Signatures                                                                                                  |
|-------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealltext1">`public static void WriteAllText(string, string?);`</a>           |
| <a href="#user-content-filewritealltext2">`public static void WriteAllText(string, string?, Encoding);`</a> |

---

<a id="user-content-filewritealltext1"></a>
```csharp
public static void WriteAllText(string path, string? contents);
```

Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

---

<a id="user-content-filewritealltext2"></a>
```csharp
public static void WriteAllText(string path, string? contents, Encoding encoding);
```

Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding to apply to the string.

### File.WriteAllTextAsync

| Signatures                                                                                                                               |
|------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealltextasync1">`public static Task WriteAllTextAsync(string, string?, CancellationToken);`</a>           |
| <a href="#user-content-filewritealltextasync2">`public static Task WriteAllTextAsync(string, string?, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filewritealltextasync1"></a>
```csharp
public static Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

---

<a id="user-content-filewritealltextasync2"></a>
```csharp
public static Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding to apply to the string.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### File.Decrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public static void Decrypt(string path);
```

Decrypts a file that was encrypted by the current account using the Encrypt(String) method.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A path that describes a file to decrypt.

### File.Encrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public static void Encrypt(string path);
```

Encrypts a file so that only the account used to encrypt the file can decrypt it.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A path that describes a file to encrypt.