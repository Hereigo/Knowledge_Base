@echo off
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)
"C:\Program Files\7-Zip\7z.exe" a -r -sdel -x!*.zip -x!*.cmd %USERPROFILE%\Documents\MyExpense_PUB_%DATE%_%mytime%.zip %USERPROFILE%\Documents\MyExpensePUB\*
PAUSE