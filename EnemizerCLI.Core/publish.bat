@echo off
rem Builds the self-contained release packages. See tools/publish.sh for the layout.
for %%r in (linux-x64 linux-arm64 osx-x64 osx-arm64 win-x64) do (
    dotnet publish EnemizerCLI.Core.csproj -c Release -r %%r --self-contained -p:PublishSingleFile=true -o ..\dist\%%r || exit /b 1
)
