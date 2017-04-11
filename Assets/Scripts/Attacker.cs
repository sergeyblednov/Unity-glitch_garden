using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Range(-1f, 1.5f)]
	public float currentSpeed;

	void Start () 
	{
		Rigidbody2D rigitbody = gameObject.AddComponent<Rigidbody2D> ();
		rigitbody.bodyType = RigidbodyType2D.Kinematic;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Debug.Log (name + " trigger enter");
	}

	public void SetSpeed(float speed) 
	{
		currentSpeed = speed;
	}
}
