using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

	public float fallSpeed = 1f;
	private bool stillFalling = true;

	// Use this for initialization
	void Update () {
		if (stillFalling == true)
		{
			transform.position -= Vector3.up * fallSpeed * Time.deltaTime; // if still falling keep going. Else Dont.
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{        
		if (coll.gameObject.tag == "Player")
		{
			stillFalling = false;

			Destroy(this.gameObject);
		}

		if (coll.gameObject.tag == "OutOfBounds")
		{
			stillFalling = false;
			// TODO: start the coroutine to let the item destroy itself after set seconds.
		}
	}
}
