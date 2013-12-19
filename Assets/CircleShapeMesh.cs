using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonMesh))]
public class CircleShapeMesh : MonoBehaviour
{
	
	public float radius;
	public int circleResolution;
	PolygonMesh polygon;
	
	// Use this for initialization
	void Start ()
	{
		polygon = GetComponent<PolygonMesh> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2[] vertices = new Vector2[circleResolution];
		Vector2[] uvs = new Vector2[circleResolution];
		for (int i=0; i<circleResolution; i++) {
			float angle = Mathf.PI * 2 * (((float)i + 1f) / circleResolution);
			float x = Mathf.Cos (angle);
			float y = Mathf.Sin (angle);		
			vertices[i]=new Vector2(x*Mathf.Abs(radius),-y*Mathf.Abs(radius));
			uvs[i]=new Vector2(x+0.5f,y+0.5f);
		}
		polygon.Vertices=vertices;
		polygon.Uvs=uvs;
	}
}
