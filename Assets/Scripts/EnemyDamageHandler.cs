using UnityEngine;
using System.Collections;

public class EnemyDamageHandler : MonoBehaviour {

	public AudioClip explosionSound;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "ShotPlayer") {

			GameObject.FindObjectOfType<Score> ().UpdateScoreUI ();

			this.enabled = false;
			Destroy (this.gameObject);

			SoundManager.instance.RandomizeSfx (explosionSound);

			Destroy (other.gameObject);
		}
	}

}
