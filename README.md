

Requirements: 
-------------
- Devkitpro for Compiling libnx https://switchbrew.org/wiki/Setting_up_Development_Environment
- Keys.dat file added to the "Resources" folder -- refer to "keys.dat template for layout and required keys
- .NetFramework for win https://www.microsoft.com/en-ca/download/details.aspx?id=49981
- Mono for Mac or Linux https://www.mono-project.com/

Special notes:
--------------
* Authoring tools no longer needed thanks to "The-4n" https://github.com/The-4n/hacBrewPack *
* Icons no longer need speical size or format*
* conrol.nacp now built in app, no more linkle
* Now uses winform, can use mono for mac/linux
* Mac and linux may experiance bugs or weird issues due to mono
* Big Chnage have been made in the code, Bugs maybe be present. If found please report them.
* Linux use hasnt been tested fully, may experiance issues

Use:
----
- Windows -- Run Nro2Nsp.exe
- Mac/Linux -- open terminal.app
            -- cd to folder ex: cd Desktop/Nro2Nsp
            -- run "sudo mono --arch=32 ./Nro2Nsp.exe

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
	 "alexzzz9" for the hblauncher source and providing useful help
	 The Whole WarezNx Discord for all the tools/information to make all of this possible

Todo:
-----
-- clean up new code
-- unknown at this time
Change log:
-----------

v3.2
-- Rewrote code for better structure
-- uses winforms now and compatable with mono for multiplatform support
-- rebuilt resources data into .dll library
-- Added more checks and error reports
-- Added log.txt in "Resources" for trobuleshooting
-- added building message (only functional on win)
-- removed linkle and added in app control.nacp building
-- Compile button always enabled now, message box will inform of missing information
-- Added image converting, any type/size should work
-- bug fixes
-- stability improvement ;)


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
