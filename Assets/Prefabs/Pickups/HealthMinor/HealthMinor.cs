using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMinor : MonoBehaviour {

	[SerializeField] private int health = 10;

	public void AddHealthMinor(){
		// ADD A MINOR AMOUNT OF HEALTH
		// TRIGGER ADD HEALTH SPARKLE EFFECT HERE.
		GameController.playerHealth += health;
	}

	public void DestroyMe(){
		Destroy (this.gameObject);
	}

}
