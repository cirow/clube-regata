using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour {

	public Canvas consoleCanvas;
	public Text hintText;
	public Text coordText;
	public bool isHint = false;
	private GameObject player;
	private PlayerInput playerInput;
	void Awake()
	{
		consoleCanvas.enabled = false;
	}

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerInput = player.GetComponent<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		
	}

	public void OpenConsole()
	{
		if(isHint)
		{
			if (consoleCanvas.enabled == true)
			{
				consoleCanvas.enabled = false;
				playerInput.canMove = true;
				isHint = false;
			}
			else
			{
				consoleCanvas.enabled = true;
				playerInput.canMove = false;
				isHint = false;
				//WriteCoordText();
			}
			
		}
		else
		{
			if (consoleCanvas.enabled == true)
			{
				consoleCanvas.enabled = false;
				playerInput.canMove = true;
				isHint = false;
			}
			else
			{
				consoleCanvas.enabled = true;
				playerInput.canMove = false;
				isHint = false;
				//WriteCoordText();
			}
			WriteCoordText();

		}
		
	}

	void WriteCoordText()
	{
		hintText.text = "Hint = Error 404";
		Vector2 coordPos = new Vector2(player.transform.position.x, player.transform.position.y);
		coordText.text = "Coord (x:y) = " + (int)coordPos.x + " : " + (int)coordPos.y;
	}

	
}
