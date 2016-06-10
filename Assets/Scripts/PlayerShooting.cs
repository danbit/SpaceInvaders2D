﻿using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject bullet;
	public Transform playerBulletSpawn;
	public float fireRate = 0.5f;

	private Renderer _renderer;
	private float nextFire = 0.0f;

	void Start () {
		_renderer = this.GetComponent<Renderer> ();
	}

	void Update(){
		if (canPlay()) {
			Shot ();
		}
	}

	void Shot(){
		if ((Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2")) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			GameObject newShot = Instantiate<GameObject> (bullet);
			newShot.tag = "ShotPlayer";
			newShot.transform.position = playerBulletSpawn.transform.position;
		}
	}

	private bool canPlay(){
		return _renderer.enabled;
	}

}