using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotator : MonoBehaviour {

	//private Rigidbody2D rigidb;

	// Use this for initialization
	void Start () 
	{
		//rigidb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Honestly, I am not sure why this works but it does...

		Vector3 playerToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		//playerToMouse.z = 0f;
		Quaternion newRotation = Quaternion.LookRotation (playerToMouse, Vector3.back);
		newRotation.x = 0f;
		newRotation.y = 0f;
		transform.rotation = newRotation;

		// Raycasting junk
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit floorHit;
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, bgMask)) 
//		{
//			Vector3 playerToMouse = floorHit.point - transform.position;
//			playerToMouse.z = 0f;
//
//			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//			rigidb.rotation = newRotation.eulerAngles.z;
//		}
	}
}
