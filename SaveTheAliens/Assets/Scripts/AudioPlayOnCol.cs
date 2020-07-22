using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayOnCol : MonoBehaviour
{
  public bool enter;
  private bool played = false;

  private AudioSource audioSource;

  private void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  private void OnTriggerExit2D(Collider2D other) {
    if(!played && !enter && other.gameObject.tag == "Player")
      playAudio();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!played && enter && other.gameObject.tag == "Player")
      playAudio();
  }

  private void playAudio(){
    if(this.audioSource != null){
      audioSource.Play();
    }
    played = true;
  }
    
}
