using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CribPart : PickupItem {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void BeTaken()
    {
        IconsManagerUI.Instance.GetPart(this.Item);
        AudioManager.instance.ItemAudio();
        Destroy(gameObject);
    }
}
