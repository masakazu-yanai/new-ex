set THIS_DIR=%~dp0
cd ..\src
dotnet run "dirIn" "%THIS_DIR%test_data"
pause
