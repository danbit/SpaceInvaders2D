﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SP2D.Core;
using SP2D.Managers;
using SP2D.Utils;

namespace SP2D{

	public class WaveController : MonoBehaviour {

		private const int ENEMIES_COLUMN = 11;
		private const int ENEMIES_ROW = 5;
		private const float HORIZONTAL_ENEMY_OFFSET = 1.27f;
		private const float VERTICAL_ENEMY_OFFSET = 1.09f;
		private const float WAVE_BOUNDARY_XMIN = -2.4f;
		private const float WAVE_BOUNDARY_XMAX = 2.7f;
		private const float ORIGINAL_SPEED = 1.0f;

		public GameObject enemyPrefab;
		public GameObject bullet;
		public AudioClip shotSound;
		public float speed;
		public int maxAmountShot;
		public float waveDownDistance;

		private Transform _transform;
		private Boundary boundary;
		private float lastY = 0;
		private bool isGoingLeft = false;
		private bool moveDown = false;
		private bool waveDone = false;
		private int columnMin;
		private int columnMax;

		void Start () {
			_transform = this.transform;
			StartCoroutine(SpawnWave ());
		}

		void Update () {	
			if (waveDone) {
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

				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

				if (enemies.Length > 0) {
					RandomEnemyShot (enemies);
					UpdateBoundary (enemies);
				}else{
					waveDone = false;

					StartCoroutine(SpawnWave ());
				}
			}
		}

		void RandomEnemyShot(GameObject[] enemies){
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

			for (int x = 0; x < ENEMIES_COLUMN; x++) {
				for (int y = 0; y < ENEMIES_ROW; y++) {
					GameObject newEnemy = Instantiate (enemyPrefab);
					newEnemy.gameObject.name = "Enemy_" + x;
					newEnemy.transform.SetParent (_transform);
					newEnemy.transform.localPosition = new Vector3 (-6.5f + x * HORIZONTAL_ENEMY_OFFSET, y * VERTICAL_ENEMY_OFFSET, 0.0f); 
				}
			}

			yield return new WaitForSeconds (1.0f);

			InitWave ();
			waveDone = true;
		}

		private void InitWave(){			
			lastY = 0;
			columnMin = 0;
			columnMax = ENEMIES_COLUMN - 1;
			speed = ORIGINAL_SPEED;

			boundary = new Boundary ();
			boundary.xMin = WAVE_BOUNDARY_XMIN;
			boundary.xMax = WAVE_BOUNDARY_XMAX;
		}

		private void UpdateBoundary(GameObject[] enemies){
			ArrayList waveColumns = new ArrayList (ENEMIES_COLUMN);

			foreach (GameObject enemy in enemies) {				
				int enemyColumn = int.Parse(enemy.name.Split('_')[1]);
				if (!waveColumns.Contains (enemyColumn)) {
					waveColumns.Add (enemyColumn);
				}
			}		

			if (columnMin != (int)waveColumns [0]) {
				boundary.xMin -= HORIZONTAL_ENEMY_OFFSET;
				columnMin++;
			}

			if (columnMax != (int)waveColumns [waveColumns.Count - 1]) {
				boundary.xMax += HORIZONTAL_ENEMY_OFFSET;
				columnMax--;
			}
				
		}

		public void IncrementWaveSpeed(){
			speed += 0.1f;
		}

	}

}