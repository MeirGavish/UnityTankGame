using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter2D(Collider2D other)
	{
		

		if (other.gameObject.tag != "Enemies" && other.gameObject.tag != "Boundary") 
		{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			GameController gameController = gameControllerObject.GetComponent<GameController> ();

			if (explosion != null ) 
			{
				if(other.gameObject.tag != "Player")
					gameController.addScore (scoreValue);
				
				Instantiate (explosion, GetComponent<Transform> ().position, Quaternion.identity);
			}

			if (other.gameObject.tag == "Player") 
			{
				Instantiate (playerExplosion, other.gameObject.GetComponent<Transform> ().position, Quaternion.identity);


				gameController.GameOver ();
			}

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
