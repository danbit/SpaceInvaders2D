using UnityEngine;
using System.Collections;

namespace SP2D{
	
	public class Destroyer : MonoBehaviour {

		void DestroyGameObject () {
			Destroy (this.gameObject);
		}

	}

}