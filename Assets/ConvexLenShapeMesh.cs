using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonMesh))]
public class ConvexLenShapeMesh : MonoBehaviour
{
	
	public Vector2 rightLenOffset;
	public float rightLenRadius;
	public Vector2 leftLenOffset;
	public float leftLenRadius;
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
		if(rightLenRadius>0&&leftLenRadius>0&&rightLenRadius<GetCenterDistance()&&leftLenRadius<GetCenterDistance())
		if (GetCenterDistance () > 0 && GetCenterDistance () < (rightLenRadius + leftLenRadius) && circleResolution > 0) {
			Vector2[] vertices = new Vector2[circleResolution * 2];
			Vector2[] uvs = new Vector2[circleResolution * 2];
			float aR = this.GetAngle (rightLenRadius, GetCenterDistance (), leftLenRadius);
			float aL = this.GetAngle (leftLenRadius, GetCenterDistance (), rightLenRadius);
			
			Vector2[] rightLen = GetVertices (rightLenOffset, rightLenRadius, Mathf.PI - aR * 0.5f, Mathf.PI + aR * 0.5f);
			Vector2[] leftLen = GetVertices (leftLenOffset, leftLenRadius, -aL * 0.5f, aL * 0.5f);
			
			for (int i=0; i<circleResolution * 2; i++) {
				if (i < circleResolution) {
					vertices [i] = rightLen [i];
				} else {
					vertices [i] = leftLen [i - circleResolution];
				}
				uvs [i] = new Vector2 (0, 0);
			}
			polygon.Vertices = vertices;
			polygon.Uvs = uvs;
		}
	}
	
	float GetCenterDistance ()
	{//h
		return Vector2.Distance (rightLenOffset, leftLenOffset);
	}
	
	float GetAngle (float a, float b, float c)
	{//return angle C
		float x = (a * a + b * b - c * c) / (2 * a * b);
		return 2 * Mathf.Acos (x);
	}
	
	Vector2[] GetVertices (Vector2 offset, float radius, float start, float end)
	{
		Vector2[] vertices = new Vector2[circleResolution];
		float angleRange = end - start;
		for (int i=0; i<circleResolution; i++) {
			float angle = start + angleRange * (((float)i + 1f) / circleResolution);
			float x = Mathf.Cos (angle);
			float y = Mathf.Sin (angle);		
			vertices [i] = new Vector2 (offset.x + x * Mathf.Abs (radius), offset.y - y * Mathf.Abs (radius));
		}
		return vertices;
	}
	
	
}






























