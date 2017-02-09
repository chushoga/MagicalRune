using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyMe(){

		Destroy (this.gameObject);

	}
}
