using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCounter : MonoBehaviour {

	public static int MAX_CHECKPOINT = 0;

	public int currentCheckpoint = 0;
	public int currentLap = 0;

	private GameManager gm;

	private void Start() {
		this.gm = GameManager.instance;
	}

	private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Road"))
    {
			int checkpointEntered = other.gameObject.GetComponentInParent<Checkpoint>().checkpointNumber;
			// Debug.Log("Hit checkpoint: " + checkpointEntered);
      if(MAX_CHECKPOINT == currentCheckpoint && checkpointEntered == 0){
				this.currentCheckpoint = checkpointEntered;
				this.currentLap++;
				// Debug.Log("Changed Checkpoint to: " + this.currentCheckpoint);
				// Debug.Log("LAP DONE: " +  currentLap);
        gm.checkFirstPlace(this);
			} else if(currentCheckpoint + 1 == checkpointEntered){
				this.currentCheckpoint = checkpointEntered;
				// Debug.Log("Changed Checkpoint to: " + this.currentCheckpoint);
				// Debug.Log(gm);
        gm.checkFirstPlace(this);

      } 
    }
	}
}
