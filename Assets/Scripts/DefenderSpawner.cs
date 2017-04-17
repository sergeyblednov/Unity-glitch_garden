using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarsDisplay starsDislay;

	// Use this for initialization
	void Start () {

		starsDislay = GameObject.FindObjectOfType<StarsDisplay> ();
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
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender> ().starCost;
		bool enoughtStars = starsDislay.UseStars (defenderCost) == StarsDisplay.Status.SUCCESS;
		if (defender && enoughtStars) {				
			Vector2 pos = SnapToGrip (CalculateWorldPointOfMouseClick ());
			SpawnDefender (pos, defender);
		} else {
			Debug.Log ("Insufficient stars");
		}
			
	}

	void SpawnDefender (Vector2 pos, GameObject defender)
	{
		GameObject newDefender = Instantiate (defender, pos, Quaternion.identity);
		newDefender.transform.parent = parent.transform;
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
