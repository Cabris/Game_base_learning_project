using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Renderer))]
public class MouseSelect : MonoBehaviour {
	Color color;
	public Renderer _rernderer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {

		if(_rernderer!=null){
			color=_rernderer.material.color;
			_rernderer.material.color = Color.red;
		}
		if(renderer!=null)
		renderer.material.color = Color.red;
	}

	void OnMouseExit() {
		if(_rernderer!=null){
			_rernderer.material.color = color;
		}
		if(renderer!=null)
		renderer.material.color = Color.white;
	}

}
