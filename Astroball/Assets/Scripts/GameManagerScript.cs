using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour {

    public const int PLAYERS_COUNT = 2;
    public static GameManagerScript instance;
    public int[] scores;

    
    public TextMeshProUGUI[] playerScores;
    public Rigidbody2D ball;
    public Rigidbody2D playerOne;
    public Rigidbody2D playerTwo;

    public GameObject countdown;

    public int PlayerWithBall = -1;


    void Awake(){
        instance = this;

    }
    void Start() {

        this.scores = new int[PLAYERS_COUNT];
        this.scores[0] = 0;
        this.scores[1] = 0;

        this.countdown.SetActive(false);
        this.Reset();
        //this.StartCountdown();

    }

    public void Reset(){

        this.StartCountdown();

        this.playerOne.transform.position = new Vector2(-4f, 0f);
        this.playerOne.velocity = Vector2.zero;
        this.playerOne.angularVelocity = 0f;

        this.playerTwo.transform.position = new Vector2(4f, 0f);
        this.playerTwo.velocity = Vector2.zero;
        this.playerTwo.angularVelocity = 0f;

        this.ball.transform.position = Vector2.zero;
        this.ball.velocity = Vector2.zero;
        this.ball.angularVelocity = 0f;

        //GameObject.FindGameObjectWithTag("Chain").GetComponent<ElasticRope>().DisconnectRope();

        
    }

    public void ScoreGoal(int scorerPlayer){

        Time.timeScale = 0.5f;
        scores[scorerPlayer]++;
        Debug.Log(scores[scorerPlayer]);
        this.playerScores[scorerPlayer].text = scores[scorerPlayer].ToString();

        Invoke("Reset", 1f);
    }

    public void StartCountdown(){

        this.countdown.SetActive(true);
        StartCoroutine("StartDelay");

    }

    IEnumerator StartDelay(){
        
        Time.timeScale = 0;
        float timePause = Time.realtimeSinceStartup + 3.5f;

        while (Time.realtimeSinceStartup < timePause)
            yield return 0;
        
        this.countdown.SetActive(false);
        Time.timeScale = 1;
    }


}
