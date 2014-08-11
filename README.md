Carnevale-di-Ivrea-Unity
========================

Dependency project for [Carnevale di Ivrea](https://github.com/pasqLisena/Carnevale-di-Ivrea)

## For Unity Dev

Set <code>Android Build</code> as Export folder for the android code. 

## Install on the main application

Tutorial for Eclipse Juno with eGit (Win 7).

* Open the Git Perspective (<code>Window > Open Perspective > Other > Git</code>)
* In "Git Repository" view, click on the "Clone" button (the one with the blue arrow)
* Set as URI, [this page URI](https://github.com/gionnyb/Carnevale-di-Ivrea-Unity/)
* Follow the wizard until the end
* Go back to Java Perspective (<code>Window > Open Perspective > Other > Java</code>)
* <code>File > New > Other > Android Project from Existing code</code>
* Browse to <code>Carnevale-di-Ivrea-Unity</code> project folder and choose <code>Android Build</code> folder
* Do <b>NOT</b> copy project on workspace, in order to preserve the link to Git Repo
* Click on Finish
* Set this new Project as Library and add it to the main project
