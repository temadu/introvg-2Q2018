using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int checkpointNumber = 1;

	private void Awake() {
		
	}

	private void Start() {
        if (CheckpointCounter.MAX_CHECKPOINT < checkpointNumber)
        {
            CheckpointCounter.MAX_CHECKPOINT = checkpointNumber;
            Debug.Log(CheckpointCounter.MAX_CHECKPOINT);
            // GameManager.instance.checkpoints = new Transform[CheckpointCounter.MAX_CHECKPOINT + 1];
        }
		GameManager.instance.checkpoints[checkpointNumber] = this.transform;
	}
}
