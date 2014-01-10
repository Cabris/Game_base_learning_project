using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {
	public GameObject source,goal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 p=new Vector2(goal.transform.position.x,goal.transform.position.y);
		source.GetComponent<LightSource>().forceLink=p;
	}
}
