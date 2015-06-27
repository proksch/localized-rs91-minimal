@echo off

:: this picks the first .csproj or .nuspec file in the working directory and builds a .nupkg from it
:: to package a specific project or file, add the .csproj or .nupkg file name after the pack option
:: -NoPackageAnalysis suppresses warnings, caused by R# bundles not adhering to the NuGet structure conventions



set TIME1=%time::=%
set TIME2=%TIME1: =0%
set TIME3=%TIME2:~0,-3%
::echo %TIME2%

set DATE1=%date:~-4,4%%date:~-10,2%%date:~-7,2%
::echo %DATE1%

set TIMESTAMP=%DATE1%-%TIME3%
echo Building @ %TIMESTAMP%...


msbuild Localized-RS91-Minimal.sln

set TARGET=C:\Users\seb\Desktop\RS9-Debug-Feed\

::C:\Users\Sven\Downloads\
nuget.exe pack Localized.RS91.Example.1.0.0-alpha1.nuspec -Verbosity detailed -NoPackageAnalysis -Version 1.0.0-v%TIMESTAMP%


echo Deploying into: %TARGET%
move *.nupkg %TARGET%

pause