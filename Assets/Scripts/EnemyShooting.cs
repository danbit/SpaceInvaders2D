using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bullet;
	public AudioClip shotSound1;
	public AudioClip shotSound2;
	public float fireRate;
	public int maxAmountShot;

	private float nextFire = 0.0f;

	void Start () {
		nextFire = Random.Range (2.0f, 10.0f);
	}

	void Update () {
		if (WaveController.isWaveDone && Time.time >= nextFire) {		
			GameObject[] shotEnemies = GameObject.FindGameObjectsWithTag ("ShotEnemy");

			if (shotEnemies.Length <= maxAmountShot) {
				GameObject newShot = Instantiate<GameObject> (bullet);
				newShot.tag = "ShotEnemy";
				newShot.transform.position = this.transform.position;

				SoundManager.instance.ChangeVolume (0.4f);
				SoundManager.instance.RandomizeSfx (shotSound1, shotSound2);
			}

			nextFire = Time.time + fireRate;
		}
	}

}
