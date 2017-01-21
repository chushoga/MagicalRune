using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedEnemy : MonoBehaviour {

	// Explosion particle
	public GameObject explosionPart;

	// FALL SPEED
	[SerializeField]
	private float fallSpeed = 3f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.position -= Vector3.up * fallSpeed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{       
		// ENEMY minus score if hits player
		if (coll.gameObject.tag == "Player") {
			// DAMAGE THE PLAYER HEALTH
			GameController.playerHealth -= 1;
			Debug.Log ("HP: " + GameController.playerHealth);
		} else if (coll.gameObject.tag == "OutOfBounds") {
			// TODO minus points??
		} else {
			// destroy the object it hit
			Destroy(coll.gameObject);
		}

		Instantiate(explosionPart, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
