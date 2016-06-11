using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public const int INITIAL_HEALTH = 2;

	public Text healthText;
	public static int health;

	void Start(){
		health = INITIAL_HEALTH;
		UpdateHealthUI ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ShotEnemy") {
			health--;
			UpdateHealthUI ();
		}
	}

	void Update () {
		if (health < 0) {
			GameOver ();
		}	
	}

	public void LevelUp(){
		health++;
		UpdateHealthUI (); 
	}

	// TODO create a Game.isDead state
	public static bool isDead(){
		return health < 0;
	}

	private void GameOver(){
		health = INITIAL_HEALTH;
		SceneManager.LoadScene ("GameOver");
	}

	private void UpdateHealthUI(){
		if (health >= 0) {
			healthText.text = health.ToString ();
		}
	}
		
}
