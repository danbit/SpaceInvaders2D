using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public void UpdateHealthUI(float health){
		GetComponent<Text>().text = health.ToString ();
	}

}
