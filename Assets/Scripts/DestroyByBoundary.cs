using UnityEngine;
using System.Collections;

namespace SP2D{

	public class DestroyByBoundary : MonoBehaviour {

		void OnTriggerEnter2D (Collider2D other) {
			Destroy(other.gameObject);
		}

	}

}
