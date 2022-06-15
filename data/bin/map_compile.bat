@echo off

set treepath=%~1
set mapname=%2
set parmBSPOptions=%~3
set parmLightOptions=%~4
set compileBSP=%5
set compileLight=%6
set compilePaths=%7

if "%parmBSPoptions%" == "-" (
    set parmBSPoptions=
)

if "%parmLightOptions%" == "-" (
    set parmLightOptions=
)

cd %treepath%

if not exist "raw\maps" mkdir "raw\maps"

if "%compileBSP%" == "1" (

    echo .
    echo .
    echo ###########################################
    echo         COMPILE BSP
    echo ###########################################
    echo .
    echo .
    
    
    copy "map_source\%mapname%.map" "raw\maps\%mapname%.map"
    "bin\cod4map.exe" -platform pc -loadFrom "map_source\%mapname%.map" %parmBSPOptions% "raw\maps\%mapname%"
)

if "%compileLight%" == "1" (
    
    echo .
    echo .
    echo ###########################################
    echo         COMPILE LIGHT
    echo ###########################################
    echo .
    echo .

    if exist "map_source\%mapname%.grid" copy "map_source\%mapname%.grid" "raw\maps\%mapname%.grid"
    "bin\cod4rad.exe" -platform pc %parmLightOptions% "raw\maps\%mapname%"
)

if exist "raw\maps\%mapname%.map"       del "raw\maps\%mapname%.map"
if exist "raw\maps\%mapname%.d3dprt"    del "raw\maps\%mapname%.d3dprt"
if exist "raw\maps\%mapname%.d3dpoly"   del "raw\maps\%mapname%.d3dpoly"
if exist "raw\maps\%mapname%.vclog"     del "raw\maps\%mapname%.vclog"
if exist "raw\maps\%mapname%.grid"      del "raw\maps\%mapname%.grid"
if exist "raw\maps\%mapname%.lin"      move "raw\maps\%mapname%.lin" "map_source\%mapname%.lin"

if "%compilePaths%" == "1" (
    
    echo .
    echo .
    echo ###########################################
    echo         CONNECTING PATHS
    echo ###########################################
    echo .
    echo .

    "sp_tool.exe" +set r_fullscreen 0 +set logfile 2 +set monkeytoy 0 +set com_introplayed 1 +set usefastfile 0 +set g_connectpaths 2 +devmap %mapname%
)

echo .
echo .
echo ###########################################
echo                DONE
echo ###########################################
echo .
echo .

:: There may be errors so hold it open
:EXIT
pause
