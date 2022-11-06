# Programming 11 - Production Outline

## Tools & Resources

This section outlines the tools and resources used in making this product.

- Visual Studio
  - Coding IntelliSense
  - Package management
  - XAML design tools
  - Compiler and debugger
  - Local git source control
- GitHub
  - Project management
  - Markdown rendering
  - Remote git source control
  - Sharing
- Visual Studio Code
  - Quick markdown viewer
  - Misc editor

## Technologies

This project used many Microsoft technologies, this section outlines the primary technologies used in this project and used to make this project work as it does.

### Build Technologies

- [DotNET](https://github.com/dotnet/runtime)
  - Fast and efficient C# 10 JIT compiler
  - Cross-platform publishing software (`Dotnet publish`)
- Window Batch Scripting
  - Local automated publishing workflow

### In-app Technologies

- [Roslyn](https://github.com/dotnet/roslyn)
  - C# analyzers and in-memory C# compiler
- [AvaloniaUI](https://github.com/mono/SkiaSharp)
  - Cross-platform MVVM/XAML-based UI framework
- [Skia Sharp](https://github.com/mono/SkiaSharp) (used by AvaloniaUI)
  - C# re-implementation of [Skia](https://github.com/google/Skia), a C/C++ graphics library maintained by Google

### Materials

- PC Hardware

### Production Steps

- XD rough design
  - Design a rough sketch of the UI with Adobe XD
- Build XAML/C# window layout
  - Create the application layout stack
- Design working XAML UI layout
  - Create the main XAML views
- Implement calculator control
  - Create the XAML calculator layout view
  - Create a bound ViewModel
  - Implement automated num-pad builder from `List<string>`
- Implement execute function
  - Use the Roslyn C# in-memory compiler to compile and run the (C# based) math notes
- Implement project file format (MNTP, **M**ath **N**otation **T**ool **P**roject) IO
  - Create the binary MNTP writer
  - Create the binary MNTP reader
- Implement editor `Query()` function (from in-memory assembly)
  - Import static `CodeExt` to call `Query()` from the in-app editor
- Write publishing script workflow
  - Write `dotnet publish` workflows in batch

### Production Time

- UI Design
  - 1-2 days (~12h)
- Backend
  - 2-4 days (~24h)
- Debugging
  - 1-2 days (~12h)

### Coordination

- Project coordination, management, and publishing will be done using [git](https://git-scm.com/) and [GitHub](https://github.com).

---

_The fully documented build progression and source code is available in the MathNotationTool GitHub [repository](https://github.com/ArchLeaders/MathNotationTool/tree/main/src)_