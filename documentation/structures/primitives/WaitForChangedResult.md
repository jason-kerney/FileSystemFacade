<!--bl
(filemeta
    (title "Wait For Changed Result"))
/bl-->

## Summary

Contains information on the change that occurred.

```csharp
public interface IWaitForChangedResult
```

## IWaitForChangedResult

- [8.1 Change Type](#user-content-iwaitforchangedresultchangetype)
- [8.2 Name](#user-content-iwaitforchangedresultname)
- [8.3 Old Name](#user-content-iwaitforchangedresultoldname)
- [8.4 Timed Out](#user-content-iwaitforchangedresulttimedout)

## IWaitForChangedResult.ChangeType

```csharp
System.IO.WatcherChangeTypes ChangeType { get; set; }
```

Gets or sets the type of change that occurred.

**value parameter** [System.IO.WatcherChangeTypes](https://docs.microsoft.com/en-us/dotnet/api/system.io.watcherchangetypes?view=net-6.0)

The type of change that occurred.

**return** [System.IO.WatcherChangeTypes](https://docs.microsoft.com/en-us/dotnet/api/system.io.watcherchangetypes?view=net-6.0)

The type of change that occurred.

## IWaitForChangedResult.Name

```csharp
string? Name { get; set; }
```

Gets or sets the name of the file or directory that changed.

**value parameter** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the file or directory that changed.

**return** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the file or directory that changed.

## IWaitForChangedResult.OldName

```csharp
string? OldName { get; set; }
```

Gets or sets the original name of the file or directory that was renamed.

**value parameter** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The original name of the file or directory that was renamed.

**return** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The original name of the file or directory that was renamed.

## IWaitForChangedResult.TimedOut

```csharp
bool TimedOut { get; set; }
```

Gets or sets a value indicating whether the wait operation timed out.


**value parameter** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the wait operation timed out.

**return** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value indicating whether the wait operation timed out.

## TBD
