<!--bl
(filemeta
    (title "Atomic Replacement Builder"))
/bl-->

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