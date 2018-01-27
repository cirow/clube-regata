using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour {

	public Canvas consoleCanvas;
	public Text hintText;
	public Text coordText;
	private GameObject player;
	void Awake()
	{
		consoleCanvas.enabled = false;
	}

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (consoleCanvas.enabled == true)
			{
				consoleCanvas.enabled = false;
			}
			else
			{
				consoleCanvas.enabled = true;
				//WriteCoordText();
			}

		}
	
		WriteCoordText();
	}

	void WriteCoordText()
	{
		hintText.text = "Hint = Bolo";
		Vector2 coordPos = new Vector2(player.transform.position.x, player.transform.position.y);
		coordText.text = "Coord (x;y) = " + (int)coordPos.x + " ; " + (int)coordPos.y;
	}

	
}
