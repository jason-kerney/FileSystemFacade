# Drive Info

## Summary

This interface models a drive and provides methods and properties to query for drive information. Use IDrives to determine what drives are available; and use IDriveInfo to determine what type of drive it is. You can also query to determine the capacity and available free space on the drive.

This is a thin facade around [System.IO.DriveInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.driveinfo?view=net-6.0)

```csharp
public interface IDriveInfo
```

## IDriveInfo

- [7.1 Available Free Space](#user-content-idriveinfoavailablefreespace)
- [7.2 Drive Format](#user-content-idriveinfodriveformat)
- [7.3 Drive Type](#user-content-idriveinfodrivetype)
- [7.4 Is Ready](#user-content-idriveinfoisready)
- [7.5 Name](#user-content-idriveinfoname)
- [7.6 Root Directory](#user-content-idriveinforootdirectory)
- [7.7 Total Free Space](#user-content-idriveinfototalfreespace)
- [7.8 Total Size](#user-content-idriveinfototalsize)
- [7.9 Volume Label](#user-content-idriveinfovolumelabel)

<!-- user-content-idriveinfo -->

## IDriveInfo.AvailableFreeSpace

```csharp
long AvailableFreeSpace { get; }
```

Indicates the amount of available free space on a drive, in bytes.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The amount of available free space on a drive, in bytes.

## IDriveInfo.DriveFormat

```csharp
string DriveFormat { get; }
```

Gets the name of the file system, such as NTFS or FAT32.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file system, such as NTFS or FAT32.

## IDriveInfo.DriveType

```csharp
System.IO.DriveType DriveType { get; }
```

Gets the drive type, such as CD-ROM, removable, network, or fixed.

**returns** [System.IO.DriveType](https://docs.microsoft.com/en-us/dotnet/api/system.io.drivetype?view=net-6.0)

The drive type, such as CD-ROM, removable, network, or fixed.

## IDriveInfo.IsReady

```csharp
bool IsReady { get; }
```

Gets a value that indicates whether a drive is ready.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

A value that indicates whether a drive is ready.

## IDriveInfo.Name

```csharp
string Name { get; }
```

Gets the name of a drive, such as C:\.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a drive, such as C:\.

## IDriveInfo.RootDirectory

```csharp
IDirectoryInfo RootDirectory { get; }
```

Gets the root directory of a drive.

**returns** [IDirectoryInfo](./DirectoryInfo.md)

The root directory of a drive.

## IDriveInfo.TotalFreeSpace

```csharp
long TotalFreeSpace { get; }
```

Gets the total amount of free space available on a drive, in bytes.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The total amount of free space available on a drive, in bytes.

## IDriveInfo.TotalSize

```csharp
long TotalSize { get; }
```

Gets the total size of storage space on a drive, in bytes.

**returns** [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-6.0)

The total size of storage space on a drive, in bytes.

## IDriveInfo.VolumeLabel

```csharp
string VolumeLabel { get; [System.Runtime.Versioning.SupportedOSPlatform("windows")] set; }
```

Gets or sets the volume label of a drive.

**value parameter** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

_Only available in Windows based OS_

The volume label of a drive.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The volume label of a drive.