using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bullet;
	public AudioClip shotSound;
	public float fireRate;
	public int maxAmountShot;

	private float nextFire = 0.0f;

	void Start () {
		nextFire = Random.Range (2.0f, 10.0f);
		enabled = false;
	}

	void Update () {
		if (Time.time >= nextFire) {
			GameObject[] shotEnemies = GameObject.FindGameObjectsWithTag ("ShotEnemy");

			if (shotEnemies.Length <= maxAmountShot) {
				GameObject newShot = Instantiate<GameObject> (bullet);
				newShot.tag = "ShotEnemy";
				newShot.transform.position = this.transform.position;

				SoundManager.instance.RandomizeSfx (shotSound);
			}

			nextFire = Time.time + fireRate;
		}
	}

}
