using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bullet;
	public float speed;
	public float fireRate = 0.5f;
	public int maxAmountShot = 10;

	private float nextFire = 0.0f;

	void Start () {
		nextFire = Random.Range (0.5f, 1.0f);
	}

	void Update () {
		if (Time.time > nextFire) {
			GameObject[] shotEnemies = GameObject.FindGameObjectsWithTag ("ShotEnemy");

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

			GameObject.FindObjectOfType<Score> ().UpdateScoreUI ();

			this.enabled = false;
			Destroy (this.gameObject);
			Destroy (other.gameObject);
		}
	}
}
