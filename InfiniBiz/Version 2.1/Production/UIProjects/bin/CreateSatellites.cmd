echo off
call corvars
cd Resources\

rem Generating satellite assemblies for ar
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\ar"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\ar\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:ar /embed:InfiniBiz_RES.ar.resources

rem Generating satellite assemblies for de
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\de"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\de\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:de /embed:InfiniBiz_RES.de.resources

rem Generating satellite assemblies for en
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\en"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\en\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:en /embed:InfiniBiz_RES.en.resources

rem Generating satellite assemblies for fr
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\fr"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\fr\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:fr /embed:InfiniBiz_RES.fr.resources

rem Generating satellite assemblies for it
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\it"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\it\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:it /embed:InfiniBiz_RES.it.resources

rem Generating satellite assemblies for ru
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\ru"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\ru\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:ru /embed:InfiniBiz_RES.ru.resources

rem Generating satellite assemblies for zh-ch
mkdir "C:\Documents and Settings\Administrator\My Documents\New Folder\zh-ch"
al /t:lib /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\zh-ch\InfiniBiz_RES.resources.dll" /v:1.0.0.0 /culture:zh-ch /embed:InfiniBiz_RES.zh-ch.resources

rem Generating satellite assemblies for the neutral language resource
al /out:"C:\Documents and Settings\Administrator\My Documents\New Folder\\InfiniBiz_RES.dll" /v:1.0.0.0 /embed:InfiniBiz_RES.resources,InfiniBiz_RES.resources
