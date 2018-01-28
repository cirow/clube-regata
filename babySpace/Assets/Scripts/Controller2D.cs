using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {



    [SerializeField]
    private float walk_speed;
    [SerializeField]
    private Transform warpPoint;

    private Collider2D playerCollider;
    private Rigidbody2D playerRigidBody;
    private Animator anim;
    public TipoItem cribPart = TipoItem.vazio;

	public int numberEquip = 0;
	public bool playBeep = true;

    private float mfaceX = 1;
    private float mfaceY = 1;
	private ConsoleManager consoleManager;
    // Use this for initialization
    void Start () {
        playerCollider = GetComponent<Collider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		consoleManager = GameObject.FindGameObjectWithTag("ConsoleManager").GetComponent<ConsoleManager>();
	}


    public TipoItem GetCribPart
    {
        get {
            return cribPart;
        }
    }
	
	// Update is called once per frame
	void Update () {
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
		if (PlayerInput.Instance.TeleportButton)
		{
			anim.Play("anim_warp");
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
		GameObject tempColliders = GameObject.FindGameObjectWithTag("Limit");
		Destroy(tempColliders);
		AudioManager.instance.InterfAudio(true);
	}

private void PegarItem(Collider2D collision)
    {
        if(collision.tag == "PickUpItem")
        {
            PickupItem itemPego = collision.gameObject.GetComponent<PickupItem>();

            switch (itemPego.Item) {
                case TipoItem.antena:
					numberEquip++;
					if (numberEquip >= 3)
					{
						playBeep = false;
						GotAllEquips();
					}
					PegarAntena(itemPego);
                    break;

                case TipoItem.capacete:
					numberEquip++;
					gameObject.GetComponent<PlayerInput>().canMove = true;
					if (numberEquip >= 3)
					{
						playBeep = false;
						GotAllEquips();
					}
					PegarCapacete(itemPego);
                    break;
                case TipoItem.console:
					numberEquip++;
					if(numberEquip >= 3)
					{

						playBeep = false;
						GotAllEquips();
					}
                    PegarConsole(itemPego);
                    break;
                default:
                    PegarPart(itemPego);
                    break;

            }
        }
    }

    private void PegarPart(PickupItem item)
    {
        if(cribPart == TipoItem.vazio)
        {
            Debug.Log("Peguei uma peça carai");
            cribPart = item.Item;
            item.BeTaken();
        }

    }

    private void PegarAntena(PickupItem item)
    {
        Debug.Log("Peguei uma antena carai");
        item.BeTaken();

    }

    private void PegarCapacete(PickupItem item)
    {
        Debug.Log("Peguei um capacete carai");
        item.BeTaken();

    }
    private void PegarConsole(PickupItem item)
    {
        Debug.Log("Peguei um console carai");
        item.BeTaken();

    }


	public void SearchHint()
	{
		Collider2D objetoPerto = Physics2D.OverlapCircle(transform.position, 1.6f, LayerMask.GetMask("ActionLayer"));
		if (objetoPerto != null && objetoPerto.tag == "HintSpot")
		{
			Debug.Log("HintSpot");
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
        if (objetoPerto != null)
        {
			//if(objetoPerto.tag == "HintSpot")
			//{
			//	Debug.Log("HintSpot");
			//	ShowHint(objetoPerto.GetComponent<HintSpot>());
			//}
           // else
		    if (objetoPerto.tag == "PickUpItem")
            {
				Debug.Log("aliwh: " + objetoPerto.tag);
                PegarItem(objetoPerto);
            }
            else if(objetoPerto.tag == "SpaceCrib")
            {
                ActionNave(objetoPerto.GetComponent<SpaceCrib>());
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
			//consoleManager.consoleCanvas.enabled = true;
			consoleManager.hintText.text = "Hint = Purple";
			consoleManager.coordText.text = "Coord (x:y) = 40:60";
			
		}
		else if(hintSpot.item == TipoItem.espelho)
		{
			consoleManager.isHint = true;
			consoleManager.hintText.text = "Hint = 6134";
			consoleManager.coordText.text = "Coord (x:y) = 50:100";
			//consoleManager.consoleCanvas.enabled = true;
		}
		else if(hintSpot.item == TipoItem.combustivel)
		{
			consoleManager.isHint = true;
			consoleManager.hintText.text = "Hint = Happy Bday";
			consoleManager.coordText.text = "Coord (x:y) = 10:10";
			//consoleManager.consoleCanvas.enabled = true;
		}
		else
		{
			Debug.Log("Tipo de hint errado");
		}
		consoleManager.OpenConsole();
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
        transform.position = warpPoint.position;
        anim.SetTrigger("FinishTeleport");

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
}
