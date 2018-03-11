using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		AudioManager.instance.WindAudio(false);
		AudioManager.instance.InterfAudio(false);
		AudioManager.instance.VictoryAudio(true);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
