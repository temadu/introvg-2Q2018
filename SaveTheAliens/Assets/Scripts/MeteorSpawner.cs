using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject meteorObj;
    float randomTime;
	public float minTime = 3.0f;
	public float maxTime = 10.0f;
	private float timePassed = 0;

    private float camHalfHeight;
    private float camHalfWidth;

	private float offset = 1.9f;

	// Use this for initialization
	void Start () {
        float randomTime = Random.Range(this.minTime, this.maxTime);
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth = Camera.main.aspect * camHalfHeight;
	}


	void Update () {
		this.timePassed += Time.deltaTime;
		if(this.timePassed >= this.randomTime){
			this.timePassed = 0;
            this.randomTime = Random.Range(this.minTime, this.maxTime);
			this.CreateAsteroid();
		}
		
	}
	void CreateAsteroid() {
		float x,y;
		if(Random.Range(0f, 1f) > 0.5f){
			x = camHalfWidth + offset;
			y = Random.Range( -this.camHalfHeight, this.camHalfHeight);
		}else{
            y = camHalfHeight + offset;
			x = Random.Range( -this.camHalfWidth, this.camHalfWidth);


		}
        GameObject meteor = Instantiate(meteorObj, new Vector2(x,y), Quaternion.identity);
        // meteor.GetComponent<MeteorMovement>().transform.position = new Vector2(x, y);
        meteor.SetActive(true);
    }
}
