using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTransporter : MonoBehaviour
{

  public GameObject mainMenu;
  public GameObject levelMenu;

  public void setMenu(int num)
  {
    switch (num)
    {
      case 0:
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
        break;
      case 1:
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
        break;
    }
  }

  public void LoadGame(int levelNum)
  {
    foreach (var meteor in GameObject.FindGameObjectsWithTag("Meteor"))
    {
      meteor.GetComponent<InstanciateObjectOnDestroy>().isQuitting = true;
    }
    SceneManager.LoadScene(levelNum);
  }

  public void QuitGame()
  {
    Application.Quit();

  }
}
