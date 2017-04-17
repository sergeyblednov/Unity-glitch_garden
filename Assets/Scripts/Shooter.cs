using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator animator;
	private AttackerSpawner laneSpawner;

	void Start () 
	{
		animator = GetComponent<Animator> ();
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		SetLaneSpawner ();
	}

	void Update () 
	{
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private void Fire ()
	{
		GameObject newProjectile = Instantiate (projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	private bool IsAttackerAheadInLane ()
	{
		if (laneSpawner.transform.childCount <= 0) {
			return false;
		}

		foreach (Transform attacker in laneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}

		return false;
	}

	private void SetLaneSpawner ()
	{
		AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner> ();
		foreach (AttackerSpawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
				return;
			}
		}
		if (!laneSpawner) {
			Debug.LogError ("There is no spawner in the lane");
		}
	}
}
