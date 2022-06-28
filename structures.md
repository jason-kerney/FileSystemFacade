
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade Structures #
#### A guide to the interfaces and objects in this library. ####

## Table Of Contents ##

- [Section 1: Atomic File System](#user-content-atomic-file-system)
- [Section 2: Atomic Actions](#user-content-atomic-actions)
- [Section 3: Atomic Replacement Builder](#user-content-atomic-replacement-builder)
- [Section 4: File Stream Factory](#user-content-file-stream-factory)
- [Section 5: File Stream](#user-content-file-stream)
- [Section 6: File System Watcher Factory](#user-content-file-system-watcher-factory)
- [Section 7: File System Watcher](#user-content-file-system-watcher)
- [Section 8: Wait For Changed Result](#user-content-wait-for-changed-result)
- [Section 9: Drive Info Factory](#user-content-drive-info-factory)
- [Section 10: Drive Info](#user-content-drive-info)
- [Section 11: File System Info](#user-content-file-system-info)
- [Section 12: Directory Info Factory](#user-content-directory-info-factory)
- [Section 13: Directory Info](#user-content-directory-info)
- [Section 14: File Info Factory](#user-content-file-info-factory)
- [Section 15: File Info](#user-content-file-info)
- [Section 16: Drives](#user-content-drives)
- [Section 17: Directory](#user-content-directory)
- [Section 18: File](#user-content-file)

## Atomic File System ##

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

Returns an [IAtomicActions](#user-content-atomic-actions) allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters. The [IFileStream](#user-content-file-stream) object is created before and disposed of after each atomic action method call.

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

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

A bitwise combination of the enumeration values that specifies additional file options.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](#user-content-file-stream)>

An atomic action allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

---

<a id='iatomicactionsfilestream2'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize);
```

Returns an [IAtomicActions](#user-content-atomic-actions) allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters. The [IFileStream](#user-content-file-stream) object is created before and disposed of after each atomic action method call.

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
    

## Atomic Actions ##

### Summary

This object allows for the interaction with filesystem objects in a discrete and short lived way.

```csharp
public interface IAtomicActions<out TFileSystem>
```

**TFileSystem**

The type of file system object it interacts with.

### IAtomicActions

- [2.1 Preform](#user-content-iatomicactionspreform)
- [2.2 Get By](#user-content-iatomicactionsgetby)

### IAtomicActions.Preform

```csharp
void Preform(Action<TFileSystem> doer);
```

Allows a non returning action to be performed on the TFileSystem.

**doer** [Action\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=net-6.0)

An action that takes a TFileSystem and acts on it.

### IAtomicActions.GetBy

```csharp
TReturn GetBy<TReturn>(Func<TFileSystem, TReturn> getter);
```

Allows for an activity to be done on TFileSystem that also returns a value.

**getter** [Func\<T,TResult\>](https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=net-6.0)

A func that takes a type TFileSystem and returns TReturn.

**TReturn**

The type to return.

**returns** TReturn

A type TReturn, that is returned from the getter.

    

## Atomic Replacement Builder ##

### Summary

A Builder for temporarily replacing the file system. This object is intended to make testing easier.

```csharp
public interface IAtomicReplacementBuilder
```

### IAtomicReplacementBuilder

- [3.1 File Stream](#user-content-iatomicreplacementbuilderfilestream)
- [3.2 File System Watcher](#user-content-iatomicreplacementbuilderfilesystemwatcher)
- [3.3 File Info](#user-content-iatomicreplacementbuilderfileinfo)
- [3.4 Directory Info](#user-content-iatomicreplacementbuilderdirectoryinfo)
- [3.5 Drive Info](#user-content-iatomicreplacementbuilderdriveinfo)
- [3.6 Drives](#user-content-iatomicreplacementbuilderdrives)
- [3.7 Directory](#user-content-iatomicreplacementbuilderdirectory)
- [3.8 File](#user-content-iatomicreplacementbuilderfile)
- [3.9 Use](#user-content-iatomicreplacementbuilderuse)

### IAtomicReplacementBuilder.FileStream

```csharp
IAtomicReplacementBuilder FileStream(IFileStreamFactory factory);
```

Allows for the factory that builds IFileStream objects to be temporarily replaced.

**factory** [IFileStreamFactory](#user-content-file-stream-factory)

The IFileStream Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with the IFileStreamFactory configured to be replaced.

### IAtomicReplacementBuilder.FileSystemWatcher

```csharp
IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherFactory factory);
```

Allows for the factory that builds IFileSystemWatcher objects to be replaced.

**factory** [IFileSystemWatcherFactory](#user-content-file-system-watcher-factory)

The IFileSystemWatcher Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with the IFileWatcherFactory configured to be replaced.

### IAtomicReplacementBuilder.FileInfo

```csharp
IAtomicReplacementBuilder FileInfo(IFileInfoFactory factory);
```

Allows for the factory that builds IFileInfo objects to be temporarily replaced.

**factory** [IFileInfoFactory](#user-content-file-info-factory)

The IFileInfo Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IFileInfoFactory configured to be replaced.

### IAtomicReplacementBuilder.DirectoryInfo

```csharp
IAtomicReplacementBuilder DirectoryInfo(IDirectoryInfoFactory factory);
```

Allows for the factory that builds IDirectoryInfo objects to be replaced.

**factory** [IDirectoryInfoFactory](#user-content-directory-info-factory)

The IDirectoryInfo Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDirectoryInfoFactory configured to be replaced.

### IAtomicReplacementBuilder.DriveInfo

```csharp
IAtomicReplacementBuilder DriveInfo(IDriveInfoFactory factory);
```

Allows for the factory that builds IDriveInfo objects to be replaced.

**factory** [IDriveInfoFactory](#user-content-drive-info-factory)

The IDriveInfo Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDiveInfoFactory configured to be replaced.

### IAtomicReplacementBuilder.Drives

```csharp
IAtomicReplacementBuilder Drives(IDrives newDrives);
```

Configures IDrives to be replaced.

**newDrives** [IDrives](#user-content-drives)

The IDrives to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDrives configured to be replaced.

### IAtomicReplacementBuilder.Directory

```csharp
IAtomicReplacementBuilder Directory(IDirectory newDirectory);
```

Configures IDirectory to be replaced.

**newDirectory** [IDirectory](#user-content-directory)

The IDirectory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDirectory configured to be replaced.

### IAtomicReplacementBuilder.File

```csharp
IAtomicReplacementBuilder File(IFile newFile);
```

Configures IFile to be replaced.

**newFile** [IFile](#user-content-file)

The IFile to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IFile configured to be replaced.

### IAtomicReplacementBuilder.Use

```csharp
void Use(Action<IAtomicFileSystem> doer);
```

Takes an action, and calls it with a specially configured instance of IAtomicFileSystem where any item configured to be replaced is replaced. This allows testing of the use of the file system. NOTE: When 'Use' exits, the IAtomicFileSystem reverts to using the real file system. If captured during this time, when use exits, it will have no lasting effect of replacing the underlying file system.

**doer** [Action\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=net-6.0)

An action to call with the replaced file system.
    

## File Stream Factory ##

### Summary

Provides a Stream for a file, supporting both synchronous and asynchronous read and write operations.

```csharp
public interface IFileStreamFactory
```

### IFileStreamFactory

- [4.1 Get File Stream](#user-content-ifilestreamfactorygetfilestream)

### IFileStreamFactory.GetFileStream

| Signatures                                                                                                                              |
|-----------------------------------------------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamfactorygetfilestream1'>`IFileStream GetFileStream(string, FileMode, FileAccess, FileShare, int, FileOptions);`</a> |
| <a href='#ifilestreamfactorygetfilestream2'>`IFileStream GetFileStream(string, FileMode, FileAccess, FileShare, int);`</a>              |
| <a href='#ifilestreamfactorygetfilestream3'>`IFileStream GetFileStream(string, FileMode, FileAccess, FileShare);`</a>                   |
| <a href='#ifilestreamfactorygetfilestream4'>`IFileStream GetFileStream(string, FileMode, FileAccess, FileShare, int, bool);`</a>        |
| <a href='#ifilestreamfactorygetfilestream5'>`IFileStream GetFileStream(string, FileMode, FileAccess);`</a>                              |
---

<a id='ifilestreamfactorygetfilestream1'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, System.IO.FileOptions options);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

A bitwise combination of the enumeration values that specifies additional file options.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.

---

<a id='ifilestreamfactorygetfilestream2'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.

---

<a id='ifilestreamfactorygetfilestream3'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.

---

<a id='ifilestreamfactorygetfilestream4'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, bool useAsync);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**useAsync** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

Specifies whether to use asynchronous I/O or synchronous I/O. However, note that the underlying operating system might not support asynchronous I/O, so when specifying true, the handle might be opened synchronously depending on the platform. When opened asynchronously, the BeginRead(Byte[], Int32, Int32, AsyncCallback, Object) and BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object) methods perform better on large reads or writes, but they might be much slower for small reads or writes. If the application is designed to take advantage of asynchronous I/O, set the useAsync parameter to true. Using asynchronous I/O correctly can speed up applications by as much as a factor of 10, but using it without redesigning the application for asynchronous I/O can decrease performance by as much as a factor of 10.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.

---

<a id='ifilestreamfactorygetfilestream5'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access);
```

Creates a new instance of the FileStream class with the specified path, creation mode, and read/write permission.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, and read/write permission.

    

## File Stream ##

### Summary

Provides a Stream for a file, supporting both synchronous and asynchronous read and write operations.

This is a thin facade around [System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-6.0)

```csharp
public interface IFileStream : IDisposable, IAsyncDisposable
```

### IFileStream

- [5.01 Stream](#user-content-ifilestreamstream)
- [5.02 Can Read](#user-content-ifilestreamcanread)
- [5.02 Can Seek](#user-content-ifilestreamcanseek)
- [5.03 Can Timeout](#user-content-ifilestreamcantimeout)
- [5.04 Can Write](#user-content-ifilestreamcanwrite)
- [5.05 Is Async](#user-content-ifilestreamisasync)
- [5.06 Length](#user-content-ifilestreamlength)
- [5.07 Name](#user-content-ifilestreamname)
- [5.08 Position](#user-content-ifilestreamposition)
- [5.09 Read Timeout](#user-content-ifilestreamreadtimeout)
- [5.10 Safe File Handle](#user-content-ifilestreamsafefilehandle)
- [5.11 Write Timeout](#user-content-ifilestreamwritetimeout)
- [5.12 Begin Read](#user-content-ifilestreambeginread)
- [5.13 Begin Write](#user-content-ifilestreambeginwrite)
- [5.14 Close](#user-content-ifilestreamclose)
- [5.15 Copy To](#user-content-ifilestreamcopyto)
- [5.16 Copy To Async](#user-content-ifilestreamcopytoasync)
- [5.17 End Read](#user-content-ifilestreamendread)
- [5.18 End Write](#user-content-ifilestreamendwrite)
- [5.19 Flush](#user-content-ifilestreamflush)
- [5.20 Flush Async](#user-content-ifilestreamflushasync)
- [5.21 Lock](#user-content-ifilestreamlock)
- [5.22 Read](#user-content-ifilestreamread)
- [5.23 Read Async](#user-content-ifilestreamreadasync)
- [5.24 Read Byte](#user-content-ifilestreamreadbyte)
- [5.25 Seek](#user-content-ifilestreamseek)
- [5.26 Set Length](#user-content-ifilestreamsetlength)
- [5.27 Unlock](#user-content-ifilestreamunlock)
- [5.28 Write](#user-content-ifilestreamwrite)
- [5.29 Write Async](#user-content-ifilestreamwriteasync)
- [5.30 Write Byte](#user-content-ifilestreamwritebyte)

### IFileStream.Stream

```csharp
System.IO.Stream Stream { get; }
```

Gets the underlying stream.

**returns** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The underlying stream.

### IFileStream.CanRead

```csharp
bool CanRead { get; }
```

Gets a value that indicates whether the current stream supports reading.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports reading.

### IFileStream.CanSeek

```csharp
bool CanSeek { get; }
```

Gets a value that indicates whether the current stream supports seeking.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports seeking.

### IFileStream.CanTimeout

```csharp
bool CanTimeout { get; }
```

Gets a value that determines whether the current stream can time out.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that determines whether the current stream can time out.

### IFileStream.CanWrite

```csharp
bool CanWrite { get; }
```

Gets a value that indicates whether the current stream supports writing.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports writing.

### IFileStream.IsAsync

```csharp
bool IsAsync { get; }
```

Gets a value that indicates whether the FileStream was opened asynchronously or synchronously.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the FileStream was opened asynchronously or synchronously.

### IFileStream.Length

```csharp
long Length { get; }
```

Gets the length in bytes of the stream.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The length in bytes of the stream.

### IFileStream.Name

```csharp
string Name { get; }
```

Gets the absolute path of the file opened in the FileStream.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The absolute path of the file opened in the FileStream.

### IFileStream.Position

```csharp
long Position { get; set; }
```

Gets or sets the current position of this stream.

**value parameter**  [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The current position of this stream.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The current position of this stream.

### IFileStream.ReadTimeout

```csharp
int ReadTimeout { get; set; }
```

Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.

**value parameter** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to read before timing out.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to read before timing out.

### IFileStream.SafeFileHandle

```csharp
SafeFileHandle SafeFileHandle { get; }
```

Gets a SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.

**returns** [SafeFileHandle](https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.safehandles.safefilehandle?view=net-6.0)

A SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.

### IFileStream.WriteTimeout

```csharp
int WriteTimeout { get; set; }
```

Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.

**value parameter** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to write before timing out.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to write before timing out.

### IFileStream.BeginRead

```csharp
IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
```

Begins an asynchronous read operation. Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer to read data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in array at which to begin reading.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**callback** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[AsyncCallback](https://docs.microsoft.com/en-us/dotnet/api/system.asynccallback?view=net-6.0)\>

The method to be called when the asynchronous read operation is completed

**state**

A user-provided object that distinguishes this particular asynchronous read request from other requests.

**returns** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

An object that references the asynchronous read.

### IFileStream.BeginWrite

```csharp
IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
```

Begins an asynchronous write operation. Consider using WriteAsync(Byte[], Int32, Int32, CancellationToken) instead.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer containing data to write to the current stream.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The zero-based byte offset in array at which to begin copying bytes to the current stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to write.

**callback** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[AsyncCallback](https://docs.microsoft.com/en-us/dotnet/api/system.asynccallback?view=net-6.0)\>

The method to be called when the asynchronous write operation is completed.

**state** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[object](https://docs.microsoft.com/en-us/dotnet/api/system.object?view=net-6.0)\>

A user-provided object that distinguishes this particular asynchronous write request from other requests.

**returns** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

An object that references the asynchronous write.

### IFileStream.Close

```csharp
void Close();
```

Closes the current stream and releases any resources(such as sockets and file handles) associated with the current stream. Instead of calling this method, ensure that the stream is properly disposed.

### IFileStream.CopyTo

| Signatures                                                         |
|--------------------------------------------------------------------|
| <a href='#ifilestreamcopyto1'>`void CopyTo(Stream);`</a>           |
| <a href='#ifilestreamcopyto2'>`void CopyTo(IFileStream);`</a>      |
| <a href='#ifilestreamcopyto3'>`void CopyTo(Stream, int);`</a>      |
| <a href='#ifilestreamcopyto4'>`void CopyTo(IFileStream, int);`</a> |

---

<a id='ifilestreamcopyto1'></a>
```csharp
void CopyTo(System.IO.Stream destination);
```

Reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

---

<a id='ifilestreamcopyto2'></a>
```csharp
void CopyTo(IFileStream destination);
```

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](#user-content-file-stream)

The stream to which the contents of the current stream will be copied.

---

<a id='ifilestreamcopyto3></a>
```csharp
void CopyTo(System.IO.Stream destination, int bufferSize);
```

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size of the buffer. This value must be greater than zero. The default size is 81920.

---

<a id='ifilestreamcopyto4></a>
```csharp
void CopyTo(IFileStream destination, int bufferSize);
```

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](#user-content-file-stream)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size of the buffer. This value must be greater than zero. The default size is 81920.

### IFileStream.CopyToAsync

| Signatures                                                                                                                               |
|------------------------------------------------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamcopytoasync1'>`Task CopyToAsync(Stream, int, CancellationToken);`</a>                                               |
| <a href='#ifilestreamcopytoasync2'>`Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken);`</a> |
| <a href='#ifilestreamcopytoasync3'>`Task CopyToAsync(Stream, CancellationToken);`</a>                                                    |
| <a href='#ifilestreamcopytoasync4'>`Task CopyToAsync(IFileStream, CancellationToken);`</a>                                               |
| <a href='#ifilestreamcopytoasync5'>`Task CopyToAsync(Stream, int);`</a>                                                                  |
| <a href='#ifilestreamcopytoasync6'>`Task CopyToAsync(IFileStream, int);`</a>                                                             |
| <a href='#ifilestreamcopytoasync7'>`Task CopyToAsync(Stream);`</a>                                                                       |
| <a href='#ifilestreamcopytoasync8'>`Task CopyToAsync(IFileStream);`</a>                                                                  |

---

<a id='ifilestreamcopytoasync1'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination, int bufferSize, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync2></a>
```csharp
Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](#user-content-file-stream)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync3'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync4'></a>
```csharp
Task CopyToAsync(IFileStream destination, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](#user-content-file-stream)

The stream to which the contents of the current stream will be copied.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync5'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination, int bufferSize);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync6'></a>
```csharp
Task CopyToAsync(IFileStream destination, int bufferSize);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](#user-content-file-stream)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync7'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination);
```

Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync8'></a>
```csharp
Task CopyToAsync(IFileStream destination);
```

Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](#user-content-file-stream)

The stream to which the contents of the current stream will be copied.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

### IFileStream.EndRead

```csharp
int EndRead(IAsyncResult asyncResult);
```

Waits for the pending asynchronous read operation to complete.(Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.)

**asyncResult** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

The reference to the pending asynchronous request to wait for.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes read from the stream, between 0 and the number of bytes you requested. Streams only return 0 at the end of the stream, otherwise, they should block until at least 1 byte is available.

### IFileStream.EndWrite

```csharp
void EndWrite(IAsyncResult asyncResult);
```

Ends an asynchronous write operation and blocks until the I/O operation is complete.(Consider using WriteAsync(Byte[], Int32, Int32, CancellationToken) instead.)

**asyncResult** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

The pending asynchronous I/O request.

### IFileStream.Flush

| Signatures                                                       |
|------------------------------------------------------------------|
| <a href='#ifilestreamflush1'>`void Flush();`</a>                 |
| <a href='#ifilestreamflush2'>`void Flush(bool flushToDisk);`</a> |

---

<a id='ifilestreamflush1'></a>
```csharp
void Flush();
```

Clears buffers for this stream and causes any buffered data to be written to the file.

---

<a id='ifilestreamflush2'></a>
```csharp
void Flush(bool flushToDisk);
```

Clears buffers for this stream and causes any buffered data to be written to the file, and also clears all intermediate file buffers.

**flushToDisk** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to flush all intermediate file buffers; otherwise, false.

### IFileStream.FlushAsync

| Signatures                                                                  |
|-----------------------------------------------------------------------------|
| <a href='#ifilestreamflushasync1'>`Task FlushAsync();`</a>                  |
| <a href='#ifilestreamflushasync2'>`Task FlushAsync(CancellationToken);`</a> |

---

<a id='ifilestreamflushasync1'></a>
```csharp
Task FlushAsync();
```

Asynchronously clears all buffers for this stream and causes any buffered data to be written to the underlying device.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous flush operation.

---

<a id='ifilestreamflushasync2'></a>
```csharp
Task FlushAsync(CancellationToken cancellationToken);
```

Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors cancellation requests.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous flush operation.

### IFileStream.Lock

```csharp
[System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
[System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
[System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
void Lock(long position, long length);
```

Prevents other processes from reading from or writing to the FileStream.

**position** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The beginning of the range to lock. The value of this parameter must be equal to or greater than zero(0).

**length** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The range to be locked.

### IFileStream.Read

| Signatures                                                    |
|---------------------------------------------------------------|
| <a href='#ifilestreamread1'>`int Read(byte[], int, int);`</a> |
| <a href='#ifilestreamread2'>`int Read(Span<byte>);`</a>       |

---

<a id='ifilestreamread1'></a>
```csharp
int Read(byte[] buffer, int offset, int count);
```

Reads a block of bytes from the stream and writes the data in a given buffer.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

When this method returns, contains the specified byte array with the values between offset and(offset + count - 1) replaced by the bytes read from the current source.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in array at which the read bytes will be placed.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The total number of bytes read into the buffer. This might be less than the number of bytes requested if that number of bytes are not currently available, or zero if the end of the stream is reached.

---

<a id='ifilestreamread2'></a>
```csharp
int Read(Span<byte> buffer);
```

Reads a sequence of bytes from the current file stream and advances the position within the file stream by the number of bytes read.

**buffer** [Span](https://docs.microsoft.com/en-us/dotnet/api/system.span-1?view=net-6.0)<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)>

A region of memory. When this method returns, the contents of this region are replaced by the bytes read from the current file stream.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The total number of bytes read into the buffer. This can be less than the number of bytes allocated in the buffer if that many bytes are not currently available, or zero(0) if the end of the stream has been reached.

### IFileStream.ReadAsync

| Signatures                                                                                        |
|---------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamreadasync1'>`ValueTask<int> ReadAsync(Memory<byte>, CancellationToken);`</a> |
| <a href='#ifilestreamreadasync2'>`Task<int> ReadAsync(byte[], int, int);`</a>                     |
| <a href='#ifilestreamreadasync3'>`Task<int> ReadAsync(byte[], int, int, CancellationToken);`</a>  |

---

<a id='ifilestreamreadasync1'></a>
```csharp
ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);
```

Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.

**buffer** [Memory](https://docs.microsoft.com/en-us/dotnet/api/system.memory-1?view=net-6.0)<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)>

The region of memory to write the data into.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1?view=net-6.0)<[int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)>

A task that represents the asynchronous read operation. The value of its Result property contains the total number of bytes read into the buffer. The result value can be less than the number of bytes allocated in the buffer if that many bytes are not currently available, or it can be 0(zero) if the end of the stream has been reached.

---

<a id='ifilestreamreadasync2'></a>
```csharp
Task<int> ReadAsync(byte[] buffer, int offset, int count);
```

Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer to write the data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in buffer at which to begin writing data from the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)\>

A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0(zero) if the end of the stream has been reached.

---

<a id='ifilestreamreadasync3'></a>
```csharp
Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
```

Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer to write the data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in buffer at which to begin writing data from the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)\>

A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0(zero) if the end of the stream has been reached.

### IFileStream.ReadByte

```csharp
int ReadByte();
```

Reads a byte from the file and advances the read position one byte.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte, cast to an Int32, or -1 if the end of the stream has been reached.

### IFileStream.Seek

```csharp
long Seek(long offset, System.IO.SeekOrigin origin);
```

Sets the current position of this stream to the given value.

**offset** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The point relative to origin from which to begin seeking.

**origin** [System.IO.SeekOrigin](https://docs.microsoft.com/en-us/dotnet/api/system.io.seekorigin?view=net-6.0)

Specifies the beginning, the end, or the current position as a reference point for offset, using a value of type SeekOrigin.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The new position in the stream.

### IFileStream.SetLength

```csharp
void SetLength(long value);
```

Sets the length of this stream to the given value.

**value**

The new length of the stream.

### IFileStream.Unlock

```csharp
[System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
[System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
[System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
void Unlock(long position, long length);
```

Allows access by other processes to all or part of a file that was previously locked.

**position**

The beginning of the range to unlock.

**length**

The range to be unlocked.

### IFileStream.Write

| Signatures                                                         |
|--------------------------------------------------------------------|
| <a href='#ifilestreamwrite1'>`void Write(byte[], int, int);`</a>   |
| <a href='#ifilestreamwrite2'>`void Write(ReadOnlySpan<byte>);`</a> |

---

<a id='ifilestreamwrite1'></a>
```csharp
void Write(byte[] buffer, int offset, int count);
```

Writes a block of bytes to the file stream.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer containing data to write to the stream.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The zero-based byte offset in array from which to begin copying bytes to the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to write.

---

<a id='ifilestreamwrite2'></a>
```csharp
void Write(ReadOnlySpan<byte> buffer);
```

Writes a sequence of bytes from a read-only span to the current file stream and advances the current position within this file stream by the number of bytes written.

**buffer** [ReadOnlySpan](https://docs.microsoft.com/en-us/dotnet/api/system.readonlyspan-1?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

A region of memory. This method copies the contents of this region to the current file stream.

### IFileStream.WriteAsync

| Signatures                                                                                             |
|--------------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamwriteasync1'>`ValueTask WriteAsync(ReadOnlyMemory<byte>, CancellationToken);`</a> |
| <a href='#ifilestreamwriteasync2'>`Task WriteAsync(byte[], int, int);`</a>                             |

---

<a id='ifilestreamwriteasync1'></a>
```csharp
ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
```

Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number of bytes written, and monitors cancellation requests.

**buffer** [ReadOnlyMemory](https://docs.microsoft.com/en-us/dotnet/api/system.readonlymemory-1?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The region of memory to write data from.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask?view=net-6.0)

A task that represents the asynchronous write operation.

---

<a id='ifilestreamwriteasync2'></a>
```csharp
Task WriteAsync(byte[] buffer, int offset, int count);
```

Asynchronously writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer to write data from.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The zero-based byte offset in buffer from which to begin copying bytes to the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to write.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### IFileStream.WriteByte

```csharp
void WriteByte(byte value);
```

Writes a byte to the current position in the file stream.

**value**

A byte to write to the stream.
    

## File System Watcher Factory ##

<-- 6 -->

## Summary

A factory to build IFileSystemWatcher objects

```csharp
public interface IFileSystemWatcherFactory
```

## IFileSystemWatcherFactory

- [6.1 Get File System Watcher](#user-content-ifilesystemwatcherfactorygetfilesystemwatcher)

## IFileSystemWatcherFactory.GetFileSystemWatcher

| Signatures                                                                                                               |
|--------------------------------------------------------------------------------------------------------------------------|
| <a href='#ifilesystemwatcherfactorygetfilesystemwatcher1'>`IFileSystemWatcher GetFileSystemWatcher();`</a>               |
| <a href='#ifilesystemwatcherfactorygetfilesystemwatcher2'>`IFileSystemWatcher GetFileSystemWatcher(string);`</a>         |
| <a href='#ifilesystemwatcherfactorygetfilesystemwatcher3'>`IFileSystemWatcher GetFileSystemWatcher(string, string);`</a> |

---

<a id='ifilesystemwatcherfactorygetfilesystemwatcher1'></a>
```csharp
IFileSystemWatcher GetFileSystemWatcher();
```

Creates a new instance of the FileSystemWatcher class.

**returns** [IFileSystemWatcher](#user-content-file-system-watcher)

A  new instance of the FileSystemWatcher class.

---

<a id='ifilesystemwatcherfactorygetfilesystemwatcher2'></a>
```csharp
IFileSystemWatcher GetFileSystemWatcher(string path);
```

Creates a new instance of the FileSystemWatcher class, given the specified directory to monitor.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The directory to monitor, in standard or Universal Naming Convention (UNC) notation.

**returns** [IFileSystemWatcher](#user-content-file-system-watcher)

A new instance of the FileSystemWatcher class, given the specified directory to monitor.

---

<a id='ifilesystemwatcherfactorygetfilesystemwatcher3'></a>
```csharp
IFileSystemWatcher GetFileSystemWatcher(string path, string filter);
```

Creates a new instance of the FileSystemWatcher class, given the specified directory and type of files to monitor.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The directory to monitor, in standard or Universal Naming Convention (UNC) notation.

**filter** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The type of files to watch. For example, "*.txt" watches for changes to all text files.

**returns** [IFileSystemWatcher](#user-content-file-system-watcher)

A new instance of the FileSystemWatcher class, given the specified directory and type of files to monitor.

    

## File System Watcher ##

## Summary

Listens to the file system change notifications and raises events when a directory, or file in a directory, changes.

This is a thin facade around [System.IO.FileSystemWatcher](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher?view=net-6.0)

```csharp
interface IFileSystemWatcher : ISupportInitialize, IDisposable, IComponent
```

## IFileSystemWatcher

- [7.01 Container](#user-content-ifilesystemwatchercontainer)
- [7.02 Enable Raising Events](#user-content-ifilesystemwatcherenableraisingevents)
- [7.03 Filter](#user-content-ifilesystemwatcherfilter)
- [7.04 Filters](#user-content-ifilesystemwatcherfilters)
- [7.05 Include Subdirectories](#user-content-ifilesystemwatcherincludesubdirectories)
- [7.06 Notify Filters](#user-content-ifilesystemwatchernotifyfilters)
- [7.07 Synchronizing Object](#user-content-ifilesystemwatchersynchronizingobject)
- [7.08 Changed](#user-content-ifilesystemwatcherchanged)
- [7.09 Created](#user-content-ifilesystemwatchercreated)
- [7.10 Deleted](#user-content-ifilesystemwatcherdeleted)
- [7.11 Error](#user-content-ifilesystemwatchererror)
- [7.12 Renamed](#user-content-ifilesystemwatcherrenamed)
- [7.13 Wait For Changed](#user-content-ifilesystemwatcherwaitforchanged)

## IFileSystemWatcher.Container

```csharp
[Browsable(false)] IContainer? Container { get; }
```

Gets the IContainer that contains the Component.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IContainer](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.icontainer?view=net-6.0)\>

The IContainer that contains the Component.

## IFileSystemWatcher.EnableRaisingEvents

```csharp
bool EnableRaisingEvents { get; set; }
```

Gets or sets a value indicating whether the component is enabled.

**value parameter** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the component is enabled.

**return value** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the component is enabled.

## IFileSystemWatcher.Filter

```csharp
string Filter { get; set; }
```

Gets or sets the filter string used to determine what files are monitored in a directory.

**value parameter** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The filter string used to determine what files are monitored in a directory.

**return** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The filter string used to determine what files are monitored in a directory.

## IFileSystemWatcher.Filters

```csharp
Collection<string> Filters { get; }
```

Gets the collection of all the filters used to determine what files are monitored in a directory.

**returns** [Collection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.collection-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The collection of all the filters used to determine what files are monitored in a directory.

## IFileSystemWatcher.IncludeSubdirectories

```csharp
bool IncludeSubdirectories { get; set; }
```

Gets or sets a value indicating whether subdirectories within the specified path should be monitored.

**value parameter** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether subdirectories within the specified path should be monitored.

**return** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether subdirectories within the specified path should be monitored.

## IFileSystemWatcher.InternalBufferSize

```csharp
int InternalBufferSize { get; set; }
```

Gets or sets the size (in bytes) of the internal buffer.

*value parameter* [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size (in bytes) of the internal buffer.

*return* [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size (in bytes) of the internal buffer.

## IFileSystemWatcher.NotifyFilters

```csharp
System.IO.NotifyFilters NotifyFilter { get; set; }
```

Gets or sets the type of changes to watch for.

**value parameter** [System.IO.NotifyFilters](https://docs.microsoft.com/en-us/dotnet/api/system.io.notifyfilters?view=net-6.0)

The type of changes to watch for.

**return** [System.IO.NotifyFilters](https://docs.microsoft.com/en-us/dotnet/api/system.io.notifyfilters?view=net-6.0)

The type of changes to watch for.

## IFileSystemWatcher.SynchronizingObject

```csharp
ISynchronizeInvoke? SynchronizingObject { get; set; }
```

Gets or sets the object used to marshal the event handler calls issued as a result of a directory change.

## IFileSystemWatcher.Changed

```csharp
event System.IO.FileSystemEventHandler? Changed;
```

Occurs when a file or directory in the specified Path is changed.

**value** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[System.IO.FileSystemEventHandler](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemeventhandler?view=net-6.0)\>

A handler that handles when a file or directory in the specified Path is changed.

## IFileSystemWatcher.Created

```csharp
event System.IO.FileSystemEventHandler? Created;
```

Occurs when a file or directory in the specified Path is created.

**value** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[System.IO.FileSystemEventHandler](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemeventhandler?view=net-6.0)\>

A handler that handles when a file or directory in the specified Path is created.

## IFileSystemWatcher.Deleted

```csharp
event System.IO.FileSystemEventHandler? Deleted;
```

Occurs when a file or directory in the specified Path is deleted.

**value** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[System.IO.FileSystemEventHandler](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemeventhandler?view=net-6.0)\>

A handler that handles when a file or directory in the specified Path is deleted.

## IFileSystemWatcher.Error

```csharp
event System.IO.ErrorEventHandler? Error;
```

Occurs when the instance of FileSystemWatcher is unable to continue monitoring changes or when the internal buffer overflows.

**value** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[System.IO.FileSystemEventHandler](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemeventhandler?view=net-6.0)\>

A handler that handles when the instance of FileSystemWatcher is unable to continue monitoring changes or when the internal buffer overflows.

## IFileSystemWatcher.Renamed

```csharp
event System.IO.RenamedEventHandler? Renamed;
```

Occurs when a file or directory in the specified Path is renamed.

**value** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[System.IO.FileSystemEventHandler](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemeventhandler?view=net-6.0)\>

A handler that handles when a file or directory in the specified Path is renamed.

## IFileSystemWatcher.WaitForChanged

| Signatures                                                                                                                  |
|-----------------------------------------------------------------------------------------------------------------------------|
| <a href='#ifilesystemwatcherwaitforchanged1'>`IWaitForChangedResult WaitForChanged(WatcherChangeTypes);`                    |
| <a href='#ifilesystemwatcherwaitforchanged2'>`IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes, int);`</a> |

---

<a id='ifilesystemwatcherwaitforchanged1'></a>
```csharp
IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType);
```

A synchronous method that returns a structure that contains specific information on the change that occurred, given the type of change you want to monitor.

**changeType** [System.IO.WatcherChangeTypes](https://docs.microsoft.com/en-us/dotnet/api/system.io.watcherchangetypes?view=net-6.0)

The WatcherChangeTypes to watch for.

**returns** [IWaitForChangedResult](#user-content-wait-for-changed-result)

A WaitForChangedResult that contains specific information on the change that occurred.

---

<a id='ifilesystemwatcherwaitforchanged2'></a>
```csharp
IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType, int timeout);
```

A synchronous method that returns a structure that contains specific information on the change that occurred, given the type of change you want to monitor and the time (in milliseconds) to wait before timing out.

**changeType** [System.IO.WatcherChangeTypes](https://docs.microsoft.com/en-us/dotnet/api/system.io.watcherchangetypes?view=net-6.0)

The WatcherChangeTypes to watch for.

**timeout** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The time (in milliseconds) to wait before timing out.

**returns** [IWaitForChangedResult](#user-content-wait-for-changed-result)

A WaitForChangedResult that contains specific information on the change that occurred.
    

## Wait For Changed Result ##

## Summary

Contains information on the change that occurred.

This is a thin facade over [System.IO.WaitForChangedResult](https://docs.microsoft.com/en-us/dotnet/api/system.io.waitforchangedresult?view=net-6.0)

```csharp
public interface IWaitForChangedResult
```

## IWaitForChangedResult

- [8.1 Change Type](#user-content-iwaitforchangedresultchangetype)
- [8.2 Name](#user-content-iwaitforchangedresultname)
- [8.3 Old Name](#user-content-iwaitforchangedresultoldname)
- [8.4 Timed Out](#user-content-iwaitforchangedresulttimedout)

## IWaitForChangedResult.ChangeType

```csharp
System.IO.WatcherChangeTypes ChangeType { get; set; }
```

Gets or sets the type of change that occurred.

**value parameter** [System.IO.WatcherChangeTypes](https://docs.microsoft.com/en-us/dotnet/api/system.io.watcherchangetypes?view=net-6.0)

The type of change that occurred.

**return** [System.IO.WatcherChangeTypes](https://docs.microsoft.com/en-us/dotnet/api/system.io.watcherchangetypes?view=net-6.0)

The type of change that occurred.

## IWaitForChangedResult.Name

```csharp
string? Name { get; set; }
```

Gets or sets the name of the file or directory that changed.

**value parameter** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the file or directory that changed.

**return** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the file or directory that changed.

## IWaitForChangedResult.OldName

```csharp
string? OldName { get; set; }
```

Gets or sets the original name of the file or directory that was renamed.

**value parameter** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The original name of the file or directory that was renamed.

**return** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The original name of the file or directory that was renamed.

## IWaitForChangedResult.TimedOut

```csharp
bool TimedOut { get; set; }
```

Gets or sets a value indicating whether the wait operation timed out.


**value parameter** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the wait operation timed out.

**return** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the wait operation timed out.
    

## Drive Info Factory ##

## Summary

A factory to build IDriveInfos

```csharp
public interface IDriveInfoFactory
```

<!-- 9 -->
## IDriveInfoFactory

- [9.1 Drive Info](#user-content-idriveinfofactorydriveInfo)

## IDriveInfoFactory.DriveInfo

```csharp
IDriveInfo DriveInfo(string driveName);
```

Provides access to information on the specified drive.

**driveName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.

**returns** [IDriveInfo](#user-content-drive-info)

Information on the specified drive.
    

## Drive Info ##

## Summary

This interface models a drive and provides methods and properties to query for drive information. Use IDrives to determine what drives are available; and use IDriveInfo to determine what type of drive it is. You can also query to determine the capacity and available free space on the drive.

This is a thin facade around [System.IO.DriveInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.driveinfo?view=net-6.0)

```csharp
public interface IDriveInfo
```

## IDriveInfo

- [10.1 Available Free Space](#user-content-idriveinfoavailablefreespace)
- [10.2 Drive Format](#user-content-idriveinfodriveformat)
- [10.3 Drive Type](#user-content-idriveinfodrivetype)
- [10.4 Is Ready](#user-content-idriveinfoisready)
- [10.5 Name](#user-content-idriveinfoname)
- [10.6 Root Directory](#user-content-idriveinforootdirectory)
- [10.7 Total Free Space](#user-content-idriveinfototalfreespace)
- [10.8 Total Size](#user-content-idriveinfototalsize)
- [10.9 Volume Label](#user-content-idriveinfovolumelabel)

<!-- user-content-idriveinfo -->

## IDriveInfo.AvailableFreeSpace

```csharp
long AvailableFreeSpace { get; }
```

Indicates the amount of available free space on a drive, in bytes.

**return** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The amount of available free space on a drive, in bytes.

## IDriveInfo.DriveFormat

```csharp
string DriveFormat { get; }
```

Gets the name of the file system, such as NTFS or FAT32.

**return** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file system, such as NTFS or FAT32.

## IDriveInfo.DriveType

```csharp
System.IO.DriveType DriveType { get; }
```

Gets the drive type, such as CD-ROM, removable, network, or fixed.

**return** [System.IO.DriveType](https://docs.microsoft.com/en-us/dotnet/api/system.io.drivetype?view=net-6.0)

The drive type, such as CD-ROM, removable, network, or fixed.

## IDriveInfo.IsReady

```csharp
bool IsReady { get; }
```

Gets a value that indicates whether a drive is ready.

**return** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether a drive is ready.

## IDriveInfo.Name

```csharp
string Name { get; }
```

Gets the name of a drive, such as C:\.

**return** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a drive, such as C:\.

## IDriveInfo.RootDirectory

```csharp
IDirectoryInfo RootDirectory { get; }
```

Gets the root directory of a drive.

**return** [IDirectoryInfo](#user-content-directory-info)

The root directory of a drive.

## IDriveInfo.TotalFreeSpace

```csharp
long TotalFreeSpace { get; }
```

Gets the total amount of free space available on a drive, in bytes.

**return** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The total amount of free space available on a drive, in bytes.

## IDriveInfo.TotalSize

```csharp
long TotalSize { get; }
```

Gets the total size of storage space on a drive, in bytes.

**return** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The total size of storage space on a drive, in bytes.

## IDriveInfo.VolumeLabel

```csharp
string VolumeLabel { get; [System.Runtime.Versioning.SupportedOSPlatform("windows")] set; }
```

Gets or sets the volume label of a drive.

**value parameter** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

_Only available in Windows based OS_

The volume label of a drive.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The volume label of a drive.
    

## File System Info ##

## Summary

Provides the interface class for both IFileInfo and IDirectoryInfo objects.

This is a thin facade around [System.IO.FileSystemInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesysteminfo?view=net-6.0)

```csharp
public interface IFileSystemInfo
```

## IFileSystemInfo

- [11.01 Attributes](#user-content-ifilesysteminfoattributes)
- [11.02 Creation Time](#user-content-ifilesysteminfocreationtime)
- [11.03 Creation Time Utc](#user-content-ifilesysteminfocreationtimeutc)
- [11.04 Exists](#user-content-ifilesysteminfoexists)
- [11.05 Extension](#user-content-ifilesysteminfoextension)
- [11.06 Full Name](#user-content-ifilesysteminfofullname)
- [11.07 Last Access Time](#user-content-ifilesysteminfolastaccesstime)
- [11.08 Last Access Time Utc](#user-content-ifilesysteminfolastaccesstimeutc)
- [11.09 Last Write Time](#user-content-ifilesysteminfolastwritetime)
- [11.10 Last Write Time Utc](#user-content-ifilesysteminfolastwritetimeutc)
- [11.11 Name](#user-content-ifilesysteminfoname)
- [11.12 Delete](#user-content-ifilesysteminfodelete)
- [11.13 Get Object Data](#user-content-ifilesysteminfogetobjectdata)
- [11.14 Refresh](#user-content-ifilesysteminforefresh)

## IFileSystemInfo.Attributes

```csharp
System.IO.FileAttributes Attributes { get; set; }
```

Gets or sets the attributes for the current file or directory.

**parameter value** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The attributes for the current file or directory.

**return** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The attributes for the current file or directory.

## IFileSystemInfo.CreationTime

```csharp
DateTime CreationTime { get; set; }
```

Gets or sets the creation time of the current file or directory.

**value parameter** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time of the current file or directory.

**return** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time of the current file or directory.

## IFileSystemInfo.CreationTimeUtc

```csharp
DateTime CreationTimeUtc { get; set; }
```

Gets or sets the creation time, in coordinated universal time (UTC), of the current file or directory.

**parameter value** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time, in coordinated universal time (UTC), of the current file or directory.

**return** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time, in coordinated universal time (UTC), of the current file or directory.

## IFileSystemInfo.Exists

```csharp
bool Exists { get; }
```

Gets a value indicating whether the file or directory exists.

**return** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the file or directory exists.

## IFileSystemInfo.Extension

```csharp
string Extension { get; }
```

Gets the extension part of the file name, including the leading dot . even if it is the entire file name, or an empty string if no extension is present.

**return** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The extension part of the file name, including the leading dot . even if it is the entire file name, or an empty string if no extension is present.

## IFileSystemInfo.FullName

```csharp
string FullName { get; }
```

Gets the full path of the directory or file.

**return** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The full path of the directory or file.

## IFileSystemInfo.LastAccessTime

```csharp
DateTime LastAccessTime { get; set; }
```

Gets or sets the time the current file or directory was last accessed.

**return** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time the current file or directory was last accessed.

## IFileSystemInfo.LastAccessTimeUtc

```csharp
DateTime LastAccessTimeUtc { get; set; }
```

Gets or sets the time, in coordinated universal time (UTC), that the current file or directory was last accessed.

**parameter value** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), that the current file or directory was last accessed.

**return** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), that the current file or directory was last accessed.

## IFileSystemInfo.LastWriteTime

```csharp
DateTime LastWriteTime { get; set; }
```

Gets or sets the time when the current file or directory was last written to.

**value parameter** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time when the current file or directory was last written to.

**return** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time when the current file or directory was last written to.

## IFileSystemInfo.LastWriteTimeUtc

```csharp
DateTime LastWriteTimeUtc { get; set; }
```

Gets or sets the time, in coordinated universal time (UTC), when the current file or directory was last written to.

**value parameter** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), when the current file or directory was last written to.

**return** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), when the current file or directory was last written to.

## IFileSystemInfo.Name
```csharp
string Name { get; }
```

For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.

**return** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

For files, returns the name of the file. For directories, returns the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property returns the name of the directory.

## IFileSystemInfo.Delete

```csharp
void Delete ();
```

Deletes a file or directory.

## IFileSystemInfo.GetObjectData

```csharp
void GetObjectData (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
```

Sets the SerializationInfo object with the file name and additional exception information.

**info** [System.Runtime.Serialization.SerializationInfo](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.serializationinfo?view=net-6.0)

The SerializationInfo that holds the serialized object data about the exception being thrown.

**context** [System.Runtime.Serialization.StreamingContext](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.streamingcontext?view=net-6.0)

The StreamingContext that contains contextual information about the source or destination.

## IFileSystemInfo.Refresh

```csharp
void Refresh ();
```

Refreshes the state of the object.
    

## Directory Info Factory ##

## Summary

A factory for building IDirectoryInfo objects

```csharp
public interface IDirectoryInfoFactory
```

## IDirectoryInfoFactory

- [12.1 Get Directory Info](#user-content-idirectoryinfofactorygetdirectoryinfo)

## IDirectoryInfoFactory.GetDirectoryInfo

```csharp
IDirectoryInfo GetDirectoryInfo(string path);
```

Creates a new instance of the IDirectoryInfo interface on the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string specifying the path on which to create the IDirectoryInfo.

**returns** [IDirectoryInfo](#user-content-directory-info)

A new instance of the IDirectoryInfo interface on the specified path.
    

## Directory Info ##

TBD
    

## File Info Factory ##

TBD
    

## File Info ##

TBD
    

## Drives ##

TBD
    

## Directory ##

TBD
    

## File ##

TBD
    

<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    