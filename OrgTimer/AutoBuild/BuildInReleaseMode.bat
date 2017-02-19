rd .\BuildResults /S /Q
md .\BuildResults



REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319 for framework 4.0 or older
REM set msBuildDir="C:\Program Files (x86)\MSBuild\14.0\Bin" for newer frameworks
set msBuildDir="C:\Program Files (x86)\MSBuild\14.0\Bin"
call %msBuildDir%\msbuild.exe  ..\OrgTimer.csproj /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=..\Bin\Release\AutoBuild_LOG.log
set msBuildDir=

REM copying Release files over
REM XCOPY ..\Bin\Release\*.* .\BuildResults\ ..don't need all of them

REM Copying Release config over
XCOPY ..\Bin\Release\OrgTimer.exe .\BuildResults\
COPY OrgTimerRelease.exe.config .\BuildResults\OrgTimer.exe.config