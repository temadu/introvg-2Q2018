using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

  [Header("Player Settings")]
  public int playerNumber = 1;
  public bool controlable = true;
  public GameObject explosionEffect;
  public Renderer rend;

  [Header("Movement Settings")]
  public float speed = 90f;
  public float turnSpeed = 5f;
  public float hoverForce = 65f;
  public float hoverHeight = 3.5f;
  public float boostSpeed = 40f;
  public float bumpSpeed = 20f;
  public float explosionForce = 20f;
  public float explosionTorque = 100f;

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
  private AudioSource engineSound;
  private bool alive = true;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    engineSound = GetComponent<AudioSource>();
    setCarColor();
  }

  void setCarColor(){
    switch (playerNumber)
    {
      case 1:
        rend.material.SetColor("_Color", new Color(0.1007f, 0.227f, 0.8f, 1f));
        break;
      case 2:
        rend.material.SetColor("_Color", new Color(0.8f, 0.3745f, 0.1275f, 1f));
        break;
      case 3:
        rend.material.SetColor("_Color", new Color(1f, 0.2f, 0.85f, 1f));
        break;
      case 4:
        rend.material.SetColor("_Color", new Color(0.15f, 1f, 1f, 1f));
        break;
    }
  }

  void Update()
  {
    if(controlable && alive){
      powerInput = Input.GetAxis("Vertical");
      if(powerInput!=0){
        StartCoroutine(FadeOut(engineSound.pitch,1f,0.5f));
      }else{
        StartCoroutine(FadeOut(engineSound.pitch,0.3f,0.5f));
      }
      turnInput = Input.GetAxis("Horizontal");
      boost = Input.GetKeyDown(KeyCode.W);
      bumpLeft = Input.GetKeyDown(KeyCode.A);
      bumpRight = Input.GetKeyDown(KeyCode.D);
    }
    // if(Input.GetKeyDown(KeyCode.R)){
    //   ResetCar();
    // }
    if(Input.GetKeyDown(KeyCode.E)){
      Explode();
    }
  }

  void FixedUpdate()
  {
    if(alive){
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
        rb.AddRelativeForce(bumpSpeed * speed,0f, 0f);
        // Explode();
      rb.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    }

  }

  public void Explode(){
    alive = false;
    engineSound.mute = true;
    rend.material.SetColor("_Color", new Color(0.35f, 0.35f, 0.35f, 1f));
    explosionEffect.SetActive(true);
    rb.constraints = RigidbodyConstraints.None;
    rb.AddRelativeForce(0f, explosionForce, 0f,ForceMode.Impulse);
    rb.AddRelativeTorque(Random.Range(0f, explosionTorque), Random.Range(0f, explosionTorque), Random.Range(0f, explosionTorque));
    GameManager.instance.DestroyPlayer(this);
  }

  public void ResetCar(Vector3 newPosition, Quaternion newRotation){
    // Reset the velocity
    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
    // "Pause" the physics
    rb.isKinematic = true;
    // Do positioning, etc
    transform.position = newPosition;
    transform.rotation = newRotation;
    // Re-enable the physics
    rb.isKinematic = false;
    setCarColor();
    explosionEffect.SetActive(false);
    engineSound.mute = false;
    alive = true;
  }

  private IEnumerator FadeOut(float pitchStart, float pitchFinish, float time){
    if (engineSound == null)
      yield return null;

    float elapsedTime = 0;
    // bgTexture.alpha = alphaStart;

    while (elapsedTime < time){
      engineSound.pitch = Mathf.Lerp(pitchStart, pitchFinish, (elapsedTime / time));
      elapsedTime += Time.deltaTime;
      yield return new WaitForEndOfFrame();
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Instakill"))
    {
     this.Explode();
    }
  }
}