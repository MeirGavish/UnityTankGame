using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseTracker : MonoBehaviour 
{
	public Text mousePositionText;

	void Start ()
	{
		updateMousePosText ();
	}

	// Update is called once per frame
	void Update () 
	{
		updateMousePosText ();
	}

	void updateMousePosText()
	{
		Vector3 worldPointMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		mousePositionText.text = 
			"Mouse Position\n" +
			"X: " + Input.mousePosition.x + "\n" +
			"Y: " + Input.mousePosition.y + "\n" +
			"Z: " + Input.mousePosition.z + "\n\n" +
			"World Point\n" + 
			"X: " + worldPointMousePos.x + "\n" +
			"Y: " + worldPointMousePos.y + "\n" +
			"Z: " + worldPointMousePos.z;
			
	}
}
