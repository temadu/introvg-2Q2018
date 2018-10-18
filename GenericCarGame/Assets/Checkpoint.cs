using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int checkpointNumber = 1;

	private void Awake() {
		if(CheckpointCounter.MAX_CHECKPOINT < checkpointNumber){
      CheckpointCounter.MAX_CHECKPOINT = checkpointNumber;
			// Debug.Log("MAX CHECKPOINT: " + CheckpointCounter.MAX_CHECKPOINT);
		}
	}

	private void Start() {
		GameManager.instance.checkpoints[checkpointNumber] = this.transform;
		// Debug.Log(GameManager.instance.checkpoints[checkpointNumber].position);
	}
}
