#pragma strict

var SceneLogicFSM : PlayMakerFSM;
SceneLogicFSM = gameObject.Find("SceneLogic").GetComponent.<PlayMakerFSM>(); //尋找SceneLogic上的PlayMaker

function Start () {

}

function Update () {

}

function OnLevelFinish(){
	//print("you win!!");
	SceneLogicFSM.Fsm.Event("Win");
}