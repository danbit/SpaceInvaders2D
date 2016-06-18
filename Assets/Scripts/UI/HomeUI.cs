using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using SP2D.Managers;

namespace SP2D.UI{

	public class HomeUI : MonoBehaviour {

		public void StartGame(){
			GameManager.instance.SetGameState (GameManager.GameState.STATE_PLAYING);
		}

	}
}