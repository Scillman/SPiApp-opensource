@echo off

set treepath=%~1
set zipper=%~2
set modname=%3
set iwdname=z_%modname%.iwd

cd %treepath%\mods\%modname%

:: Clean previous build
if exist "%iwdname%" del "%iwdname%"

:: Copy files that need to be included into the IWD file
if exist "accuracy" "%zipper%" a -r -tzip "%iwdname%" accuracy
if exist "images" "%zipper%" a -r -tzip "%iwdname%" images
if exist "sound" "%zipper%" a -r -tzip "%iwdname%" sound
if exist "weapons" "%zipper%" a -r -tzip "%iwdname%" weapons

:: There may be errors so hold it open
pause
