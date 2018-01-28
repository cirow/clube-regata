using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.GetComponentInParent<HintSpot>().PullTriggerEnter2D(collision);
		Debug.Log("Hint trigger enter");
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		gameObject.GetComponentInParent<HintSpot>().PullTriggerExit2D(collision);
	}
}
