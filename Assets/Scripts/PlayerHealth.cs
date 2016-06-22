using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using SP2D.Managers;
using SP2D.Utils;
using SP2D.UI;

namespace SP2D{
		
	public class PlayerHealth : MonoBehaviour {

		public static int health;

		void OnTriggerEnter2D(Collider2D other){
			if (other.CompareTag("ShotEnemy") && !GameManager.instance.PlayerIsDead) {
				health--;
				GameObject.FindObjectOfType<Health> ().UpdateHealthUI (health);
			}
		}

		void Update () {
			if (health == 0) {
				GameManager.instance.SetGameState (GameManager.GameState.STATE_GAME_OVER);
			}	
		}

		public void LevelUp(){
			health++;
			GameObject.FindObjectOfType<Health> ().UpdateHealthUI (health);
		}
			
	}

}