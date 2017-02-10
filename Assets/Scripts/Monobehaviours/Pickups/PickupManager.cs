using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

	[SerializeField] private int minorHealth = 10;
	[SerializeField]private GameObject button;
	[SerializeField]private GameObject inventoryBar;

	void Update() {
		if (Input.GetKeyDown ("space")) {
			print ("space key was pressed");
			GameObject newButton = Instantiate (button) as GameObject;
			newButton.transform.SetParent (inventoryBar.transform, false);
		}
	}

	// MINOR HEALTH
	public void HealthMinor(){
		// ADD A MINOR AMOUNT OF HEALTH
		// TRIGGER ADD HEALTH SPARKLE EFFECT HERE.
		Debug.Log("minorHeath: " + minorHealth);
		GameController.playerHealth -= minorHealth;

	}

	public void DestroyMe(){

		Destroy (this.gameObject);

	}


}
