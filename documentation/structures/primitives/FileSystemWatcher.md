<!--bl
(filemeta
    (title "File System Watcher"))
/bl-->

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

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

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

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

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

**returns** [System.IO.NotifyFilters](https://docs.microsoft.com/en-us/dotnet/api/system.io.notifyfilters?view=net-6.0)

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