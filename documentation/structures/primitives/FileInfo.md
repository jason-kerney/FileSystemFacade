<!--bl
(filemeta
    (title "File Info"))
/bl-->

### Summary

Provides properties and instance methods for the creation, copying, deletion, moving, and opening of files, and aids in the creation of IFileStream objects.

This is a thin facade around [System.IO.FileInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=net-6.0)

```csharp
public interface IFileInfo: IFileSystemInfo
```

### IFileInfo

- [12.01 Directory](#user-content-ifileinfodirectory)
- [12.02 Directory Name](#user-content-ifileinfodirectoryname)
- [12.03 Is Read Only](#user-content-ifileinfoisreadonly)
- [12.04 Length](#user-content-ifileinfolength)
- [12.05 Append Text](#user-content-ifileinfoappendtext)
- [12.06 Copy To](#user-content-ifileinfocopyto)
- [12.07 Create](#user-content-ifileinfocreate)
- [12.08 Create Text](#user-content-ifileinfocreatetext)
- [12.09 Decrypt](#user-content-ifileinfodecrypt)
- [12.10 Encrypt](#user-content-ifileinfoencrypt)
- [12.11 Move To](#user-content-ifileinfomoveto)
- [12.12 Open](#user-content-ifileinfoopen)
- [12.13 Open Read](#user-content-ifileinfoopenread)
- [12.14 Open Text](#user-content-ifileinfoopentext)
- [12.15 Open Write](#user-content-ifileinfoopenwrite)
- [12.16 Replace](#user-content-ifileinforeplace)

### IFileInfo.Directory

```csharp
public IDirectoryInfo? Directory { get; }
```

Gets an instance of the parent directory.

**value parameter** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An instance of the parent directory.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An instance of the parent directory.

### IFileInfo.DirectoryName

```csharp
string? DirectoryName { get; }
```

Gets a string representing the directory's full path.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

### IFileInfo.IsReadOnly

```csharp
bool IsReadOnly { get; set; }
```

Gets or sets a value that determines if the current file is read only.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that determines if the current file is read only.

### IFileInfo.Length

```csharp
public long Length { get; }
```

Gets the size, in bytes, of the current file.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The size, in bytes, of the current file.

### IFileInfo.AppendText

```csharp
System.IO.StreamWriter AppendText ();
```

Creates a StreamWriter that appends text to the file represented by this instance of the FileInfo.

**returns** [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

A new StreamWriter.

### IFileInfo.CopyTo

| Signatures                                                                     |
|--------------------------------------------------------------------------------|
| <a href='#user-content-ifileinfocopyto1'>`IFileInfo CopyTo(string);`</a>       |
| <a href='#user-content-ifileinfocopyto2'>`IFileInfo CopyTo(string, bool);`</a> |

---

<a id='user-content-ifileinfocopyto1'></a>
```csharp
IFileInfo CopyTo(string destFileName);
```

Copies an existing file to a new file, disallowing the overwriting of an existing file.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the new file to copy to.

**returns** [IFileInfo](./FileInfo.md)

A new file with a fully qualified path.

---

<a id='user-content-ifileinfocopyto2'></a>
```csharp
IFileInfo CopyTo(string destFileName, bool overwrite);
```

Copies an existing file to a new file, allowing the overwriting of an existing file.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the new file to copy to.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to allow an existing file to be overwritten; otherwise, false.

**returns** [IFileInfo](./FileInfo.md)

A new file, or an overwrite of an existing file if overwrite is true. If the file exists and overwrite is false, an IOException is thrown.

### IFileInfo.Create

```csharp
IFileStream Create ();
```

Creates a file.

**returns** [IFileStream](./FileStream.md)

A new file.

### IFileInfo.CreateText

```csharp
System.IO.StreamWriter CreateText ();
```

Creates a StreamWriter that writes a new text file.

**returns** [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

A new StreamWriter.

### IFileInfo.Decrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
void Decrypt ();
```

Decrypts a file that was encrypted by the current account using the Encrypt() method.

### IFileInfo.Encrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
void Encrypt ();
```

Encrypts a file so that only the account used to encrypt the file can decrypt it.

### IFileInfo.MoveTo

| Signatures                                                                |
|---------------------------------------------------------------------------|
| <a href='#user-content-ifileinfomoveto1'>`void MoveTo(string);`</a>       |
| <a href='#user-content-ifileinfomoveto2'>`void MoveTo(string, bool);`</a> |

---

<a id='user-content-ifileinfomoveto1'></a>
```csharp
void MoveTo(string destFileName);
```

Moves a specified file to a new location, providing the option to specify a new file name.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to move the file to, which can specify a different file name.

---

<a id='user-content-ifileinfomoveto2'></a>
```csharp
void MoveTo(string destFileName, bool overwrite);
```

Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to move the file to, which can specify a different file name.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to overwrite the destination file if it already exists; false otherwise.

### IFileInfo.Open

| Signatures                                                                                      |
|-------------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileinfoopen1">`IFileStream Open(FileMode);`</a>                        |
| <a href="#user-content-ifileinfoopen2">`IFileStream Open(FileMode, FileAccess);`</a>            |
| <a href="#user-content-ifileinfoopen3">`IFileStream Open(FileMode, FileAccess, FileShare);`</a> |

---

<a id="user-content-ifileinfoopen1"></a>
```csharp
IFileStream Open(System.IO.FileMode mode);
```

Opens a file in the specified mode.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode constant specifying the mode (for example, Open or Append) in which to open the file.

**returns** [IFileStream](./FileStream.md)

A file opened in the specified mode, with read/write access and unshared.

---

<a id="user-content-ifileinfoopen2"></a>
```csharp
IFileStream Open(System.IO.FileMode mode, System.IO.FileAccess access);
```

Opens a file in the specified mode with read, write, or read/write access.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode constant specifying the mode (for example, Open or Append) in which to open the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess constant specifying whether to open the file with Read, Write, or ReadWrite file access.

**returns** [IFileStream](./FileStream.md)

A FileStream object opened in the specified mode and access, and unshared.

---

<a id="user-content-ifileinfoopen3"></a>
```csharp
IFileStream Open(System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Opens a file in the specified mode with read, write, or read/write access and the specified sharing option.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode constant specifying the mode (for example, Open or Append) in which to open the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess constant specifying whether to open the file with Read, Write, or ReadWrite file access.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A FileShare constant specifying the type of access other FileStream objects have to this file.

**returns** [IFileStream](./FileStream.md)

A FileStream object opened with the specified mode, access, and sharing options.

### IFileInfo.OpenRead

```csharp
IFileStream OpenRead ();
```

Creates a read-only FileStream.

**returns** [IFileStream](./FileStream.md)

A new read-only FileStream object.

### IFileInfo.OpenText

```csharp
System.IO.StreamReader OpenText ();
```

Creates a StreamReader with UTF8 encoding that reads from an existing text file.

**returns** [System.IO.StreamReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-6.0)

A new StreamReader with UTF8 encoding.

### IFileInfo.OpenWrite

```csharp
IFileStream OpenWrite ();
```

Creates a write-only FileStream.

**returns** [IFileStream](./FileStream.md)

A write-only unshared FileStream object for a new or existing file.

### IFileInfo.Replace

| Signatures                                                                                |
|-------------------------------------------------------------------------------------------|
| <a href="#user-content-ifileinforeplace1">`IFileInfo Replace(string, string?);`</a>       |
| <a href="#user-content-ifileinforeplace2">`IFileInfo Replace(string, string?, bool);`</a> |

---

<a id="user-content-ifileinforeplace1"></a>
```csharp
IFileInfo Replace(string destinationFileName, string? destinationBackupFileName);
```

Replaces the contents of a specified file with the file described by the current FileInfo object, deleting the original file, and creating a backup of the replaced file.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file to replace with the current file.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of a file with which to create a backup of the file described by the destFileName parameter.

**returns** [IFileInfo](./FileInfo.md)

A FileInfo object that encapsulates information about the file described by the destFileName parameter.

---

<a id="user-content-ifileinforeplace2"></a>
```csharp
IFileInfo Replace(string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
```

Replaces the contents of a specified file with the file described by the current FileInfo object, deleting the original file, and creating a backup of the replaced file. Also specifies whether to ignore merge errors.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file to replace with the current file.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of a file with which to create a backup of the file described by the destFileName parameter.

**ignoreMetadataErrors** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to ignore merge errors (such as attributes and ACLs) from the replaced file to the replacement file; otherwise false.

**returns** [IFileInfo](./FileInfo.md)

A FileInfo object that encapsulates information about the file described by the destFileName parameter.