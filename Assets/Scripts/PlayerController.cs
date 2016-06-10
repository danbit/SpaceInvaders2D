using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax;
}	

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float speed;
	public float fireRate = 0.5f;

	private Renderer _renderer;
	private float nextFire = 0.0f;

	void Start () {
		_renderer = this.GetComponent<Renderer> ();
	}

	void Update(){
		if (canPlay()) {
			MovePlayer ();
			Shot ();
		}
	}
		
	void Shot(){
		if ((Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2")) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			GameObject newShot = Instantiate<GameObject> (shot);
			newShot.tag = "ShotPlayer";
			newShot.transform.position = shotSpawn.transform.position;
		}
	}

	void MovePlayer(){
		float moveHorizontal = Input.GetAxis ("Horizontal");

		this.transform.Translate (new Vector3(moveHorizontal * speed * Time.deltaTime, 0.0f, 0.0f));

		this.transform.position = new Vector3 (
			Mathf.Clamp(this.transform.position.x, boundary.xMin, boundary.xMax),
			this.transform.position.y,
			0.0f
		);
	}

	private bool canPlay(){
		return _renderer.enabled;
	}
		
}

