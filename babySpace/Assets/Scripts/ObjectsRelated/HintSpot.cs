using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSpot : MonoBehaviour {

	[SerializeField]
	protected AudioClip[] hintMusics;

	[SerializeField]
	public TipoItem item;

	AudioSource audioSource;
	public GameObject player;
	bool playHint = false;
	float maxDist;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		if(item == TipoItem.combustivel)
		{
			audioSource.clip = hintMusics[0];
		}
		else if(item == TipoItem.espelho)
		{
			audioSource.clip = hintMusics[1];
		}
		else if(item == TipoItem.motor)
		{
			audioSource.clip = hintMusics[2];
		}
		else
		{
			Debug.Log("Item tipo errado para hints");
		}		
		audioSource.volume = 0.5f;
	}

	public void PullTriggerEnter2D(Collider2D collision)
	{
		playHint = true;
		maxDist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
		//Debug.Log("distMax = " + Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)));
		//StartCoroutine(BeepInterval(endWaitTime));
		//PlayHintMusic();
		Debug.Log("Hint trigger enter");
	}
	public void PullTriggerExit2D(Collider2D collision)
	{
		playHint = false;
		Debug.Log("Hint trigger exit");
	}


	void PlayHintMusic(bool play)
	{
		if(play)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
			float auxDist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
			audioSource.volume = Mathf.Lerp(0.9f, 0f, (int)auxDist / maxDist);
			AudioManager.instance.InterVolume(Mathf.Lerp(0.7f, 0.0f, 1 - (int)auxDist / maxDist));
		}
		else
		{
			audioSource.Stop();
		}
	
	}
	/*
	IEnumerator BeepInterval(float waitTime)
	{
		while (player.GetComponent<Controller2D>().playBeep && beepRout)
		{
			if (audioSource.isPlaying)
			{
				audioSource.Stop();
				audioSource.Play();
			}
			else
			{
				audioSource.Play();
			}
			float auxDist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
			waitTime = Mathf.Lerp(startWaitTime, endWaitTime, 1 - (int)auxDist / maxDist);
			audioSource.volume = Mathf.Lerp(0.6f, 0.03f, (int)auxDist / maxDist);

			yield return new WaitForSeconds(waitTime);
		}
	}*/
	// Update is called once per frame
	void Update ()
	{
		PlayHintMusic(playHint);
	}
}
