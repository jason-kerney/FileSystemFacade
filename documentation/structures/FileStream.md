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

- [5.1 Stream](#user-content-ifilestreamstream)
- [5.2 Can Read](#user-content-ifilestreamcanread)
- [5.2 Can Seek](#user-content-ifilestreamcanseek)
- [5.3 Can Timeout](#user-content-ifilestreamcantimeout)
- [5.4 Can Write](#user-content-ifilestreamcanwrite)
- [5.5 Is Async](#user-content-ifilestreamisasync)
- [5.6 Length](#user-content-ifilestreamlength)
- [5.7 Name](#user-content-ifilestreamname)
- [5.8 Position](#user-content-ifilestreamposition)
- [5.9 Read Timeout](#user-content-ifilestreamreadtimeout)

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