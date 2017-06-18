%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /target:Clean CH.DataAccess.csproj /property:Configuration=Debug   /p:DefineConstants="FW4;NOASYNC"
%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /target:Clean CH.DataAccess.csproj /property:Configuration=Release /p:DefineConstants="FW4;NOASYNC"
%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe CH.DataAccess.csproj /property:Configuration=Debug   /property:OutputPath=bin\Debug.4.0\   /property:TargetFrameworkVersion=v4.0 /p:DefineConstants="FW4;NOASYNC"
%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe CH.DataAccess.csproj /property:Configuration=Release /property:OutputPath=bin\Release.4.0\ /property:TargetFrameworkVersion=v4.0 /p:DefineConstants="FW4;NOASYNC"

@echo off

±‡“ÎÕÍ≥… 

pause

 
