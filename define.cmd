@echo off
set outfile=Notifier.exe
set buildfiles=Notifier.cs
set strongname=/keyfile:keyfile.snk
set appicon=-win32icon:onequbit.ico
set winexeoptions=-target:winexe %appicon% %strongname%
set consoleoptions=-target:exe %appicon% %strongname%
set compileoptions=-out:%outfile% %winexeoptions%
