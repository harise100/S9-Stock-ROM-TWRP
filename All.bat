@echo off

REM Modify name according to Samsungs naming
SET NAME=G960FXXU6CSGD

echo Building TWRP flashable zips
pause

echo Extracting your tar.md5 images
.\bin\7z x .\SOURCE\AP_*.md5 -o.\SOURCE\ -y
.\bin\7z x .\SOURCE\BL_*.md5 -o.\SOURCE\ -y
.\bin\7z x .\SOURCE\CP_*.md5 -o.\SOURCE\ -y
.\bin\7z x .\SOURCE\CSC_*.md5 -o.\SOURCE\ -y
del /S /Q .\SOURCE\*.md5
echo Extracting all images with .lz4 extension
echo ROM Files
.\bin\lz4.exe -d .\SOURCE\system.img.lz4 .\SOURCE\system.img.simg
.\bin\lz4.exe -d .\SOURCE\boot.img.lz4 .\SOURCE\boot.img
.\bin\lz4.exe -d .\SOURCE\modem.bin.lz4 .\SOURCE\modem.bin
.\bin\lz4.exe -d .\SOURCE\modem_debug.bin.lz4 .\SOURCE\modem_debug.bin
.\bin\lz4.exe -d .\SOURCE\vendor.img.lz4 .\SOURCE\vendor.img.simg
.\bin\lz4.exe -d .\SOURCE\dqmdbg.img.lz4 .\SOURCE\dqmdbg.img.simg
.\bin\lz4.exe -d .\SOURCE\odm.img.lz4 .\SOURCE\odm.img.simg
echo BL Files
.\bin\lz4.exe -d .\SOURCE\cm.bin.lz4 .\SOURCE\cm.bin
.\bin\lz4.exe -d .\SOURCE\keystorage.bin.lz4 .\SOURCE\keystorage.bin
.\bin\lz4.exe -d .\SOURCE\param.bin.lz4 .\SOURCE\param.bin
.\bin\lz4.exe -d .\SOURCE\sboot.bin.lz4 .\SOURCE\sboot.bin
.\bin\lz4.exe -d .\SOURCE\up_param.bin.lz4 .\SOURCE\up_param.bin
del /S /Q .\SOURCE\*.lz4
echo Extraction done

echo Extracting simg to img
.\bin\simg2img.exe ./SOURCE/system.img.simg ./SOURCE/system.img
.\bin\simg2img.exe ./SOURCE/vendor.img.simg ./SOURCE/vendor.img
.\bin\simg2img.exe ./SOURCE/dqmdbg.img.simg ./SOURCE/dqmdbg.img
.\bin\simg2img.exe ./SOURCE/odm.img.simg ./SOURCE/odm.img
del /S /Q .\SOURCE\*.simg
echo Building csc/odm contents
.\bin\7z x .\SOURCE\odm.img -o.\SOURCE\odm -y
.\bin\OmcTextDecoder d .\SOURCE\odm
echo done

echo Copy images to templates
echo ROM Files

copy .\SOURCE\boot.img .\ROM_G960F\ALEXNDR\images
copy .\SOURCE\dqmdbg.img .\ROM_G960F\ALEXNDR\images
copy .\SOURCE\modem.bin .\ROM_G960F\ALEXNDR\images
copy .\SOURCE\modem_debug.bin .\ROM_G960F\ALEXNDR\images
copy .\SOURCE\system.img .\ROM_G960F\ALEXNDR\images
copy .\SOURCE\vendor.img .\ROM_G960F\ALEXNDR\images
Xcopy /E /I .\SOURCE\odm .\ROM_G960F\ALEXNDR\csc\odm

echo BL Files
copy .\SOURCE\cm.bin .\BL_G960F\ALEXNDR\images
copy .\SOURCE\keystorage.bin .\BL_G960F\ALEXNDR\images
copy .\SOURCE\param.bin .\BL_G960F\ALEXNDR\images
copy .\SOURCE\sboot.bin .\BL_G960F\ALEXNDR\images
copy .\SOURCE\up_param.bin .\BL_G960F\ALEXNDR\images

echo Copiing done

echo Building TWRP zip files
cd .\ROM_G960F
..\bin\7z a -r %NAME%_DevBase_v6.0.zip META-INF options.prop ALEXNDR
move .\%NAME%_DevBase_v6.0.zip ..\
cd..

cd .\BL_G960F
..\bin\7z a -r BL_%NAME%.zip META-INF ALEXNDR
move .\BL_%NAME%.zip ..\
cd..
echo done

echo Cleaning up...
del /S /Q .\SOURCE\*.*
rmdir /S /Q .\SOURCE\odm
rmdir /S /Q .\SOURCE\meta-data
del /S /Q .\ROM_G960F\ALEXNDR\images\*.*
rmdir /S /Q .\ROM_G960F\ALEXNDR\csc\odm
del /S /Q .\BL_G960F\ALEXNDR\images\*.*

echo Script made by harry
pause