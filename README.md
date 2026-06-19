[![Nuget](https://img.shields.io/nuget/v/DouglasDwyer.FixedArray)](https://www.nuget.org/packages/DouglasDwyer.FixedArray)
[![Downloads](https://img.shields.io/nuget/dt/DouglasDwyer.FixedArray)](https://www.nuget.org/packages/DouglasDwyer.FixedArray)

# DouglasDwyer.FixedArray

Rust-style fixed-size stack-allocated arrays for C#. Provides `Array1<T>` through `Array32<T>` — value types backed by `[InlineArray]` that live entirely on the stack with no heap allocation.

## Installation

```
dotnet add package DouglasDwyer.FixedArray
```

The package bundles a Roslyn source generator that emits `Array1<T>`–`Array32<T>` into your project at compile time. No runtime dependency is needed beyond the small support types (`IFixedArray<T>`, `FixedArrayEnumerator<T, A>`) included in the package.

## Usage

### Construction

Use C# collection expressions (requires C# 12+):

```csharp
Array3<int> rgb = [255, 128, 0];
```

Or use the explicit constructor:

```csharp
var point = new Array2<float>(1.0f, 2.5f);
```

### Indexing

Each type is an `[InlineArray]` struct, so standard index syntax works:

```csharp
Array3<int> v = [10, 20, 30];
int x = v[0];
v[1] = 99;
```

### Enumeration

All array types implement `IEnumerable<T>`, so `foreach` and LINQ work out of the box:

```csharp
Array4<string> words = ["hello", "fixed", "stack", "array"];

foreach (var w in words)
    Console.WriteLine(w);

var upper = words.Select(w => w.ToUpper()).ToList();
```

### Equality

Arrays support `==`, `!=`, `Equals`, and `GetHashCode`, all compared element-by-element:

```csharp
Array2<int> a = [1, 2];
Array2<int> b = [1, 2];
Console.WriteLine(a == b); // True
```

## API

| Type | Description |
|---|---|
| `Array1<T>` – `Array32<T>` | Stack-allocated fixed-size array structs. |
| `IFixedArray<T>` | Interface exposing `Length` and `Get(int i)`, useful for generic constraints. |
| `FixedArrayEnumerator<T, A>` | Struct enumerator returned by `GetEnumerator()` — no boxing. |

## Requirements

- .NET 8.0 or later
- C# 12 or later (for collection expression syntax)