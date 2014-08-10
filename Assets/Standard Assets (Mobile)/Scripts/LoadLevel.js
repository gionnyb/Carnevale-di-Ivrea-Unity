#pragma strict

var livel: String = "";
var Gui : GUIText;
private var percentage : float = 0;

function Start () {
	yield WaitForSeconds(5);
    DontDestroyOnLoad(this);
    print ("Loading...");
    
    yield LoadLevelWithProgress (livel);
    print ("Loading complete");
}
 
function LoadLevelWithProgress (levelToLoad : String) {
    var async = Application.LoadLevelAsync(levelToLoad);
    while (!async.isDone) {
    	percentage = Mathf.Round(async.progress*100);
    	Gui.guiText.text =  percentage + " % ";
        yield;
    }
}