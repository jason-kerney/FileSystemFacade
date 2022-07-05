<!--bl
(filemeta
    (title "Static Drive Replacement"))
/bl-->

### Summary

The items to use in replacing drive objects in the static file system. This class makes testing easier.

```csharp
public interface IStaticDriveReplacement
```

### IStaticDriveReplacement

- [4.1 Drive Info](#user-content-istaticdrivereplacementdriveinfo)
- [4.2 Drives](#user-content-istaticdrivereplacementdrives)

### IStaticDriveReplacement.DriveInfo

```csharp
IDriveInfoFactory DriveInfo { get; }
```

Gets the IDriveInfoFactory to use when the static file system is set to replacement mode.

**returns** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md#drive-info-factory)

The IDriveInfoFactory to use when the static file system is set to replacement mode.

### IStaticDriveReplacement.Drives

```csharp
IDrives Drives { get; }
```

Gets the IDrives to use when the static file system is set to replacement mode.

**returns** [IDrives](./documentation/structures/primitives/Drives.md#drives)

The IDrives to use when the static file system is set to replacement mode.