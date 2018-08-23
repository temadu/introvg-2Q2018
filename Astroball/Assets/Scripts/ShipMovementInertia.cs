using UnityEngine;
using System.Collections;

public class ShipMovementInertia : MonoBehaviour {

    [Header("Movement Settings")]
    public float power = 10;
    public float maxSpeed = 20;
    public float rotSpeed = 5;

    [Header("Controller Settings")]
    public KeyCode thrusterKey = KeyCode.UpArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    private Vector2 velocity;
    Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        velocity = new Vector2(body.velocity.x, body.velocity.y);

        if (velocity.magnitude > maxSpeed){
            velocity = velocity.normalized;
            velocity *= maxSpeed;
        }

        if (Input.GetKey(this.thrusterKey)){
            body.AddForce(transform.up * power);
        }
        if (Input.GetKey(this.leftKey)){
            body.AddTorque(rotSpeed * Time.deltaTime);
            //transform.Rotate(transform.forward * rotSpeed);
        }
        if (Input.GetKey(this.rightKey)){
            body.AddTorque(-rotSpeed * Time.deltaTime);
            //transform.Rotate(transform.forward * -rotSpeed);
        }
    }
}
