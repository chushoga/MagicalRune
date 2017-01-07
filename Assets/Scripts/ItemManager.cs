using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public GameObject explosionPart;
    public float fallSpeed = 1f;

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
			if (gameObject.tag == "Enemy") {
				GameController.score -= 1;
				Destroy(this.gameObject);
				// TODO: Instantiate a partical effect
			} else {
				GameController.score += 1;
				Destroy(this.gameObject);
				// TODO: Instantiate a partical effect
			}
        }

		// if the gameobject hits of its same tag then destroy the collided one
		if (gameObject.tag == coll.gameObject.tag) {
			Destroy (this.gameObject);
		}

		if (coll.gameObject.tag == "OutOfBounds")
		{			
			Instantiate(explosionPart, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
    }
}
