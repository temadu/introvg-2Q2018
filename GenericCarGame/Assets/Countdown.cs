using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {

  public TMPro.TextMeshProUGUI counterText;
	
	public void Count3(){
		counterText.text = "3";
	}
	public void Count2(){
		counterText.text = "2";
	}
	public void Count1(){
		counterText.text = "1";
	}
	public void GO(){
		counterText.text = "GO!";
	}
}
