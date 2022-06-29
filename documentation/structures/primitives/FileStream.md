# File Stream

## Summary

Provides a Stream for a file, supporting both synchronous and asynchronous read and write operations.

This is a thin facade around [System.IO.FileStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-6.0)

```csharp
public interface IFileStream : IDisposable, IAsyncDisposable
```

## IFileStream

- [2.01 Stream](#user-content-ifilestreamstream)
- [2.02 Can Read](#user-content-ifilestreamcanread)
- [2.02 Can Seek](#user-content-ifilestreamcanseek)
- [2.03 Can Timeout](#user-content-ifilestreamcantimeout)
- [2.04 Can Write](#user-content-ifilestreamcanwrite)
- [2.05 Is Async](#user-content-ifilestreamisasync)
- [2.06 Length](#user-content-ifilestreamlength)
- [2.07 Name](#user-content-ifilestreamname)
- [2.08 Position](#user-content-ifilestreamposition)
- [2.09 Read Timeout](#user-content-ifilestreamreadtimeout)
- [2.10 Safe File Handle](#user-content-ifilestreamsafefilehandle)
- [2.11 Write Timeout](#user-content-ifilestreamwritetimeout)
- [2.12 Begin Read](#user-content-ifilestreambeginread)
- [2.13 Begin Write](#user-content-ifilestreambeginwrite)
- [2.14 Close](#user-content-ifilestreamclose)
- [2.15 Copy To](#user-content-ifilestreamcopyto)
- [2.16 Copy To Async](#user-content-ifilestreamcopytoasync)
- [2.17 End Read](#user-content-ifilestreamendread)
- [2.18 End Write](#user-content-ifilestreamendwrite)
- [2.19 Flush](#user-content-ifilestreamflush)
- [2.20 Flush Async](#user-content-ifilestreamflushasync)
- [2.21 Lock](#user-content-ifilestreamlock)
- [2.22 Read](#user-content-ifilestreamread)
- [2.23 Read Async](#user-content-ifilestreamreadasync)
- [2.24 Read Byte](#user-content-ifilestreamreadbyte)
- [2.25 Seek](#user-content-ifilestreamseek)
- [2.26 Set Length](#user-content-ifilestreamsetlength)
- [2.27 Unlock](#user-content-ifilestreamunlock)
- [2.28 Write](#user-content-ifilestreamwrite)
- [2.29 Write Async](#user-content-ifilestreamwriteasync)
- [2.30 Write Byte](#user-content-ifilestreamwritebyte)

## IFileStream.Stream

```csharp
System.IO.Stream Stream { get; }
```

Gets the underlying stream.

**returns** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The underlying stream.

## IFileStream.CanRead

```csharp
bool CanRead { get; }
```

Gets a value that indicates whether the current stream supports reading.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports reading.

## IFileStream.CanSeek

```csharp
bool CanSeek { get; }
```

Gets a value that indicates whether the current stream supports seeking.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports seeking.

## IFileStream.CanTimeout

```csharp
bool CanTimeout { get; }
```

Gets a value that determines whether the current stream can time out.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that determines whether the current stream can time out.

## IFileStream.CanWrite

```csharp
bool CanWrite { get; }
```

Gets a value that indicates whether the current stream supports writing.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the current stream supports writing.

## IFileStream.IsAsync

```csharp
bool IsAsync { get; }
```

Gets a value that indicates whether the FileStream was opened asynchronously or synchronously.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether the FileStream was opened asynchronously or synchronously.

## IFileStream.Length

```csharp
long Length { get; }
```

Gets the length in bytes of the stream.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The length in bytes of the stream.

## IFileStream.Name

```csharp
string Name { get; }
```

Gets the absolute path of the file opened in the FileStream.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The absolute path of the file opened in the FileStream.

## IFileStream.Position

```csharp
long Position { get; set; }
```

Gets or sets the current position of this stream.

**value parameter**  [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The current position of this stream.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The current position of this stream.

## IFileStream.ReadTimeout

```csharp
int ReadTimeout { get; set; }
```

Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.

**value parameter** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to read before timing out.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to read before timing out.

## IFileStream.SafeFileHandle

```csharp
SafeFileHandle SafeFileHandle { get; }
```

Gets a SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.

**returns** [SafeFileHandle](https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.safehandles.safefilehandle?view=net-6.0)

A SafeFileHandle object that represents the operating system file handle for the file that the current FileStream object encapsulates.

## IFileStream.WriteTimeout

```csharp
int WriteTimeout { get; set; }
```

Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.

**value parameter** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to write before timing out.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

A value, in milliseconds, that determines how long the stream will attempt to write before timing out.

## IFileStream.BeginRead

```csharp
IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
```

Begins an asynchronous read operation. Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The buffer to read data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in array at which to begin reading.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**callback** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[AsyncCallback](https://docs.microsoft.com/en-us/dotnet/api/system.asynccallback?view=net-6.0)\>

The method to be called when the asynchronous read operation is completed

**state** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[object](https://docs.microsoft.com/en-us/dotnet/api/system.object?view=net-6.0)\>

A user-provided object that distinguishes this particular asynchronous read request from other requests.

**returns** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

An object that references the asynchronous read.

## IFileStream.BeginWrite

```csharp
IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);
```

Begins an asynchronous write operation. Consider using WriteAsync(Byte[], Int32, Int32, CancellationToken) instead.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The buffer containing data to write to the current stream.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The zero-based byte offset in array at which to begin copying bytes to the current stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to write.

**callback** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[AsyncCallback](https://docs.microsoft.com/en-us/dotnet/api/system.asynccallback?view=net-6.0)\>

The method to be called when the asynchronous write operation is completed.

**state** [Nullable](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)\<[object](https://docs.microsoft.com/en-us/dotnet/api/system.object?view=net-6.0)\>

A user-provided object that distinguishes this particular asynchronous write request from other requests.

**returns** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

An object that references the asynchronous write.

## IFileStream.Close

```csharp
void Close();
```

Closes the current stream and releases any resources(such as sockets and file handles) associated with the current stream. Instead of calling this method, ensure that the stream is properly disposed.

## IFileStream.CopyTo

| Signatures                                                         |
|--------------------------------------------------------------------|
| <a href='#ifilestreamcopyto1'>`void CopyTo(Stream);`</a>           |
| <a href='#ifilestreamcopyto2'>`void CopyTo(IFileStream);`</a>      |
| <a href='#ifilestreamcopyto3'>`void CopyTo(Stream, int);`</a>      |
| <a href='#ifilestreamcopyto4'>`void CopyTo(IFileStream, int);`</a> |

---

<a id='ifilestreamcopyto1'></a>
```csharp
void CopyTo(System.IO.Stream destination);
```

Reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

---

<a id='ifilestreamcopyto2'></a>
```csharp
void CopyTo(IFileStream destination);
```

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](./FileStream.md)

The stream to which the contents of the current stream will be copied.

---

<a id='ifilestreamcopyto3'></a>
```csharp
void CopyTo(System.IO.Stream destination, int bufferSize);
```

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size of the buffer. This value must be greater than zero. The default size is 81920.

---

<a id='ifilestreamcopyto4'></a>
```csharp
void CopyTo(IFileStream destination, int bufferSize);
```

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](./FileStream.md)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size of the buffer. This value must be greater than zero. The default size is 81920.

## IFileStream.CopyToAsync

| Signatures                                                                                                                               |
|------------------------------------------------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamcopytoasync1'>`Task CopyToAsync(Stream, int, CancellationToken);`</a>                                               |
| <a href='#ifilestreamcopytoasync2'>`Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken);`</a> |
| <a href='#ifilestreamcopytoasync3'>`Task CopyToAsync(Stream, CancellationToken);`</a>                                                    |
| <a href='#ifilestreamcopytoasync4'>`Task CopyToAsync(IFileStream, CancellationToken);`</a>                                               |
| <a href='#ifilestreamcopytoasync5'>`Task CopyToAsync(Stream, int);`</a>                                                                  |
| <a href='#ifilestreamcopytoasync6'>`Task CopyToAsync(IFileStream, int);`</a>                                                             |
| <a href='#ifilestreamcopytoasync7'>`Task CopyToAsync(Stream);`</a>                                                                       |
| <a href='#ifilestreamcopytoasync8'>`Task CopyToAsync(IFileStream);`</a>                                                                  |

---

<a id='ifilestreamcopytoasync1'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination, int bufferSize, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync2'></a>
```csharp
Task CopyToAsync(IFileStream destination, int bufferSize, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](./FileStream.md)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync3'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync4'></a>
```csharp
Task CopyToAsync(IFileStream destination, CancellationToken cancellationToken);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](./FileStream.md)

The stream to which the contents of the current stream will be copied.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync5'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination, int bufferSize);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync6'></a>
```csharp
Task CopyToAsync(IFileStream destination, int bufferSize);
```

Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](./FileStream.md)

The stream to which the contents of the current stream will be copied.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync7'></a>
```csharp
Task CopyToAsync(System.IO.Stream destination);
```

Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.

**destination** [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-6.0)

The stream to which the contents of the current stream will be copied.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

---

<a id='ifilestreamcopytoasync8'></a>
```csharp
Task CopyToAsync(IFileStream destination);
```

Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.

**destination** [IFileStream](./FileStream.md)

The stream to which the contents of the current stream will be copied.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous copy operation.

## IFileStream.EndRead

```csharp
int EndRead(IAsyncResult asyncResult);
```

Waits for the pending asynchronous read operation to complete.(Consider using ReadAsync(Byte[], Int32, Int32, CancellationToken) instead.)

**asyncResult** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

The reference to the pending asynchronous request to wait for.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes read from the stream, between 0 and the number of bytes you requested. Streams only return 0 at the end of the stream, otherwise, they should block until at least 1 byte is available.

## IFileStream.EndWrite

```csharp
void EndWrite(IAsyncResult asyncResult);
```

Ends an asynchronous write operation and blocks until the I/O operation is complete.(Consider using WriteAsync(Byte[], Int32, Int32, CancellationToken) instead.)

**asyncResult** [IAsyncResult](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=net-6.0)

The pending asynchronous I/O request.

## IFileStream.Flush

| Signatures                                                       |
|------------------------------------------------------------------|
| <a href='#ifilestreamflush1'>`void Flush();`</a>                 |
| <a href='#ifilestreamflush2'>`void Flush(bool flushToDisk);`</a> |

---

<a id='ifilestreamflush1'></a>
```csharp
void Flush();
```

Clears buffers for this stream and causes any buffered data to be written to the file.

---

<a id='ifilestreamflush2'></a>
```csharp
void Flush(bool flushToDisk);
```

Clears buffers for this stream and causes any buffered data to be written to the file, and also clears all intermediate file buffers.

**flushToDisk** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to flush all intermediate file buffers; otherwise, false.

## IFileStream.FlushAsync

| Signatures                                                                  |
|-----------------------------------------------------------------------------|
| <a href='#ifilestreamflushasync1'>`Task FlushAsync();`</a>                  |
| <a href='#ifilestreamflushasync2'>`Task FlushAsync(CancellationToken);`</a> |

---

<a id='ifilestreamflushasync1'></a>
```csharp
Task FlushAsync();
```

Asynchronously clears all buffers for this stream and causes any buffered data to be written to the underlying device.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous flush operation.

---

<a id='ifilestreamflushasync2'></a>
```csharp
Task FlushAsync(CancellationToken cancellationToken);
```

Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors cancellation requests.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous flush operation.

## IFileStream.Lock

```csharp
[System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
[System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
[System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
void Lock(long position, long length);
```

Prevents other processes from reading from or writing to the FileStream.

**position** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The beginning of the range to lock. The value of this parameter must be equal to or greater than zero(0).

**length** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The range to be locked.

## IFileStream.Read

| Signatures                                                    |
|---------------------------------------------------------------|
| <a href='#ifilestreamread1'>`int Read(byte[], int, int);`</a> |
| <a href='#ifilestreamread2'>`int Read(Span<byte>);`</a>       |

---

<a id='ifilestreamread1'></a>
```csharp
int Read(byte[] buffer, int offset, int count);
```

Reads a block of bytes from the stream and writes the data in a given buffer.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

When this method returns, contains the specified byte array with the values between offset and(offset + count - 1) replaced by the bytes read from the current source.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in array at which the read bytes will be placed.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The total number of bytes read into the buffer. This might be less than the number of bytes requested if that number of bytes are not currently available, or zero if the end of the stream is reached.

---

<a id='ifilestreamread2'></a>
```csharp
int Read(Span<byte> buffer);
```

Reads a sequence of bytes from the current file stream and advances the position within the file stream by the number of bytes read.

**buffer** [Span](https://docs.microsoft.com/en-us/dotnet/api/system.span-1?view=net-6.0)<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)>

A region of memory. When this method returns, the contents of this region are replaced by the bytes read from the current file stream.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The total number of bytes read into the buffer. This can be less than the number of bytes allocated in the buffer if that many bytes are not currently available, or zero(0) if the end of the stream has been reached.

## IFileStream.ReadAsync

| Signatures                                                                                        |
|---------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamreadasync1'>`ValueTask<int> ReadAsync(Memory<byte>, CancellationToken);`</a> |
| <a href='#ifilestreamreadasync2'>`Task<int> ReadAsync(byte[], int, int);`</a>                     |
| <a href='#ifilestreamreadasync3'>`Task<int> ReadAsync(byte[], int, int, CancellationToken);`</a>  |

---

<a id='ifilestreamreadasync1'></a>
```csharp
ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);
```

Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.

**buffer** [Memory](https://docs.microsoft.com/en-us/dotnet/api/system.memory-1?view=net-6.0)<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)>

The region of memory to write the data into.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1?view=net-6.0)<[int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)>

A task that represents the asynchronous read operation. The value of its Result property contains the total number of bytes read into the buffer. The result value can be less than the number of bytes allocated in the buffer if that many bytes are not currently available, or it can be 0(zero) if the end of the stream has been reached.

---

<a id='ifilestreamreadasync2'></a>
```csharp
Task<int> ReadAsync(byte[] buffer, int offset, int count);
```

Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The buffer to write the data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in buffer at which to begin writing data from the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)\>

A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0(zero) if the end of the stream has been reached.

---

<a id='ifilestreamreadasync3'></a>
```csharp
Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
```

Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The buffer to write the data into.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte offset in buffer at which to begin writing data from the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to read.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)\>

A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0(zero) if the end of the stream has been reached.

## IFileStream.ReadByte

```csharp
int ReadByte();
```

Reads a byte from the file and advances the read position one byte.

**returns** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The byte, cast to an Int32, or -1 if the end of the stream has been reached.

## IFileStream.Seek

```csharp
long Seek(long offset, System.IO.SeekOrigin origin);
```

Sets the current position of this stream to the given value.

**offset** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The point relative to origin from which to begin seeking.

**origin** [System.IO.SeekOrigin](https://docs.microsoft.com/en-us/dotnet/api/system.io.seekorigin?view=net-6.0)

Specifies the beginning, the end, or the current position as a reference point for offset, using a value of type SeekOrigin.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The new position in the stream.

## IFileStream.SetLength

```csharp
void SetLength(long value);
```

Sets the length of this stream to the given value.

**value** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The new length of the stream.

## IFileStream.Unlock

```csharp
[System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
[System.Runtime.Versioning.UnsupportedOSPlatform("macos")]
[System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
void Unlock(long position, long length);
```

Allows access by other processes to all or part of a file that was previously locked.

**position** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The beginning of the range to unlock.

**length** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The range to be unlocked.

## IFileStream.Write

| Signatures                                                         |
|--------------------------------------------------------------------|
| <a href='#ifilestreamwrite1'>`void Write(byte[], int, int);`</a>   |
| <a href='#ifilestreamwrite2'>`void Write(ReadOnlySpan<byte>);`</a> |

---

<a id='ifilestreamwrite1'></a>
```csharp
void Write(byte[] buffer, int offset, int count);
```

Writes a block of bytes to the file stream.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The buffer containing data to write to the stream.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The zero-based byte offset in array from which to begin copying bytes to the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to write.

---

<a id='ifilestreamwrite2'></a>
```csharp
void Write(ReadOnlySpan<byte> buffer);
```

Writes a sequence of bytes from a read-only span to the current file stream and advances the current position within this file stream by the number of bytes written.

**buffer** [ReadOnlySpan](https://docs.microsoft.com/en-us/dotnet/api/system.readonlyspan-1?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

A region of memory. This method copies the contents of this region to the current file stream.

## IFileStream.WriteAsync

| Signatures                                                                                             |
|--------------------------------------------------------------------------------------------------------|
| <a href='#ifilestreamwriteasync1'>`ValueTask WriteAsync(ReadOnlyMemory<byte>, CancellationToken);`</a> |
| <a href='#ifilestreamwriteasync2'>`Task WriteAsync(byte[], int, int);`</a>                             |

---

<a id='ifilestreamwriteasync1'></a>
```csharp
ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
```

Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number of bytes written, and monitors cancellation requests.

**buffer** [ReadOnlyMemory](https://docs.microsoft.com/en-us/dotnet/api/system.readonlymemory-1?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The region of memory to write data from.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask?view=net-6.0)

A task that represents the asynchronous write operation.

---

<a id='ifilestreamwriteasync2'></a>
```csharp
Task WriteAsync(byte[] buffer, int offset, int count);
```

Asynchronously writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.

**buffer** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The buffer to write data from.

**offset** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The zero-based byte offset in buffer from which to begin copying bytes to the stream.

**count** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The maximum number of bytes to write.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

## IFileStream.WriteByte

```csharp
void WriteByte(byte value);
```

Writes a byte to the current position in the file stream.

**value** [byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)

A byte to write to the stream.