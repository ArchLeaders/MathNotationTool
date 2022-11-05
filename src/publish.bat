@ECHO OFF

DEL /Q .\publish\Linux64-MathNotationTool
DEL /Q .\publish\OSx64-MathNotationTool
DEL /Q .\publish\Win64-MathNotationTool.exe

ECHO Publish linux-x64
START "publish-linux-x64" /B /WAIT dotnet publish -r linux-x64 --configuration Release --version-suffix 0.1.0 --output .\publish --sc true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true
RENAME .\publish\MathNotationTool Linux64-MathNotationTool

ECHO Publish osx-x64
START "publish-osx-x64" /B /WAIT dotnet publish -r osx-x64 --configuration Release --version-suffix 0.1.0 --output .\publish --sc true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true
RENAME .\publish\MathNotationTool OSx64-MathNotationTool

ECHO Publish win-x64
START "publish-win-x64" /B /WAIT dotnet publish -r win-x64 --configuration Release --version-suffix 0.1.0 --output .\publish --sc true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true
RENAME .\publish\MathNotationTool.exe Win64-MathNotationTool.exe

PAUSE