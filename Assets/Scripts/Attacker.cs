﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Time then every attacker can seen in seconds")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	void Start () 
	{
		animator = gameObject.GetComponent<Animator> ();
	}

	void Update () 
	{
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
	}

	public void SetSpeed(float speed) 
	{
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage)
	{
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}

	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}
}
