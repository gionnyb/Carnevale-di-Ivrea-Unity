Carnevale-di-Ivrea-Unity
========================

Dependency project for [Carnevale di Ivrea](https://github.com/pasqLisena/Carnevale-di-Ivrea)

## Unity export

Tutorial for Unity

* <code>File > Build Settings
* Choose both scenes
* Choose Android
* Do not select anything and click <code>Build</code>
* Build anywhere

## Import as Git Repo

Tutorial for Eclipse Juno with eGit (Win 7).

* Open the Git Perspective (<code>Window > Open Perspective > Other > Git</code>)
* In "Git Repository" view, click on the "Clone" button (the one with the blue arrow)
* Set as URI, [this page URI](https://github.com/gionnyb/Carnevale-di-Ivrea-Unity/)
* Follow the wizard until the end
* Go back to Java Perspective (<code>Window > Open Perspective > Other > Java</code>)
* <code>File > New > Other > Android Project from Existing code</code>

## Install on the main application

Tutorial for Eclipse Juno with eGit (Win 7).

* Browse to <code>Carnevale-di-Ivrea-Unity</code> project folder and choose <code>Temp\StagingArea</code> folder
* Do <b>NOT</b> copy project on workspace, in order to preserve the link to Git Repo
* Click on Finish
* Set this new Project as Library and add it to the main project
* Copy the content of UnityPlayerNativeActivity\assets to CarnevaleDiIvrea\assets (it would be only the folder <code>bin</code>)
