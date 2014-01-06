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
		Debug.Log("js binding test");
		testJs1 c = (testJs1)gameObject.GetComponent("testJs1");
		c.testPrint("test call",5);
		string[] strs=new string[]{"a","ss","swdwe","105w"};
		c.testPrint2(strs);
		Vector2[] vects=new Vector2[]{new Vector2(5,8),new Vector2(-5.5f,47),new Vector2(7.9f,-0.05f)};
		c.testPrint2(vects);
		Debug.Log("~js binding test");
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
