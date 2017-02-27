using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealthMinor: MonoBehaviour {

	[SerializeField]GameObject pickup;
	GameObject inventoryBar;

	[SerializeField] float fallSpeed = 1f;
	[SerializeField] float timeout = 5f;
	public Sprite icon;

	// check if the object is still falling or not.
	bool stillFalling;

	SpriteRenderer sr;

	void Start (){
		sr = gameObject.GetComponent<SpriteRenderer>();
		inventoryBar = GameObject.Find("Inventory");
		stillFalling = true;
	}

	// Use this for initialization
	void FixedUpdate () {
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

			// check the length of the inventory bar and remove the first picked item if count is greater than 3
			if(inventoryBar.transform.childCount > 2){
				Debug.Log("Remove the first child " + inventoryBar.transform.childCount);
				Destroy(inventoryBar.transform.GetChild(0).gameObject);
			} 


			GameObject newButton = Instantiate (pickup) as GameObject;
			newButton.transform.SetParent (inventoryBar.transform, false);


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
