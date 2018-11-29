using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject playerMenu;
	public bool randomStage;

	public void setMenu(int num){
		switch (num)
		{
			case 0:
				playerMenu.SetActive(false);
				mainMenu.SetActive(true);
				break;
			case 1:
				randomStage = false;
                mainMenu.SetActive(false);
                playerMenu.SetActive(true);
				break;
			case 2:
				randomStage = true;
                mainMenu.SetActive(false);
                playerMenu.SetActive(true);
				break;
		}
	}
	
	public void LoadGame(int playerNum){
		Properties.players = playerNum;
		this.gameObject.SetActive(false);
        mainMenu.SetActive(false);
        playerMenu.SetActive(false);
		if(randomStage)
			SceneManager.LoadScene("RandomCircuit");
		else
			SceneManager.LoadScene("PreGeneratedCircuit");
	}

	public void QuitGame(){
		Application.Quit();

	}
}
