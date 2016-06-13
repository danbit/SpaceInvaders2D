using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverUI : MonoBehaviour {

	public void Restart(){
		GameManager.instance.SetGameState (GameManager.GameState.STATE_PLAYING);
	}

	public void QuitGame(){
		Application.Quit ();
	}

}

