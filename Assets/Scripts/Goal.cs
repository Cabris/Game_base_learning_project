using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public LightSource source;
	public float waitTime;
	public float count;
	bool isConnect;
	// Use this for initialization
	void Start () {
		isConnect=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isConnect){
			count+=Time.deltaTime;
			if(count>=waitTime){
				OnConnected();
			}
		}
		else{
			count=0;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.collider.tag=="LightSourceTrigger")
			isConnect = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		isConnect = false;
	}
	
	void OnConnected(){
		
		
	}
	
	
}
