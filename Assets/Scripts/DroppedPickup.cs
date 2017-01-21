using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedPickup : MonoBehaviour {
	
	[SerializeField]
	public float fallSpeed = 1f;

	[SerializeField]
	private float timeout = 5f;

	// check if the object is still falling or not.
	private bool stillFalling = true;

	SpriteRenderer sr;

	void Start (){
		sr = gameObject.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Update () {
		if (stillFalling == true)
		{
			transform.position -= Vector3.up * fallSpeed * Time.deltaTime; // if still falling keep going. Else Dont.
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{   
		if (coll.gameObject.tag == "Player") {
			stillFalling = false;

			// TODO give some bonus here
			// give some bonus here

			Destroy (this.gameObject);
		} else if (coll.gameObject.tag == "OutOfBounds") {
			stillFalling = false;

			// start the timout timer
			StartCoroutine(removeDrop());
		}
	}

	IEnumerator removeDrop(){
		yield return new WaitForSeconds (timeout);
		for(var n = 0; n < 5; n++)
		{
			
			sr.enabled = true;
			yield return new WaitForSeconds(.1f);
			sr.enabled = false;
			yield return new WaitForSeconds(.1f);
		}
		sr.enabled = true;
		Destroy (this.gameObject);
	}
}
