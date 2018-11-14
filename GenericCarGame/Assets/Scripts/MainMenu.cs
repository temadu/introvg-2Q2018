using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public void LoadGame(){
		this.gameObject.SetActive(false);
		SceneManager.LoadScene("Circuit1");
	}

	public void QuitGame(){
		Application.Quit();

	}
}
