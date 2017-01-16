using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour {
	void OnDrawGizmosSelected() {
		Camera camera = GetComponent<Camera>();
		Vector3 p = camera.ScreenToWorldPoint(new Vector3(camera.nearClipPlane/2, camera.nearClipPlane/2, 0));
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(p, 2f);
	}
}
