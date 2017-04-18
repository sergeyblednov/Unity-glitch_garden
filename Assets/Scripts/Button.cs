using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttons;

	void Start () 
	{
		buttons = GameObject.FindObjectsOfType<Button> ();
		Text costText = GetComponentInChildren<Text> ();
		if (costText) {
				costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
		} else {
			Debug.LogWarning(name + " has no a cost text!");
		}

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
