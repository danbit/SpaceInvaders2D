using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public Text healthText;
	public int health;

	void Start(){
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

	private void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}

	private void UpdateHealthUI(){
		healthText.text = health.ToString ();
	}
		
}
