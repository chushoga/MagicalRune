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
		if (coll.gameObject.tag == "Player")
		{
			// DAMAGE THE PLAYER HEALTH
			GameController.playerHealth -= 1;
			Debug.Log("HP: " + GameController.playerHealth);

		}

		// if the gameobject hits of its same tag then destroy the collided one
		if (gameObject.tag == coll.gameObject.tag) {
			
		}

		if (coll.gameObject.tag == "OutOfBounds")
		{			
			GameController.score += 1000;
			Debug.Log("SCORE: " + GameController.score);
		}

		Instantiate(explosionPart, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
