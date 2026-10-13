# Part G — Short Answers

## 1. .csproj Contents

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

All four properties mentioned in Part A are present:

- `OutputType`: Set to `Exe`, so the project builds as an executable.
- `TargetFramework`: Set to `net10.0`, targeting .NET 10.
- `ImplicitUsings`: Set to `enable`, so common namespaces are included automatically.
- `Nullable`: Set to `enable`, so nullable reference type analysis is enabled.

## 2. Do #region / #endregion change the compiled output?

No, they do not change the compiled output. They help organize code into collapsible sections in the editor, making large files easier to navigate.

## 3. When would you use /// XML documentation comments instead of //?

I use `///` to document public classes, methods, and properties. The documentation can appear in IntelliSense and help other developers understand how to use the code. I use `//` for regular comments inside the code.

## 4. Why does C# have no true global variables, and what's the closest equivalent?

C# uses classes and other types to organize data instead of allowing variables to exist globally. A `static` field inside a class is a common alternative because it can be accessed using the class name. However, shared mutable state should be used carefully because it can make code harder to maintain and test.
