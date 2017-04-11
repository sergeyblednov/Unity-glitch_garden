using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		MusicManager manager = GameObject.FindObjectOfType<MusicManager> ();
		manager.SetVolume (PlayerPrefsManager.GetMasterVolume ());
	}
}
