using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public static int health = 3;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ShotEnemy" && !GameManager.instance.PlayerIsDead) {
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
