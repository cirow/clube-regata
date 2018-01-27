using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject mPlayer;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 cameraFollowPos = new Vector3(mPlayer.transform.position.x, mPlayer.transform.position.y, -10f);
		transform.position = cameraFollowPos;
	}
}
