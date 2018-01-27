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

	public int numberEquip = 0;
	public bool playBeep = true;
	// Use this for initialization
	void Start () {
        playerCollider = GetComponent<Collider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
      //  playerRigidBody.velocity = new Vector2(PlayerInput.Instance.MoveX, PlayerInput.Instance.MoveY);
	}
    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + (PlayerInput.Instance.MoveDirection * walk_speed * Time.fixedDeltaTime));
        anim.SetFloat("MoveX", PlayerInput.Instance.MoveX);
        anim.SetFloat("MoveY", PlayerInput.Instance.MoveY);
        if (PlayerInput.Instance.ActionButton)
        {
            SearchAction();
        }
        if (PlayerInput.Instance.TeleportButton)
        {
            anim.Play("anim_warp");
        }

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
            itemPego.BeTaken();
        }
    }

    private void PegarPart(PickupItem item)
    {
        Debug.Log("Peguei uma peça carai");
        item.BeTaken();
    }

    private void PegarAntena(PickupItem item)
    {
        Debug.Log("Peguei uma antena carai");
       // item.BeTaken();

    }

    private void PegarCapacete(PickupItem item)
    {
        Debug.Log("Peguei um capacete carai");
      //  item.BeTaken();

    }
    private void PegarConsole(PickupItem item)
    {
        Debug.Log("Peguei um console carai");
      //  item.BeTaken();

    }

    public void SearchAction()
    {
        Collider2D objetoPerto = Physics2D.OverlapCircle(transform.position, 1.6f, LayerMask.GetMask("ActionLayer"));
        if (objetoPerto != null)
        {
            if(objetoPerto.tag == "PickUpItem")
            {
                PegarItem(objetoPerto);
            }
        }
        else
        {
            Debug.Log("nada perto");
        }
    }

    private void Teleport()
    {
        transform.position = warpPoint.position;
        anim.SetTrigger("FinishTeleport");

    }
}
