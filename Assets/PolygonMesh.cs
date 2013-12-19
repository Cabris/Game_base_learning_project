using UnityEngine;
using System.Collections;

public class PolygonMesh : MonoBehaviour
{
	
	public Vector2[] newVertices;
	public Vector2[] newUV;
	public int[] newTriangles;
	
	// Use this for initialization
	void Start ()
	{
		Mesh mesh = new Mesh ();
		GetComponent<MeshFilter> ().mesh = mesh;
		mesh.vertices = ToVector3(this.newVertices);;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		mesh.Clear ();
		mesh.vertices = ToVector3(this.newVertices);
		mesh.uv = newUV;
		
		Triangulator t=new Triangulator(newVertices);
		newTriangles=t.Triangulate();
		mesh.triangles = newTriangles;
	}
	
	private Vector3[] ToVector3 (Vector2[] vertices2D)
	{
		Vector3[] vertices = new Vector3[vertices2D.Length];
		for (int i=0; i<vertices.Length; i++) {
			vertices [i] = new Vector3 (vertices2D [i].x, vertices2D [i].y, 0);
		}
		return vertices;
	}
	
	public Vector2[] Vertices {
		get{return newVertices;}
		set{newVertices=value;}
	}
	
	public Vector2[] Uvs{
		get{return newUV;}
		set{newUV=value;}
	}
	
}
