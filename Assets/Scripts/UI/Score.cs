using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private int score = 0;

	public void UpdateScoreUI(){
		score += 10;

		if (score % 1000 == 0) {
			GameObject.FindObjectOfType<PlayerHealth> ().LevelUp ();
		}
		GetComponent<Text>().text = score.ToString ();
	}
}
