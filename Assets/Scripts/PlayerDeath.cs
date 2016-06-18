using UnityEngine;
using System.Collections;
using SP2D.Managers;

namespace SP2D{
		
	public class PlayerDeath : MonoBehaviour {

		void OnTriggerEnter2D (Collider2D other) {		
			if (other.tag == "ShotEnemy" && !GameManager.instance.PlayerIsDead) {			
				GameManager.instance.PlayerIsDead = true;
				AnimationManager.instance.PlayExplosion(transform);

				DestroyAllEnemiesShots ();
				GameManager.instance.EnableAllEnemies (false);

				enabled = false;
				Destroy (this.gameObject);
			}
		}

		void DestroyAllEnemiesShots(){
			GameObject[] shots = GameObject.FindGameObjectsWithTag("ShotEnemy");
			foreach (GameObject shot in shots) {
				Destroy (shot.gameObject);
			}
		}

	}

}