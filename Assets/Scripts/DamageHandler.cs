using UnityEngine;
using UnityEngine.UI;
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
			Die ();
		}	
	}

	public void LevelUp(){
		health++;
		UpdateHealthUI (); 
	}

	private void Die(){
		Debug.Log ("Die");
		Destroy (this.gameObject);
	}

	private void UpdateHealthUI(){
		healthText.text = health.ToString ();
	}
		
}
