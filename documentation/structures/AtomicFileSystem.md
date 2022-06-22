<!--bl
(filemeta
    (title "Atomic File System"))
/bl-->

## Summary

The Atomic File System represent short lived use of the file system. This represents a way to handle when we have objects that live for the length of a method or function but do not persist as file system objects afterwards.

There is one interface and one concrete class. The concrete class inherits the interface. It is recommended you access the class through the interface.

## IAtomicActions

[1.1 Description](#user-content-description)
[1.2 Replace](#user-content-replace)
[1.3 File Stream](#user-content-filestream)

### Description

 Represents a way to interact with the file system through atomic actions which dispose of disposable filesystem objects after the actions have completed.

### Replace

```csharp
IAtomicReplacementBuilder Replace { get; }
```

Replace builds an [Atomic Replacement Builder](#user-content-atomic-replacement-builder) to allow for the testing of code that takes an Atomic File System.

### FileStream

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

