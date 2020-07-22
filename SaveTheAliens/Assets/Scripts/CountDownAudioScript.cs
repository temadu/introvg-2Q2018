using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownAudioScript : MonoBehaviour {

    public AudioSource audioTick;
    public AudioSource audioFinal;


    public void PlayAudio()
    {
        audioTick.Play();
    }
	
    public void PlayLastAudio()
    {
        audioFinal.Play();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
