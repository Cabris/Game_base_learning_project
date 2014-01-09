using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	public PlayMakerFSM fsm;
	public string _event="";
	// Use this for initialization
	void Start () {
		if(fsm==null)fsm=Camera.main.GetComponent<PlayMakerFSM>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick ()
	{
		fsm.SendEvent(_event);
	}
}
