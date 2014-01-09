#pragma strict

var SceneLogicFSM : PlayMakerFSM;
SceneLogicFSM = gameObject.Find("WinAni").GetComponent.<PlayMakerFSM>(); //尋找SceneLogic上的PlayMaker

function Start () {

}

function Update () {

}

function OnLevelFinish(){
	//print("you win!!");
	SceneLogicFSM.Fsm.Event("Win");
}

function OnTransportedAndStopTimer()
{
	SceneLogicFSM.Fsm.Event("Send Stop Message");
}

function OnConnectedPlayLaserSound()
{
	SceneLogicFSM.Fsm.Event("Send Play Laser Sound Message");
}