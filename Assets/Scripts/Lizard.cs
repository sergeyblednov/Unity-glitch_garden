using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;

	void Start () 
	{
		attacker = gameObject.GetComponent<Attacker> ();
		animator = gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;

		if (!obj.GetComponent<Defender> ()) {
			return;
		}
			
		animator.SetBool ("isAttacking", true);
		attacker.Attack (obj);
	}
}
