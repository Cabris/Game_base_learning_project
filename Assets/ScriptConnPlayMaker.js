#pragma strict

var TestFSM : PlayMakerFSM;
TestFSM = gameObject.Find("Main Camera").GetComponent.<PlayMakerFSM>(); //尋找Main Camera上的PlayMaker

function Start () {

}

function Update () {

}

function OnGUI ()
{
	if(GUI.Button (Rect(295, 145,75,40),"Test"))
	{
		TestFSM.Fsm.Event("Start an Event"); //執行Main Camera上的PlayMaker之Start an Event事件
	}
}