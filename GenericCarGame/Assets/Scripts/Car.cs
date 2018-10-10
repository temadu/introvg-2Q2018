using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

  [Header("Player Settings")]
  public int playerNumber = 1;
  public bool controlable = true;

  [Header("Movement Settings")]
  public float speed = 90f;
  public float turnSpeed = 5f;
  public float hoverForce = 65f;
  public float hoverHeight = 3.5f;
  public float boostSpeed = 40f;
  public float bumpSpeed = 20f;

  [Header("Controller Settings")]
  public KeyCode thrusterKey = KeyCode.UpArrow;
  public KeyCode leftKey = KeyCode.LeftArrow;
  public KeyCode rightKey = KeyCode.RightArrow;

  private float powerInput;
  private float turnInput;
  private bool boost;
  private bool bumpLeft;
  private bool bumpRight;
  private Rigidbody rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    if(controlable){
      powerInput = Input.GetAxis("Vertical");
      turnInput = Input.GetAxis("Horizontal");
      boost = Input.GetKeyDown(KeyCode.W);
      bumpLeft = Input.GetKeyDown(KeyCode.A);
      bumpRight = Input.GetKeyDown(KeyCode.D);
    }
  }

  void FixedUpdate()
  {
    Ray ray = new Ray(transform.position, -transform.up);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, hoverHeight))
    {
      float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
      Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
      rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
    }

    rb.AddRelativeForce(0f, 0f, powerInput * speed);
    if(boost)
      rb.AddRelativeForce(0f,0f, boostSpeed * speed);
    else if(bumpLeft)
      rb.AddRelativeForce(-bumpSpeed * speed,0f, 0f);
    else if(bumpRight)
      // rb.AddRelativeForce(bumpSpeed * speed,0f, 0f);
      Explode();
    rb.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

  }

  void Explode(){

  }
}