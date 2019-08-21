@echo off
echo  Extracting simg to img

.\bin\simg2img.exe ./SOURCE/system.img.simg ./SOURCE/system.img
.\bin\simg2img.exe ./SOURCE/vendor.img.simg ./SOURCE/vendor.img
.\bin\simg2img.exe ./SOURCE/dqmdbg.img.simg ./SOURCE/dqmdbg.img
.\bin\simg2img.exe ./SOURCE/odm.img.simg ./SOURCE/odm.img

echo Extraction done
echo Script made by harry
pause