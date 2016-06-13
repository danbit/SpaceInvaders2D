using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	private const int INITIAL_PLAYER_HEALTH = 3;
	public static GameManager instance = null;

	private Text healthText;

	public enum GameState{
		STATE_HOME_MENU,
		STATE_PLAYING,
		STATE_GAME_OVER
	}

	GameState gameState;

	private bool playerIsDead;
	public bool PlayerIsDead {
		get { return this.playerIsDead; }
		set { this.playerIsDead = value; }
	}

	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		SetGameState(GameState.STATE_HOME_MENU);
	}

	void UpdateGameState(){
		switch (gameState) {
		case(GameState.STATE_HOME_MENU):
			
			break;
		case(GameState.STATE_PLAYING):
			PlayerHealth.health = INITIAL_PLAYER_HEALTH;

			SceneManager.LoadScene ("MainLevel");
			break;
		case(GameState.STATE_GAME_OVER):
			SceneManager.LoadScene ("GameOver");

			break;
		default:
			break;
		}
	}

	public void SetGameState(GameState state){
		this.gameState = state;
		UpdateGameState ();
	}

	public void UpdateHealthUI(float health){
		healthText.text = health.ToString ();
	}

	public void Pause(){
		Time.timeScale = 0;
	}

	public void Resume(){
		Time.timeScale = 1;
	}

	public bool isPaused(){
		return Time.timeScale == 0;
	}

	public void EnableAllEnemies(bool enabled){
		GameObject.FindObjectOfType<WaveController> ().enabled = enabled;

		EnemyShooting[] enemies = GameObject.FindObjectsOfType<EnemyShooting> ();
		foreach (EnemyShooting enemy in enemies) {
			enemy.enabled = enabled;
		}
	}

	void OnLevelWasLoaded(int level){
		if (level == 1) {
			healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
			UpdateHealthUI(INITIAL_PLAYER_HEALTH);
		}
	}

}
