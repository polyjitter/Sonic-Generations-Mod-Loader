# Sonic Generations Mod Loader
A mod loader for Sonic Generations on the PC! This is a modification of [SLW Mod Loader](https://github.com/Radfordhound/SLW-Mod-Loader).

Please note that once SLW Mod Loader has functionality for Sonic Generations, this repo will disappear forever!

##How do I use this?
After [downloading the latest binary](https://github.com/GoldtexTwitch/Sonic-Generations-Mod-Loader/releases/latest), simply make a "mods" folder within your Sonic Generations installation directory, then place a bunch of folders inside said mods directory (one for each mod) each containing all the modified files you'd like the game to load. Then, just fire up the mod loader (SLWModLoader.exe), check the checkbox(es) next to the mods you'd like to use in-game, and click "Play!"

###Mod installation tutorial by "Mac" (made for 1.4 but still applies to later revisions):

[![Mod installation tutorial](http://img.youtube.com/vi/u-5uCVJ8Ci0/0.jpg)](https://www.youtube.com/watch?v=u-5uCVJ8Ci0 "Mod installation tutorial")

##How do I release mods for this?
**The following section is for mod developers only. If all you want to do is play with some mods made by others, simply follow the above steps.**

Mods designed for the mod loader come in the form of folders that contain the following:

- A "mod.ini" file (a file which describes your mod, as well as all it's various details).
- A "disk" folder
  - A "bb/bb2/bb3" folder
    - All your modified files/folders from the root of Sonic Generations' .cpk files on in their raw form (typically .ar.00 files).

So long as the structure of your mod remains in this way, virtually any file in the game can be modified and released as part of your mod.

As an example, the totally not original character "Marie Themed Sonic" mod has a file/folder structure that goes like so:

- A "mod.ini" file
- A "disk" folder
  - A "bb3" folder
    - Sonic.ar.00
    - Sonic.ar.01
    - Sonic.arl

Wereas the "MLG Speedrun Zone 1" mod (which modifies certain files not on the root of the .cpk) has a file/folder structure that goes like so:

- A "mod.ini" file
- A "disk" folder
  - A "bb" folder
    - A "Packed" folder
      - w1a01_obj_00.orc
      - w1a01_obj_01.orc
      - w1a01_obj_02.orc
      - w1a01_obj_03.orc


###The mod.ini file
The mod.ini file is a mod configuration file that details all the user-friendly information about your mod, as well as how CPKREDIR should load the mod.

The version of the format used in Sonic Generations Mod Loader is a variation on the format used in SonicGMI, with some minor changes/additions here and there.

Here's an example of a mod.ini file:
```
[Main]
IncludeDir0="."
IncludeDirCount=1
SaveFile="Saves\sonic.sav"
UpdateServer="http://unleashed.l0nk.org/update_server_unleashed_project/"

[Desc]
Title="Unleashed Project"
Description="Total Conversion Mod that ports most of Sonic Unleashed's day levels from the Xbox 360 version into Generations PC. Starting a New Game with Save File Redirection enabled is recommended."
Version="1.0"
Date="03/18/2013"
Author="Team Unleashed"
AuthorURL="https://www.youtube.com/channel/UCkTKDJx4zCUcYVjjWh3gC7g"
URL="http://www.moddb.com/mods/sonic-generations-unleashed-project"

[CPKs]
disk\bb.cpk="bb.ini"
disk\bb2.cpk="bb2.ini"
disk\bb3.cpk="bb3.ini"
```

The following is a list of the most important values that can be used in a mod.INI file:

###Main

**IncludeDir0-??** Specifies which folders will be included with your mod, allowing you to modify the default file/folder structure mentioned above.

**IncludeDirCount** Specifies how many folders will be included with your mod.

**UpdateServer** A modification of the existing SonicGMI value that specifies the link to a raw .txt file containing URLs in a particular format. This feature has **not yet been added**, and will be further detailed once it is. However, I recommend linking a .txt file just in case anyway, as it will allow you to release auto-downloading updates to your mods once the mod loader has been updated to support this feature.

**SaveFile** Tells the mod loader that there's a save file that came with the mod itself and that it should load that save instead.

###Desc

**Title** The name of your mod as shown in the mod loader.

**Description** A description of your mod that is shown when your mod is highlighted in the mod loader.
Typing a "\n" in this value will indicate a new line within the mod loader, **which should be done to keep your mods loadable!**

**Date** The date the mod was originally created as shown in the mod loader.

**Author** The author(s) of the mod. **You can include multiple authors in this value!** Simply seperate the authors via a space, followed by an ampersand, and another space. (Like this: "Radfordhound & Gotta Play Fast") They will be loaded as seperate authors within the mod loader, allowing you to link to them seperately.

**AuthorURL** The URL(s) to the author(s) of the mod. (Such as websites, YouTube channels, and social media accounts.) **You can include multiple authors in this value!** Simply seperate the authors' URLs via a space, followed by an ampersand, and another space. (Like this: "https://www.youtube.com/user/Radfordhound & https://www.youtube.com/channel/UCZfOGBkXRKICFozWU5bE0Xg") They will be loaded as seperate URLs within the mod loader and automatically linked with the data contained in the "Author" value, allowing you to link to them seperately.

**URL** The URL of the mod (aka mod homepages/threads/release videos).


There are many other values that can be used in a mod.ini file, many of which are already being used in several mods. So keep an eye out for em' in other released mods! :)
