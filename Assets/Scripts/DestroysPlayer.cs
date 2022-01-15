using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroysPlayer : MonoBehaviour {

	public GameObject playerExplosion;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			GameController gameController = gameControllerObject.GetComponent<GameController> ();
			Instantiate (playerExplosion, other.gameObject.GetComponent<Transform> ().position, Quaternion.identity);

			gameController.GameOver ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
