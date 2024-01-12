@echo off

REM Copy ../Art/icon.png to the current directory
copy /y ..\Art\icon.png .
REM Copy ../Art/manifest.json to the current directory
copy /y ..\Art\manifest.json .
REM Copy ../README.md to the current directory
copy /y ..\README.md .
REM Copy ../CHANGELOG.md to the current directory
copy /y ..\CHANGELOG.md .
REM Copy all files from ../Bundles to the current directory
xcopy /s /y /q ..\Bundles\* .\

REM Create a zip file named WackyCosmetics.zip containing all files (except build.bat) in the current directory
"C:\Program Files\7-Zip\7z.exe" a WackyCosmetics.zip * -x!build.bat -x!WackyCosmetics.zip

for %%I in (*) do if not "%%I"=="WackyCosmetics.zip" if not "%%I"=="build.bat" del /q "%%I"
for /d %%D in (*) do if not "%%D"=="WackyCosmetics.zip" if not "%%D"=="build.bat" rd /s /q "%%D"