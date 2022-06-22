
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade Structures #
#### A guide to the interfaces and objects in the library. ####

## Table Of Contents ##

- [Section 1: Atomic File System](#user-content-atomic-file-system)
- [Section 2: Atomic Replacement Builder](#user-content-atomic-replacement-builder)
- [Section 3: File Stream](#user-content-file-stream)

## Atomic File System ##

## Summary

The Atomic File System represent short lived use of the file system. This represents a way to handle when we have objects that live for the length of a method or function but do not persist as file system objects afterwards.

There is one interface and one concrete class. The concrete class inherits the interface. It is recommended you access the class through the interface.

## IAtomicActions

### Description

 Represents a way to interact with the file system through atomic actions.

### Replace

Replace builds an [Atomic Replacement Builder](#user-content-atomic-replacement-builder) to allow for the testing of code that takes an Atomic File System.

```csharp
IAtomicReplacementBuilder Replace { get; }
```

### FileStream

Returns an atomic action allowing the interaction with a [IFileStream](#user-content-file-stream) specified by the parameters.


    

## Atomic Replacement Builder ##

TBD
    

## File Stream ##

TBD
    

<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    