  # NRO2NSP
<p align="center">
    <b> This is an easy to use nsp builder that will make rediction nsps or Retroarch Forwarders out of Nros</b><br>
</p>
<p align="center"> 
<img src="https://github.com/Root-MtX/Nro2Nsp/blob/master/Images/themedMenu.JPG?raw=true" width="500" height="600">
</p>

## Whats New:

### Releases:
[3.3.6 Beta 1](https://github.com/Root-MtX/Nro2Nsp/raw/master/Releases/Betas/Nro2Nsp%203.3.6%20-%20Beta%201.zip)
- export forwarders as "Nros" - Rom Forwarders that can be launched from the HBMenu instead of the Homescreen (Note youll need to use Title Overide for titles that require more ram)
- Added Setting to allow offical TitleId range, Use with caution to avoid conflicting ids (Allows Hid-mitm)

[v3.3.5 Stable](https://github.com/Root-MtX/Nro2Nsp/releases/tag/3.3.5)
Things added since Beta:
- Recompiled for 9.0.0 (note nros forwarded to must be recompiled for 9.0.0 as well)

Things added in Betas:
Special thanks to Liam and LeMageFro for testing and vast knowleadge
- Added warning about romfs compatibility
- Fixed "Keyfile" missing error
- Fixed Nro data import repeating error messages
- Updated hacpackbrew
- Updated Nstool (requires visual studio C++ 2015)
- Appears to have fixed could not start software error
- Removed savedata allocation
- Added gif size warning message if greater than 60kb
- Added UnquailifiedApproval flag in ndpm (Thanks Liam)
- Fixed KernalPermisson
- Fixed rror due to file permissions
- Adjusted npdm to prevent save data allocation
- Started custom npdm/nacp creation framework (to be completed)
- Refractoring

v3.3.4 Stable
- Changed icon conversion again with option to disable conversion, should fix ? icons
- Changed working directory/folder permissions
- Added Message for settings import is using for the first time
- Revamped dialog boxes
- Added psp core and rom paths
- Improved logger for troubleshooting
- Fixed error with spaced in path

v3.3.3
- Fixed "no logo" enable checkbox stuck enabled
- Removed settings locations and replaced with export/import settings
- Fixed crash when using application defaults 
- Changed image conversion to prvent quailty loss on non jpeg images and non 256x256 images
- Added image color checks to prevent "?" icon
- Added Custom Message Box with theme support
- Updated icon database

v3.3.2 Stable
- Added "Custom Keys Path" to load keys from your own path
- Fixed keys file missing error from Resources folder
- (Keys.dat, Keys.txt, and prod.keys) now all supported
- Added Help icons on main page and settings page for help with use/settings
- Added "Key Generation" setting in Settings menu
- Added LinkLabel theming
- Fixed "Settings.xml" loading error
- Added "Icon Database" LinkLabel to community collection link
- Removed "Old Style Title Id" From setings
- Updated Keys Template file
- Plus the addtion of the following beta features

Beta 4:
- Added basic theming 
- Added settings.xml that will export saved settings so saved values will not need to be changed each update
- Settings will be saved to /user/appdata/roaming/Nro2Nsp/settings.xml if it fails to write there then 
  it will be saved at ./Resources/setting.xml
- Settings will load from /user/appdata/roaming/Nro2Nsp/settings.xml or ./Resources/setting.xml 
  (./Resources/ takes priority)
- Added export settings link in settings menu
- Fixed default rom paths.xml to follow Retroarch Ultimate Pack (Credits: jnackmclain)
- Even more Logos (Credits: JAS, jnackmclain, Jafece)
- Added [] around title id for use with nut gui
- keys.dat can be loaded from ./Resources/ folder or Drive:/Users/user/AppData/Roaming/Nro2Nsp/
  (./Resources/ takes priority)
Beta 3:
- Fixed Hbmenu Forwarder would crash when exiting a loaded nro
- Fixed Logs deleting/missing build information 
- Added more logos in logo folder (Credits: jnackmclain)
Beta 2:
- Fixed Logo error when build failed and another build was attempted
- Minor stabilty tweaks 
- Changed "set logos as default" to a check box instead of a diaglog box
- "No logo" option now sets icons to black in logo menu 
- Code clean up
- Small changes to update notifications
Beta 1 :
- Added application update notifcations with downloading (beta/stable setting - beta is enabled by default)
- Fixed Icon loss of quality even if conversion isnt required (.jpg/.jpeg 256x256 doesnt need conversion)
- Can import .nro data from Icon box now (either icon only or icon and all meta)
- Added changelog option with update notification
- Added Logo Menu in settings (rec sizes logo:160x40 Animation:256x80)
- Added version checks
- Various loggger additions
- Added Logos to Logo folder (Credits: JAS, jnackmclain, Jafece)

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

### Beta Releases:
[Beta](https://github.com/Root-MtX/Nro2Nsp/tree/master/Releases/Betas)
Please Note this is beta and it may experiance bugs/issues, please report them so I can clean them up before Stable releases

# Getting Started
## Requirements: 
There is a couple small requirements to use this application, see [here](https://github.com/Root-MtX/Nro2Nsp/wiki/Requirements) to get it all setup!

## Special notes:
There's a couple of special things to note , see [here](https://github.com/Root-MtX/Nro2Nsp/wiki/Special-Notes) to learn more!

## How to run:
Lets get down to the good stuff, i feel like its really easy but lets explain some things in [here](https://github.com/Root-MtX/Nro2Nsp/wiki/Use)!

## Troubleshooting:
If for some reason you run into any issues, please check [here](https://github.com/Root-MtX/Nro2Nsp/wiki/Troubleshooting) for common mistakes

## XML Editing:
In the Resources folder there is a couple .xml files.The main ones for the end users are cores.xml and paths.xml. Check [this](https://github.com/Root-MtX/Nro2Nsp/wiki/Xml-Editing) out for information on editing these to your needs.

## Settings:
Check [this](https://github.com/Root-MtX/Nro2Nsp/wiki/Settings) out for information about configurable settings!

## Credits: 
Big shout out to [these](https://github.com/Root-MtX/Nro2Nsp/wiki/Credits) special people for all the help and support! 	

## Todo:
See whats in store for features or things that need to be improved [here](https://github.com/Root-MtX/Nro2Nsp/wiki/Todo)

## Discord: 
Visit me on [Discord](https://discord.gg/yTSfphh) for the newest features and fastest support!

