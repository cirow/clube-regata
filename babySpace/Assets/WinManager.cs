using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		AudioManager.instance.WindAudio(false);
		AudioManager.instance.BeepingAudio(false);
		AudioManager.instance.VictoryAudio(true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
