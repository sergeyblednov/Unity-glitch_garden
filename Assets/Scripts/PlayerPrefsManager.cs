using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume) 
	{
		if (volume >= 0 && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Volume value is out of the range");
		}
	}

	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockedLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError ("Try to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked (int level) 
	{
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Level index not in build order");
			return false;
		}
	}

	public static void SetDifficulty(float value)
	{
		if (value >= 1f && value <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, value);
		} else {
			Debug.LogError ("Difficulty value is out of the range");
		}
	}

	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
