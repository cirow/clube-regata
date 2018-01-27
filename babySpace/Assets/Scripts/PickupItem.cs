using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoItem {
    capacete, antena, console, motor, combustivel, espelho, vazio
}

public enum ItemDetectSound { motor, combustivel, espelho}

public class PickupItem : MonoBehaviour {

    [SerializeField]
    protected AudioClip audioEffect;
    protected Collider2D collisionRadius;

    [SerializeField]
    private TipoItem item;

    // Use this for initialization
    void Start () {
        collisionRadius = GetComponent<Collider2D>();
		
	}

    public TipoItem Item
    {
        get
        {
            return item;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void BeTaken()
    {
        Debug.Log("I just got taken!");
        Destroy(gameObject);
    }
}
