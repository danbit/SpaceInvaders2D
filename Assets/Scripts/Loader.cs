using UnityEngine;
using System.Collections;
using SP2D.Managers;

namespace SP2D{
		
	public class Loader : MonoBehaviour {
		
		public GameObject gameManager;          //GameManager prefab to instantiate.
		public GameObject soundManager;         //SoundManager prefab to instantiate.
		public GameObject animationManager;		 //AnimationManager prefab to instantiate.

		void Awake ()
		{
			if (GameManager.instance == null)
				Instantiate(gameManager);

			if (SoundManager.instance == null)
				Instantiate(soundManager);

			if (AnimationManager.instance == null)
				Instantiate(animationManager);
			
		}

	}

}