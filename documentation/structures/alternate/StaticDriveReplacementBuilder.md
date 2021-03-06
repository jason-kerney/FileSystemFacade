<!--bl
(filemeta
    (title "Static Drive Replacement Builder"))
/bl-->

### Summary

A builder used to aid in replacing drive items in the static file system. This object makes testing easier.

```csharp
public interface IStaticDriveReplacementBuilder
```

### IStaticDriveReplacementBuilder

- [3.1 Replace Drive Info](#user-content-istaticdrivereplacementbuilderreplacedriveinfo)
- [3.2 Replace Drives](#user-content-istaticdrivereplacementbuilderreplacedrives)
- [3.3 Build](#user-content-istaticdrivereplacementbuilderbuild)

### IStaticDriveReplacementBuilder.ReplaceDriveInfo

```csharp
IStaticDriveReplacementBuilder ReplaceDriveInfo(IDriveInfoFactory factory);
```

Configures the IDriveInfoFactory to use when the static file system is put into replacement mode.

**factory** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md#drive-info-factory)

The IDriveInfoFactory to use.

**returns** [IStaticDriveReplacementBuilder](#user-content-istaticdrivereplacementbuilder)

An instance of the builder with IDriveInfoFactory configured to be replaced.

### IStaticDriveReplacementBuilder.ReplaceDrives

```csharp
IStaticDriveReplacementBuilder ReplaceDrives(IDrives drives);
```

Configures the IDrives to use when the static file system is put into replacement mode.

**drives** [IDrives](./documentation/structures/primitives/Drives.md#drives)

The IDrives to use when the static file system is put into replacement mode.

**returns**

An instance of the builder with the IDrives configured to be replaced.

### IStaticDriveReplacementBuilder.Build

```csharp
IStaticDriveReplacement Build();
```

Builds the configuration item that is used to tell the static file system what drive based objects to use when put into replacement mode.

**returns** [IStaticDriveReplacement](#user-content-static-drive-replacement)

The configuration item that is used to tell the static file system what drive based objects to use when put into replacement mode.