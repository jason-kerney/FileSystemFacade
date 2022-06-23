
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade Structures #
#### A guide to the interfaces and objects in the library. ####

## Table Of Contents ##

- [Section 1: Atomic File System](#user-content-atomic-file-system)
- [Section 2: Atomic Replacement Builder](#user-content-atomic-replacement-builder)
- [Section 3: Atomic Actions](#user-content-atomic-actions)
- [Section 4: File Stream](#user-content-file-stream)
- [Section 5: Drive Info](#user-content-drive-info)
- [Section 6: Directory Info](#user-content-directory-info)

## Atomic File System ##

## Summary

The Atomic File System represent short lived use of the file system. This represents a way to handle when we have objects that live for the length of a method or function but do not persist as file system objects afterwards.

There is one interface and one concrete class. The concrete class inherits the interface. It is recommended you access the class through the interface.

## IAtomicActions

- [1.1 Description](#user-content-iatomicactions_description)
- [1.2 Replace](#user-content-iatomicactions_replace)
- [1.3 File Stream](#user-content-iatomicactions_filestream)
- [1.4 Drive Info](#user-content-iatomicactions_driveinfo)
- [1.5 Directory Info](#user-content-iatomicactions_directoryinfo)
- [1.6 File Info](#user-content-iatomicactions_fileinfo)

### Description

 Represents a way to interact with the file system through atomic actions which dispose of disposable filesystem objects after the actions have completed.

### Replace

```csharp
IAtomicReplacementBuilder Replace { get; }
```

Replace builds an [Atomic Replacement Builder](#user-content-atomic-replacement-builder) to allow for the testing of code that takes an Atomic File System.

### IAtomicActions.FileStream

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

### IAtomicActions.DriveInfo

```csharp
IAtomicActions<IDriveInfo> DriveInfo(string driveName);
```

Returns an atomic action allowing the interaction with a IDriveInfo specified by the drive name.

**driveName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDriveInfo](#use-content-drive-info)>

An atomic action allowing the interaction with a IDriveInfo specified by the drive name.

### IAtomicActions.DirectoryInfo

```csharp
IAtomicActions<IDirectoryInfo> DirectoryInfo(string path);
```

Returns an atomic action allowing the interaction with a IDirectoryInfo specified by the path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string specifying the path on which to create the IDirectoryInfo.

**returns** [IAtomicActions](#user-content-atomic-actions)<[IDirectoryInfo](#user-content-directory-info)>

An atomic action allowing the interaction with a IDirectoryInfo specified by the path.

### IAtomicActions.FileInfo

TBD Stuff
    

## Atomic Replacement Builder ##

TBD
    

## Atomic Actions ##

TBD
    

## File Stream ##

TBD
    

## Drive Info ##

TBD
    

## Directory Info ##

TBD
    

<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    