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
			eulerAngles.x=0.7f;
		if(y)
			eulerAngles.y=0.4f;
		if(z)
			eulerAngles.z=1.025f;
		transform.Rotate(eulerAngles * Time.deltaTime*speed);
	}
}
