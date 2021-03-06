# Drive Info Factory

## Summary

A factory to build IDriveInfos

```csharp
public interface IDriveInfoFactory
```

<!-- 9 -->
## IDriveInfoFactory

- [6.1 Drive Info](#user-content-idriveinfofactorydriveInfo)

## IDriveInfoFactory.DriveInfo

```csharp
IDriveInfo DriveInfo(string driveName);
```

Provides access to information on the specified drive.

**driveName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.

**returns** [IDriveInfo](./DriveInfo.md)

Information on the specified drive.