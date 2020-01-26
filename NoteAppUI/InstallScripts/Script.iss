; -- Example1.iss --
; Demonstrates copying 3 files and creating an icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=NoteApp
AppVersion=1.0
WizardStyle=modern
DefaultDirName={autopf}\NoteApp
DefaultGroupName=NoteApp
UninstallDisplayIcon={app}\NoteApp.exe
Compression=lzma2
SolidCompression=yes
OutputDir=C:\Users\Михаил\source\repos\NoteApp\NoteAppUI\InstallScripts\Installers

[Files]
Source: "C:\Users\Михаил\source\repos\NoteApp\NoteAppUI\InstallScripts\Release\NoteAppUI.exe"; DestDir: "{app}"
Source: "C:\Users\Михаил\source\repos\NoteApp\NoteAppUI\InstallScripts\Release\Newtonsoft.Json.dll"; DestDir: "{app}"
Source: "C:\Users\Михаил\source\repos\NoteApp\NoteAppUI\InstallScripts\Release\NoteApp.dll"; DestDir: "{app}"

[Icons]
Name: "{group}\My Program"; Filename: "{app}\NoteApp.exe"
