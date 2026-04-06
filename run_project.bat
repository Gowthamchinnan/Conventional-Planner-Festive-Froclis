@echo off
setlocal

set "IIS_EXPRESS_X86=C:\Program Files (x86)\IIS Express\iisexpress.exe"
set "IIS_EXPRESS_X64=C:\Program Files\IIS Express\iisexpress.exe"

if exist "%IIS_EXPRESS_X64%" (
    set "IIS_EXE=%IIS_EXPRESS_X64%"
) else if exist "%IIS_EXPRESS_X86%" (
    set "IIS_EXE=%IIS_EXPRESS_X86%"
) else (
    echo [ERROR] IIS Express was not found on this machine.
    echo Please install Visual Studio or IIS Express separately (https://www.microsoft.com/en-us/download/details.aspx?id=48264).
    echo For now, opening the project folder...
    explorer .
    pause
    exit /b 1
)

echo [INFO] Starting IIS Express for 'Conventional Festive Frolics' on http://localhost:5000...
start "" "%IIS_EXE%" /path:"%~dp0" /port:5000
timeout /t 2 >nul
start http://localhost:5000/Homepage.aspx

echo [INFO] Application is running. Close the IIS Express tray icon when finished.
pause
