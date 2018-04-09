set p=%0
cd /d %p:\win_compile_Release.bat=\%

call "C:\Program Files\Microsoft Visual Studio 10.0\VC\bin\x86_amd64\vcvarsx86_amd64.bat"

set PRJ_CFG=Release
set TmpOutFile1= "setup\ImageAnalysisClient.exe"

set BinDir= setup


@echo 开始编译%PRJ_CFG%版本
IF EXIST %TmpOutFile1% echo 删除上次编译生成的安装文件
IF EXIST %TmpOutFile1% del %TmpOutFile1%


cd %BinDir%
regsvr32 /s ChannelDrawing.ocx

@echo 开始编译...
cd ..
devenv /nologo /Rebuild "%PRJ_CFG%|x86" ImageAnalysisClient.sln > build_ImageAnalysisClient_win32_%PRJ_CFG%.log


IF NOT EXIST %TmpOutFile1% goto ERR1


@echo 编译成功...
goto END

:ERR1
@echo %TmpOutFile1%编译失败，请检查代码
echo %TmpOutFile1% build err by shenbin
goto END


:END

