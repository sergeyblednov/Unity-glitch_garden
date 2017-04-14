using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

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

		if (obj.GetComponent<Stone> ()) {
			animator.SetTrigger ("jump trigger");
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
