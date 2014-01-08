using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneLogic : MonoBehaviour {
	
	[SerializeField]
	Goal goal;
	[SerializeField]
	LightSource source;
	[SerializeField]
	MouseSelect[] selectables;
	
	// Use this for initialization
	void Start () {
		selectables=GetComponentsInChildren<MouseSelect>();
		goal.OnConnected += this.OnConnected;
		source.OnTransportEnd  +=this.OnTransported;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnConnected(){
		if(source!=null){
			source.Selecttion.rotateable=false;
			source.Selecttion.dragable=false;
			source.Selecttion.Enabled=false;
			Vector2 end=new Vector2(goal.transform.position.x,goal.transform.position.y);
			source.StartTransport(end);
			foreach(MouseSelect s in selectables)
				s.Enabled=false;
			Hashtable args = new Hashtable();
			args.Add("time",0.85f);
			args.Add("from",1f);
			args.Add("to",0f);
			args.Add ("onupdate","updateAlpha");
			args.Add("onupdatetarget",gameObject);
			args.Add("easeType", iTween.EaseType.easeInOutExpo);
			iTween.ValueTo(gameObject,args);
			
		}
	}
	
	void updateAlpha(float a){
		foreach(MouseSelect s in selectables){
			Color c=s.gameObject.GetComponent<SpriteRenderer>().color;
			c.a=a;
			s.gameObject.GetComponent<SpriteRenderer>().color=c;
		}
	}
	
	void OnTransported(){
		Camera c = Camera.main;
		Hashtable args = new Hashtable();
		args.Add("speed",6.4f);
		args.Add("position",
		         new Vector3(source.transform.position.x,
		            source.transform.position.y,
		            c.transform.position.z));
		args.Add ("oncompletetarget",gameObject);
		args.Add ("oncomplete","cameraZoom");
		args.Add("easeType", iTween.EaseType.easeInOutQuint);
		iTween.MoveTo(c.gameObject,args);
	}
	
	void cameraZoom(){
		Camera c = Camera.main;
		Hashtable args = new Hashtable();
		args.Add("time",0.45f);
		args.Add("from",7f);
		args.Add("to",2.5f);
		args.Add ("onupdate","cameraZoomUpdate");
		args.Add("onupdatetarget",gameObject);
		args.Add("easeType", iTween.EaseType.easeInOutExpo);
		args.Add ("oncomplete","onLevelFinish");
		args.Add ("oncompletetarget",gameObject);
		iTween.ValueTo(c.gameObject,args);
	}
	
	void onLevelFinish(){
		LevelFinish c = (LevelFinish)gameObject.GetComponent("LevelFinish");
		c.OnLevelFinish();
	}
	
	void cameraZoomUpdate(float z){
		Camera c = Camera.main;
		c.orthographicSize = z;
	}
}
