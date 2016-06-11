using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverUI : MonoBehaviour {

	public void Restart(){
		SceneManager.LoadScene ("MainLevel");
	}

	public void QuitGame(){
		Application.Quit ();
	}

}

