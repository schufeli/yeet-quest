# Yeet Quest

## To Run API:
got to Visual Studio and `Press F5`

## To Run APP:
### First install:
`cd app`

`npm install`

`ionic serve -d`

should be available on http://localhost:8100/home

### Second Run (after install):
`cd app`

`ionic serve -d`

should be available on http://localhost:8100/home


## Wichtige commands

Run `npm install --save @capacitor/core @capacitor/cli;`

### Run to Build to Device:
Run `npx cap init; ionic build; npx cap add android; npx cap open android`

### Run to Update to Device:
Run `ionic build; npx cap copy; npx cap open android`

# Create App with Device
## Installieren
Run ` npm install --save @capacitor/core @capacitor/cli`
Run ` npx cap init`

## Projekt kompillieren
Run ` ionic build`

## Plattform hinzufügen
Run ` npx cap add ios`
### oder
Run ` npx cap add android`

## App öffnen
Run ` npx cap open ios`
### oder
Run `npx cap open android`

## App aktualisieren
Run `ionic build; npx cap copy`

## Icon generieren
Run `npm install -g cordova-res`
>Generate Asset Bundle for IOS and Android

Run `cordova-res`

>Structure should be like 

```
resources/
├── android
|   ├── icon-background.png
|   └── icon-foreground.png
├── icon.png
└── splash.png
config.xml
```
* `resources/icon.(png|jpg)` must be at least 1024×1024px
* `resources/splash.(png|jpg)` must be at least 2732×2732px

Add generated images to native project

Run ```cordova-res android --skip-config --copy or cordova-res ios --skip-config```
