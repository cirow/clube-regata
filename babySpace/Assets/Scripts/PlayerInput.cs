using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput Instance = null;

    private float moveX;
    private float moveY;
    private bool actionButton;
    private bool teleportButton;
	// Use this for initialization
	void Start () {
        if(PlayerInput.Instance == null)
        {
            PlayerInput.Instance = this;
        }
        else
        {
            Debug.Log("Trying to instantiate 2 PlayerInput Instances");
            Destroy(this);
        }


        moveX = 0;
        moveY = 0;
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
		moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        actionButton = Input.GetButtonDown("Jump");
        teleportButton = Input.GetKeyDown(KeyCode.T);


        //Debug.Log("MoveX: " + moveX);
        //Debug.Log("MoveY: " + moveY);


    }
}
