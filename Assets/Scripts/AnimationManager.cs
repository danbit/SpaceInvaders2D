using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {	
	
	public static AnimationManager instance = null;

	public AudioClip explosionSound;
	public GameObject explosionPrefab;

	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}

	public void PlayExplosion(Transform target){
		GameObject newExplosion = Instantiate<GameObject> (explosionPrefab);
		newExplosion.transform.position = target.position;
		SoundManager.instance.RandomizeSfx (explosionSound);
	}

}

