using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconsManagerUI : MonoBehaviour {


	public Image motorIcon;
	public Image fuelIcon;
	public Image mirrorIcon;
	public Text posTextUI;

	public bool m_gotMotor;
	public bool m_gotFuel;
	public bool m_gotMirror;

	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
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
		posTextUI.text = "Pos: " + (int)player.transform.position.x + " ; " + (int)player.transform.position.y;
	}
		

}
