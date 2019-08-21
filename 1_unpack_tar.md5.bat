@echo off
echo Extracting your tar.md5 images
.\bin\7z x .\SOURCE\AP_*.md5 -o.\SOURCE\ -y
.\bin\7z x .\SOURCE\BL_*.md5 -o.\SOURCE\ -y
.\bin\7z x .\SOURCE\CP_*.md5 -o.\SOURCE\ -y
.\bin\7z x .\SOURCE\CSC_*.md5 -o.\SOURCE\ -y
echo Extraction done
echo Script made by harry
pause