using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttons;

	void Start () 
	{
		buttons = GameObject.FindObjectsOfType<Button> ();
	}

	void OnMouseDown() 
	{
		foreach (Button button in buttons) {
			button.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
