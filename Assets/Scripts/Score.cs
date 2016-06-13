using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoreText;

	private int score = 0;

	public void UpdateScoreUI(){
		score += 10;

		if (score % 1000 == 0) {
			GameObject.FindObjectOfType<PlayerHealth> ().LevelUp ();
		}

		scoreText.text = score.ToString ();
	}
}
