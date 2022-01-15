using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public Transform shotSpawn;
	public GameObject projectile;
	public GameObject muzzleFlash;
	public float projectileSpeed;
	public float fireRate;

	public float muzzleFlashOffset;

	private float nextFire;
	private float myTime = 0f;
	
	// Update is called once per frame
	void Update () 
	{
		myTime = myTime + Time.deltaTime;

		if (Input.GetButtonDown("Fire1") && myTime > nextFire)
		{
			nextFire = myTime + fireRate;
			Instantiate (muzzleFlash, shotSpawn.position + muzzleFlashOffset*shotSpawn.up, UtilityFunctions.rotate90Degrees(shotSpawn.rotation));
			GameObject projectileInstance = Instantiate(projectile, shotSpawn.position, Quaternion.identity);
			Rigidbody2D projectileRigidb = projectileInstance.GetComponent<Rigidbody2D> ();

			projectileRigidb.velocity = transform.up * projectileSpeed;

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}


}
