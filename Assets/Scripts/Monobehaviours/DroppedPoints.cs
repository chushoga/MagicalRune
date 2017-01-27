using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedPoints : MonoBehaviour {

	public GameObject explosionPart;

	[SerializeField]
	private float fallSpeed = 1f;

	[SerializeField]
	private int pointWorth = 100;


	// Update is called once per frame
	void Update () {
		transform.position -= Vector3.up * fallSpeed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{       
		// ENEMY minus score if hits player
		if (coll.gameObject.tag == "Player") {
			// Get a point if the player catches
			GameController.score += pointWorth;
			Instantiate (explosionPart, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		} else {
			Instantiate(explosionPart, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
