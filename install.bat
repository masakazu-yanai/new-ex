@ECHO OFF

:: Get a directory path of a bat file.
set THIS_DIR=%~dp0
set THIS_DIR2=%THIS_DIR:\=\\%
    :: Replace  \ -> \\

echo %THIS_DIR%

::------------------------------------------------------------
:: Init vars for a registory.
set APP_NAME=NewEx
set BIN_PATH=%THIS_DIR2%bin\\new-ex.exe
set INS_FNM=install.reg

::------------------------------------------------------------
:: file, DirectorySel, DirectoryIn
(
echo Windows Registry Editor Version 5.00
echo.
echo [HKEY_CLASSES_ROOT\*\shell\%APP_NAME%]
echo "Icon"="\"%THIS_DIR2%data\\icon\\icon.ico\""
echo.
echo [HKEY_CLASSES_ROOT\*\shell\%APP_NAME%\command]
echo @="\"%BIN_PATH%\" \"file\" \"%%1\""
echo.
echo.
echo [HKEY_CLASSES_ROOT\Directory\shell\%APP_NAME%]
echo "Icon"="\"%THIS_DIR2%data\\icon\\icon.ico\""
echo.
echo [HKEY_CLASSES_ROOT\Directory\shell\%APP_NAME%\command]
echo @="\"%BIN_PATH%\" \"dirSel\" \"%%1\""
echo.
echo.
echo [HKEY_CLASSES_ROOT\Directory\Background\shell\%APP_NAME%]
echo "Icon"="\"%THIS_DIR2%data\\icon\\icon.ico\""
echo.
echo [HKEY_CLASSES_ROOT\Directory\Background\shell\%APP_NAME%\command]
echo @="\"%BIN_PATH%\" \"dirIn\" \"%%V\""
echo.
)> %INS_FNM%
%INS_FNM%
del %INS_FNM%

::------------------------------------------------------------
::pause
exit
