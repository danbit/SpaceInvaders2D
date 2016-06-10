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
			if(playerRenderer.enabled)
				StartCoroutine (DieAndRespawn (waitTime));
		}
	}

	IEnumerator DieAndRespawn(float waitTime) {
		playerRenderer.enabled = false;

		destroyAllEnemiesShots ();
		enabledWave (false);
		enabledEnemies (false);

		playerPrefab.transform.position = Vector3.zero;
		yield return new WaitForSeconds(waitTime);

		enabledWave (true);
		enabledEnemies (true);
		playerPrefab.transform.position = spawnPoint.position;
		playerRenderer.enabled = true;
	}

	void destroyAllEnemiesShots(){
		GameObject[] shots = GameObject.FindGameObjectsWithTag("ShotEnemy");
		foreach (GameObject shot in shots) {
			Destroy (shot);
		}
	}

	void enabledEnemies(bool enabled){
		EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController> ();
		foreach (EnemyController enemy in enemies) {
			enemy.enabled = enabled;
		}
	}

	void enabledWave(bool enabled){
		WaveController waveController = GameObject.FindObjectOfType<WaveController> ();
		waveController.enabled = enabled;
	}
}
