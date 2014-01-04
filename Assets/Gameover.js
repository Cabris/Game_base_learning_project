#pragma strict

function OnTriggerEnter (other : Collider) {
Debug.Log("123");
   /*if(other.tag==("lightSprite")){
   		Debug.Log("123");
	   	GUI.Box(Rect(5,Screen.height-Screen.height/4 , Screen.width-10,Screen.height/4),"npc : ｢･･････｣");
   }*/
}

var timer:int;
var count:int;

function Start () {
	count = 60;
}
function Update () 
{
	timer=Mathf.Floor(Time.time);
	if(timer<=60)
	{
		var temp = GameObject.Find("Timer");
		count=60-timer;
		temp.guiText.text = count.ToString();
	}
}