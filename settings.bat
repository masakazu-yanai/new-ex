@ECHO OFF

:: Get a directory path of a bat file.
set THIS_DIR=%~dp0

set OUTPUT_PATH=data\config.user.json

::------------------------------------------------------------
:: Q. language
echo Select Language [1,2]
echo 1. Japanese (ja)
echo 2. English (en)
choice /c 12 /n > nul
if errorlevel 1 set LANG=ja
if errorlevel 2 set LANG=en
echo Language setting is: %LANG%
echo.

::------------------------------------------------------------
:: Output JSON
(
echo {
echo    "language": "%LANG%"
echo }
)> %THIS_DIR%%OUTPUT_PATH%

echo Create JSON file: %OUTPUT_PATH%
echo.
pause
