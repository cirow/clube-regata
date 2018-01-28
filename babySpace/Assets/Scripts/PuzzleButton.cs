using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour {

    public string correct_key;
    public bool key_is_correct = false;

    public string inserted_key = "a";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision started");
        if(collider.tag == "Letra")
        {
            Debug.Log("É uma letra");

            InsertKey(collider.gameObject.GetComponent<Letra>());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        key_is_correct = false;
    }

    private void InsertKey(Letra letra)
    {
        if (letra.Valor_Letra == correct_key)
        {
            key_is_correct = true;
            Debug.Log("Key is correta");
            PuzzleManager.Instance.CheckPuzzleLetras();
        }
    }

    public bool IsKeyCorrect()
    {
        return key_is_correct;
    }
}
