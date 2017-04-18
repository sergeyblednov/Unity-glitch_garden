using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.gameObject.GetComponent<Attacker> ()) {
			animator.SetTrigger ("underAttack trigger");
		}
	}
}
