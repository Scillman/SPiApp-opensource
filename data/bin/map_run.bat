@echo off

set treepath=%~1
set mapname=%2
set cmdOptions=%~3
set exename=%~4
set mpmap=%5

if "%mpmap%" == "1" (
    set exename=iw3mp.exe
)

cd %treepath%
"%exename%" +set logfile 2 +set monkeytoy 0 +set com_introplayed 1 +devmap %mapname% %cmdOptions%
