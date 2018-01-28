using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letra : MonoBehaviour {

    private Rigidbody2D rigidBody;

    [SerializeField]
    private string valor_letra;

    [SerializeField]
    private float marginRight, marginLeft, marginUp, marginDown;
    private float maxX, maxY, minX, minY;

    RaycastHit2D hit;


    public string Valor_Letra
    {
        get
        {
            return valor_letra;
        }
    }


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

        maxX = transform.position.x + marginRight;
        minX = transform.position.x - marginLeft;
        maxY = transform.position.y + marginUp;
        minY = transform.position.y - marginDown;

    }
	
	// Update is called once per frame
	void Update () {
            Debug.DrawRay(transform.position + Vector3.right * 0.6f * PlayerInput.Instance.MoveX, Vector3.right * PlayerInput.Instance.MoveX, Color.red);

    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if((PlayerInput.Instance.MoveX != 0) && PlayerInput.Instance.MoveY == 0)
        {
            Vector3 mposition = new Vector3(transform.position.x + PlayerInput.Instance.MoveX, transform.position.y,transform.position.z);
            mposition.x = Mathf.Clamp(mposition.x, minX, maxX);

            hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.6f * PlayerInput.Instance.MoveX, transform.position.y), Vector2.right * PlayerInput.Instance.MoveX, .5f, LayerMask.GetMask("PuzzleBox"));

            if (hit.collider != null)
            {
                Debug.Log("Raycast Hit");
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                rigidBody.MovePosition(mposition);

            }
            //transform.Translate(Vector3.right * PlayerInput.Instance.MoveX);

        }
        else if ((PlayerInput.Instance.MoveY != 0) && PlayerInput.Instance.MoveX == 0)
        {
            Vector3 mposition = new Vector3(transform.position.x, transform.position.y + PlayerInput.Instance.MoveY, transform.position.z);
            mposition.y = Mathf.Clamp(mposition.y, minY, maxY);

            hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.6f * PlayerInput.Instance.MoveY), Vector2.up * PlayerInput.Instance.MoveY, .5f, LayerMask.GetMask("PuzzleBox"));

            if (hit.collider != null)
            {
                Debug.Log("Raycast Hit");
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                rigidBody.MovePosition(mposition);

            }
            //transform.Translate(Vector3.right * PlayerInput.Instance.MoveX);

        }
        //else if ((PlayerInput.Instance.MoveY != 0) && PlayerInput.Instance.MoveX == 0)
        //{
        //    Vector2 mposition = new Vector2(transform.position.x,transform.position.y + PlayerInput.Instance.MoveY);
        //    mposition.y = Mathf.Clamp(mposition.y, minY, maxY);

        //    rigidBody.MovePosition(mposition);
        //}
    }
}
