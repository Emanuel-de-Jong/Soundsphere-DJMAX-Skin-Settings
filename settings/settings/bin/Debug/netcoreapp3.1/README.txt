        ╔════════════════════════════════╗
        ║ ┏━━━┓   ┏┓ ┏━┓┏━┓ ┏━━━┓ ┏━┓┏━┓ ║
        ║ ┗┓┏┓┃   ┃┃ ┃ ┗┛ ┃ ┃┏━┓┃ ┗┓┗┛┏┛ ║
        ║  ┃┃┃┃   ┃┃ ┃┏┓┏┓┃ ┃┃ ┃┃  ┗┓┏┛  ║
        ║  ┃┃┃┃ ┏┓┃┃ ┃┃┃┃┃┃ ┃┗━┛┃  ┏┛┗┓  ║
        ║ ┏┛┗┛┃ ┃┗┛┃ ┃┃┃┃┃┃ ┃┏━┓┃ ┏┛┏┓┗┓ ║
        ║ ┗━━━┛ ┗━━┛ ┗┛┗┛┗┛ ┗┛ ┗┛ ┗━┛┗━┛ ║
        ╚════════════════════════════════╝ V1.0
Created by NotAFluentSpeaker#4166 and KillBottt#1368



I. Introduction
Welcome!
This is a skin made for the VSRG, soundsphere (github.com/semyon422/soundsphere).
It is inspired by the PORTABLE 1 gear CLASSIC note skin from DJMAX Respect V.
In this readme, we will be explaining how to use it.
Supported keymodes are: 4k, 5k, 6k, 8k, 10k, 10kfade*.
8k looks like 6k with 2 multi column fxes. The same goes for 10k but with 4 fxes.
Each of these modes also has a 2 side track mode which adds 2 more buttons
representing the side tracks in djmax.

fade*:
The fx buttons in this skin are faded so that you can see 
both of them when they overlap.



II. Setting the skin up
1. Put this folder in soundsphere\userdata\skins.

(optional but recommended)2. Go to DJMAX\settings\customscores and 
choose a custom score* of your liking. "with early and late" means 
that it will show MIN if you hit too early.
DJMAX does not have this feature, so it is not the default.
Now overwrite CustomScore.lua in soundsphere\sphere\screen\gameplay 
with your chosen custom score. Make sure you rename it to CustomScore.lua.

(optional)3. Overwrite soundsphere\sphere\screen\result\JudgeTable.lua* 
with DJMAX\settings\JudgeTable.lua
Do the same for soundsphere\userdata\interface\result.json 
with DJMAX\settings\result.json*

4. Start up soundsphere and select one of the keymodes this skin supports.

custom score*:
The grade you see after hitting a note.
In DJMAX this is displayed as MAX100% - MAX1% but you may also know it as
Great - Bad.

judge table and result*:
Styles the result screen and sets the grades you can get (e.g. A+).



III. Customizing the skin
The settings.exe in the folder gives you the option to turn certain visuals 
on or off. You might have to install .NET Core before being able to use it.
.NET Core is a very popular framework from micorsoft that you will likely
need in the near future anyways.

You can also change the images used by the skin by overwriting them with your own images.

Most files can be moved around and put into different sub folders as long as
they are not outside the DJMAX folder.
Exceptions for this are: settings.exe, log.txt and metadata.json.
After restructuring the files, you will need to press Apply in the settings.exe.

The name of the folder represents the name of the skin.
If you change the folder name, it should change the name of the skin inside soundsphere.
You have to press Apply in the settings.exe here as well.



IV. troubleshooting
Most often, the problem has one of the following causes:
- A file is missing or named incorrectly (including json files)
- You haven't used settings.exe after changing a name or the
position of a file.

If you are still having problems, you can contact us via discord.



V. End note
You should know enough to start using the skin now.
If you find any bugs or or have questions about the skin, 
you can contact us via discord.
Thank you for using our skin and have a good time playing!