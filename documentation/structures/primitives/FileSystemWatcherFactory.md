<!--bl
(filemeta
    (title "File System Watcher Factory"))
/bl-->

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
