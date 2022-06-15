@echo off

set treepath=%~1
set language=%2
set mapname=%3

cd %treepath%\bin
linker_pc.exe -language %language% %mapname%

:: There may be errors so hold it open
pause
