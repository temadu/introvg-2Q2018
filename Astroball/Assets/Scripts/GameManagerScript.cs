using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour {

    public const int PLAYERS_COUNT = 2;
    public const int END_GAME_SCORE = 2;

    public bool goalResetBlock = false;

    public static GameManagerScript instance;
    public int[] scores;
    public int winner = -1;
    
    public TextMeshProUGUI[] playerScores;
    public Rigidbody2D ball;
    public Rigidbody2D playerOne;
    public Rigidbody2D playerTwo;
    public AudioSource goalSound;

    public GameObject countdown;

    public int playerWithBall = -1;


    void Awake(){
        instance = this;

    }
    void Start() {

        this.scores = new int[PLAYERS_COUNT];
        this.scores[0] = 0;
        this.scores[1] = 0;

        this.countdown.SetActive(false);
        this.winner = -1;
        this.Reset();

    }

    private void ResetPlayerPositions(){

        this.playerOne.transform.position = new Vector2(-4f, 0f);
        this.playerOne.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        this.playerOne.velocity = Vector2.zero;
        this.playerOne.angularVelocity = 0f;

        this.playerTwo.transform.position = new Vector2(4f, 0f);
        this.playerTwo.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        this.playerTwo.velocity = Vector2.zero;
        this.playerTwo.angularVelocity = 0f;
    }

    public void Reset(){

        this.StartCountdown();

        this.ResetPlayerPositions();

        this.ball.transform.position = Vector2.zero;
        this.ball.velocity = Vector2.zero;
        this.ball.angularVelocity = 0f;
        this.goalResetBlock = false;

    }

    public void GoToMenu(){

        SceneManager.LoadScene(0);
    }

    public void ScoreGoal(int scorerPlayer){
        this.goalResetBlock = true;
        Time.timeScale = 0.5f;
        scores[scorerPlayer]++;
        // Debug.Log(scores[scorerPlayer]);
        this.playerScores[scorerPlayer].text = scores[scorerPlayer].ToString();
        goalSound.Play();

        if (scores[scorerPlayer] == END_GAME_SCORE) {
            foreach (var meteor in GameObject.FindGameObjectsWithTag("Meteor")){
                meteor.GetComponent<InstanciateObjectOnDestroy>().isQuitting = true;
            }
            this.ResetPlayerPositions();
            this.winner = scorerPlayer;

            if (scorerPlayer == 0)
                ParticleHelperScript.Instance.Winner(this.playerOne.transform.position, scorerPlayer);
            else
                ParticleHelperScript.Instance.Winner(this.playerTwo.transform.position, scorerPlayer);

            Invoke("GoToMenu", 3f);
        }else{
            Invoke("Reset", 1f);
        }
    }

    public void StartCountdown(){

        this.countdown.SetActive(true);
        StartCoroutine("StartDelay");

    }

    IEnumerator StartDelay(){
        
        Time.timeScale = 0;
        float timePause = Time.realtimeSinceStartup + 3.5f;

        while (Time.realtimeSinceStartup < timePause) {
            yield return 0;
        }
        this.countdown.SetActive(false);
        Time.timeScale = 1;
    }


}
