﻿using UnityEngine;
using System.Collections;
using SP2D.Utils;
using SP2D.Managers;

namespace SP2D{
		
	public class PlayerRespawn : MonoBehaviour {

		public GameObject playerPrefab;

		void Update(){
			if (GameManager.instance.PlayerIsDead) {
				GameManager.instance.PlayerIsDead = false;
				StartCoroutine (Respawn ());
			}
		}

		IEnumerator Respawn(){
			yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1.5f));

			if (!GameManager.instance.IsGameOver ()) {
				GameObject newPlayer = Instantiate<GameObject> (playerPrefab);
				newPlayer.transform.position = this.transform.position;		

				GameManager.instance.EnableAllEnemies (true);
			}
		}

	}

}