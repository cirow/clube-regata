using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private bool isPressed;
    [SerializeField]
    private int rock_number;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateSwitch()
    {
        PuzzleManager.Instance.RockPuzzle(rock_number);
        Debug.Log("Activate Switch");
    }


}
