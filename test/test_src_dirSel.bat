set THIS_DIR=%~dp0
cd ..\src
dotnet run "dirSel" "%THIS_DIR%test_data\dirSel-test"
pause
