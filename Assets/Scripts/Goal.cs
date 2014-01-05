using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public LightSource source;
	public float waitTime;
	public float count;
	public bool isConnect;
	bool connected;
	// Use this for initialization
	void Start () {
		isConnect=false;
		connected=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!connected){
			if(isConnect){
				count+=Time.deltaTime;
				if(count>=waitTime){
					OnConnected();
					connected=true;
				}
			}
			else{
				count=0;
			}
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="LightSourceTrigger"){
			isConnect = true;
			source=other.gameObject.transform.parent.gameObject.GetComponent<LightSource>();
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		isConnect = false;
	}
	
	void OnConnected(){
		
		
	}
	
	
}
