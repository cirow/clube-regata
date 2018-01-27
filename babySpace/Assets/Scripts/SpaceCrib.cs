using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCrib : MonoBehaviour {

    private bool hasMotor = false;
    private bool hasFuel = false;
    private bool hasMirror = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttachPart(TipoItem cribPart)
    {
        switch (cribPart)
        {
            case TipoItem.motor:
                hasMotor = true;
                Debug.Log("Got Motor");

                break;
            case TipoItem.combustivel:
                hasFuel = true;
                Debug.Log("Got Fuel");

                break;
            case TipoItem.espelho:
                hasMirror = true;
                Debug.Log("Got Mirror");
  
                break;
            default:
                Debug.Log("Error, not supported part");
                break;
        }
    }
}
