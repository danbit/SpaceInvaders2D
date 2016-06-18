using UnityEngine;
using System.Collections;
using SP2D.Core;
using SP2D.Managers;

namespace SP2D{
		
	public class WaveController : MonoBehaviour {

		private const int ENEMIES_COLUMN = 11;
		private const int ENEMIES_ROW = 5;
		private const float HORIZONTAL_ENEMY_OFFSET = 1.27f;
		private const float VERTICAL_ENEMY_OFFSET = 1.09f;

		public GameObject enemyPrefab;
		public GameObject bullet;
		public AudioClip shotSound;
		public Boundary boundary;
		public float speed;
		public int maxAmountShot;
		public float waveDownDistance;

		private Transform _transform;
		private float lastY = 0;
		private bool isGoingLeft = false;
		private bool moveDown = false;

		void Start () {
			_transform = this.transform;
			SpawnWave ();	
		}

		void Update () {	

			if (!isGoingLeft && !moveDown) {	
				if (_transform.position.x > boundary.xMax) {
					_transform.position = new Vector3 (boundary.xMax, _transform.position.y, 0.0f);
					lastY = _transform.position.y;
					moveDown = true;
					isGoingLeft = true;
				} else {
					_transform.Translate (speed * Vector3.right * Time.deltaTime);
				}
			} else if (isGoingLeft && !moveDown) {
				if (_transform.position.x < boundary.xMin) {
					_transform.position = new Vector3 (boundary.xMin, _transform.position.y, 0.0f);
					lastY = _transform.position.y;
					moveDown = true;
					isGoingLeft = false;
				} else {
					_transform.Translate (speed * Vector3.left * Time.deltaTime);
				}
			} 

			if(moveDown){
				if (lastY - _transform.position.y >= waveDownDistance) {
					moveDown = false;
				}

				_transform.Translate (speed * Vector3.down * Time.deltaTime);
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
			_transform.position = Vector3.zero; // back to original position
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

}