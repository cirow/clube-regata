using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private static PlayerInput instance = null;

    private float moveX;
    private float moveY;
    private bool actionButton;
    private bool teleportButton;
	// Use this for initialization
	public bool canMove = false;

	void Start () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Trying to instantiate 2 PlayerInput Instances");
            Destroy(this);
        }


        moveX = 0;
        moveY = 0;
	}

    public static PlayerInput Instance
    {
        get
        {
            return instance;
        }
    }

    public Vector2 MoveDirection
    {
        get
        {
            return new Vector3(PlayerInput.Instance.MoveX, PlayerInput.Instance.MoveY);
        }
    }

    public float MoveX
    {
        get
        {
            return moveX;
        } 
    }
    public float MoveY
    {
        get
        {
            return moveY;
        }
    }

    public bool ActionButton
    {
        get
        {
            return actionButton;
        }
    }

    public bool TeleportButton
    {
        get
        {
            return teleportButton;
        }
    }

    // Update is called once per frame
    void Update () {
		if(canMove)
		{
			moveX = Input.GetAxisRaw("Horizontal");
			moveY = Input.GetAxisRaw("Vertical");
		}
		else
		{
			moveX = 0;
			moveY = 0;
		}
        actionButton = Input.GetButtonDown("Jump");
        teleportButton = Input.GetKeyDown(KeyCode.T);


        //Debug.Log("MoveX: " + moveX);
        //Debug.Log("MoveY: " + moveY);


    }
}
