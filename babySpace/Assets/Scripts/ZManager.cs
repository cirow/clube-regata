using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.00001f * transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
