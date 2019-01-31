  # NRO2NSP
<p align="center">
    <b> This is an easy to use nsp builder that will make rediction nsps or Retroarch Forwarders out of Nros</b><br>
</p>
<p align="center"> 
<img src="https://github.com/Root-MtX/Nro2Nsp/blob/master/Images/mainScreen.png">
</p>

## Whats New:

### Beta Release:
[v3.3.2 Beta 1:](https://github.com/Root-MtX/Nro2Nsp/tree/master/Releases/Betas)
- Added application update notifcations with downloading (beta/stable setting - beta is enabled by default)
- Fixed Icon loss of quality even if conversion isnt required (.jpg/.jpeg 256x256 doesnt need conversion)
- Can import .nro data from Icon box now (either icon only or icon and all meta)
- Added changelog option with update notification
- Added Logo Menu in settings (rec sizes logo:160x40 Animation:256x80)
- Added version checks
- Various loggger additions
- Added Logos to Logo folder (Credits: JAS, jnackmclain, Jafece)


Please Note this is beta and it may experiance bugs/issues, please report them so I can clean them up before Stable releases

### Stable Release:
v3.3.1
- Removed Popup for Select User Account
- Stability Improvements

v3.3.0
- Fixed lockup when selecting (+) on forwarder nro when loaded in the background
- Devkitpro no longer needed (Thanks Natinusala)
- Retroarch rom forwarders now supported (Thanks Natinusala)
- Tweaks to NACP and NPDM building
- Added core database (./Resources/cores.xml)
- Added rom path database (./Resources/paths.xml)
- Fixed directory cleaning
- Fixed special characters displaying as (?) -- Limtied to Switch's Character Library
- Fixed crash if icon was set and then an icon was loaded from a .nro
- Will only clear the icon if build is successful
- Fixed rolling id would count when build failed
- Custom error handling, no more crashes for incorrect paths (Nothing fancy but you shouldnt normally see this)

<p align="center"> 
<img src="https://github.com/Root-MtX/Nro2Nsp/blob/master/Images/errorOutput.jpg">
</p>


## Requirements: 
- Keys.dat file added to the "Resources" folder -- refer to "keys.dat template for layout and required keys
- [.NetFramework](https://www.microsoft.com/en-ca/download/details.aspx?id=49981) - For Windows
- [Mono](https://www.mono-project.com/) - for Mac or Linux 

## Special notes:
- If you're getting an error "234C02" when installing, then your cfw patches are wrong/missing.
- To load Meta information from .nro automatically, load the .nro by clicking "romfs" and choose yes.
  This will automatically load all the information from the .nro. If you want to use sdmc then select "sdmc" after and use as normal -- may incorperate import button instead if requested
- Some nros are not working with romfs (old tinfoil, dOPUS) use sdmc for those for now
- Title ids now follow (05xxxxxxxxxx0000)
- Mac and linux may experiance bugs or weird issues due to mono 
  (First launch may take a while to load, be paitent / ui looks less pleasing as well)
- Big changes have been made in the code, bugs maybe be present. If found please report them.

## How to run:
### Windows 
- Run Nro2Nsp.exe

### Mac/Linux 
- Open terminal.app
- cd to folder location

ex:
```
cd Desktop/Nro2Nsp
```
- Then type
```
sudo mono --arch=32 ./Nro2Nsp.exe 
```
- Linux users report that --arch=32 is not supported and not needed
## Use:
## Standard Nro Forwarder

- Add you nsp details 

ex: 
```
     AppName:  TestApp
     Title Id: 05000F2300000000 *Must be 16 Characters long in hex form and start with 05*    
     Made by:  MtX         	
     Version:  1.0.0
```
- Import your icon by clicking the icon box 
- You have two choices for paths

  sdmc: For loading an nro from an sd path *Nsp does not contain the nro, it only points to it*

ex: 
```
sdmc: /switch/tinfoil/tinfoil.nro    
```
  *Please note that paths must be exact (case sensitive) and will throw a system error if theres no mathing .nro*
 
  romfs: For building nro internally of thr nsp, pick your nro and it should do the rest 
  *Does not need tinfoil on the sd card*
ex: 
```
romfs: /tinfoil.nro 
```

## Retroarch Rom Forwarder 

- Add you nsp details 
ex: 
```
     AppName:  Super Mario World
     Title Id: 05000F2300000000 *Must be 16 Characters long in hex form and start with 05    
     Made by:  Retroarch          	
     Version:  1.0.0
 ```

- Core Path: Path to the core to load for the rom
ex:
```
sdmc:  /retroarch/cores/snes9x_libretro_libnx.nro
```
- Rom Path: Path to the Rom to load  
ex: 
```
sdmc:  /Roms/Snes/Super Mario World.smc
```
- Click the compile Button
- Wait for compiling to finsh
- Your .Nsp should be good to go!


## XML Editing:
<p align="center"> 
<img src="https://github.com/Root-MtX/Nro2Nsp/blob/master/Images/coreList.png">
</p>

### Cores.xml - Preset core list for retorarch with paths
- layout ex: 
```
<details>
 <core>
  <name>Nintendo - Quicknes</name> 
   <path>/retroarch/cores/quicknes_libretro_libnx.nro</path>
   <show>true</show>
 </core>
<core> 
  <name>Super Nintendo - Snex9x</name> 
  <path>/retroarch/cores/snes9x_libretro_libnx.nro</path> 
  <show>true</show>
 </core>
</details>
```
- name: Name of core
- path: Path to the core
- show: If set to anything but true it will be hidden

### paths.xml - Preset rom path for where system roms are located
- layout ex: 
```
<details>
 <system>
  <name>Nintendo 64</name> 
  <path>/roms/N64/</path>
  <show>true</show>
 </system>
 <system>
   <name>Nintendo 64</name> 
   <path>/roms/N64/</path>
   <show>true</show>
 </system>
</details>
```
- name: Name of the System
- path: Path to the rom directory per system
- show: If set to anything but true it will be hidden

## Settings:
- Preset Author: Set the default Author, to speed things up if using the same one
- Rolling Title Id: Set the base Title Id and after each build it'll increase by 1
- Perserve Data: Saves exefs, contol, and nca data in ./RawData folder
- Old Style Title Id: Use old style title key format "05XXXXXXXXXXXXXX"

## Credits: 	
- "Natinusala" for differnt approach of hbl to work with Retroarch/forwarders
- "Switchbrew" for the hblauncher source https://github.com/switchbrew/nx-hbloader
- "The-4n" for Hacbrewpack   https://github.com/The-4n/hacBrewPack
- "alexzzz9" for the hblauncher source and providing useful help
- "jakcron" for Nstool for extracting nro info https://github.com/jakcron/NNTools
- The Whole WarezNx Discord for all the tools/information to make all of this possible

## Todo:
- fix file permissions for linux/mac to remove sudo command
- better intergration for Mac
- change the ui (may require some help)
- fix certain .nros not working with romfs
