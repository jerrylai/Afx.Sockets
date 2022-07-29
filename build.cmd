@echo off
set Build="%SYSTEMDRIVE%\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MsBuild.exe"
if exist publish rd /s /q publish
%Build% "NET20/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET46/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET461/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET462/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET47/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET471/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET472/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
%Build% "NET48/Afx.Sockets/Afx.Sockets.csproj" /t:Rebuild /p:Configuration=Release
dotnet build "NETStandard2.0/Afx.Sockets/Afx.Sockets.csproj" -c Release
dotnet build "NETStandard2.1/Afx.Sockets/Afx.Sockets.csproj" -c Release
dotnet build "NET6.0/Afx.Sockets/Afx.Sockets.csproj" -c Release
cd publish
del /q/s *.pdb
pause