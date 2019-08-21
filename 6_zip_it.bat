
@echo off
echo Building TWRP zip files

SET NAME=G960FXXU6CSGD

cd .\ROM_G960F
..\bin\7z a -r %NAME%_DevBase_v6.0.zip META-INF options.prop ALEXNDR
move .\%NAME%_DevBase_v6.0.zip ..\
cd..

cd .\BL_G960F
..\bin\7z a -r BL_%NAME%.zip META-INF ALEXNDR
move .\BL_%NAME%.zip ..\
cd..
echo done
echo Script made by harry
pause