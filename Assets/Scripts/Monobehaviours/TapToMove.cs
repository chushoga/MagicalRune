﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class TapToMove : MonoBehaviour {
	
	//REFERENCES
	Animator anim;

	// flag to check if the user had tapped or clicked
	// set to true on click. Reset to false on reaching destination
	private bool flag = false;

	// moving bool for animation
	private bool movingLeft = false;
	private bool movingRight = false;

	// destination point
	private Vector3 endPoint;

	// alter this to change the speed of movement
	public float speed = 1;

	void Awake () {
		anim = GetComponent<Animator>();
	}

	void Start () {
		endPoint = transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		// *************************************************
		// MOVEMENT DETECTION
		// check if the screen is touched or clicked
		// *************************************************

		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0))) {
			// create a Ray on the tapped/click postion
			Ray ray;

			// for unity editor
			#if UNITY_EDITOR

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// for touch devices
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			//Debug.Log("MOBILE");
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif

			// decalare a variable of RaycastHit struct
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			// Check if the ray hits any collider
			if(hit) {
				
				flag = true; // set hit flag to true
				
				// save the click/tap postion
				endPoint.x = hit.point.x;
				endPoint.y = transform.position.y;
				endPoint.z = transform.position.z;
			}
		}


		// Check if reached the destination or not.
		if(Mathf.Approximately(transform.position.magnitude, endPoint.magnitude))
		{
			// this if will run only once in this loop 
			// put things you want to happen only once here.
			if (flag == true)
			{
				//Debug.Log("Destination Reached");
			}

			flag = false; // reset the hit flag

		}

		// Move the player while the flag is set to true
		if (flag == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
		}

		// check if moving and what direction. Set flags accorningly
		if (flag == true && transform.position.x > endPoint.x) {
			movingLeft = true;
			movingRight = false;
		} else {
			movingLeft = false;
		}
		if (flag == true && transform.position.x < endPoint.x) {
			movingLeft = false;
			movingRight = true;
		} else {
			movingRight = false;
		}

		// set the moving or not flag for animation
		anim.SetBool("isMoving", flag);

		// set left or right bool
		anim.SetBool("movingLeft", movingLeft);
		anim.SetBool("movingRight", movingRight);

	
	}
}