@echo off

set treepath=%~1
set language=%2
set modname=%3

cd %treepath%\mods\%modname%

:: Clean up previous build
if exist "mod.ff" del mod.ff

:: Copy files that need to be included into the Fast File
if exist "accuracy" xcopy accuracy ..\..\raw\accuracy /SYI
if exist "aim_assist" xcopy aim_assist ..\..\raw\aim_assist /SYI
if exist "aitype" xcopy aitype ..\..\raw\aitype /SYI
if exist "animtrees" xcopy animtrees ..\..\raw\animtrees /SYI
if exist "character" xcopy character ..\..\raw\character /SYI
if exist "codescripts" xcopy codescripts ..\..\raw\codescripts /SYI
if exist "common_scripts" xcopy common_scripts ..\..\raw\common_scripts /SYI
if exist "fonts" xcopy fonts ..\..\raw\fonts /SYI
if exist "fx" xcopy fx ..\..\raw\fx /SYI
if exist "images" xcopy images ..\..\raw\images /SYI
if exist "info" xcopy info ..\..\raw\info /SYI
if exist "lights" xcopy lights ..\..\raw\lights /SYI
if exist "maps" xcopy maps ..\..\raw\maps /SYI
if exist "material_properties" xcopy material_properties ..\..\raw\material_properties /SYI
if exist "materials" xcopy materials ..\..\raw\materials /SYI
if exist "mp" xcopy mp ..\..\raw\mp /SYI
if exist "mptype" xcopy mptype ..\..\raw\mptype /SYI
if exist "phys_collmaps" xcopy phys_collmaps ..\..\raw\phys_collmaps /SYI
if exist "physic" xcopy physic ..\..\raw\physic /SYI
if exist "reflections" xcopy reflections ..\..\raw\reflections /SYI
if exist "rumble" xcopy rumble ..\..\raw\rumble /SYI
if exist "shock" xcopy shock ..\..\raw\shock /SYI
if exist "sound" xcopy sound ..\..\raw\sound /SYI
if exist "soundaliases" xcopy soundaliases ..\..\raw\soundaliases /SYI
if exist "statemaps" xcopy statemaps ..\..\raw\statemaps /SYI
if exist "sun" xcopy sun ..\..\raw\sun /SYI
if exist "techniques" xcopy techniques ..\..\raw\techniques /SYI
if exist "techsets" xcopy techsets ..\..\raw\techsets /SYI
if exist "ui" xcopy ui ..\..\raw\ui /SYI
if exist "ui_mp" xcopy ui_mp ..\..\raw\ui_mp /SYI
if exist "vision" xcopy vision ..\..\raw\vision /SYI
if exist "weapons" xcopy weapons ..\..\raw\weapons /SYI
if exist "xanim" xcopy xanim ..\..\raw\xanim /SYI
if exist "xmodel" xcopy xmodel ..\..\raw\xmodel /SYI
if exist "xmodelalias" xcopy xmodelalias ..\..\raw\xmodelalias /SYI
if exist "xmodelparts" xcopy xmodelparts ..\..\raw\xmodelparts /SYI
if exist "xmodelpieces" xcopy xmodelpieces ..\..\raw\xmodelpieces /SYI
if exist "xmodelsurfs" xcopy xmodelsurfs ..\..\raw\xmodelsurfs /SYI

:: The language directory
if exist "%language%" xcopy %language% ..\..\raw\%language% /SYI

:: Config files
if exist "*.cfg" xcopy "*.cfg" ..\..\raw /SYI

:: Copy the zone_source  file
copy /Y mod.csv ..\..\zone_source\

:: Build the Fast File
cd %treepath%\bin
linker_pc.exe -language %language% -compress -cleanup mod

:: Copy the Fast File into the mod directory
cd %treepath%\mods\%modname%
copy /Y ..\..\zone\%language%\mod.ff

:: There may be errors so hold it open
pause
