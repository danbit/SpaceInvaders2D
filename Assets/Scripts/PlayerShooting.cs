using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject bullet;
	public Transform playerBulletSpawn;
	public AudioClip shotSound;
	public float fireRate = 0.25f;

	private Renderer _renderer;
	private float nextFire = 0.0f;

	void Start () {
		_renderer = this.GetComponent<Renderer> ();
	}

	void Update(){
		if (CanPlay()) {
			if ((Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2")) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				GameObject newShot = Instantiate<GameObject> (bullet);
				newShot.tag = "ShotPlayer";
				newShot.transform.position = playerBulletSpawn.transform.position;

				SoundManager.instance.RandomizeSfx (shotSound);
			}
		}
	}

	//TODO create a Game.pause state
	private bool CanPlay(){
		return _renderer.enabled;
	}

}
