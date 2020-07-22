using UnityEngine;
using System.Collections;

public class ResetPointOnLeaveScreen : MonoBehaviour {

    private float camHalfHeight;
    private float camHalfWidth;
    public float offsetX;
    public float offsetY;

    // Use this for initialization
    void Start () {
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth =  Camera.main.aspect * camHalfHeight;
    }
	
	// Update is called once per frame
	void Update () {
        if(GameManagerScript.instance.goalResetBlock) return;
        if (transform.position.x > camHalfWidth + offsetX){
            // transform.position = new Vector2((-camHalfWidth - offsetX) + 0.0001f , transform.position.y);
            GameManagerScript.instance.Reset();
        }
        else if (transform.position.x < -camHalfWidth - offsetX){
            GameManagerScript.instance.Reset();
            // transform.position = new Vector2((camHalfWidth + offsetX) - 0.0001f, transform.position.y);
        }

        if (transform.position.y > camHalfHeight + offsetY){
            GameManagerScript.instance.Reset();
            // transform.position = new Vector2(transform.position.x, (-camHalfHeight - offsetY) + 0.0001f);
        }
        else if (transform.position.y < -camHalfHeight - offsetY){
            GameManagerScript.instance.Reset();
            // transform.position = new Vector2(transform.position.x, (camHalfHeight + offsetY) - 0.0001f);
        }
    }
}
