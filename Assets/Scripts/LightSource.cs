using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightSource : MonoBehaviour
{
	public Vector2 origin;
	public Vector2 originVector;
	public Vector2 endPoint;
	public LightSprite lightSprite;
	public List<Vector2> positions = new List<Vector2> ();
	public int maxReflectCount = 10;
	
	// Use this for initialization
	void Start ()
	{
		positions.Add (origin);
	}
	
	// Update is called once per frame
	void Update ()
	{
		origin = toVector2 (transform.position);
		originVector = toVector2 (transform.rotation);
		endPoint=origin;
		positions.Clear ();
		lightSprite.BeforeUpdateVertexs();
		updateReflection (origin, originVector, 0);
		updatateVertex ();
		lightSprite.UpdateVertexs();
	}
	
	void updateReflection (Vector2 origin, Vector2 direc, int i)//origin's count
	{
		RaycastHit2D hit;
		bool isHit = false;
		if (i > maxReflectCount){
			endPoint=origin;
			return;
		}
		if (i == 0) {
			positions.Add (origin);
			i++;
		}
		string _tag="";
		hit=Physics2D.Raycast (origin, direc);
		if (hit.collider!=null) {
			 _tag=hit.collider.gameObject.tag;
			if (_tag == "Reflectable"||_tag=="LightGoal")
				isHit = true;
		} 
		if (isHit) {
			if(_tag=="Reflectable"){
				Vector3 hitPosition = hit.point;
				Vector3 normal = hit.normal;
				if (positions.Count <= i) {
					positions.Add (toVector2 (hitPosition));
					i++;
					Vector2 r = toVector2( onReflection (direc, normal));
					updateReflection (positions [positions.Count - 1]+r*0.01f, r, i);
				}
			}
			if(_tag=="LightGoal"){
				endPoint=hit.point;
			}
		} else {
			endPoint = origin+direc*50;
		}
		
	}
	
	Vector3 onReflection (Vector3 i, Vector3 n)
	{
		Vector3 r;
		r = i - 2 * (Vector3.Dot (i, n)) * n;
		return r.normalized;
	}
	
	void updatateVertex ()
	{
		lightSprite.SetVertexCount (positions.Count + 1);
		for (int i=0; i<positions.Count; i++) {
			setLineRendererPos(i,positions [i]);
		}
//		Vector3 lastP = positions [positions.Count - 1];
//		Vector3 infiniteP = origin;
//		float max = 500;
//		infiniteP = lastP + toVector3 (endPoint) * max;
		setLineRendererPos(positions.Count,endPoint);
	}
	
	Vector2 toVector2 (Vector3 v)
	{
		return new Vector2 (v.x, v.y);
	}
	
	Vector3 toVector3 (Vector2 v)
	{
		return new Vector3 (v.x, v.y, 0);
	}
	
	Vector2 toVector2 (Quaternion q)
	{
		Vector3 v3 = q.eulerAngles;
		float zr = (v3.z) * Mathf.PI / 180;
		
		float x = Mathf.Cos (zr);
		float y = Mathf.Sin (zr);
		
		return new Vector2 (x, y).normalized;
	}
	
	void setLineRendererPos(int i,Vector2 v){
		Vector3 v3=toVector3(v);
		v3.z=0.1f;
		lightSprite.SetPosition (i, v3);
	}
	
}
