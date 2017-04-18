using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

	void OnMouseDown()
	{
		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelManager.LoadLevel ("01a Start");
	}
}
