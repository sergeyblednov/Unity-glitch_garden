using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider)
	{
		Debug.Log (name + " trigger enter");
	}
}
