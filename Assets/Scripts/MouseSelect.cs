using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Renderer))]
public class MouseSelect : MonoBehaviour {
	public bool dragable,rotateable;
	Color SelectingColor=Color.red;
	Color tempColor;
	public Renderer subRernderer;
	Dragable _dragable;
	Rotateable _rotateable;
	public SelectionState selectionState;
	public bool isHover;//滑鼠是否移上去

	// Use this for initialization
	void Start () {
		_dragable=GetComponent<Dragable>();
		_rotateable=GetComponent<Rotateable>();
		selectionState=SelectionState.NotSelect;
		isHover=false;

	}
	
	// Update is called once per frame
	void Update () {
		if(_rotateable!=null)
			_rotateable.Enabled=rotateable;
		if(_dragable!=null)
			_dragable.Enabled=dragable;
		upDateMaterialStaus();
		
		if (Input.GetMouseButtonDown(0)&&!isHover||Input.GetKey(KeyCode.Escape)){//
			selectionState=SelectionState.NotSelect;
		}
		
	}
	
	void upDateMaterialStaus(){
		if(selectionState==SelectionState.Selected){
			if(subRernderer!=null){
				tempColor=subRernderer.material.color;
				subRernderer.material.color =SelectingColor;
			}
			if(renderer!=null){
				renderer.material.color =SelectingColor;
			}
		}if(selectionState==SelectionState.NotSelect){
			if(subRernderer!=null)
				subRernderer.material.color = tempColor;
			if(renderer!=null)
				renderer.material.color = Color.white;
		}
	}

	void OnMouseDown() {
		selectionState=SelectionState.Selected;
	}
	
	void OnMouseUp() {
		//selectionState=SelectionState.NotSelect;
	}
	
	void OnMouseEnter() {
		isHover=true;
	}
	
	void OnMouseExit() {
		isHover=false;
	}
	
	public enum SelectionState{
		NotSelect,//未選取
		Selected//選取
	};
	
}
