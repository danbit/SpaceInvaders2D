using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax;
}	

public class PlayerMovement : MonoBehaviour {

	public Boundary boundary;
	public float speed;

	private Transform _transform;

	void Start(){
		_transform = this.transform;
	}

	void Update () {
		MovePlayer ();
	}

	void MovePlayer(){
		float moveHorizontal = Input.GetAxis ("Horizontal");

		_transform.Translate (new Vector3(moveHorizontal * speed * Time.deltaTime, 0.0f, 0.0f));

		_transform.position = new Vector3 (
			Mathf.Clamp(this.transform.position.x, boundary.xMin, boundary.xMax),
			_transform.position.y,
			0.0f
		);
	}
}
