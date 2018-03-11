using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    private static QuestManager instance = null;



    public static QuestManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        if (PuzzleManager.Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Trying to instantiate 2 Puzzle Manager");
        }
		AudioManager.instance.WindAudio(true);

    }

    // Update is called once per frame
    void Update () {
		
	}



    public void OpenWall()
    {
        GameObject tempColliders = GameObject.FindGameObjectWithTag("ParentLimit");
        Destroy(tempColliders);
    }

    public void StageRadio()
    {
        OpenWall();
        AudioManager.instance.InterfAudio(true);
        IconsManagerUI.Instance.ShowObjective(1);


    }

    public void TodosOsEquips()
    {
        Controller2D.Player.teleportEnabled = true;
        
        StageRadio();
    }
}
