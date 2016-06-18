using UnityEngine;
using System.Collections;
using SP2D.UI;
using SP2D.Managers;

namespace SP2D{

	public class EnemyDamageHandler : MonoBehaviour {

		void OnTriggerEnter2D (Collider2D other) {
			if (other.tag == "ShotPlayer") {
				GameObject.FindObjectOfType<Score> ().UpdateScoreUI ();
				this.enabled = false;

				Destroy (this.gameObject);
				AnimationManager.instance.PlayExplosion(transform);

				Destroy (other.gameObject);
			}
		}

	}

}