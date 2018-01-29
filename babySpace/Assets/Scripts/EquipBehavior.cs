using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipBehavior : PickupItem
{
	AudioSource audioSource;
	public GameObject player;
	bool beepRout = false;
	float startWaitTime = 0.3f;
	float endWaitTime = 0.05f;
	float maxDist;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioEffect;
		audioSource.volume = 0.5f;
	}

	public void PullTriggerEnter2D(Collider2D collision)
	{
		beepRout = true;
		maxDist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
		//Debug.Log("distMax = " + Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)));
		StartCoroutine(BeepInterval(endWaitTime));
	}
	public void PullTriggerExit2D(Collider2D collision)
	{
		beepRout = false;
	}



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
			audioSource.volume = Mathf.Lerp(0.7f, 0.01f, (int)auxDist / maxDist);
			
			yield return new WaitForSeconds(waitTime);
		}
	}



}
