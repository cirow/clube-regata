using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.GetComponentInParent<EquipBehavior>().PullTriggerEnter2D(collision);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		gameObject.GetComponentInParent<EquipBehavior>().PullTriggerExit2D(collision);
	}
}
