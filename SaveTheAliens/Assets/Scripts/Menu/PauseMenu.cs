using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool IsPaused = false;
	public static float PauseTime = 0;

	public GameObject pauseMenuUI;
  public Animator countdownAnim;

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
    countdownAnim.speed = 0;
    // PauseTime = Time.realtimeSinceStartup;
		IsPaused = true;
	}

	public void Resume(){
		pauseMenuUI.SetActive(false);
    countdownAnim.speed = 1;
    if (!CountdownCanvas.IsPlaying) {
		  Time.timeScale = 1f;
    }
    // PauseTime = 0;
		IsPaused = false;
	}

	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	public void QuitGame(){
		Application.Quit();

	}
}
