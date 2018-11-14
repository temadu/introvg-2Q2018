using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameText : MonoBehaviour {

  public TMPro.TextMeshProUGUI endGameText;

	public void setEndGameText(){
		int winner = GameManager.instance.winner;
		endGameText.text = "PLAYER " + winner + " WON";
		setTextColor(winner);
	}
  void setTextColor(int playerNumber)
  {
    switch (playerNumber)
    {
      case 1:
				endGameText.color = new Color(0.1007f, 0.227f, 0.8f, 1f);
        break;
      case 2:
				endGameText.color = new Color(0.8f, 0.3745f, 0.1275f, 1f);
        break;
      case 3:
				endGameText.color = new Color(1f, 0.2f, 0.85f, 1f);
        break;
      case 4:
				endGameText.color = new Color(0.15f, 1f, 1f, 1f);
        break;
    }
  }
}
