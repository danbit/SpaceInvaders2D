using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HomeUI : MonoBehaviour {

	public void StartGame(){
		SceneManager.LoadScene ("MainLevel");
	}

}
