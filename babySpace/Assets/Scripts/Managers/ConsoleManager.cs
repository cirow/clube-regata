using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour {

	public Canvas consoleCanvas;
	public Text hint1Text;
	public Text hint2Text;
	public Text hint3Text;
	public Text coordText;
	public bool isHint = false;
	private GameObject player;
	private PlayerInput playerInput;
	private Controller2D playerController;
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
		//if(isHint)
		//{
		//	if (consoleCanvas.enabled == true)
		//	{
		//		consoleCanvas.enabled = false;
		//		playerInput.canMove = true;
		//		isHint = false;
		//	}
		//	else
		//	{
		//		consoleCanvas.enabled = true;
		//		playerInput.canMove = false;
		//		isHint = false;
		//		//WriteCoordText();
		//	}
			
		//}
		//else
		//{
		//	if (consoleCanvas.enabled == true)
		//	{
		//		consoleCanvas.enabled = false;
		//		playerInput.canMove = true;
		//		isHint = false;
		//	}
		//	else
		//	{
		//		consoleCanvas.enabled = true;
		//		playerInput.canMove = false;
		//		isHint = false;
		//		//WriteCoordText();
		//	}
		//	WriteCoordText();
		//}

		if (consoleCanvas.enabled == true)
		{
			consoleCanvas.enabled = false;
			playerInput.canMove = true;
			//isHint = false;
		}
		else
		{
			consoleCanvas.enabled = true;
			playerInput.canMove = false;
			//isHint = false;
			//WriteCoordText();
		}
		WriteCoordText();

	}

	void WriteCoordText()
	{
		if(Controller2D.Player.gotHint1)
		{
			hint1Text.text =  "Hint 1 = Orange - (64:37)";
			
		}
		else
		{
			hint1Text.text = "Hint = Error 404";
		}
		if (Controller2D.Player.gotHint2)
		{
			hint2Text.text = "Hint 2 = 6134 - (50:4)";

		}
		else
		{
			hint2Text.text = "Hint = Error 404";
		}
		if (Controller2D.Player.gotHint3)
		{
			hint3Text.text = "Hint 3 = GGJ10Y - (12:12)";

		}
		else
		{
			hint3Text.text = "Hint = Error 404";
		}
		//hint1Text.text = "Hint = Error 404";
		Vector2 coordPos = new Vector2(player.transform.position.x, player.transform.position.y);
		coordText.text = "Current Pos (x:y) = " + (int)coordPos.x + " : " + (int)coordPos.y;
	}

	
}
