using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCrib : MonoBehaviour {

    private bool hasMotor = false;
    private bool hasFuel = false;
    private bool hasMirror = false;



	public GameObject motorChild;
	public GameObject combChild;
	public GameObject espelhoChild;
	public AudioClip attachFx;

	private AudioSource audioSource;


	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hasMotor && hasFuel && hasMirror)
		{
			AudioManager.instance.win = true;
		}
	}

    public void AttachPart(TipoItem cribPart)
    {
        switch (cribPart)
        {
            case TipoItem.motor:
                hasMotor = true;
				PutMotor();
                Debug.Log("Got Motor");

                break;
            case TipoItem.combustivel:
                hasFuel = true;
				PutCombustivel();
                Debug.Log("Got Fuel");

                break;
            case TipoItem.espelho:
                hasMirror = true;
				PutEspelho();
                Debug.Log("Got Mirror");
  
                break;
            default:
                Debug.Log("Error, not supported part");
                break;
        }
		audioSource.PlayOneShot(attachFx); 
    }

	public void PutMotor()
	{
		hasMotor = true;
		motorChild.GetComponent<SpriteRenderer>().enabled = true;
		IconsManagerUI.Instance.MarkMotor();
	}

	public void PutCombustivel()
	{
		hasFuel = true;
		combChild.GetComponent<SpriteRenderer>().enabled = true;
		IconsManagerUI.Instance.MarkFuel();
	}

	public void PutEspelho()
	{
		hasMirror = true;
		espelhoChild.GetComponent<SpriteRenderer>().enabled = true;
		IconsManagerUI.Instance.MarkMirror();
	}


}
