﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}

	void OnLevelWasLoaded (int level)
	{
		AudioClip clip = levelMusicChangeArray [level];
		if (clip) {
			audioSource.clip = clip;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void SetVolume (float volume)
	{
		audioSource.volume = volume;
	}
}
