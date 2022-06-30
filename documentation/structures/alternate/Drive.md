<!--bl
(filemeta
    (title "Drive"))
/bl-->

### Summary

A static class that aids in getting Drive info and an enumeration of drives on the system.

It is preferable to use the [Atomic File System](./structures.md). This should only be used when you are creating long file items that live longer then a single method.

### Drive

- [1.1 Replace](#user-content-drivereplace)
- [1.2 Drive Info](#user-content-drivedriveinfo)
- [1.3 Get Drives](#user-content-drivegetdrives)
- [1.4 Build Replacement](#user-content-drivebuildreplacement)

<!--
#user-content-drive
-->

### Drive.Replace

```csharp
public static IDisposable Replace(IStaticDriveReplacement replacement)
```

Puts the static Drive class in replacement mode. This temporarily causes the static Drive class to replace how it works.

This is used to allow testing.

***WARNING:*** This allows changing of how the system works until the returned object is disposed.

**replacement** [IStaticDriveReplacement](#user-content-static-drive-replacement)

The configuration of how to replace the inners of the static class.

**returns** [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0)

An IDisposable that when disposed reverts the static Drive class to its default behavior

***WARNING:*** This allows changing of how the system works until the returned object is disposed.

### Drive.DriveInfo

```csharp
public static IDriveInfoFactory DriveInfo { get; }
```

This returns an IDriveInfoFactory used to build information about a Drive on the system.

**returns** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md)

An IDriveInfoFactory used to build information about a Drive on the system.

### Drive.GetDrives

```csharp
public static IDriveInfo[] GetDrives();
```

Retrieves the drive names of all logical drives on a computer.

**returns** [IDriveInfo](./documentation/structures/primitives/DriveInfo.md)

An array of type IDriveInfo that represents the logical drives on a computer.

### Drive.BuildReplacement

```csharp
public static IStaticDriveReplacementBuilder BuildReplacement();
```

Returns a new builder object that makes configuring how the static Drive class behaves in replacement mode easier.

This method facilitates testing.

**returns**

A builder to build the configuration object used by the 'Replace' method.