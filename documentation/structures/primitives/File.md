# File

## Summary

Provides methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of IFileStream objects.

This is a thin facade around [System.IO.File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0).

```csharp
public interface IFile
```

## IFile

- [15.01 Append All Lines](#user-content-ifileappendalllines)
- [15.02 Append All Lines Async](#user-content-ifileappendalllinesasync)
- [15.03 Append All Text](#user-content-ifileappendalltext)
- [15.04 Append All Text Async](#user-content-ifileappendalltextasync)
- [15.05 Append Text](#user-content-ifileappendtext)
- [15.06 Copy](#user-content-ifilecopy)
- [15.07 Create](#user-content-ifilecreate)
- [15.08 Create Text](#user-content-ifilecreatetext)
- [15.09 Delete](#user-content-ifiledelete)
- [15.10 Exists](#user-content-ifileexists)
- [15.11 Get Attributes](#user-content-ifilegetattributes)
- [15.12 Get Creation Time](#user-content-ifilegetcreationtime)
- [15.13 Get Creation Time Utc](#user-content-ifilegetcreationtimeutc)
- [15.14 Get Last Access Time](#user-content-ifilegetlastaccesstime)
- [15.15 Get Last Access Time Utc](#user-content-ifilegetlastaccesstimeutc)
- [15.16 Get Last Write Time](#user-content-ifilegetlastwritetime)
- [15.17 Get Last Write Time Utc](#user-content-ifilegetlastwritetimeutc)
- [15.18 Move](#user-content-ifilemove)
- [15.19 Open](#user-content-ifileopen)
- [15.20 Open Read](#user-content-ifileopenread)
- [15.21 Open Text](#user-content-ifileopentext)
- [15.22 Open Write](#user-content-ifileopenwrite)
- [15.23 Read All Bytes](#user-content-ifilereadallbytes)
- [15.24 Read All Bytes Async](#user-content-ifilereadallbytesasync)
- [15.25 Read All Lines](#user-content-ifilereadalllines)
- [15.26 Read All Lines Async](#user-content-ifilereadalllinesasync)
- [15.27 Read All Text](#user-content-ifilereadalltext)
- [15.28 Read All Text Async](#user-content-ifilereadalltextasync)
- [15.29 Read Lines](#user-content-ifilereadlines)
- [15.30 Set Attributes](#user-content-ifilesetattributes)
- [15.31 Set Creation Time](#user-content-ifilesetcreationtime)
- [15.32 Set Creation Time Utc](#user-content-ifilesetcreationtimeutc)
- [15.33 Set Last Access Time](#user-content-ifilesetlastaccesstime)
- [15.34 Set Last Access Time Utc](#user-content-ifilesetlastaccesstimeutc)
- [15.35 Set Last Write Time](#user-content-ifilesetlastwritetime)
- [15.36 Set LastWrite Time Utc](#user-content-ifilesetlastwritetimeutc)
- [15.37 Write All Bytes](#user-content-ifilewriteallbytes)
- [15.38 Write All Bytes Async](#user-content-ifilewriteallbytesasync)
- [15.39 Write All Lines](#user-content-ifilewritealllines)
- [15.40 Write All Lines Async](#user-content-ifilewritealllinesasync)
- [15.41 Write All Text](#user-content-ifilewritealltext)
- [15.42 Write All Text Async](#user-content-ifilewritealltextasync)
- [15.43 Decrypt](#user-content-ifiledecrypt)
- [15.44 Encrypt](#user-content-ifileencrypt)

<!-- 
#user-content-ifile
-->

## IFile.AppendAllLines

| Signatures                                                                                                     |
|----------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileappendalllines1">`void AppendAllLines(string, IEnumerable<string>);`</a>           |
| <a href="#user-content-ifileappendalllines2">`void AppendAllLines(string, IEnumerable<string>, Encoding);`</a> |

---

<a id="user-content-ifileappendalllines1"></a>
```csharp
void AppendAllLines(string path, IEnumerable<string> contents);
```

Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

---

<a id="user-content-ifileappendalllines2"></a>
```csharp
void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
```

Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

## IFile.AppendAllLinesAsync

| Signatures                                                                                                                                  |
|---------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileappendalllinesasync1">`Task AppendAllLinesAsync(string, IEnumerable<string>, CancellationToken);`</a>           |
| <a href="#user-content-ifileappendalllinesasync2">`Task AppendAllLinesAsync(string, IEnumerable<string>, Encoding, CancellationToken);`</a> |

---

<a id="user-content-ifileappendalllinesasync1"></a>
```csharp
Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
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

<a id="user-content-ifileappendalllinesasync2"></a>
```csharp
Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
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

## IFile.AppendAllText

| Signatures                                                                                       |
|--------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileappendalltext1">`void AppendAllText(string, string?);`</a>           |
| <a href="#user-content-ifileappendalltext2">`void AppendAllText(string, string?, Encoding);`</a> |

---

<a id="user-content-ifileappendalltext1"></a>
```csharp
void AppendAllText(string path, string? contents);
```

Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

---

<a id="user-content-ifileappendalltext2"></a>
```csharp
void AppendAllText(string path, string? contents, Encoding encoding);
```

Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

## IFile.AppendAllTextAsync

| Signatures                                                                                                                    |
|-------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileappendalltextasync1">`Task AppendAllTextAsync(string, string?, CancellationToken);`</a>           |
| <a href="#user-content-ifileappendalltextasync2">`Task AppendAllTextAsync(string, string?, Encoding, CancellationToken);`</a> |

---

<a id="user-content-ifileappendalltextasync1"></a>
```csharp
Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
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

<a id="user-content-ifileappendalltextasync2"></a>
```csharp
Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
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

## IFile.AppendText

```csharp
System.IO.StreamWriter AppendText(string path);
```

Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file to append to.

**returns** [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

A stream writer that appends UTF-8 encoded text to the specified file or to a new file.

## IFile.Copy

| Signatures                                                                |
|---------------------------------------------------------------------------|
| <a href="#user-content-ifilecopy1">`void Copy(string, string);`</a>       |
| <a href="#user-content-ifilecopy2">`void Copy(string, string, bool);`</a> |

---

<a id="user-content-ifilecopy1"></a>
```csharp
void Copy(string sourceFileName, string destFileName);
```

Copies an existing file to a new file. Overwriting a file of the same name is not allowed.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to copy.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the destination file. This cannot be a directory or an existing file.

---

<a id="user-content-ifilecopy2"></a>
```csharp
void Copy(string sourceFileName, string destFileName, bool overwrite);
```

Copies an existing file to a new file. Overwriting a file of the same name is allowed.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to copy.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the destination file. This cannot be a directory.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if the destination file can be overwritten; otherwise, false.

## IFile.Create

| Signatures                                                                               |
|------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilecreate1">`IFileStream Create(string);`</a>                   |
| <a href="#user-content-ifilecreate2">`IFileStream Create(string, int);`</a>              |
| <a href="#user-content-ifilecreate3">`IFileStream Create(string, int, FileOptions);`</a> |

---

<a id="user-content-ifilecreate1"></a>
```csharp
IFileStream Create(string path);
```

Creates or overwrites a file in the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path and name of the file to create.

**returns** [IFileStream](./FileStream.md)

A FileStream that provides read/write access to the file specified in path.

---

<a id="user-content-ifilecreate2"></a>
```csharp
IFileStream Create(string path, int bufferSize);
```

The path and name of the file to create.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**returns** [IFileStream](./FileStream.md)

A FileStream with the specified buffer size that provides read/write access to the file specified in path.

---

<a id="user-content-ifilecreate3"></a>
```csharp
IFileStream Create(string path, int bufferSize, System.IO.FileOptions options);
```

Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to create or overwrite the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path and name of the file to create.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

One of the FileOptions values that describes how to create or overwrite the file.

**returns** [IFileStream](./FileStream.md)

A new file with the specified buffer size.

## IFile.CreateText

```csharp
System.IO.StreamWriter CreateText(string path);
```

Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for writing.

**returns** [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

A StreamWriter that writes to the specified file using UTF-8 encoding.

## IFile.Delete

```csharp
void Delete(string path);
```

Deletes the specified file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to be deleted. Wildcard characters are not supported.

## IFile.Exists

```csharp
bool Exists(string? path);
```

Determines whether the specified file exists.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to check.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

true if the caller has the required permissions and path contains the name of an existing file; otherwise, false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.

## IFile.GetAttributes

```csharp
System.IO.FileAttributes GetAttributes(string path);
```

Gets the FileAttributes of the file on the path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file.

**returns** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The FileAttributes of the file on the path.

## IFile.GetCreationTime

```csharp
DateTime GetCreationTime(string path);
```

Returns the creation date and time of the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain creation date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in local time.

## IFile.GetCreationTimeUtc

```csharp
DateTime GetCreationTimeUtc(string path);
```

Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain creation date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in UTC time.

## IFile.GetLastAccessTime

```csharp
DateTime GetLastAccessTime(string path);
```

Returns the date and time the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.

## IFile.GetLastAccessTimeUtc

```csharp
DateTime GetLastAccessTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.

## IFile.GetLastWriteTime

```csharp
DateTime GetLastWriteTime(string path);
```

Returns the date and time the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in local time.

## IFile.GetLastWriteTimeUtc

```csharp
DateTime GetLastWriteTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in UTC time.

## IFile.Move

| Signatures                                                                |
|---------------------------------------------------------------------------|
| <a href="#user-content-ifilemove1">`void Move(string, string);`</a>       |
| <a href="#user-content-ifilemove2">`void Move(string, string, bool);`</a> |

---

<a id="user-content-ifilemove1"></a>
```csharp
void Move(string sourceFileName, string destFileName);
```

Moves a specified file to a new location, providing the option to specify a new file name.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to move. Can include a relative or absolute path.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The new path and name for the file.

---

<a id="user-content-ifilemove2"></a>
```csharp
void Move(string sourceFileName, string destFileName, bool overwrite);
```

Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to move. Can include a relative or absolute path.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The new path and name for the file.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to overwrite the destination file if it already exists; false otherwise.

## IFile.Open

| Signatures                                                                                          |
|-----------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileopen1">`IFileStream Open(string, FileMode);`</a>                        |
| <a href="#user-content-ifileopen2">`IFileStream Open(string, FileMode, FileAccess);`</a>            |
| <a href="#user-content-ifileopen3">`IFileStream Open(string, FileMode, FileAccess, FileShare);`</a> |

---

<a id="user-content-ifileopen1"></a>
```csharp
IFileStream Open(string path, System.IO.FileMode mode);
```

Opens a FileStream on the specified path with read/write access with no sharing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**returns** [IFileStream](./FileStream.md)

A FileStream opened in the specified mode and path, with read/write access and not shared.

---

<a id="user-content-ifileopen2"></a>
```csharp
IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access);
```

Opens a FileStream on the specified path, with the specified mode and access with no sharing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess value that specifies the operations that can be performed on the file.

**returns** [IFileStream](./FileStream.md)

An unshared FileStream that provides access to the specified file, with the specified mode and access.

---

<a id="user-content-ifileopen3"></a>
```csharp
IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
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

**returns** [IFileStream](./FileStream.md)

A FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.

## IFile.OpenRead

```csharp
IFileStream OpenRead(string path);
```

Opens an existing file for reading.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for reading.

**returns** [IFileStream](./FileStream.md)

A read-only FileStream on the specified path.

## IFile.OpenText

```csharp
System.IO.StreamReader OpenText(string path);
```

Opens an existing UTF-8 encoded text file for reading. 

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for reading.

**returns** [IFileStream](./FileStream.md)

A StreamReader on the specified path.

## IFile.OpenWrite

```csharp
IFileStream OpenWrite(string path);
```

Opens an existing file or creates a new file for writing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for writing.

**returns** [IFileStream](./FileStream.md)

An unshared FileStream object on the specified path with Write access.

## IFile.ReadAllBytes

```csharp
byte[] ReadAllBytes(string path);
```

Opens a binary file, reads the contents of the file into a byte array, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [IFileStream](./FileStream.md)

A byte array containing the contents of the file.

## IFile.ReadAllBytesAsync

```csharp
Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the byte array containing the contents of the file.

## IFile.ReadAllLines

| Signatures                                                                                |
|-------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilereadalllines1">`string[] ReadAllLines(string);`</a>           |
| <a href="#user-content-ifilereadalllines2">`string[] ReadAllLines(string, Encoding);`</a> |

---

<a id="user-content-ifilereadalllines1"></a>
```csharp
string[] ReadAllLines(string path);
```

Opens a text file, reads all lines of the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string array containing all lines of the file.

---

<a id="user-content-ifilereadalllines2"></a>
```csharp
string[] ReadAllLines(string path, Encoding encoding);
```

Opens a file, reads all lines of the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string array containing all lines of the file.

## IFile.ReadAllLinesAsync

| Signatures                                                                                                                   |
|------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilereadalllinesasync1">`Task<string[]> ReadAllLinesAsync(string, CancellationToken);`</a>           |
| <a href="#user-content-ifilereadalllinesasync2">`Task<string[]> ReadAllLinesAsync(string, Encoding, CancellationToken);`</a> |

---

<a id="user-content-ifilereadalllinesasync1"></a>
```csharp
Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all lines of the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.

---

<a id="user-content-ifilereadalllinesasync2"></a>
```csharp
Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
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

## IFile.ReadAllText

| Signatures                                                                            |
|---------------------------------------------------------------------------------------|
| <a href="#user-content-ifilereadalltext1">`string ReadAllText(string, Encoding);`</a> |
| <a href="#user-content-ifilereadalltext2">`string ReadAllText(string);`</a>           |

---

<a id="user-content-ifilereadalltext1"></a>
```csharp
string ReadAllText(string path, Encoding encoding);
```

Opens a file, reads all text in the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string containing all text in the file.

---

<a id="user-content-ifilereadalltext2"></a>
```csharp
string ReadAllText(string path);
```

Opens a text file, reads all the text in the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string containing all the text in the file.

## IFile.ReadAllTextAsync

| Signatures                                                                                                               |
|--------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilereadalltextasync1">`Task<string> ReadAllTextAsync(string, CancellationToken);`</a>           |
| <a href="#user-content-ifilereadalltextasync2">`Task<string> ReadAllTextAsync(string, Encoding, CancellationToken);`</a> |

---

<a id="user-content-ifilereadalltextasync1"></a>
```csharp
Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all the text in the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A task that represents the asynchronous read operation, which wraps the string containing all text in the file.

---

<a id="user-content-ifilereadalltextasync2"></a>
```csharp
Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
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

## IFile.ReadLines

| Signatures                                                                                     |
|------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilereadlines1">`IEnumerable<string> ReadLines(string);`</a>           |
| <a href="#user-content-ifilereadlines2">`IEnumerable<string> ReadLines(string, Encoding);`</a> |

---

<a id="user-content-ifilereadlines1"></a>
```csharp
IEnumerable<string> ReadLines(string path);
```

Reads the lines of a file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to read.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

All the lines of the file, or the lines that are the result of a query.

---

<a id="user-content-ifilereadlines2"></a>
```csharp
IEnumerable<string> ReadLines(string path, Encoding encoding);
```

Read the lines of a file that has a specified encoding.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to read.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding that is applied to the contents of the file.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

All the lines of the file, or the lines that are the result of a query.

## IFile.Replace

| Signature                                                                                |
|------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilereplace1">`void Replace(string, string, string?);`</a>       |
| <a href="#user-content-ifilereplace2">`void Replace(string, string, string?, bool);`</a> |

---

<a id="user-content-ifilereplace1"></a>
```csharp
void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName);
```

Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file that replaces the file specified by destinationFileName.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file being replaced.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the backup file.

---

<a id="user-content-ifilereplace2"></a>
```csharp
void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
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

## IFile.SetAttributes

```csharp
void SetAttributes(string path, System.IO.FileAttributes fileAttributes);
```

Sets the specified FileAttributes of the file on the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file.

**fileAttributes** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

A bitwise combination of the enumeration values.

## IFile.SetCreationTime

```csharp
void SetCreationTime(string path, DateTime creationTime);
```

Sets the date and time the file was created.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the creation date and time information.

**creationTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the creation date and time of path. This value is expressed in local time.

## IFile.SetCreationTimeUtc

```csharp
void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the file was created.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the creation date and time information.

**creationTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the creation date and time of path. This value is expressed in UTC time.

## IFile.SetLastAccessTime

```csharp
void SetLastAccessTime(string path, DateTime lastAccessTime);
```

Sets the date and time the specified file was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the access date and time information.

**lastAccessTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last access date and time of path. This value is expressed in local time.

## IFile.SetLastAccessTimeUtc

```csharp
void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the access date and time information.

**lastAccessTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last access date and time of path. This value is expressed in UTC time.

## IFile.SetLastWriteTime

```csharp
void SetLastWriteTime(string path, DateTime lastWriteTime);
```

Sets the date and time that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in local time.

## IFile.SetLastWriteTimeUtc

```csharp
void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.

## IFile.WriteAllBytes

```csharp
void WriteAllBytes(string path, byte[] bytes);
```

Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**bytes** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The bytes to write to the file.

## IFile.WriteAllBytesAsync

```csharp
Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);
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

## IFile.WriteAllLines

| Signatures                                                                                                   |
|--------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilewritealllines1">`void WriteAllLines(string, string[], Encoding);`</a>            |
| <a href="#user-content-ifilewritealllines2">`void WriteAllLines(string, IEnumerable<string>, Encoding);`</a> |
| <a href="#user-content-ifilewritealllines3">`void WriteAllLines(string, IEnumerable<string>);`</a>           |
| <a href="#user-content-ifilewritealllines4">`void WriteAllLines(string, string[]);`</a>                      |

---

<a id="user-content-ifilewritealllines1"></a>
```csharp
void WriteAllLines(string path, string[] contents, Encoding encoding);
```

Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string array to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

An Encoding object that represents the character encoding applied to the string array.

---

<a id="user-content-ifilewritealllines2"></a>
```csharp
void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
```

Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

---

<a id="user-content-ifilewritealllines3"></a>
```csharp
void WriteAllLines(string path, IEnumerable<string> contents);
```

Creates a new file, writes a collection of strings to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

---

<a id="user-content-ifilewritealllines4"></a>
```csharp
void WriteAllLines(string path, string[] contents);
```

Creates a new file, write the specified string array to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string array to write to the file.

## IFile.WriteAllLinesAsync

| Signatures                                                                                                                      |
|---------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilewritealllinesasync1">`Task WriteAllLinesAsync(string, IEnumerable<string>, CancellationToken);`</a> |

---

<a id="user-content-ifilewritealllinesasync1"></a>
```csharp
Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
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

```csharp
Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
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

## IFile.WriteAllText

| Signature                                                                                      |
|------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilewritealltext1">`void WriteAllText(string, string?);`</a>           |
| <a href="#user-content-ifilewritealltext2">`void WriteAllText(string, string?, Encoding);`</a> |

---

<a id="user-content-ifilewritealltext1"></a>
```csharp
void WriteAllText(string path, string? contents);
```

Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

---

<a id="user-content-ifilewritealltext2"></a>
```csharp
void WriteAllText(string path, string? contents, Encoding encoding);
```

Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding to apply to the string.

## IFile.WriteAllTextAsync

| Signatures                                                                                                                  |
|-----------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifilewritealltextasync1">`Task WriteAllTextAsync(string, string?, CancellationToken);`</a>           |
| <a href="#user-content-ifilewritealltextasync2">`Task WriteAllTextAsync(string, string?, Encoding, CancellationToken);`</a> |

---

<a id="user-content-ifilewritealltextasync1"></a>
```csharp
Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
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

<a id="user-content-ifilewritealltextasync2"></a>
```csharp
Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
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

## IFile.Decrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
void Decrypt(string path);
```

Decrypts a file that was encrypted by the current account using the Encrypt(String) method.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A path that describes a file to decrypt.

## IFile.Encrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
void Encrypt(string path);
```

Encrypts a file so that only the account used to encrypt the file can decrypt it.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A path that describes a file to encrypt.