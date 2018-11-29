using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollow : MonoBehaviour {

	GameManager gm;
	private int fpCheckpoint;
	private int currentCheckpoint;
	public int checkpointsBehind = -4;
	// Use this for initialization
	public float speed = 5f;

	void Start () {
		this.gm = GameManager.instance;
       	ResetWall();
    }
	
	// Update is called once per frame
	void Update () {
		fpCheckpoint = gm.firstPlace.currentCheckpoint;
		currentCheckpoint = fpCheckpoint - checkpointsBehind;
		if(currentCheckpoint < 0){
			currentCheckpoint = (CheckpointCounter.MAX_CHECKPOINT + 1) + currentCheckpoint;
		}
		// Debug.Log(gm.checkpoints.Length);
		// Debug.Log(CheckpointCounter.MAX_CHECKPOINT);
		transform.rotation = gm.checkpoints[currentCheckpoint].rotation;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, gm.checkpoints[currentCheckpoint].position, step);
		// transform.position = gm.checkpoints[currentCheckpoint].position;
	}

	public void ResetWall(){
		// if(gm == null) return;
		fpCheckpoint = GameManager.instance.firstPlace.currentCheckpoint;
		currentCheckpoint = fpCheckpoint - checkpointsBehind;
		if(currentCheckpoint < 0){
			// Debug.Log(currentCheckpoint);
			currentCheckpoint = (CheckpointCounter.MAX_CHECKPOINT + 1) + currentCheckpoint;
			// Debug.Log(CheckpointCounter.MAX_CHECKPOINT);
		}
		// Debug.Log(fpCheckpoint);
		transform.rotation = GameManager.instance.checkpoints[currentCheckpoint].rotation;
		transform.position = GameManager.instance.checkpoints[currentCheckpoint].position;
		// Debug.Log(GameManager.instance.checkpoints[currentCheckpoint].position);
    }
}
