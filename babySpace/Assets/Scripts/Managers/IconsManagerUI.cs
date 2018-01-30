using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconsManagerUI : MonoBehaviour {


    public static IconsManagerUI instance = null;

	public  Image motorIcon;
	public  Image fuelIcon;
	public  Image mirrorIcon;
	public Image motorMark;
	public Image fuelMark;
	public Image mirrorMark;
	public  Text posTextUI;
	public Text ajudaDosNoob;

	public bool m_gotMotor = false;
	public bool m_gotFuel = false;
	public bool m_gotMirror = false;

	private GameObject player;

	// Use this for initialization
	void Start ()
	{
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("Trying to create 2 IconManager");
        }

		player = GameObject.FindGameObjectWithTag("Player");
	}


    public static IconsManagerUI Instance
    {
        get
        {
            return instance;
        }
    }

	public void MarkMirror()
	{
		mirrorMark.GetComponent<Image>().enabled = true;
	}
	public void MarkMotor()
	{
		motorMark.GetComponent<Image>().enabled = true;
	}
	public void MarkFuel()
	{
		fuelMark.GetComponent<Image>().enabled = true;
	}

	public void GetPart(TipoItem part)
    {
        switch (part)
        {
            case TipoItem.motor:
                Debug.Log("Motor");
                m_gotMotor = true;
                break;

            case TipoItem.combustivel:
                Debug.Log("fuel");
                m_gotFuel = true;
                break;

            case TipoItem.espelho:
                Debug.Log("mirror");

                m_gotMirror = true;
                break;

            default:
                Debug.Log("Erro! Objeto não é uma parte da nave!");
                break;
        }
    }

	public void ShowObjective(int index)
	{
		if(index == 0)
		{
			ajudaDosNoob.text = "Objective: Find all your equipment.";
		}
		else if(index == 1)
		{
			ajudaDosNoob.text = "Objective: Solve the puzzles to find the missing parts of the ship and then place them back.\nYou can find hints in the map to help.";
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(m_gotMotor)
		{
			motorIcon.color = Color.white;
		}
		else
		{
			motorIcon.color = Color.black;
		}
		if (m_gotFuel)
		{
			fuelIcon.color = Color.white;
		}
		else
		{
			fuelIcon.color = Color.black;
		}
		if (m_gotMirror)
		{
			mirrorIcon.color = Color.white;
		}
		else
		{
			mirrorIcon.color = Color.black;
		}
		posTextUI.text = "Pos = " + (int)player.transform.position.x + " : " + (int)player.transform.position.y;
	}
		

}
