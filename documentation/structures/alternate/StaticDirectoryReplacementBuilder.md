<!--bl
(filemeta
    (title "Static Directory Replacement Builder"))
/bl-->

### Summary

This is a builder that helps setup the configuration of Directory objects to replace when the static file system is put into replacement mode. This object helps with testing.

```csharp
public interface IStaticDirectoryReplacementBuilder
```

### IStaticDirectoryReplacementBuilder

- [6.1 Replace Directory Info](#user-content-istaticdirectoryreplacementbuilderreplacedirectoryinfo)
- [6.2 Replace Directory](#user-content-istaticdirectoryreplacementbuilderreplacedirectory)
- [6.3 Replace File System Watcher](#user-content-istaticdirectoryreplacementbuilderreplacefilesystemwatcher)
- [6.4 Build](#user-content-istaticdirectoryreplacementbuilderbuild)

<!--
#user-content-istaticdirectoryreplacementbuilder
-->

### IStaticDirectoryReplacementBuilder.ReplaceDirectoryInfo

```csharp
IStaticDirectoryReplacementBuilder ReplaceDirectoryInfo(IDirectoryInfoFactory factory);
```

Configures the IDirectoryInfoFactory to use when the static file system is put into replacement mode.

**factory** [IDirectoryInfoFactory](./documentation/structures/primitives/DirectoryInfoFactory.md#directory-info-factory)

The IDirectoryInfoFactory to use when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-istaticdirectoryreplacementbuilder)

An instance of the builder with the IDirectoryInfo configured to be replaced when the static file system is put into replacement mode.

### IStaticDirectoryReplacementBuilder.ReplaceDirectory

```csharp
IStaticDirectoryReplacementBuilder ReplaceDirectory(IDirectory newDirectory);
```

Configures the IDirectory to use when the static file system is put into replacement mode.

**newDirectory** [IDirectory](./documentation/structures/primitives/Directory.md#directory)

The IDirectory to use when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-istaticdirectoryreplacementbuilder)

An instance of the builder with the IDirectory configured to be replaced when the static file system is put into replacement mode.

### IStaticDirectoryReplacementBuilder.ReplaceFileSystemWatcher

```csharp
IStaticDirectoryReplacementBuilder ReplaceFileSystemWatcher(IFileSystemWatcherFactory factory);
```

Configures the IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

**factory** [IFileSystemWatcherFactory](./documentation/structures/primitives/FileSystemWatcherFactory.md#file-system-watcher-factory)

The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-istaticdirectoryreplacementbuilder)

An instance of the builder with the IFilesSystemWatcherFactory configured to be replaced when the static file system is put into replacement mode.

### IStaticDirectoryReplacementBuilder.Build

```csharp
IStaticDirectoryReplacement Build();
```

Builds the configuration object used when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacement](#user-content-static-directory-replacement)

The configuration object used when the static file system is put into replacement mode.