using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject enemyPrefab;
	public float speed;
	public float direction;

	private Camera _mainCamera;
	private float enemyWidth;
	private float xMin;
	private float xMax;
	private const int ENEMIES_ROW = 10;
	private const int ENEMIES_COLUMN = 5;
	private const float HORIZONTAL_ENEMY_OFFSET = 1.27f;
	private const float VERTICAL_ENEMY_OFFSET = 1.09f;

	// Use this for initialization
	void Start () {
		//this.enemyWidth = enemyPrefab.GetComponent<SpriteRenderer> ().sprite.rect.width;
		//_mainCamera = Camera.main;
		//float verticaltExtent = _mainCamera.orthographicSize;    
		//float horzontalExtent = verticaltExtent * Screen.width / Screen.height;
		//Vector3 left = _mainCamera.ViewportToWorldPoint (new Vector3 (0.0f, 0.0f, _mainCamera.nearClipPlane));
		spawnWave ();	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.Translate( new Vector3(speed * direction * Time.deltaTime, 0.0f, 0.0f));

		if (this.transform.position.x <= -1.6f || this.transform.position.x >= 3.2f) {
			direction = -direction;
		}
	}

	private void spawnWave(){
		for (int x = 0; x < ENEMIES_ROW; x++) {
			for (int y = 0; y < ENEMIES_COLUMN; y++) {
				GameObject newEnemy = Instantiate (enemyPrefab);
				newEnemy.transform.SetParent (this.transform);
				newEnemy.transform.localPosition = new Vector3 (-6.5f + x * HORIZONTAL_ENEMY_OFFSET, y * VERTICAL_ENEMY_OFFSET, 0.0f); 
			}
		}
	}
}
