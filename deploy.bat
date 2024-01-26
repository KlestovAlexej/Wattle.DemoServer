rmdir Deploy /s /q
IF %ERRORLEVEL% NEQ 0 EXIT 1

mkdir Deploy\Prod\logs
IF %ERRORLEVEL% NEQ 0 EXIT 1

Tools\deploy.bat 1> Deploy/BuildLog.txt 2>&1

echo —борка успешно выполнена > Deploy/ReadMe.txt
