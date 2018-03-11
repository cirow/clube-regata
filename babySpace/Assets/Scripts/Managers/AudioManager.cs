using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance = null;

	public AudioClip[] backgroundAudios;
	public AudioClip[] detectAudios;
	public AudioClip interfAudio;
    public AudioClip gotItem;
	public bool win;
	public bool dontHaveEquip;

	private AudioSource[] audioSources;
	private LevelManager levelManager;

	void Awake()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			//Leave here just in case we need after
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start ()
	{
		levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
		audioSources = GetComponents<AudioSource>();	
		if(audioSources.Length >= 2)
		{
			Debug.Log("audio sources ok");
		}
		else
		{
			Debug.Log("error getting audio sources");
		}
		VictoryAudio(true);
	}



	public void WindAudio(bool play)
	{
		if(audioSources[1].isPlaying)
		{
			audioSources[1].Stop();
			Debug.Log("stop victory start wind");
		}
		if (play)
		{
			audioSources[0].clip = backgroundAudios[0];
			audioSources[0].volume = 0.5f;
			if (audioSources[0].isPlaying)
			{
				audioSources[0].Stop();
				audioSources[0].Play();
			}
			else
			{
				audioSources[0].Play();
			}
		}
		else
		{
			Debug.Log("wind audio off");
			if (audioSources[0].clip == null)
			{
				//do nothing
			}
			else
			{
				audioSources[0].Stop();
			}
		}
	}

	public void VictoryAudio(bool play)
	{
		if (audioSources[0].isPlaying)
		{
			Debug.Log("stop wind start victory");
			audioSources[0].Stop();
		}
		if (play)
		{
			Debug.Log("victory audio on");
			audioSources[1].clip = backgroundAudios[1];
			if (audioSources[1].isPlaying)
			{
				audioSources[1].Stop();
				audioSources[1].Play();
			}
			else
			{
				audioSources[1].Play();
			}
		}
		else
		{
			Debug.Log("victory audio off");
			if (audioSources[1].clip == null)
			{
				//do nothing
			}
			else
			{
				audioSources[1].Stop();
			}
		}
	}

	public void InterfAudio(bool play)
	{
		if (play)
		{
			audioSources[2].clip = interfAudio;
			if (audioSources[2].isPlaying)
			{
				audioSources[2].Stop();
				audioSources[2].Play();
				audioSources[2].volume = 0.5f;
			}
			else
			{

				audioSources[2].Play();
			}
		}
		else
		{
			Debug.Log("interf audio off");
			if (audioSources[2].clip == null)
			{
				//do nothing
			}
			else
			{
				audioSources[2].Stop();
			}
		}
	}

    public void ItemAudio()
    {
        audioSources[3].PlayOneShot(gotItem);
    }

    public void InterVolume(float vol)
    {
        if(audioSources[2].isPlaying)
        {
            audioSources[2].volume = vol;
        }
    }

	void Update ()
	{
		if(win)
		{
			levelManager.LoadLevel("Win");
			win = false;
		}
	}
}
