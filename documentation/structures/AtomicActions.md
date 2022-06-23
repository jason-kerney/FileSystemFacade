<!--bl
(filemeta
    (title "Atomic Actions"))
/bl-->

### Summary

This object allows for the interaction with filesystem objects in a discrete and short lived way.

### IAtomicActions

- [2.1 Description](#user-content-iatomicactions-description)
- [2.2 Preform](#user-content-iatomicactionspreform)
- [2.3 Preform](#user-content-iatomicactionsgetby)

### IAtomicActions Description

```csharp
public interface IAtomicActions<out TFileSystem>
```

**TFileSystem** 

The type of file system object it interacts with.

### IAtomicActions.Preform

```csharp
void Preform(Action<TFileSystem> doer);
```

Allows a non returning action to be performed on the TFileSystem.

**doer** [Action\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=net-6.0)

An action that takes a TFileSystem and acts on it.

### IAtomicActions.GetBy

```csharp
TReturn GetBy<TReturn>(Func<TFileSystem, TReturn> getter);
```

Allows for an activity to be done on TFileSystem that also returns a value.

**getter** [Func\<T,TResult\>](https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=net-6.0)

A func that takes a type TFileSystem and returns TReturn.

**TReturn** 

The type to return.

**returns** TReturn

A type TReturn, that is returned from the getter.
