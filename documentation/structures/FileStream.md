<!--bl
(filemeta
    (title "File Stream"))
/bl-->

<!-- 5 -->

### Summary

Provides a Stream for a file, supporting both synchronous and asynchronous read and write operations.

```csharp
public interface IFileStream : IDisposable, IAsyncDisposable
```

### IFileStream

- [5.01 Stream](#user-content-ifilestreamstream)
- [5.02 Can Read](#user-content-ifilestreamcanread)
- [5.02 Can Seek](#user-content-ifilestreamcanseek)
- [5.03 Can Timeout](#user-content-ifilestreamcantimeout)
- [5.04 Can Write](#user-content-ifilestreamcanwrite)
- [5.05 Is Async](#user-content-ifilestreamisasync)
- [5.06 Length](#user-content-ifilestreamlength)
- [5.07 Name](#user-content-ifilestreamname)
- [5.08 Position](#user-content-ifilestreamposition)
- [5.09 Read Timeout](#user-content-ifilestreamreadtimeout)
- [5.10 Safe File Handle](#user-content-ifilestreamsafefilehandle)
- [5.11 Write Timeout](#user-content-ifilestreamwritetimeout)
- [5.12 Begin Read](#user-content-ifilestreambeginread)

### IFileStream.Stream

```csharp
System.IO.Stream Stream { get; }
```

Gets the underlying stream.

**returns** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The underlying stream.

### IFileStream.CanRead

```csharp
bool CanRead { get; }
```

Gets a value that indicates whether the current stream supports reading.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports reading.

### IFileStream.CanSeek

```csharp
bool CanSeek { get; }
```

Gets a value that indicates whether the current stream supports seeking.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports seeking.

### IFileStream.CanTimeout

```csharp
bool CanTimeout { get; }
```

Gets a value that determines whether the current stream can time out.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that determines whether the current stream can time out.

### IFileStream.CanWrite

```csharp
bool CanWrite { get; }
```

Gets a value that indicates whether the current stream supports writing.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports writing.

### IFileStream.IsAsync

```csharp
bool IsAsync { get; }
```

Gets a value that indicates whether the FileStream was opened asynchronously or synchronously.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the FileStream was opened asynchronously or synchronously.

### IFileStream.Length

```csharp
long Length { get; }
```

Gets the length in bytes of the stream.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The length in bytes of the stream.

### IFileStream.Name

```csharp
string Name { get; }
```

Gets the absolute path of the file opened in the FileStream.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The absolute path of the file opened in the FileStream.

### IFileStream.Position

```csharp
long Position { get; set; }
```

Gets or sets the current position of this stream.

**value parameter**  [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The current position of this stream.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The current position of this stream.

### IFileStream.ReadTimeout

```csharp
int ReadTimeout { get; set; }
```

Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.

**value parameter** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to read before timing out.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to read before timing out.

### IFileStream.SafeFileHandle

```csharp
SafeFileHandle SafeFileHandle { get; }
```

Gets a SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.

**returns** [SafeFileHandle](https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.safehandles.safefilehandle?view=net-6.0)

A SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.

### IFileStream.WriteTimeout

```csharp
int WriteTimeout { get; set; }
```

Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.

**value parameter** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to write before timing out.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to write before timing out.

### IFileStream.BeginRead

```csharp
IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
```

Begins an asynchronous read operation. Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.

**buffer** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)[\[ \]](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

The buffer to read data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in array at which to begin reading.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**callback** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[AsyncCallback](https://docs.microsoft.com/en-us/dotnet/api/system.asynccallback?view=net-6.0)\>

The method to be called when the asynchronous read operation is completed

**state**

A user-provided object that distinguishes this particular asynchronous read request from other requests.

**returns**

An object that references the asynchronous read.
