using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightSource : MonoBehaviour
{
	[SerializeField]
	Vector2 origin;
	[SerializeField]
	Vector2 originVector;
	[SerializeField]
	Vector2 endPoint;
	[SerializeField]
	LightSprite lightSprite;
	[SerializeField]
	Transform sourceTriggrt;
	public List<Vector2> positions = new List<Vector2> ();
	int maxReflectCount = 10;
	public MouseSelect Selecttion{get;private set;}
	bool transportStart=false;
	public delegate void OnTransportEndEvent();
	public OnTransportEndEvent OnTransportEnd ;
	
	
	void Start ()
	{
		positions.Add (origin);
		this.Selecttion=GetComponent<MouseSelect>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		origin = toVector2 (transform.position);
		originVector = toVector2 (transform.rotation);
		endPoint = origin;
		positions.Clear ();
		lightSprite.BeforeUpdateVertexs ();
		if(!transportStart){
			updateReflection (origin, originVector, 0);
			updatateVertex ();
		}
		lightSprite.UpdateVertexs ();
		updtaeTrigger();
		
	}
	
	void updtaeTrigger(){
		sourceTriggrt.position=toVector3(endPoint);
	}
	
	void updateReflection (Vector2 origin, Vector2 direc, int i)//origin's count
	{
		RaycastHit2D hit;
		bool isHit = false;
		if (i > maxReflectCount) {
			endPoint = origin;
			return;
		}
		if (i == 0) {
			positions.Add (origin);
			i++;
		}
		string _tag = "";
		hit = Physics2D.Raycast (origin, direc);
		if (hit.collider != null) {
			_tag = hit.collider.gameObject.tag;
			if (_tag == "Reflectable" || _tag == "LightGoal" || _tag == "Barrier")
				isHit = true;
		} 
		if (isHit) {
			if (_tag == "Reflectable") {
				Vector3 hitPosition = hit.point;
				Vector3 normal = hit.normal;
				if (positions.Count <= i) {
					positions.Add (toVector2 (hitPosition));
					i++;
					Vector2 r = toVector2 (onReflection (direc, normal));
					updateReflection (positions [positions.Count - 1] + r * 0.01f, r, i);
				}
			}
			if (_tag == "LightGoal") {
				endPoint = hit.point;
				
			}
			if (_tag == "Barrier") {
				endPoint = hit.point;
			}
		} else {
			endPoint = origin + direc * 50;
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
			setLineRendererPos (i, positions [i]);
		}
		setLineRendererPos (positions.Count, endPoint);
	}
	
	void setLineRendererPos (int i, Vector2 v)
	{
		Vector3 v3 = toVector3 (v);
		v3.z = 0.1f;
		lightSprite.SetPosition (i, v3);
	}
	
	Vector3[] toVector3Array(List<Vector2> v2s){
		Vector3[] v3s=new Vector3[v2s.Count];
		for(int i=0;i<v2s.Count;i++){
			v3s[i]=toVector2(v2s[i]);
		}
		return v3s;
	}
	
	public void StartTransport(Vector2 end){
		List<Vector2> v2s = new List<Vector2> ();
		foreach(Vector2 v in positions){
			v2s.Add(v);
		}
		v2s.Add (end);
		
		Hashtable args = new Hashtable();
		args.Add("speed",15f);
		args.Add("orienttopath",true);
		args.Add("path",toVector3Array(v2s));
		args.Add ("oncomplete","transportEndedd");
		iTween.MoveTo(gameObject,args);
		transportStart = true;
	}
	
	void transportEndedd(){
		if (OnTransportEnd != null)
			OnTransportEnd ();
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
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
