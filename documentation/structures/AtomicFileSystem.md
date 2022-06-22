<!--bl
(filemeta
    (title "Atomic File System"))
/bl-->

## Summary

The Atomic File System represent short lived use of the file system. This represents a way to handle when we have objects that live for the length of a method or function but do not persist as file system objects afterwards.

There is one interface and one concrete class. The concrete class inherits the interface. It is recommended you access the class through the interface.

## IAtomicActions

### Description

 Represents a way to interact with the file system through atomic actions.

### Replace

Replace builds an [Atomic Replacement Builder](#atomc-replacement-builder) to allow for the testing of code that takes an Atomic File System.

```csharp
IAtomicReplacementBuilder Replace { get; }
```

### FileStream

Returns an atomic action allowing the interaction with a [IFileStream](#file-stream) specified by the parameters.

