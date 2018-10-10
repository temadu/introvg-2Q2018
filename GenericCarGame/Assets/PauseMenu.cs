using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool IsPaused = false;

	public GameObject pauseMenuUI;

	void Start () {
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			if(IsPaused)
				Resume();
			else
				Pause();
	}

	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		IsPaused = true;
	}

	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		IsPaused = false;
	}

	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame(){
		Application.Quit();

	}
}
