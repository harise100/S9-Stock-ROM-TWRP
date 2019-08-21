@echo off
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
echo Extraction done
echo Script made by harry
pause