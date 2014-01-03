using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LightSprite : MonoBehaviour
{
	LineRenderer _lineRenderer;
	List<LineRenderer> lines = new List<LineRenderer> ();
	public int _count=0;
	// Use this for initialization
	void Start ()
	{
		_lineRenderer = GetComponentInChildren<LineRenderer> ();
		initializeVertex (20);
	}

	public void UpdateVertexs ()
	{
		for (int i = 0; i < lines.Count; i++) {
			if (i < _count-1)
				lines [i].SetVertexCount (2);
			else
				lines [i].SetVertexCount (0);
		}
	}

	public void BeforeUpdateVertexs ()
	{
		for (int i = 0; i < lines.Count; i++) {
				lines [i].SetVertexCount (2);
		}
	}

	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void initializeVertex (int count)
	{
		this._count=count;
		ClearLine ();
		for (int i = 0; i < count; i++) {
			GameObject go = Instantiate (_lineRenderer.gameObject) as GameObject;
			go.transform.parent = transform;
			LineRenderer line = go.GetComponent<LineRenderer> ();
			line.SetVertexCount (2);
			lines.Add (line);
		}
	}
	
	public void SetVertexCount (int count)
	{
		if(count>lines.Count)
			throw new Exception("112");
		_count=count;
	}
	
	public void SetPosition (int c, Vector3 p)
	{
		
		for (int i=0; i<2; i++) {
			for (int j=0; j<_count-1; j++) {
				if ((i + j) == c) {
					lines [j].SetPosition (i, p);
				}
			}
		}
	}
	
	void ClearLine ()
	{
		for (int i=0; i<lines.Count; i++) {
			GameObject go = lines [i].gameObject;
			Destroy (go);
		}
		lines.Clear ();
	}
}



















