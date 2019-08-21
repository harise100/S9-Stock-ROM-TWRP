@echo off
echo Copy images to templates
pause
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
echo Script made by harry
pause