using UnityEngine;
using System.Collections;

public class ShipMovementSimple : MonoBehaviour {

    [Header("Movement Settings")]
    public float power = 10;
    public float maxSpeed = 20;
    public float rotSpeed = 5;
    
    [Header("Controller Settings")]
    public KeyCode thrusterKey = KeyCode.UpArrow;
    public AudioSource thrusterSound;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode removeRopeKey = KeyCode.Z;
    
    private Vector2 velocity;
    Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        if(this.thrusterSound == null){
          this.thrusterSound = GameObject.Find("Thruster").GetComponent<AudioSource>();
          this.thrusterSound.Play();
        }
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
            StartCoroutine(FadeOut(thrusterSound.pitch,0.9f,0.8f));
            
            // if(!thrusterSound.isPlaying){
            //   thrusterSound.Play();
            // }
        } else {
          StartCoroutine(FadeOut(thrusterSound.pitch,0.2f,0.65f));
          // thrusterSound.Stop();
        }
        if (Input.GetKey(this.leftKey)){
            //body.AddTorque(rotSpeed * Time.deltaTime);
            transform.Rotate(transform.forward * rotSpeed);
        }
        if (Input.GetKey(this.rightKey)){
            //body.AddTorque(-rotSpeed * Time.deltaTime);
            transform.Rotate(transform.forward * -rotSpeed);
        }
        // if (Input.GetKey(this.removeRopeKey)){
        //     if(GameManagerScript.instance.playerWithBall == this.gameObject.GetComponent<ShipData>().playerNumber)
        //         GameObject.FindGameObjectWithTag("Chain").GetComponent<ElasticRope>().DisconnectRope();
        // }


    }

  private IEnumerator FadeOut(float pitchStart, float pitchFinish, float time)
  {
    if (thrusterSound == null)
      yield return null;

    float elapsedTime = 0;
    // bgTexture.alpha = alphaStart;

    while (elapsedTime < time)
    {
      thrusterSound.pitch = Mathf.Lerp(pitchStart, pitchFinish, (elapsedTime / time));
      elapsedTime += Time.deltaTime;
      yield return new WaitForEndOfFrame();
    }
  }
}
