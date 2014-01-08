using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		Vector3 v=new Vector3();
		float max=12f;
		float min=4.8f;
		v.x=Random.Range(min,max)*getpn();
		v.y=Random.Range(min,max)*getpn();
		rigidbody.velocity=v;
	}
	
	int getpn(){
		float v=Random.Range(-1,1);
		if(v>0)
			return 1;
		if(v<0)
			return -1;
		return 1;
	}
	
	
}
