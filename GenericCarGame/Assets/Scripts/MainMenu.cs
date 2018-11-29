using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject playerMenu;
	public void setMenu(int num){
		switch (num)
		{
			case 0:
				playerMenu.SetActive(false);
				mainMenu.SetActive(true);
				break;
			case 1:
                mainMenu.SetActive(false);
                playerMenu.SetActive(true);
				break;
		}
	}
	
	public void LoadGame(int playerNum){
		Properties.players = playerNum;
		this.gameObject.SetActive(false);
		SceneManager.LoadScene("RandomCircuit");
	}

	public void QuitGame(){
		Application.Quit();

	}
}
