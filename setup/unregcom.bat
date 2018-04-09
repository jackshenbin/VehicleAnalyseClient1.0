set p=%0
cd /d %p:\unregcom.bat=\%

regedit /s unreg.reg
regsvr32 /s/u .\ChannelDrawing.ocx
pause