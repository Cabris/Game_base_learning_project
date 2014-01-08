using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Renderer))]
public class MouseSelect : MonoBehaviour {
	public bool dragable,rotateable;
	Color SelectingColor=Color.red;
	public Renderer subRernderer;
	Dragable _dragable;
	Rotateable _rotateable;
	public SelectionState selectionState;
	public bool isHover;//滑鼠是否移上去
	public bool Enabled;
	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		_dragable=GetComponent<Dragable>();
		_rotateable=GetComponent<Rotateable>();
		spriteRenderer=GetComponent<SpriteRenderer>();
		selectionState=SelectionState.NotSelect;
		isHover=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(_rotateable!=null)
			_rotateable.Enabled=rotateable&&Enabled;
		if(_dragable!=null)
			_dragable.Enabled=dragable&&Enabled;
		if(Enabled)
		upDateMaterialStaus();
		if(!Enabled){
			isHover=false;
			 selectionState=SelectionState.NotSelect;
		}
		if (Input.GetMouseButtonDown(0)&&!isHover||Input.GetKey(KeyCode.Escape)||!Enabled){//
			selectionState=SelectionState.NotSelect;
		}
		SelectingColor=getColor(Time.time);
	}
	
	void upDateMaterialStaus(){
		int m=0;
		if(subRernderer!=null)
			m=subRernderer.materials.Length-1;
		if(selectionState==SelectionState.Selected){
			if(subRernderer!=null)
				subRernderer.materials[m].color =SelectingColor;
			if(renderer!=null)
				renderer.material.color =SelectingColor;
			if(spriteRenderer!=null)
				spriteRenderer.color=SelectingColor;
		}if(selectionState==SelectionState.NotSelect||!Enabled){
			if(isHover){
				if(subRernderer!=null)
					subRernderer.materials[m].color =SelectingColor;
				if(renderer!=null)
					renderer.material.color =SelectingColor;
				if(spriteRenderer!=null)
					spriteRenderer.color=SelectingColor;
			}
			else{
				if(subRernderer!=null)
					subRernderer.materials[m].color = Color.white;
				if(renderer!=null)
					renderer.material.color = Color.white;
				if(spriteRenderer!=null)
					spriteRenderer.color=Color.white;}
		}
		
	}
	
	Color getColor(float parm){
		Color c=new Color();
		float r=(Mathf.Sin(parm*8.85f)+3f)/4f;
		float g=(Mathf.Cos(parm*8.65f+3f)+3f)/4f;
		float b=(Mathf.Sin(-parm*8.78f+1.25f)+3f)/4f;
		if(isHover){
			r=1;
			g=(Mathf.Sin(parm*15f)+3f)/4f;
			b=(Mathf.Sin(parm*15f)+3f)/4f;
		}
		c.r=r;
		c.g=g;
		c.b=b;
		c.a=1;
		return c;
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
