using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	private const int ENEMIES_COLUMN = 11;
	private const int ENEMIES_ROW = 5;
	private const float HORIZONTAL_ENEMY_OFFSET = 1.27f;
	private const float VERTICAL_ENEMY_OFFSET = 1.09f;

	public GameObject enemyPrefab;
	public GameObject bullet;
	public AudioClip shotSound;
	public float speed;
	public float direction;
	public int maxAmountShot;

	private Transform _transform;

	void Start () {
		_transform = this.transform;
		SpawnWave ();	
	}

	void Update () {				
		_transform.Translate( new Vector3(speed * direction * Time.deltaTime, 0.0f, 0.0f));

		if (_transform.position.x <= -3.1f || _transform.position.x >= 3.4f) {
			direction = -direction;
			// TODO to down wave
		}

		if (_transform.childCount == 0) {
			StartCoroutine(SpawnWave ());
		}

		RandomEnemyShot ();
	}

	void RandomEnemyShot(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject enemyToShot = enemies[Random.Range (0, enemies.Length-1)];

		GameObject[] shotEnemies = GameObject.FindGameObjectsWithTag ("ShotEnemy");
		if (shotEnemies.Length <= maxAmountShot) {
			GameObject newShot = Instantiate<GameObject> (bullet);
			newShot.tag = "ShotEnemy";
			newShot.transform.position = enemyToShot.transform.position;

			SoundManager.instance.RandomizeSfx (shotSound);
		}
	}

	IEnumerator SpawnWave(){
		yield return StartCoroutine (CreateEnemies ());
	}

	IEnumerator CreateEnemies(){
		for (int x = 0; x < ENEMIES_COLUMN; x++) {
			for (int y = 0; y < ENEMIES_ROW; y++) {
				GameObject newEnemy = Instantiate (enemyPrefab);
				newEnemy.gameObject.name = "Enemy " + y + 1;
				newEnemy.transform.SetParent (_transform);
				newEnemy.transform.localPosition = new Vector3 (-6.5f + x * HORIZONTAL_ENEMY_OFFSET, y * VERTICAL_ENEMY_OFFSET, 0.0f); 
			}
		}
		yield return new WaitForSeconds (0.5f);
	}

}
