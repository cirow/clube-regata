using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();		
		}
	}

	public void LoadLevel(string name)
	{
		Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);	
	}

	public void QuitRequest()
	{
		Debug.Log("Quit requested.");
		Application.Quit();
	}
}
