set THIS_DIR=%~dp0
cd ..\src
dotnet run "file" "%THIS_DIR%test_data\file-test.txt"
pause
