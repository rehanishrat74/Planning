echo off
call corvars
cd Resources\

rem Generating satellite assemblies for de
mkdir "D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\de"
al /t:lib /out:"D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\de\mine.resources.dll" /v:1.0.0.0 /culture:de /embed:mine.de.resources

rem Generating satellite assemblies for en
mkdir "D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\en"
al /t:lib /out:"D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\en\mine.resources.dll" /v:1.0.0.0 /culture:en /embed:mine.en.resources

rem Generating satellite assemblies for es-es
mkdir "D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\es-es"
al /t:lib /out:"D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\es-es\mine.resources.dll" /v:1.0.0.0 /culture:es-es /embed:mine.es-es.resources

rem Generating satellite assemblies for fr
mkdir "D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\fr"
al /t:lib /out:"D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\fr\mine.resources.dll" /v:1.0.0.0 /culture:fr /embed:mine.fr.resources

rem Generating satellite assemblies for the neutral language resource
al /out:"D:\Web Application\AccountsCentre\Development\Version 1.0\Accounts Centre Multilingual\UI Projects\bin\Satelitte\\mine.dll" /v:1.0.0.0 /embed:mine.resources,mine.resources
