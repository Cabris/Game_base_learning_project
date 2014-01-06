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
						transform.Rotate (Vector3.forward * speed * Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime);//滑鼠滾輪控制旋轉
		}

		public bool Enabled{ get; set; }
}
