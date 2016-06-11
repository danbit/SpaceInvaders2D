using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour {

	public float speed;
	private float direction = 1;

	void Update(){
		if(this.tag.Equals("ShotEnemy")){
			direction = -1;
		}

		Vector3 velocity = new Vector3 (0.0f, speed * direction * Time.deltaTime, 0.0f);
		this.transform.position += velocity;
	}

}
