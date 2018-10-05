# Nro2Nsp
This is a very early project and is actually my first attempt at c# 
code is messy right now but seems to work well... hopefully

Requirements: 
-------------
- Devkitpro for Compiling libnx https://switchbrew.org/wiki/Setting_up_Development_Environment
- Keys.dat file added to the "Resources" folder -- refer to "keys.dat template for layout and required keys
- Windows OS

Special notes:
--------------
* Authoring tools no longer needed thanks to "The-4n" https://github.com/The-4n/hacBrewPack *
* Icons now need to be 256x256 .jpg *
* Compile button will only be visable once all requirements are met - Change app name, Change Author, Change title   id, Add icon, Pick Sdmc with path or Pick romfs with a valid .nro *
* If you dont properly fill out the meta info before importing icon and filling out the romfs/sdmc section then the   compile button may not enable. Fix you meta info and either reload the icon or reset your romfs/sdmc info.*

Use:
----
- Run Nro2Nsp.exe
- Add you nsp details 

     ex: 
     AppName:  TestApp
     Title Id: 01000F2300000000 *Must be 16 Characters long in hex form*    
     Made by:  Matt_Teix          	
     Version:  1.0.0

- Import your icon by clicking the Icon box *Must be 256 x 256 .jpg*
- You have two choices for paths

  sdmc: For loading an nro from an sd path *Nsp does not contain the nro, it only points to it*
  ex: 
  sdmc: /switch/tinfoil/tinfoil.nro      
  *Please note that paths must be exact (case sensitive) and will throw a system error if theres no mathing .nro*
 
  romfs: For building nro internally of thr nsp, pick your nro and it should do the rest 
  *Does not need tinfoil on the sd card*
  ex: 
  romfs: /tinfoil.nro 

- Click the compile Button
- Wait for compiling to finsh
- Your .Nsp should be good to go!


Credits: 
--------
         "Switchbrew" for the hblauncher source https://github.com/switchbrew/nx-hbloader
	 "The-4n" for Hacbrewpack   https://github.com/The-4n/hacBrewPack
	 "MegatonHammer" for Linkle https://github.com/MegatonHammer/linkle
	 "alexzzz9" for the hblauncher source and providing useful help
	 The Whole WarezNx Discord for all the tools/information to make all of this possible

Todo:
-----
- Learn more c# coding
- Clean up code -started-
- Make App look nicer -started-
- Add exception handling -started-
- osx and linux support 
Change log:
-----------

V3.0.1
- fixed bug with speacial characters in app name
- added logo folder in "Resources" folder, insert your own if you like
- added some exception comments for common user errors
- added keys.dat-template.txt for layout and keys required

v3.0.0
- removed need for Nintendo Sdk tools, now legal
- cleaned up code
- added more file checks
- added title key to nsp name for better keeping track of used title keys
- restricted title id to hex values only
- added more catch exceptions to prevent crashes
- cleaned up readme

v2.0.1
- turns out im not good at visual aspects so undid most of my visual aspects
- removed import icon, just click the icon to change now
- added file check for authtool, metatool, and devkitpro. no longer crashes if missing.

V2.0.0
- face lift to make it look a little nicer
- more code cleanup
- deletes temp files on exit now

v1.0.6
- major code cleanup, better function calling
- auto reload app after build in case you want to build another nsp
- fixed bug with folder builing order

v1.0.5
-Restricted Title id input to 16 characters

v1.0.4
- added builing .nsp
- added auto import .nro (for romfs)

v1.0.3
- added meta creation
- added pathing of npdm
- added icon import and size check

v1.0.2 
- fixed crash when lauching from paths with spaces
- implemented resources