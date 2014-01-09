#pragma strict

var timer:int;
var count:int;
var gameover : boolean = false;

function Start () {
	count = 10;
}
function Update () 
{
	Debug.Log(Application.loadedLevel);
	var temp = GameObject.Find("Timer");
	timer = Mathf.Floor(Time.timeSinceLevelLoad);
	if(timer<=10)
	{
		//	var temp = GameObject.Find("Timer");
		count=10-timer;
		//temp.guiText.text = count.ToString();
	}
	temp.guiText.text = count.ToString();
	if(count == 0)
		gameover = true;
	else if(count <= 5)
		temp.guiText.color = Color.red;
}

function OnGUI ()
{
	if(gameover)
	{
		list.levelname = Application.loadedLevel;
		Application.LoadLevel ("Gameover");
	}
}