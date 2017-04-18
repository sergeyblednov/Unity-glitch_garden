using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Slider))]
public class GameTimer : MonoBehaviour {

	public float levelSeconds = 10f;
	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winLabel;
	private bool isEndOfLevel = false;

	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		slider = GetComponent <Slider> ();
		audioSource = GetComponent<AudioSource> ();

		SetupWinLabel ();
	}

	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = Time.timeSinceLevelLoad >= levelSeconds;
		if (timeIsUp && !isEndOfLevel) {
			isEndOfLevel = true;
			winLabel.SetActive (true);
			audioSource.Play ();
			Invoke ("LoadNextLevel", audioSource.clip.length);
		}
	}

	void SetupWinLabel ()
	{
		winLabel = GameObject.Find ("You win");
		if (!winLabel) {
			Debug.LogWarning ("There is no You win label");
		} else {
			winLabel.SetActive (false);
		}
	}

	void LoadNextLevel() 
	{
		levelManager.LoadNextLevel ();
	}

}
