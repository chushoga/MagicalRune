using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

	[SerializeField]
	private float minorHealth = 10;

	// MINOR HEALTH
	public void HealthMinor(){
		// ADD A MINOR AMOUNT OF HEALTH
		// TRIGGER ADD HEALTH SPARKLE EFFECT HERE.
		Debug.Log("minorHeath: " + minorHealth);
	}
}
