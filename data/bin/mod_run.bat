@echo off

set treepath=%~1
set modname=%2
set exename=%~3
set mpmod=%4
set cmdOptions=%~5


if "%mpmod%" == "1" (
    set exename=iw3mp.exe
)

cd %treepath%
"%exename%" +set logfile 2 +set monkeytoy 0 +set com_introplayed 1 +set fs_game "mods\%modname%" %cmdOptions%
