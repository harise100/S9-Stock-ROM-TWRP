@echo off
echo Cleaning up...
del /S /Q .\SOURCE\*.*
rmdir /S /Q .\SOURCE\odm
rmdir /S /Q .\SOURCE\meta-data
del /S /Q .\ROM_G960F\ALEXNDR\images\*.*
rmdir /S /Q .\ROM_G960F\ALEXNDR\csc\odm
del /S /Q .\BL_G960F\ALEXNDR\images\*.*
echo done
echo Script made by harry
pause