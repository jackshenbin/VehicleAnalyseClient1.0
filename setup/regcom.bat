set p=%0
cd /d %p:\regcom.bat=\%

C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm /codebase .\Bocom.ImageAnalysisClient.OCX.dll

regsvr32 .\ChannelDrawing.ocx
pause