using UnityEngine;
using System.Collections;

public class MeteorMovement : MonoBehaviour {

    private Vector2 moveDir;
    private Rigidbody2D body;

    public float minSpeed = 5f;
    public float maxSpeed = 15f;
    private float speed;

    public float minSpin = 15f;
    public float maxSpin = 30f;
    private float spin;
    
        void Start () {
        moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        moveDir.Normalize();
        body = GetComponent<Rigidbody2D>();

        speed = Random.Range(minSpeed, maxSpeed);
        spin = Random.Range(minSpin, maxSpin);
	}
	
	void Update () {
        transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
        transform.Rotate(transform.forward * spin * Time.deltaTime);
	}
}
