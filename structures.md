
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade's Primary File System Access #
#### A guide to the interfaces and objects that allow you to access the file system. ####

## Table Of Contents ##

- [Section 1: Atomic File System](#user-content-atomic-file-system)
- [Section 2: Atomic Actions](#user-content-atomic-actions)
- [Section 3: Atomic Replacement Builder](#user-content-atomic-replacement-builder)
- [Section 4: Primitives](#user-content-primitives)
- [Section 5: Alternate File System Access](#user-content-alternate-file-system-access)

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

Returns an [IAtomicActions](#user-content-atomic-actions) allowing the interaction with a [IFileStream](./documentation/structures/primitives/FileStream.md) specified by the parameters. The [IFileStream](./documentation/structures/primitives/FileStream.md) object is created before and disposed of after each atomic action method call.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current [IFileStream](./documentation/structures/primitives/FileStream.md) object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the [IFileStream](./documentation/structures/primitives/FileStream.md) object. This also determines the values returned by the CanRead and CanWrite properties of the [IFileStream](./documentation/structures/primitives/FileStream.md) object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](./documentation/structures/primitives/FileStream.md)>

An atomic action allowing the interaction with a [IFileStream](./documentation/structures/primitives/FileStream.md) specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

---

<a id='iatomicactionsfilestream3'></a>
```csharp
IAtomicActions<IFileStream> FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Returns [IAtomicActions](#user-content-atomic-actions) allowing the interaction with a [IFileStream](./documentation/structures/primitives/FileStream.md) specified by the parameters.  The [IFileStream](./documentation/structures/primitives/FileStream.md) object is created before and disposed of after each atomic action method call.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current [IFileStream](./documentation/structures/primitives/FileStream.md) object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the [IFileStream](./documentation/structures/primitives/FileStream.md) object. This also determines the values returned by the CanRead and CanWrite properties of the [IFileStream](./documentation/structures/primitives/FileStream.md) object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](./documentation/structures/primitives/FileStream.md)>

An atomic action allowing the interaction with a [IFileStream](./documentation/structures/primitives/FileStream.md) specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

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

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](./documentation/structures/primitives/FileStream.md)>

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

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFileStream](./documentation/structures/primitives/FileStream.md)>

An atomic action allowing the interaction with a IFileStream specified by the parameters. NOTE: The file stream is created just before each of the atomic action's methods and disposed of afterwards.

#### IAtomicFileSystem.DriveInfo

```csharp
IAtomicActions<IDriveInfo> DriveInfo(string driveName);
```

Returns an atomic action allowing the interaction with a IDriveInfo specified by the drive name.

**driveName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDriveInfo](./documentation/structures/primitives/DriveInfo.md)>

An atomic action allowing the interaction with a IDriveInfo specified by the drive name.

#### IAtomicActions.DirectoryInfo

```csharp
IAtomicActions<IDirectoryInfo> DirectoryInfo(string path);
```

Returns an atomic action allowing the interaction with a IDirectoryInfo specified by the path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string specifying the path on which to create the IDirectoryInfo.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDirectoryInfo](./documentation/structures/primitives/DirectoryInfo.md)>

An atomic action allowing the interaction with a IDirectoryInfo specified by the path.

#### IAtomicFileSystem.FileInfo

```csharp
IAtomicActions<IFileInfo> FileInfo(string fileName);
```

Returns an atomic action allowing the interaction with a IFileInfo specified by the file name.

**fileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.

**returns ** [IAtomicActions](#user-content-atomic-actions)<[IFileInfo](./documentation/structures/primitives/FileInfo.md)>

An atomic action allowing the interaction with a IFileInfo specified by the file name.

### IAtomicFileSystem.Drives

```csharp
IAtomicActions<IDrives> Drives { get; }
```

Returns an atomic action allowing the interaction with a IDrives.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDrives](./documentation/structures/primitives/Drives.md)>

An atomic action allowing the interaction with a IDrives.

### IAtomicFileSystem.Directory

```csharp
IAtomicActions<IDirectory> Directory { get; }
```

Returns an atomic action allowing the interaction with IDirectory.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDirectory](./documentation/structures/primitives/Directory.md)>

An atomic action allowing the interaction with IDirectory.

### IAtomicFileSystem.File

```csharp
IAtomicActions<IFile> File { get; }
```

Returns an atomic action allowing the interaction with IFile.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IFile](./documentation/structures/primitives/File.md)>

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

**factory** [IFileStreamFactory](./documentation/structures/primitives/FileStreamFactory.md)

The IFileStream Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with the IFileStreamFactory configured to be replaced.

### IAtomicReplacementBuilder.FileSystemWatcher

```csharp
IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherFactory factory);
```

Allows for the factory that builds IFileSystemWatcher objects to be replaced.

**factory** [IFileSystemWatcherFactory](./documentation/structures/primitives/FileSystemWatcherFactory.md)

The IFileSystemWatcher Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with the IFileWatcherFactory configured to be replaced.

### IAtomicReplacementBuilder.FileInfo

```csharp
IAtomicReplacementBuilder FileInfo(IFileInfoFactory factory);
```

Allows for the factory that builds IFileInfo objects to be temporarily replaced.

**factory** [IFileInfoFactory](./documentation/structures/primitives/FileInfoFactory.md)

The IFileInfo Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IFileInfoFactory configured to be replaced.

### IAtomicReplacementBuilder.DirectoryInfo

```csharp
IAtomicReplacementBuilder DirectoryInfo(IDirectoryInfoFactory factory);
```

Allows for the factory that builds IDirectoryInfo objects to be replaced.

**factory** [IDirectoryInfoFactory](./documentation/structures/primitives/DirectoryInfoFactory.md)

The IDirectoryInfo Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDirectoryInfoFactory configured to be replaced.

### IAtomicReplacementBuilder.DriveInfo

```csharp
IAtomicReplacementBuilder DriveInfo(IDriveInfoFactory factory);
```

Allows for the factory that builds IDriveInfo objects to be replaced.

**factory** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md)

The IDriveInfo Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDiveInfoFactory configured to be replaced.

### IAtomicReplacementBuilder.Drives

```csharp
IAtomicReplacementBuilder Drives(IDrives newDrives);
```

Configures IDrives to be replaced.

**newDrives** [IDrives](./documentation/structures/primitives/Drives.md)

The IDrives to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDrives configured to be replaced.

### IAtomicReplacementBuilder.Directory

```csharp
IAtomicReplacementBuilder Directory(IDirectory newDirectory);
```

Configures IDirectory to be replaced.

**newDirectory** [IDirectory](./documentation/structures/primitives/Directory.md)

The IDirectory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with IDirectory configured to be replaced.

### IAtomicReplacementBuilder.File

```csharp
IAtomicReplacementBuilder File(IFile newFile);
```

Configures IFile to be replaced.

**newFile** [IFile](./documentation/structures/primitives/File.md)

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
    

## Primitives ##

This links to the documentation on each of the primitives that are used by the File System Facade

1. [File Stream Factory](./documentation/structures/primitives/FileStreamFactory.md)
2. [File Stream](./documentation/structures/primitives/FileStream.md)
3. [File System Watcher Factory](./documentation/structures/primitives/FileSystemWatcherFactory.md)
4. [File System Watcher](./documentation/structures/primitives/FileSystemWatcher.md)
5. [Wait For Changed Result](./documentation/structures/primitives/WaitForChangedResult.md)
6. [Drive Info Factory](./documentation/structures/primitives/DriveInfoFactory.md)
7. [Drive Info](./documentation/structures/primitives/DriveInfo.md)
8. [File System Info](./documentation/structures/primitives/FileSystemInfo.md)
9. [Directory Info Factory](./documentation/structures/primitives/DirectoryInfoFactory.md)
10. [Directory Info](./documentation/structures/primitives/DirectoryInfo.md)
11. [File Info Factory](./documentation/structures/primitives/FileInfoFactory.md)
12. [File Info](./documentation/structures/primitives/FileInfo.md)
13. [Drives](./documentation/structures/primitives/Drives.md)
14. [Directory](./documentation/structures/primitives/Directory.md)
15. [File](./documentation/structures/primitives/File.md)
    

## Alternate File System Access ##

There is a whole other way to access file system objects that allows for long lived objects. It is however harder to test, and as such not considered the primary way to access those objects.

You can find those objects documented here: [Alternate File System Access](./alternate.md)
    

<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    