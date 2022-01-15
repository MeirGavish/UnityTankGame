using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour 
{
	public float speed;
	public float steer;
	public Boundary boundary;

	private Rigidbody2D rigidb;


	// Use this for initialization
	void Start () {
		rigidb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float mHorizontal = Input.GetAxisRaw ("Horizontal");
		float mVertical = Input.GetAxis ("Vertical");

		// Normalize to 1
		//mHorizontal = Mathf.Sign(mHorizontal) * 1.0f; 
		//mVertical = Mathf.Sign (mVertical) * 1.0f;

		rigidb.velocity = transform.up * mVertical * speed;	// "up" is forward in 2D
		rigidb.angularVelocity = steer * -mHorizontal*Mathf.Sign(mVertical);


		// Clamp position within boundary
		rigidb.position = new Vector2
			(
				Mathf.Clamp(rigidb.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp(rigidb.position.y, boundary.yMin, boundary.yMax)
			);
	}
}
