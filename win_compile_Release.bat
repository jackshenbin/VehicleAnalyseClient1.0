set p=%0
cd /d %p:\win_compile_Release.bat=\%

call "C:\Program Files\Microsoft Visual Studio 10.0\VC\bin\x86_amd64\vcvarsx86_amd64.bat"

set PRJ_CFG=Release
set TmpOutFile1= "setup\ImageAnalysisClient.exe"

set BinDir= setup


@echo ��ʼ����%PRJ_CFG%�汾
IF EXIST %TmpOutFile1% echo ɾ���ϴα������ɵİ�װ�ļ�
IF EXIST %TmpOutFile1% del %TmpOutFile1%


cd %BinDir%
regsvr32 /s ChannelDrawing.ocx

@echo ��ʼ����...
cd ..
devenv /nologo /Rebuild "%PRJ_CFG%|x86" ImageAnalysisClient.sln > build_ImageAnalysisClient_win32_%PRJ_CFG%.log


IF NOT EXIST %TmpOutFile1% goto ERR1


@echo ����ɹ�...
goto END

:ERR1
@echo %TmpOutFile1%����ʧ�ܣ��������
echo %TmpOutFile1% build err by shenbin
goto END


:END

