using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Renderer))]
public class MouseSelect : MonoBehaviour {
	public bool dragable,rotateable;
	Color SelectingColor=Color.red;
	Color tempColor;
	public Renderer _rernderer;
	Dragable _dragable;
	Rotateable _rotateable;
	// Use this for initialization
	void Start () {
		_dragable=GetComponent<Dragable>();
		_rotateable=GetComponent<Rotateable>();
		//		if(_rotateable!=null)
		//			rotateable=_rotateable.Enabled;
		//		if(_dragable!=null)
		//			dragable=_dragable.Enabled;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_rotateable!=null)
			_rotateable.Enabled=rotateable;
		if(_dragable!=null)
			_dragable.Enabled=dragable;
	}
	
	void OnMouseEnter() {
		
		if(_rernderer!=null){
			tempColor=_rernderer.material.color;
			_rernderer.material.color =SelectingColor;
		}
		if(renderer!=null){
			renderer.material.color =SelectingColor;
		}
	}
	
	void OnMouseExit() {
		if(_rernderer!=null)
			_rernderer.material.color = tempColor;
		
		if(renderer!=null)
			renderer.material.color = Color.white;
	}
	
}
