@echo off

set treepath=%~1
set makelog=%2
set cullxmodel=%3
set mapname=%4
set exename=%~5
set mpmap=%6
set prefix=

cd %treepath%

if "%mpmap%" == "1" (
    set exename=iw3mp.exe
    set prefix=mp\
)

if not exist "main\maps\%prefix%" mkdir "main\maps\%prefix%"
if exist "map_source\%mapname%.grid" copy "map_source\%mapname%.grid" "map_source\main\maps\%prefix%%mapname%.grid"

"%exename%" +set r_fullscreen 0 +set developer 1 +set logfile 2 +set r_vc_makelog %makelog% +set r_vc_showlog 16 +set r_cullxmodel %cullxmodel% +set thereisacow 1337 +set com_introplayed 1 +devmap %mapname%

if exist "map_source\%mapname%.grid"    attrib -r "map_source\%mapname%.grid"
if exist "main\maps\%prefix%%mapname%.grid"     move /Y "main\maps\%prefix%%mapname%.grid" "map_source\%mapname%.grid"
