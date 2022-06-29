<!--bl
(filemeta
    (title "Drives"))
/bl-->

### Summary

Use IDrives to determine what drives are available, and what type of drives they are.

```csharp
public interface IDrives
```

### IDrives

- [16.1 Get Drives](#user-content-idrivesgetdrives)

### IDrives.GetDrives

```csharp
IDriveInfo[] GetDrives ();
```

Retrieves the drive names of all logical drives on a computer.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IDriveInfo](#user-content-drive-info)\>

An array of type IDriveInfo that represents the logical drives on a computer.