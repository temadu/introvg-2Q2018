using UnityEngine;
using System.Collections;

public class LoopOnLevel : MonoBehaviour {

    public float yBounds;
    public float xBounds;
    private Renderer render;

    // Use this for initialization
    void Start () {
        render = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > xBounds){
            transform.position = new Vector2(-xBounds + 0.0001f , transform.position.y);
        }
        else if (transform.position.x < -xBounds){
            transform.position = new Vector2(xBounds - 0.0001f, transform.position.y);
        }

        if (transform.position.y > yBounds){
            transform.position = new Vector2(transform.position.x, (-yBounds) + 0.0001f);
        }
        else if (transform.position.y < -yBounds){
            transform.position = new Vector2(transform.position.x, (yBounds) - 0.0001f);
        }
    }
}
