using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour {

    public const int PLAYERS_COUNT = 2;
    public static GameManagerScript instance;
    public int[] scores;

    public TextMeshProUGUI[] playerScores;


    void Awake(){
        instance = this;

    }
    void Start() {

        this.scores = new int[PLAYERS_COUNT];
        this.scores[0] = 0;
        this.scores[1] = 0;

    }

    public void ScoreGoal(int scorerPlayer){
        scores[scorerPlayer]++;
        Debug.Log(scores[scorerPlayer]);
        this.playerScores[scorerPlayer].text = scores[scorerPlayer].ToString();

    }

    void Update(){
        // Set the displayed text to be the word "Score" followed by the score value.
        
    }


}
