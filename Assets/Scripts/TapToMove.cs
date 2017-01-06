﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToMove : MonoBehaviour {

	// flag to check if the user had tapped or clicked
	// set to true on click. Reset to false on reaching destination
	private bool flag = false;

	// destination point
	private Vector3 endPoint;

	// alter this to change the speed of movement
	public float duration = 50.0f;

	// vertical position of object
	private float xAxis;

	// Use this for initialization
	void Start () {
		// save the y axis value of gameobject
		xAxis = gameObject.transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		// check if the screen is touched or clicked
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
		{
			//RaycastHit2D hit;

			// create a Ray on the tapped/click postion
			Ray ray;

			// for unity editor
			#if UNITY_EDITOR
			//Debug.Log("UNITY EDITOR");
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// for touch devices
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			//Debug.Log("MOBILE");
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif

			// decalare a variable of RaycastHit struct
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
			//Debug.Log(hit);

			// Check if the ray hits any collider

			if(hit)
			{
				// set flag to indicate to move the object
				flag = true;

				// save the click/tap postion
				endPoint = hit.point;



				// because we do not want to change the y axis value based on touch 
				// position, reset it to the origional y axis value
				//endPoint.y = xAxis;

				//Debug.Log("HIT COLLIDER" + endPoint.x);

			}
//
//			Debug.Log("HIT COLLIDER CHECKED: "  + flag);
//			Debug.Log("position mag " + gameObject.transform.position.magnitude);
//			Debug.Log("endPoint mag " + endPoint.magnitude);
//			Debug.Log("APPROX" + Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude));
//			Debug.Log("------------------------------------------------------------");

			// check if the flag for movement is true and the current position
			// is not the same as the clicked/touched position
			if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
			{
//				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, 
//															endPoint, 
//															1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
//				Debug.Log(gameObject.transform.position);
//				Debug.Log(endPoint);
//				Debug.Log(1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
				gameObject.transform.position = new Vector3(endPoint.x, endPoint.y, endPoint.z);
			} 
			// set the movement indictor flag to false if the endpoint and current gameobject position are equal
			else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) 
			{
				flag = false;
				Debug.Log("I am here");
			}
		}
	}
}
