<!--bl
(filemeta
    (title "Static Directory Replacement"))
/bl-->

### Summary

A class that configures what directory objects to use when the static file system is put into replacement mode. This object makes testing easier.

```csharp
public interface IStaticDirectoryReplacement
```

### IStaticDirectoryReplacement

- [7.1 File System Watcher](#user-content-istaticdirectoryreplacementfilesystemwatcher)
- [7.2 Director Info](#user-content-istaticdirectoryreplacementdirectorinfo)
- [7.3 Directory](#user-content-istaticdirectoryreplacementdirectory)

<!--
#user-content-istaticdirectoryreplacement
-->

### IStaticDirectoryReplacement.FileSystemWatcher

```csharp
IFileSystemWatcherFactory FileSystemWatcher { get; }
```

The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

**returns** [IFileSystemWatcherFactory](./documentation/structures/primitives/FileSystemWatcherFactory.md#file-system-watcher-factory)

The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

### IStaticDirectoryReplacement.DirectorInfo

```csharp
IDirectoryInfoFactory DirectorInfo { get; }
```

The IDirectoryInfoFactory to use when the static file system is put into replacement mode.

**returns** [IDirectoryInfoFactory](./documentation/structures/primitives/DirectoryInfoFactory.md#directory-info-factory)

The IDirectoryInfoFactory to use when the static file system is put into replacement mode.

### IStaticDirectoryReplacement.Directory

```csharp
IDirectory Directory { get; }
```

The IDirectory to use when the static file system is put into replacement mode.

**returns** [IDirectory](./documentation/structures/primitives/Directory.md#directory)

The IDirectory to use when the static file system is put into replacement mode.