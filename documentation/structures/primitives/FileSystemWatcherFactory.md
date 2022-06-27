<!--bl
(filemeta
    (title "File System Watcher Factory"))
/bl-->

<-- 6 -->

## Summary

A factory to build IFileSystemWatcher objects

```csharp
public interface IFileSystemWatcherFactory
```

## IFileSystemWatcherFactory

- [6.1 Get File System Watcher](#user-content-ifilesystemwatcherfactorygetfilesystemwatcher)

## IFileSystemWatcherFactory.GetFileSystemWatcher

```csharp
IFileSystemWatcher GetFileSystemWatcher();
```

Creates a new instance of the FileSystemWatcher class.

**returns** [IFileSystemWatcher](#user-content-file-system-watcher)

A  new instance of the FileSystemWatcher class.

---

```csharp
IFileSystemWatcher GetFileSystemWatcher(string path);
```

Creates a new instance of the FileSystemWatcher class, given the specified directory to monitor.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The directory to monitor, in standard or Universal Naming Convention (UNC) notation.

**returns** [IFileSystemWatcher](#user-content-file-system-watcher)

A new instance of the FileSystemWatcher class, given the specified directory to monitor.

---

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
