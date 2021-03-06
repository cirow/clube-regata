﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {


    private static Controller2D player = null;

    [SerializeField]
    private float walk_speed;
    [SerializeField]
    private Transform warpPoint;
    [SerializeField]
    private SpriteRenderer helpPopUp;

    [SerializeField]
    private SpriteRenderer equipBaloon;
    [SerializeField]
    private SpriteRenderer pipBaloon;
	[SerializeField]
	private SpriteRenderer teleportBaloon;

	private Collider2D playerCollider;
    private Rigidbody2D playerRigidBody;
    private Animator anim;
    public TipoItem cribPart = TipoItem.vazio;

    public bool gotHelmet, gotAntena, gotPip = false;
	public bool gotHint1, gotHint2, gotHint3 = false;
	public bool teleportEnabled = false;
	public int numberEquip = 0;
	public bool playBeep = true;

    private float mfaceX = 1;
    private float mfaceY = 1;
	private ConsoleManager consoleManager;
    // Use this for initialization
    void Start () {

        if(Controller2D.Player == null)
        {
            player = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("Error, trying to instantiate 2 players");
        }


        playerCollider = GetComponent<Collider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		consoleManager = GameObject.FindGameObjectWithTag("ConsoleManager").GetComponent<ConsoleManager>();
        equipBaloon.enabled = false;
		
	}


    public static Controller2D Player
    {
        get
        {
            return player;
        }
    }

    public TipoItem GetCribPart
    {
        get {
            return cribPart;
        }
    }
	
    public Animator Anim
    {
        get
        {
            return anim;
        }
    }
	// Update is called once per frame
	void Update ()
	{
        //  playerRigidBody.velocity = new Vector2(PlayerInput.Instance.MoveX, PlayerInput.Instance.MoveY);

        //anim.SetFloat("MoveX", PlayerInput.Instance.MoveX);
        //anim.SetFloat("MoveY", PlayerInput.Instance.MoveY);

        if ((PlayerInput.Instance.MoveX != 0) || (PlayerInput.Instance.MoveY != 0))
        {
            anim.SetBool("walking", true);
            anim.SetFloat("MoveX", PlayerInput.Instance.MoveX);
            anim.SetFloat("MoveY", PlayerInput.Instance.MoveY);
            UpdateFace();


        }
        else
        {
            anim.SetBool("walking", false);

        }
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			SearchHint();
		}
		if (PlayerInput.Instance.ActionButton)
		{
			SearchAction();
		}
		if (PlayerInput.Instance.TeleportButton && teleportEnabled)
		{
            StartTeleport();
		}


	}
	private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + (PlayerInput.Instance.MoveDirection * walk_speed * Time.fixedDeltaTime));
	}

	void GotAllEquips ()
	{
		//Tem todo o equipamento entao toca o audio da interferencia
		//Destroi colisores que limitam o inicio

        SelecionarLayerWeight(0);
        QuestManager.Instance.TodosOsEquips();


    }

    public bool AllEquips()
    {
        if(gotPip && gotHelmet && gotAntena)
        {
			
            return true;
        }
        return false;
    }



    private void PegarItem(Collider2D collision)
    {
        if(collision.tag == "PickUpItem")
        {
            PickupItem itemPego = collision.gameObject.GetComponent<PickupItem>();

            switch (itemPego.Item) {
                case TipoItem.antena:
					numberEquip++;
                    //gotAntena = true;
                    PegarAntena(itemPego);
                    if (AllEquips())
					{
						playBeep = false;
						GotAllEquips();
					}
                    break;

                case TipoItem.capacete:
					numberEquip++;
                    //gotHelmet = true;
					gameObject.GetComponent<PlayerInput>().canMove = true;
                    PegarCapacete(itemPego);

                    if (AllEquips())
					{
						playBeep = false;
						GotAllEquips();
					}
                    break;
                case TipoItem.console:
					numberEquip++;
                    //gotPip = true;
                    PegarConsole(itemPego);

                    if (AllEquips())
					{

						playBeep = false;
						GotAllEquips();
					}
                    break;
                default:
                    PegarPart(itemPego);
                    break;

            }
        }
    }

    public void PegarPart(PickupItem item)
    {
        if(cribPart == TipoItem.vazio)
        {
           // Debug.Log("Peguei uma peça carai");
            cribPart = item.Item;
            item.BeTaken();
			teleportBaloon.enabled = true;
        }

    }

    private void PegarAntena(PickupItem item)
    {
        // Debug.Log("Peguei uma antena carai");
        gotAntena = true;
        item.BeTaken();
        AtualizarSprites();


    }

    private void PegarCapacete(PickupItem item)
    {
        //  Debug.Log("Peguei um capacete carai");
        gotHelmet = true;
        anim.SetLayerWeight(4, 0f);
        anim.SetLayerWeight(2, 1f);
        helpPopUp.enabled = false;
        item.BeTaken();
        AtualizarSprites();

    }

    private void Levantar()
    {

    }
    private void PegarConsole(PickupItem item)
    {
        //  Debug.Log("Peguei um console carai");
        gotPip = true;
        item.BeTaken();
        AtualizarSprites();


    }

    private void AtualizarSprites()
    {
        if (gotHelmet)
        {
            if (gotAntena)
            {
                if (gotPip)
                {
                    SelecionarLayerWeight(0);
                }
                else
                {
                    SelecionarLayerWeight(3);
                }
            }
            else
            {
                if (gotPip)
                {
                    SelecionarLayerWeight(1);
                }
                else
                {
                    SelecionarLayerWeight(2);
                }
            }
        }
        else
        {
            SelecionarLayerWeight(4);
        }
    }

    private void SelecionarLayerWeight(int layer_index)
    {
        for (int i = 1; i <= 4; i++) // zera todos os layers
        {
            anim.SetLayerWeight(i, 0f);
        }
        if (layer_index <= 4 && layer_index > 0)
        {

            anim.SetLayerWeight(layer_index, 1f); // seta o desejado
        }
    }


	public void SearchHint()
	{
		Collider2D objetoPerto = Physics2D.OverlapCircle(transform.position, 1.6f, LayerMask.GetMask("ActionLayer"));
		if (objetoPerto != null && objetoPerto.tag == "HintSpot")
		{
			//Debug.Log("HintSpot");
			ShowHint(objetoPerto.GetComponent<HintSpot>());
		}
		else
		{
			consoleManager.isHint = false;
			consoleManager.OpenConsole();
		}
	}

    public void SearchAction()
    {
        Collider2D objetoPerto = Physics2D.OverlapCircle(transform.position, 1.6f, LayerMask.GetMask("ActionLayer"));
        if (objetoPerto != null && PlayerInput.Instance.game_is_started)
        {
			//if(objetoPerto.tag == "HintSpot")
			//{
			//	Debug.Log("HintSpot");
			//	ShowHint(objetoPerto.GetComponent<HintSpot>());
			//}
           // else
		    if (objetoPerto.tag == "PickUpItem")
            {
				//Debug.Log("aliwh: " + objetoPerto.tag);
                PegarItem(objetoPerto);
            }
            else if(objetoPerto.tag == "SpaceCrib")
            {
                ActionNave(objetoPerto.GetComponent<SpaceCrib>());
            }
            else if (objetoPerto.tag == "RockSwitch")
            {
                RockPress(objetoPerto.GetComponent<Rock>());
            }

        }
        else
        {
            Debug.Log("nada perto");
        }
    }

	void ShowHint(HintSpot hintSpot)
	{
		
		if (hintSpot.item == TipoItem.motor)
		{
			consoleManager.isHint = true;
			gotHint1 = true;
			//consoleManager.consoleCanvas.enabled = true;
			//consoleManager.hintText.text = "Hint = Orange";
			//consoleManager.coordText.text = "Coord (x:y) = 64:37";
			//consoleManager.OpenConsole();

		}
		else if(hintSpot.item == TipoItem.espelho)
		{
			consoleManager.isHint = true;
			gotHint2 = true;
			//consoleManager.hintText.text = "Hint = 6134";
			//consoleManager.coordText.text = "Coord (x:y) = 50:4";
			//consoleManager.consoleCanvas.enabled = true;
			//consoleManager.OpenConsole();
		}
		else if(hintSpot.item == TipoItem.combustivel)
		{
			consoleManager.isHint = true;
			gotHint3 = true;
			//consoleManager.hintText.text = "Hint = GGJ10Y";
			//consoleManager.coordText.text = "Coord (x:y) = 12:12";
			//consoleManager.consoleCanvas.enabled = true;
			//consoleManager.OpenConsole();
		}
		else
		{
			Debug.Log("Tipo de hint errado");
		}
		consoleManager.OpenConsole();
	}

    private void RockPress(Rock pedra)
    {
        //Debug.Log("Pedra action");
        pedra.ActivateSwitch();
    }


    private void ActionNave(SpaceCrib nave)
    {
        if (cribPart != TipoItem.vazio)
        {
            nave.AttachPart(cribPart);

            cribPart = TipoItem.vazio;
        }
    }

    private void Teleport()
    {
      //  transform.localScale = new Vector2(1, 1);
        transform.position = warpPoint.position;
		teleportBaloon.enabled = false;
       // transform.localScale = new Vector2(1, 10f);
        anim.Play("anim_warp_reverse");


    }

    private void EndTeleport()
    {
        anim.SetTrigger("FinishTeleportAnimation");
        playerCollider.enabled = true;
        PlayerInput.Instance.UnfreezePlayer();
        teleportEnabled = true;


    }

    private void StartTeleport()
    {
        anim.Play("anim_warp");
        PlayerInput.Instance.FreezePlayer();
        playerCollider.enabled = false;
        teleportEnabled = false;

    }
    private void StartScaleTeleport(float y_scl)
    {
        transform.localScale = new Vector3(1, Mathf.Lerp(transform.localScale.y, y_scl, 1f), 1);

    }

    private void StopScaleTeleport(float step)
    {
        transform.localScale = new Vector3(1, Mathf.Lerp(transform.localScale.y, 1f, step), 1);

    }

    //private IEnumerator ScaleTeleport(float y_value)
    //{
    //    transform.localScale = new Vector3(1, Mathf.Lerp(transform.localScale.y, 10f, 0.5f), 1);

    //    yield return new WaitForFixedUpdate();
    //}

    public void PlayWarpSound()
    {
        GetComponent<AudioSource>().Play();
    }

    private void UpdateFace()
    {

        if(PlayerInput.Instance.MoveX == 1)
        {
            mfaceX = 1;
        }
        else if(PlayerInput.Instance.MoveX == -1)
        {
            mfaceX = -1;
        }

        if (PlayerInput.Instance.MoveY == 1)
        {
            mfaceY = 1;
        }
        else if (PlayerInput.Instance.MoveY == -1)
        {
            mfaceY = -1;
        }

        if(PlayerInput.Instance.MoveX != 0 && PlayerInput.Instance.MoveY == 0)
        {
            mfaceX = PlayerInput.Instance.MoveX;
            mfaceY = -1;
        }

        anim.SetFloat("faceX", mfaceX);
        anim.SetFloat("faceY", mfaceY);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Limit")
        {
            equipBaloon.enabled = true;
        }
    }



    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Limit")
        {
            equipBaloon.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "baloonTrig")
        {
            pipBaloon.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "baloonTrig")
        {
            pipBaloon.enabled = false;
        }
    }
}