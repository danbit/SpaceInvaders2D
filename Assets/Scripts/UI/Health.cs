using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SP2D.Managers;

namespace SP2D.UI{

	public class Health : MonoBehaviour {

		void Start(){
			UpdateHealthUI (GameManager.INITIAL_PLAYER_HEALTH);
		}

		public void UpdateHealthUI(float health){
			GetComponent<Text>().text = health.ToString ();
		}

	}

}