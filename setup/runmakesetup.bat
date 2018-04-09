echo off
set RarInstaller="C:\Program Files (x86)\WinRAR\RAR.exe"
setlocal EnableDelayedExpansion
set name=%date:~0,4%%date:~5,2%%date:~8,2%
set /p b=<"release note.txt"
echo %b%
set a=%b:~-11%
set version=!b:%a%=!
setlocal DisableDelayedExpansion
%RarInstaller% a -o+ -r -x%0 -x*.log -x*.list -xlog\ -xcomment.txt -x*.pdb -xIRASClient*.exe -zcomment.txt -sfx IRASClient_%version%_%name%.exe
copy /y IRASClient_%version%_%name%.exe IRASClient.exe