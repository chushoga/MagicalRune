using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

	[SerializeField] float destoryAfterSeconds = 0.5f;

	// Use this for initialization
	void Start () {

		StartCoroutine(RemoveParticleSystem());

	}
	
	// Update is called once per frame
	IEnumerator RemoveParticleSystem() {
		yield return new WaitForSeconds(destoryAfterSeconds);
		Destroy(this.gameObject);
	}
}
