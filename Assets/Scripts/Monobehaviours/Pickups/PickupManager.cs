using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {
	
	[SerializeField]private GameObject pickup;
	[SerializeField]private GameObject inventoryBar;

	void Update() {
		if (Input.GetKeyDown ("space")) {
			print ("space key was pressed");
			GameObject newButton = Instantiate (button) as GameObject;
			newButton.transform.SetParent (inventoryBar.transform, false);
		}
	}


}
