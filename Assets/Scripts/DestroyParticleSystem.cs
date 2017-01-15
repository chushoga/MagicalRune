using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine(RemoveParticleSystem());

	}
	
	// Update is called once per frame
	IEnumerator RemoveParticleSystem() {
		yield return new WaitForSeconds(0.5f);
		Destroy(this.gameObject);
	}
}
