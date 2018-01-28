using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveManager : MonoBehaviour {

	public static NaveManager instance = null;

	public bool gotMotor = false;
	public bool gotCombustivel = false;
	public bool gotEspelho = false;

	public GameObject motorChild;
	public GameObject combChild;
	public GameObject espelhoChild;
	// Use this for initialization
	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			//print("Duplicated music player self-destructing!");
		}
		else
		{
			instance = this;
		}
	}

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void PutMotor()
	{

	}

	public void PutCombustivel()
	{

	}

	public void PutEspelho()
	{

	}
}
