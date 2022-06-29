<!--bl
(filemeta
    (title "Atomic File System"))
/bl-->

### Summary

The Atomic File System represent short lived use of the file system. This represents a way to handle when we have objects that live for the length of a method or function but do not persist as file system objects afterwards.

There is one interface and one concrete class. The concrete class inherits the interface. It is recommended you access the class through the interface.

```csharp
public interface IAtomicFileSystem
```

### IAtomicFileSystem

- [1.1 Replace](#user-content-iatomicfilesystemreplace)
- [1.2 File Stream](#user-content-iatomicfilesystemfilestream)
- [1.3 Drive Info](#user-content-iatomicfilesystemdriveinfo)
- [1.4 Directory Info](#user-content-iatomicfilesystemdirectoryinfo)
- [1.5 File Info](#user-content-iatomicfilesystemfileinfo)
- [1.6 Drives](#user-content-iatomicfilesystemdrives)
- [1.7 Directory](#user-content-iatomicfilesystemdirectory)
- [1.8 File](#user-content-iatomicfilesystemfile)

#### IAtomicFileSystem.Replace

```csharp
IAtomicReplacementBuilder Replace { get; }
```

Replace builds an [Atomic Replacement Builder](#user-content-atomic-replacement-builder) to allow for the testing of code that takes an Atomic File System.

#### IAtomicFileSystem.FileStream

| Signatures                                                                                                                                    |
|-----------------------------------------------------------------------------------------------------------------------------------------------|
| <a href='#iatomicactionsfilestream1'>`IAtomicActions<IFileStream> FileStream(string, FileMode, FileAccess, FileShare, int, FileOptions);`</a> |
| <a href='#iatomicactionsfilestream2'>`IAtomicActions<IFileStream> FileStream(string, FileMode, FileAccess, FileShare, int);`</a>              |
| <a href='iatomicactionsfilestream3'>`IAtomicActions<IFileStream> FileStream(string, FileMode, FileAccess, FileShare);`</a>                    |
| <a href='iatomicactionsfilestream4'>`IAtomicActions<IFileStream> FileStream(string, FileMode, FileAccess, FileShare, int, bool);`</a>         |
| <a href='iatomicactionsfilestream5'>`IAtomicActions<IFileStream> FileStream(string, FileMode, FileAccess);`</a>                               |

---

<a id='iatomicactionsfilestream1'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, System.IO.FileOptions options);
```

Returns an IAtomicActions allowing the interaction with a IFileStream specified by the parameters. The IFileStream object is created before and disposed of after each atomic action method call.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current IFileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the IFileStream object. This also determines the values returned by the CanRead and CanWrite properties of the IFileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

A bitwise combination of the enumeration values that specifies additional file options.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](./documentation/structures/primitives/FileStream.md)>

An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

---

<a id='iatomicactionsfilestream2'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize);
```

Returns an [IAtomicActions](#user-content-atomic-actions) allowing the interaction with a [IFileStream](./documentation/structures/primitives/FileStream.md) specified by the parameters. The [IFileStream](#user-content-file-stream) object is created before and disposed of after each atomic action method call.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current [IFileStream](#user-content-file-stream) object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the [IFileStream](#user-content-file-stream) object. This also determines the values returned by the CanRead and CanWrite properties of the [IFileStream](#user-content-file-stream) object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](#user-content-file-stream)>

An atomic action allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

---

<a id='iatomicactionsfilestream3'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Returns [IAtomicActions](#user-content-atomic-actions) allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters.  The [IFileStream](#user-content-file-stream) object is created before and disposed of after each atomic action method call.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current [IFileStream](#user-content-file-stream) object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the [IFileStream](#user-content-file-stream) object. This also determines the values returned by the CanRead and CanWrite properties of the [IFileStream](#user-content-file-stream) object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](#user-content-file-stream)>

An atomic action allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

---

<a id='iatomicactionsfilestream4'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, bool useAsync);
```

Returns an atomic action allowing the interaction with a IFileStream specified by the parameters.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current IFileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the IFileStream object. This also determines the values returned by the CanRead and CanWrite properties of the IFileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**useAsync** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

Specifies whether to use asynchronous I/O or synchronous I/O. However, note that the underlying operating system might not support asynchronous I/O, so when specifying true, the handle might be opened synchronously depending on the platform. When opened asynchronously, the BeginRead(Byte[], Int32, Int32, AsyncCallback, Object) and BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object) methods perform better on large reads or writes, but they might be much slower for small reads or writes. If the application is designed to take advantage of asynchronous I/O, set the useAsync parameter to true. Using asynchronous I/O correctly can speed up applications by as much as a factor of 10, but using it without redesigning the application for asynchronous I/O can decrease performance by as much as a factor of 10.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](#user-content-file-stream)>

An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

---

<a id='iatomicactionsfilestream5'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access);
```

Returns an atomic action allowing the interaction with a IFileStream specified by the parameters.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current IFileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the IFileStream object. This also determines the values returned by the CanRead and CanWrite properties of the IFileStream object. CanSeek is true if path specifies a disk file.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](#user-content-file-stream)>

An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

#### IAtomicFileSystem.DriveInfo

```csharp
IAtomicActions<IDriveInfo> DriveInfo(string driveName);
```

Returns an atomic action allowing the interaction with a IDriveInfo specified by the drive name.

**driveName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDriveInfo](#use-content-drive-info)>

An atomic action allowing the interaction with a IDriveInfo specified by the drive name.

#### IAtomicActions.DirectoryInfo

```csharp
IAtomicActions<IDirectoryInfo> DirectoryInfo(string path);
```

Returns an atomic action allowing the interaction with a IDirectoryInfo specified by the path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string specifying the path on which to create the IDirectoryInfo.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDirectoryInfo](#user-content-directory-info)>

An atomic action allowing the interaction with a IDirectoryInfo specified by the path.

#### IAtomicFileSystem.FileInfo

```csharp
IAtomicActions<IFileInfo> FileInfo(string fileName);
```

Returns an atomic action allowing the interaction with a IFileInfo specified by the file name.

**fileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.

**returns ** [IAtomicActions](#user-content-atomic-actions)<[IFileInfo](#user-content-file-info)>

An atomic action allowing the interaction with a IFileInfo specified by the file name.

### IAtomicFileSystem.Drives

```csharp
IAtomicActions<IDrives> Drives { get; }
```

Returns an atomic action allowing the interaction with a IDrives.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDrives](#user-content-drives)>

An atomic action allowing the interaction with a IDrives.

### IAtomicFileSystem.Directory

```csharp
IAtomicActions<IDirectory> Directory { get; }
```

Returns an atomic action allowing the interaction with IDirectory.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDirectory](#user-content-directory)>

An atomic action allowing the interaction with IDirectory.

### IAtomicFileSystem.File

```csharp
IAtomicActions<IFile> File { get; }
```

Returns an atomic action allowing the interaction with IFile.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFile](#user-content-file)>

An atomic action allowing the interaction with IFile.