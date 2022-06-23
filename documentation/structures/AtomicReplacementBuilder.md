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

### IAtomicReplacementBuilder.FileStream

```csharp
IAtomicReplacementBuilder FileStream(IFileStreamFactory factory);
```

Allows for the factory that builds IFileStream objects to be temporarily replaced.

**factory** [IFileStreamFactory](#user-content-file-stream-factory)

The IFileStream Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with the IFileStreamFactory configured to be replaced.

### IAtomicReplacementBuilder.FilesSystemWatcher

```csharp
IAtomicReplacementBuilder FilesSystemWatcher(IFilesSystemWatcherFactory factory);
```

Allows for the factory that builds IFileSystemWatcher objects to be replaced.

**factory** [IFileSystemWatcherFactory](#user-content-files-system-watcher-factory)

The IFileSystemWatcher Factory to use when 'Use' is called.

**returns** [IAtomicReplacementBuilder](#user-content-atomic-replacement-builder)

The current instance of the builder with the IFileWatcherFactory configured to be replaced.
