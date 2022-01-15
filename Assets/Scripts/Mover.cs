using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;

	Rigidbody2D rigidb;

	// Use this for initialization
	void Start () {
		rigidb = GetComponent<Rigidbody2D> ();
		rigidb.velocity = new Vector2 (transform.up.x, transform.up.y) * speed;
	}

}
