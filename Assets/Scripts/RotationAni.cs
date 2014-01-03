using UnityEngine;
using System.Collections;

public class RotationAni : MonoBehaviour {
	public bool x,y,z;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 eulerAngles=new Vector3();
		if(x)
			eulerAngles.x=1;
		if(y)
			eulerAngles.y=1;
		if(z)
			eulerAngles.z=1;
		transform.Rotate(eulerAngles * Time.deltaTime*speed);
	}
}
