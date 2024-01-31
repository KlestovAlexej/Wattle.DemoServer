mkdir Deploy\Prod\Processing\bin\Release
IF %ERRORLEVEL% NEQ 0 EXIT 1

mkdir Deploy\Prod\Processing\bin\Debug
IF %ERRORLEVEL% NEQ 0 EXIT 1

mkdir Deploy\Test\logs
IF %ERRORLEVEL% NEQ 0 EXIT 1

mkdir Deploy\Test\Processing\bin\Release
IF %ERRORLEVEL% NEQ 0 EXIT 1

mkdir Deploy\Test\Processing\bin\Debug
IF %ERRORLEVEL% NEQ 0 EXIT 1

rem --- BUILD_TEST -----------------

rmdir src\DemoServer.Processing.Application\bin /s /q
IF %ERRORLEVEL% NEQ 0 EXIT 1

rmdir src\DemoServer.Processing.Application\obj /s /q
IF %ERRORLEVEL% NEQ 0 EXIT 1

dotnet build Tools\MSBuild\Publish.csproj "/p:BuildProfile=/p:DefineConstants=BUILD_TEST" "/p:DefineConstants=BUILD_TEST"
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy Publish\ProductDescription.xml Deploy\Test\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy src\DemoServer.Processing.Application\WindowsRegister.txt Deploy\Test\Processing\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy src\DemoServer.Processing.DataAccess.Postgresql\DemoServer.Processing.sql Deploy\Test\Processing\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy /Y /E src\DemoServer.Processing.Application\bin\Release\net8.0-windows\win-x64\ Deploy\Test\Processing\bin\Release\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy /Y /E src\DemoServer.Processing.Application\bin\Debug\net8.0-windows\win-x64\ Deploy\Test\Processing\bin\Debug\
IF %ERRORLEVEL% NEQ 0 EXIT 1

rem --- BUILD_PROD -----------------

rmdir src\DemoServer.Processing.Application\bin /s /q
IF %ERRORLEVEL% NEQ 0 EXIT 1

rmdir src\DemoServer.Processing.Application\obj /s /q
IF %ERRORLEVEL% NEQ 0 EXIT 1

dotnet build Tools\MSBuild\Publish.csproj "/p:BuildProfile=/p:DefineConstants=BUILD_PROD" "/p:DefineConstants=BUILD_PROD"
IF %ERRORLEVEL% NEQ 0 EXIT 1

rem Публикация пакетов nuget
rem dotnet nuget push Publish\NuGet\ShtrihM.DemoServer.Processing.Api.Common.*.nupkg --skip-duplicate -k <NUGET-KEY> -sk <NUGET-KEY> -s https://api.nuget.org/v3/index.json -ss https://nuget.org/ -t 300 -d
rem IF %ERRORLEVEL% NEQ 0 EXIT 1
rem dotnet nuget push Publish\NuGet\ShtrihM.DemoServer.Processing.Api.Clients.*.nupkg --skip-duplicate -k <NUGET-KEY> -sk <NUGET-KEY> -s https://api.nuget.org/v3/index.json -ss https://nuget.org/ -t 300 -d
rem IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy Publish\ProductDescription.xml Deploy\Prod\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy src\DemoServer.Processing.Application\WindowsRegister.txt Deploy\Prod\Processing\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy src\DemoServer.Processing.DataAccess.Postgresql\DemoServer.Processing.sql Deploy\Prod\Processing\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy /Y /E src\DemoServer.Processing.Application\bin\Release\net8.0-windows\win-x64\ Deploy\Prod\Processing\bin\Release\
IF %ERRORLEVEL% NEQ 0 EXIT 1

xcopy /Y /E src\DemoServer.Processing.Application\bin\Debug\net8.0-windows\win-x64\ Deploy\Prod\Processing\bin\Debug\
IF %ERRORLEVEL% NEQ 0 EXIT 1

echo Сборка успешно выполнена > Publish/ReadMe.txt
IF %ERRORLEVEL% NEQ 0 EXIT 1

echo Сборка успешно выполнена > Deploy/ReadMe.txt
