using UnityEngine;
using System.Collections;

public class StayLoopOnScreen : MonoBehaviour {

    private float camHalfHeight;
    private float camHalfWidth;
    private Renderer render;
    public float offsetX;
    public float offsetY;

    // Use this for initialization
    void Start () {
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth =  Camera.main.aspect * camHalfHeight;
        render = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > camHalfWidth + offsetX){
            transform.position = new Vector2((-camHalfWidth - offsetX) + 0.0001f , transform.position.y);
        }
        else if (transform.position.x < -camHalfWidth - offsetX){
            transform.position = new Vector2((camHalfWidth + offsetX) - 0.0001f, transform.position.y);
        }

        if (transform.position.y > camHalfHeight + offsetY){
            transform.position = new Vector2(transform.position.x, (-camHalfHeight - offsetY) + 0.0001f);
        }
        else if (transform.position.y < -camHalfHeight - offsetY){
            transform.position = new Vector2(transform.position.x, (camHalfHeight + offsetY) - 0.0001f);
        }
    }
}
