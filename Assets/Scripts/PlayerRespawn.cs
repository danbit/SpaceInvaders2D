using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	public GameObject playerPrefab;
	public Transform spawnPoint;
	public float waitTime;

	private Renderer playerRenderer;

	void Start(){
		playerRenderer = playerPrefab.GetComponent<Renderer> ();
	}

	void OnTriggerEnter2D (Collider2D other) {		
		if (other.tag == "ShotEnemy") {
			playerRenderer.enabled = false;
			pause (true);

			StartCoroutine (Respawn (waitTime));
		}
	}

	IEnumerator Respawn(float waitTime) {
		destroyAllEnemiesShots ();
		yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(waitTime));

		pause (false);

		playerPrefab.transform.position = spawnPoint.position;
		playerRenderer.enabled = true;
	}

	void destroyAllEnemiesShots(){
		GameObject[] shots = GameObject.FindGameObjectsWithTag("ShotEnemy");
		foreach (GameObject shot in shots) {
			Destroy (shot);
		}
	}

	private void pause(bool paused){
		Time.timeScale = paused ? 0 : 1;
	}

}
