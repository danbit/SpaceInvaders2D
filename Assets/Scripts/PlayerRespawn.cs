using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	public GameObject playerPrefab;
	public Transform spawnPoint;
	public AudioClip explosionSound;
	public float waitTime;

	private Renderer playerRenderer;

	void Start(){
		playerRenderer = playerPrefab.GetComponent<Renderer> ();
	}

	void OnTriggerEnter2D (Collider2D other) {		
		if (other.tag == "ShotEnemy" && !DamageHandler.isDead()) {
			playerRenderer.enabled = false;
			SoundManager.instance.RandomizeSfx (explosionSound);
			Pause (true);

			StartCoroutine (Respawn (waitTime));
		}
	}

	IEnumerator Respawn(float waitTime) {
		DestroyAllEnemiesShots ();
		yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(waitTime));

		Pause (false);

		playerPrefab.transform.position = spawnPoint.position;
		playerRenderer.enabled = true;
	}

	void DestroyAllEnemiesShots(){
		GameObject[] shots = GameObject.FindGameObjectsWithTag("ShotEnemy");
		foreach (GameObject shot in shots) {
			Destroy (shot);
		}
	}

	private void Pause(bool paused){
		Time.timeScale = paused ? 0 : 1;
	}

}
