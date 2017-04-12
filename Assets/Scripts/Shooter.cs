﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject projectileParent;
	public GameObject gun;

	private void Fire ()
	{
		GameObject newProjectile = Instantiate (projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
