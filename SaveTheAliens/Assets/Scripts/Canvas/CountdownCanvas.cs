using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownCanvas : MonoBehaviour
{

  public static bool IsPlaying = false;

  public TMPro.TextMeshProUGUI counterText;
  public AudioSource threeSound;
  public AudioSource twoSound;
  public AudioSource oneSound;
  public AudioSource goSound;

  public void Start(){
    Time.timeScale = 0;
    IsPlaying = true;
    if (this.threeSound == null)
      this.threeSound = GameObject.Find("3").GetComponent<AudioSource>();
    if (this.twoSound == null)
      this.twoSound = GameObject.Find("2").GetComponent<AudioSource>();
    if (this.oneSound == null)
      this.oneSound = GameObject.Find("1").GetComponent<AudioSource>();
    if (this.goSound == null)
      this.goSound = GameObject.Find("GO").GetComponent<AudioSource>();

  }

  public void Clean()
  {
    counterText.text = "";
    gameObject.SetActive(false);
    IsPlaying = false;
  }
  public void Count3()
  {
    counterText.text = "3";
    threeSound.Play();
  }
  public void Count2()
  {
    counterText.text = "2";
    twoSound.Play();
  }
  public void Count1()
  {
    counterText.text = "1";
    oneSound.Play();
  }
  public void GO()
  {
    counterText.text = "GO!";
    goSound.Play();
    Time.timeScale = 1;
  }

  
}
