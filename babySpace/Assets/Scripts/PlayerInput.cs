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
    public bool game_is_started = false;

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
            if (canMove)
            {
                return moveX;
            }
            else
            {
                return 0f;
            }
        } 
    }
    public float MoveY
    {
        get
        {
            if (canMove)
            {
                return moveY;
            }
            else
            {
                return 0f;
            }
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

    public void FreezePlayer()
    {
        canMove = false;
    }

    public void UnfreezePlayer()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update () {
		if(canMove && game_is_started)
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
        if (actionButton && !game_is_started)
        {
            game_is_started = true;
            Controller2D.Player.Anim.SetTrigger("getUp");
            Controller2D.Player.Anim.SetLayerWeight(4, 1f);
            actionButton = false;
        }
        teleportButton = Input.GetKeyDown(KeyCode.T);


        //Debug.Log("MoveX: " + moveX);
        //Debug.Log("MoveY: " + moveY);


    }
}
