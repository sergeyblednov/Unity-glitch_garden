using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find ("Defenders");
		if (!parent) {
			parent = new GameObject ("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () 
	{
		if (Button.selectedDefender) {
			Vector2 pos = SnapToGrip (CalculateWorldPointOfMouseClick ());
			GameObject defender = Instantiate (Button.selectedDefender, pos, Quaternion.identity);
			defender.transform.parent = parent.transform;
		}
	}

	#region Helpers methods

	Vector2 CalculateWorldPointOfMouseClick () 
	{
		return Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	Vector2 SnapToGrip(Vector2 rawWorldPos)
	{
		return new Vector2 (Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
	}

	#endregion
}
