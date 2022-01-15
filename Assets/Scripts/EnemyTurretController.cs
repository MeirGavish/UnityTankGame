using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : MonoBehaviour {

	public float waitBeforeBeginShooting;
	public float shootingInterval;
	public float projectileSpeed;
	public float muzzleFlashOffset;

	public Transform shotSpawn;
	//private GameObject player;
	public GameObject projectile;
	public GameObject muzzleFlash;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (shootCoroutine ());
	}
	
	// Update is called once per frame
	void Update () {
		pointAtPlayer ();
	}

	void pointAtPlayer()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null)
			return;
		Vector3 enemyToPlayer = player.transform.position - transform.position;
		Quaternion newRotation = Quaternion.LookRotation (enemyToPlayer, Vector3.back);
		newRotation = UtilityFunctions.keepIn2D (newRotation);
		transform.rotation = newRotation;
	}

	IEnumerator shootCoroutine()
	{
		yield return new WaitForSeconds (waitBeforeBeginShooting);


		while (true) 
		{
			Instantiate (muzzleFlash, shotSpawn.position + muzzleFlashOffset * shotSpawn.up, UtilityFunctions.rotate90Degrees (shotSpawn.rotation));
			GameObject projectileInstance = Instantiate (projectile, shotSpawn.position, Quaternion.identity);
			Rigidbody2D projectileRigidb = projectileInstance.GetComponent<Rigidbody2D> ();

			projectileRigidb.velocity = transform.up * projectileSpeed;

			yield return new WaitForSeconds (shootingInterval);
		}
	}
}
