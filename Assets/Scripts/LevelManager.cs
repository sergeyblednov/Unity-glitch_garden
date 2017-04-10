using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() 
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;		
	}

	void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode)
	{
		Debug.Log ("Loaded level: " + SceneManager.GetActiveScene().buildIndex);
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel() 
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

}
