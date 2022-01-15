using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions : MonoBehaviour {

	public static Quaternion rotate90Degrees(Quaternion quaternion)
	{
		Vector3 angles = quaternion.eulerAngles;
		angles.z -= 90;
		return Quaternion.Euler (angles);
	}

	public static Quaternion keepIn2D(Quaternion quaternion)
	{
		quaternion.x = 0;
		quaternion.y = 0;
		return quaternion;

//		Vector3 angles = quaternion.eulerAngles;
//		angles.y = 0;
//		angles.x = 0;
//
//
//		return Quaternion.Euler (angles);
	}
}
