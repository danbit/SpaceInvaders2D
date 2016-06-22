using UnityEngine;
using System.Collections;

namespace SP2D{
	
	public class BulletZigZagMover : MonoBehaviour {

		public float speed;
		private float direction = -1;
		private float offset;

		void Start(){
			offset = transform.position.x - 1.0f;
			Debug.Log ("transform.position.x= " + transform.position.x);
		}

		void Update(){
			transform.position = new Vector3 (Mathf.PingPong (Time.time * direction, 1) + offset, transform.position.y, 0.0f);

			Vector3 moveDown = new Vector3 (transform.position.x, speed * direction * Time.deltaTime, 0.0f);
			transform.position += moveDown;
		}

	}
		

}
