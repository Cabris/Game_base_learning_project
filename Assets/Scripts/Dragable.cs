using UnityEngine;
using System.Collections;

public class Dragable : MonoBehaviour
{
	Vector3 screenPoint, offset, scanPos;
	// Use this for initialization
	void Start ()
	{
		Enabled=true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		scanPos = transform.position;
	}
	
	void OnMouseDown ()
	{
		screenPoint = Camera.main.WorldToScreenPoint (scanPos);
		offset = scanPos - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag ()
	{
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		if(Enabled)
			transform.position = curPosition;
	}
	
	public bool Enabled{get;set;}
	
}
