# Menu-System

Simple and extensible menu system.  
Made with Unity 2019.4.18f1  
Uses DOTween plugin.  

## How to add your own menu transition  

1. Create a script inheriting from **MenuBase**.  
2. Override **TurnOn** and **TurnOff** methods.  
3. Call **TurnOnComplete** and **TurnOffComplete** at the end of your methods and you're done!

## Included menus

### Simple menu
Menus that are simply being enabled/disabled

<img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/MenuSystem/MenuSimple.gif" height="256">

### Fade menu
Menus that are simply being faded in/out.  
Uses DOTween plugin for transitions.

<img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/MenuSystem/MenuFade.gif" height="256">
