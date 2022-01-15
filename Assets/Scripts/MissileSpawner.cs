using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

	public GameObject missileObject;
	public GameObject tankObject;
	public float spawnRange;

	public void spawnMissile()
	{
		Vector2 spawnPosition = 
			transform.right * Random.Range (-spawnRange, spawnRange) + transform.position;

		float targetRange = spawnRange * 0.6f;
		Vector2 missileTarget = transform.right * Random.Range (-targetRange, targetRange);

		Vector2 missileDirection = missileTarget - spawnPosition;

		Quaternion missileRotation = Quaternion.LookRotation (missileDirection, Vector3.back);

		missileRotation.x = 0;
		missileRotation.y = 0;

		Instantiate (missileObject, spawnPosition, missileRotation);

	}

	public void spawnTank()
	{
		Vector2 spawnPosition = 
			transform.right * Random.Range (-spawnRange, spawnRange) + transform.position;
		Instantiate (tankObject, spawnPosition, transform.rotation);
	}
}
