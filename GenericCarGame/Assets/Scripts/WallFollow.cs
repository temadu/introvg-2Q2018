using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollow : MonoBehaviour {

	GameManager gm;
	private int fpCheckpoint;
	private int currentCheckpoint;
	public int checkpointsBehind = 2;
	// Use this for initialization
	void Start () {
		this.gm = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		fpCheckpoint = gm.firstPlace.currentCheckpoint;
		currentCheckpoint = fpCheckpoint - checkpointsBehind;
		if(currentCheckpoint < 0){
			currentCheckpoint = (CheckpointCounter.MAX_CHECKPOINT + 1) + currentCheckpoint;
		}
		transform.rotation = gm.checkpoints[currentCheckpoint].rotation;
		transform.position = gm.checkpoints[currentCheckpoint].position;
	}

	void ResetWall(){

	}
}
