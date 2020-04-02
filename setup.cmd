@ECHO OFF
SETLOCAL

REM Set up database
SET MusicFestival=src\MusicFestival.Blazor.Epi
IF EXIST %MusicFestival%\App_Data (
    ECHO Remove all files from the app data folder
    DEL %MusicFestival%\App_Data\*.* /F /Q || Exit /B 1
) ELSE (
    MKDIR %MusicFestival%\App_Data || Exit /B 1
)

REM Copy the database files to the site.
XCOPY /y/i build\database\DefaultSiteContent.episerverdata %MusicFestival%\App_Data\ || Exit /B 1
XCOPY /y/i/k build\database\musicfestival.mdf %MusicFestival%\App_Data\ || Exit /B 1
XCOPY /y/i/k build\database\GeoLiteCity.dat %MusicFestival%\App_Data\ || Exit /B 1
XCOPY /y/i build\automation\ProvisionDatabase_MVC.cs %MusicFestival%\App_Code\ || Exit /B 1

EXIT /B %ERRORLEVEL%
