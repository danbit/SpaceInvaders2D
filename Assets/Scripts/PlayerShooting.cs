using UnityEngine;
using System.Collections;
using SP2D.Managers;

namespace SP2D{
		
	public class PlayerShooting : MonoBehaviour {

		public GameObject bullet;
		public Transform playerBulletSpawn;
		public AudioClip shotSound;
		public float fireRate = 0.25f;

		private float nextFire = 0.0f;

		void Update(){
			if ((Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Jump")) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				GameObject newShot = Instantiate<GameObject> (bullet);
				newShot.tag = "ShotPlayer";
				newShot.transform.position = playerBulletSpawn.transform.position;

				SoundManager.instance.RandomizeSfx (shotSound);
			}
		}

	}

}