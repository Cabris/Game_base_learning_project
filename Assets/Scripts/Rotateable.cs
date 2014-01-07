using UnityEngine;
using System.Collections;

public class Rotateable : MonoBehaviour
{

		public float speed;

		// Use this for initialization
		void Start ()
		{
				Enabled = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void OnMouseOver ()
		{
				if (Enabled)
				{
					if(Input.GetKey("left"))
					{
						transform.Rotate (Vector3.forward * speed * Time.deltaTime);//左按鍵控制左旋轉
				 	}
					else if(Input.GetKey("right"))
					{
						transform.Rotate (Vector3.back * speed * Time.deltaTime);//右按鍵控制右旋轉
					}
					else
					{
						transform.Rotate (Vector3.forward * speed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime);//滑鼠滾輪控制旋轉
					}
				}
		}
		public bool Enabled{ get; set; }
}
