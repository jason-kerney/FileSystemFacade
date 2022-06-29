# File System Info

## Summary

Provides the interface class for both IFileInfo and IDirectoryInfo objects.

This is a thin facade around [System.IO.FileSystemInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesysteminfo?view=net-6.0)

```csharp
public interface IFileSystemInfo
```

## IFileSystemInfo

- [8.01 Attributes](#user-content-ifilesysteminfoattributes)
- [8.02 Creation Time](#user-content-ifilesysteminfocreationtime)
- [8.03 Creation Time Utc](#user-content-ifilesysteminfocreationtimeutc)
- [8.04 Exists](#user-content-ifilesysteminfoexists)
- [8.05 Extension](#user-content-ifilesysteminfoextension)
- [8.06 Full Name](#user-content-ifilesysteminfofullname)
- [8.07 Last Access Time](#user-content-ifilesysteminfolastaccesstime)
- [8.08 Last Access Time Utc](#user-content-ifilesysteminfolastaccesstimeutc)
- [8.09 Last Write Time](#user-content-ifilesysteminfolastwritetime)
- [8.10 Last Write Time Utc](#user-content-ifilesysteminfolastwritetimeutc)
- [8.11 Name](#user-content-ifilesysteminfoname)
- [8.12 Delete](#user-content-ifilesysteminfodelete)
- [8.13 Get Object Data](#user-content-ifilesysteminfogetobjectdata)
- [8.14 Refresh](#user-content-ifilesysteminforefresh)

## IFileSystemInfo.Attributes

```csharp
System.IO.FileAttributes Attributes { get; set; }
```

Gets or sets the attributes for the current file or directory.

**parameter value** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The attributes for the current file or directory.

**returns** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The attributes for the current file or directory.

## IFileSystemInfo.CreationTime

```csharp
DateTime CreationTime { get; set; }
```

Gets or sets the creation time of the current file or directory.

**value parameter** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time of the current file or directory.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time of the current file or directory.

## IFileSystemInfo.CreationTimeUtc

```csharp
DateTime CreationTimeUtc { get; set; }
```

Gets or sets the creation time, in coordinated universal time (UTC), of the current file or directory.

**parameter value** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time, in coordinated universal time (UTC), of the current file or directory.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The creation time, in coordinated universal time (UTC), of the current file or directory.

## IFileSystemInfo.Exists

```csharp
bool Exists { get; }
```

Gets a value indicating whether the file or directory exists.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the file or directory exists.

## IFileSystemInfo.Extension

```csharp
string Extension { get; }
```

Gets the extension part of the file name, including the leading dot . even if it is the entire file name, or an empty string if no extension is present.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The extension part of the file name, including the leading dot . even if it is the entire file name, or an empty string if no extension is present.

## IFileSystemInfo.FullName

```csharp
string FullName { get; }
```

Gets the full path of the directory or file.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The full path of the directory or file.

## IFileSystemInfo.LastAccessTime

```csharp
DateTime LastAccessTime { get; set; }
```

Gets or sets the time the current file or directory was last accessed.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time the current file or directory was last accessed.

## IFileSystemInfo.LastAccessTimeUtc

```csharp
DateTime LastAccessTimeUtc { get; set; }
```

Gets or sets the time, in coordinated universal time (UTC), that the current file or directory was last accessed.

**parameter value** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), that the current file or directory was last accessed.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), that the current file or directory was last accessed.

## IFileSystemInfo.LastWriteTime

```csharp
DateTime LastWriteTime { get; set; }
```

Gets or sets the time when the current file or directory was last written to.

**value parameter** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time when the current file or directory was last written to.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time when the current file or directory was last written to.

## IFileSystemInfo.LastWriteTimeUtc

```csharp
DateTime LastWriteTimeUtc { get; set; }
```

Gets or sets the time, in coordinated universal time (UTC), when the current file or directory was last written to.

**value parameter** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), when the current file or directory was last written to.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The time, in coordinated universal time (UTC), when the current file or directory was last written to.

## IFileSystemInfo.Name
```csharp
string Name { get; }
```

For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

For files, returns the name of the file. For directories, returns the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property returns the name of the directory.

## IFileSystemInfo.Delete

```csharp
void Delete ();
```

Deletes a file or directory.

## IFileSystemInfo.GetObjectData

```csharp
void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
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