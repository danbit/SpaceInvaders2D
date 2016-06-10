using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject bullet;
	public float speed;
	public float fireRate;
	public int maxAmountShot = 10;

	private float nextFire = 0.0f;

	// Use this for initialization
	void Awake () {
		nextFire = Random.Range (1.0f, 5.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time >= nextFire) {
			GameObject[] shotEnemies = GameObject.FindGameObjectsWithTag ("ShotEnemy");

			//Debug.Log ("shotEnemies.Lengt= " + shotEnemies.Length);
			if (shotEnemies.Length < maxAmountShot) {
				GameObject newShot = Instantiate<GameObject> (bullet);
				newShot.tag = "ShotEnemy";
				newShot.transform.position = this.transform.position;
			}

			nextFire = Time.time + fireRate;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "ShotPlayer") {

			GameObject.FindObjectOfType<ScoreController> ().UpdateScore ();

			this.enabled = false;
			Destroy (this.gameObject);
			Destroy (other.gameObject);
		}
	}
}
