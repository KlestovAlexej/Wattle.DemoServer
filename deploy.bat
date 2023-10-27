rmdir Deploy /s /q
IF %ERRORLEVEL% NEQ 0 EXIT 1

mkdir Deploy\Prod\logs
IF %ERRORLEVEL% NEQ 0 EXIT 1

Tools\deploy.bat > Deploy/BuildLog.txt
