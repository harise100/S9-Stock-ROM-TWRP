@echo off
echo Building csc/odm contents

.\bin\7z x .\SOURCE\odm.img -o.\SOURCE\odm -y

echo Decoding XML files

.\bin\OmcTextDecoder d .\SOURCE\odm

echo done
echo Script made by harry
pause