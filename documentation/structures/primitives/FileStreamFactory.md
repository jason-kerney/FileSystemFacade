<!--bl
(filemeta
    (title "File Stream Factory"))
/bl-->

### Summary

Provides a Stream for a file, supporting both synchronous and asynchronous read and write operations.

```csharp
public interface IFileStreamFactory
```

### IFileStreamFactory

- [4.1 Get File Stream](#user-content-ifilestreamfactorygetfilestream)

### IFileStreamFactory.GetFileStream

|                                                    | Signature                                                                               |
|----------------------------------------------------|-----------------------------------------------------------------------------------------|
| <a href='#ifilestreamfactorygetfilestream1'>1</a>  | `IFileStream GetFileStream(string, FileMode, FileAccess, FileShare, int, FileOptions);` |
| <a href='#ifilestreamfactorygetfilestream2'>2</a>  | `IFileStream GetFileStream(string, FileMode, FileAccess, FileShare, int);`              |
| <a href='#ifilestreamfactorygetfilestream3'>3></a> | `IFileStream GetFileStream(string, FileMode, FileAccess, FileShare);`                   |
| <a href='#ifilestreamfactorygetfilestream4'>4</a>  | `IFileStream GetFileStream(string, FileMode, FileAccess, FileShare, int, bool);`        |
| <a href='#ifilestreamfactorygetfilestream5'>5</a>  | `IFileStream GetFileStream(string, FileMode, FileAccess);`                              |
---

<a id='ifilestreamfactorygetfilestream1'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, System.IO.FileOptions options);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

A bitwise combination of the enumeration values that specifies additional file options.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.

---

<a id='ifilestreamfactorygetfilestream2'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.

---

<a id='ifilestreamfactorygetfilestream3'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.

---

<a id='ifilestreamfactorygetfilestream4'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize, bool useAsync);
```

Creates a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file will be shared by processes.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A positive Int32 value greater than 0 indicating the buffer size. The default buffer size is 4096.

**useAsync** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

Specifies whether to use asynchronous I/O or synchronous I/O. However, note that the underlying operating system might not support asynchronous I/O, so when specifying true, the handle might be opened synchronously depending on the platform. When opened asynchronously, the BeginRead(Byte[], Int32, Int32, AsyncCallback, Object) and BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object) methods perform better on large reads or writes, but they might be much slower for small reads or writes. If the application is designed to take advantage of asynchronous I/O, set the useAsync parameter to true. Using asynchronous I/O correctly can speed up applications by as much as a factor of 10, but using it without redesigning the application for asynchronous I/O can decrease performance by as much as a factor of 10.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.

---

<a id='ifilestreamfactorygetfilestream5'></a>
```csharp
IFileStream GetFileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access);
```

Creates a new instance of the FileStream class with the specified path, creation mode, and read/write permission.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A relative or absolute path for the file that the current FileStream object will encapsulate.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

One of the enumeration values that determines how to open or create the file.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A bitwise combination of the enumeration values that determines how the file can be accessed by the FileStream object. This also determines the values returned by the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.

**returns** [IFileStream](#user-content-file-stream)

A new instance of the FileStream class with the specified path, creation mode, and read/write permission.
