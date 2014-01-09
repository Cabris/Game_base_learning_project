#pragma strict

static var levelname : int;

function Start () {
}

function Update () {
}

function OnGUI ()
{
	if(GUI.Button(Rect(300, Screen.height/2, 200, 100), "Retry"))
		Application.LoadLevel(levelname);
	if(GUI.Button(Rect(600, Screen.height/2, 200, 100), "Level Map"))
		Application.LoadLevel ("LevelMap");
	if(GUI.Button(Rect(900, Screen.height/2, 200, 100), "Menu"))
		Application.LoadLevel ("MainMenu");
}