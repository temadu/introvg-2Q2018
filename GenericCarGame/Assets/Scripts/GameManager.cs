using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  public const int END_GAME_SCORE = 3;

  public float countDownTimer = 3.5f;
  public int circuitLength = 8;

  public float distanceBetweenCars = 1f;
  public static GameManager instance;
  
  public CheckpointCounter firstPlace;
  public Transform[] checkpoints;
  
  public int winner = -1;

  public GameObject playerScoresPanel;
  public GameObject endGamePanel;
  public TextMeshProUGUI[] playerScoresGUI;
  public GameObject countdown;
  public Car[] players;
  private List<Car> playersLeft;
  private int[] playerScores;
  public CameraFollow cameraFollow;


  void Awake()
  {
    instance = this;
    firstPlace = players[0].GetComponent<CheckpointCounter>();
    this.checkpoints = new Transform[circuitLength];

  }
  void Start()
  { 
    this.playerScores = new int[players.Length];
    
    this.countdown.SetActive(false);
    this.winner = -1;
    this.Reset();
  }

  

  public void Reset(){
    Time.timeScale = 1f;
    this.playerScoresPanel.SetActive(false);
    this.ResetPlayerPositions();
    this.StartCountdown();
  }

  private void ResetPlayerPositions(){
    this.playersLeft = new List<Car>();
    this.cameraFollow.targets = new List<Car>();
    CheckpointCounter counter;
    for (int i = 0; i < players.Length; i++){
      this.playersLeft.Add(this.players[i]);
      this.cameraFollow.targets.Add(this.players[i]);
      this.players[i].ResetCar(new Vector3(1f - i * distanceBetweenCars, 0.2f, 1f), new Quaternion(0f, 0f, 0f, 1f));
      counter = this.players[i].GetComponent<CheckpointCounter>();
      counter.currentLap = counter.currentCheckpoint = 0;
    }
    cameraFollow.ResetCamera();
    // this.firstPlace = players[0].GetComponent<CheckpointCounter>();
  }

  public void GoToMenu(){
    this.playerScoresPanel.SetActive(false);
    this.endGamePanel.SetActive(false);
    Time.timeScale = 1f;
    SceneManager.LoadScene(0);
  }

  public void DestroyPlayer(Car player)
  {
    if(playersLeft.Count > 1){
      playersLeft.RemoveAll(x => x.playerNumber == player.playerNumber);
      cameraFollow.targets.RemoveAll(x => x.playerNumber == player.playerNumber);
      if(playersLeft.Count == 1){
        playerScores[playersLeft[0].playerNumber-1]++;
        this.playerScoresGUI[playersLeft[0].playerNumber - 1].text = playerScores[playersLeft[0].playerNumber - 1].ToString();
        this.playerScoresPanel.SetActive(true);
        if(playerScores[playersLeft[0].playerNumber-1] == END_GAME_SCORE){
          this.winner = playersLeft[0].playerNumber;
          endGamePanel.SetActive(true);
          // Time.timeScale = 0.5f;
          Invoke("GoToMenu", 2f);
        }
        else
          Invoke("Reset", 2f);
      }
    }
  }

  public void StartCountdown()
  {

    this.countdown.SetActive(true);
    StartCoroutine("StartDelay");

  }

  IEnumerator StartDelay()
  {

    Time.timeScale = 0;
    float timePause = Time.realtimeSinceStartup + countDownTimer;

    while (Time.realtimeSinceStartup < timePause)
    {
      yield return 0;
    }
    this.countdown.SetActive(false);
    Time.timeScale = 1;
  }

  public void checkFirstPlace(CheckpointCounter player){
    // Debug.Log(player.GetComponent<Car>().playerNumber + ": " + player.currentCheckpoint);
    if(firstPlace.currentLap > player.currentLap)
      return;
    if(firstPlace.currentCheckpoint >= player.currentCheckpoint)
      return;
    // Debug.Log("Changed First Place");
    firstPlace = player;
  }

}
