using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeOnCol : MonoBehaviour
{
  public bool enter;
  public float speed;
  private bool played = false;

  private AudioSource audioSource;

  private void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  private void OnTriggerExit2D(Collider2D other) {
    if(!played && !enter && other.gameObject.tag == "Player")
      played = true;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!played && enter && other.gameObject.tag == "Player")
      played = true;
  }

  private void Update() {
    if(played)
      transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
  }
    
}
