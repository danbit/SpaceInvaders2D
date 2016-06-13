using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HomeUI : MonoBehaviour {

	public void StartGame(){
		GameManager.instance.SetGameState (GameManager.GameState.STATE_PLAYING);
	}

}
