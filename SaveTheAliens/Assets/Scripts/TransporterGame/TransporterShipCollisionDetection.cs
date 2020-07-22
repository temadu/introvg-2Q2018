using UnityEngine;
using System.Collections;

public class TransporterShipCollisionDetection : MonoBehaviour {

    public GameObject elasticRope;
    private Rigidbody2D ballRB;
    public AudioSource hitSound;
    public AudioSource disconnectRopeSound;
    public AudioSource ballPickupSound;
    public AudioSource portalAudio;

    private int inPortal = 0;

    private void Start() {
      if(this.hitSound == null)
        this.hitSound = GameObject.Find("Crash").GetComponent<AudioSource>();

      if (this.disconnectRopeSound == null)
        this.disconnectRopeSound = GameObject.Find("ReleaseAlien").GetComponent<AudioSource>();

      if (this.ballPickupSound == null)
        this.ballPickupSound = GameObject.Find("GrabAlien").GetComponent<AudioSource>();

      if (this.portalAudio == null)
        this.portalAudio = GameObject.Find("Portal").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other){

        if (other.gameObject.tag == "Ball"){
            if (this.HasTheBall()) return;
            ballRB = other.rigidbody;
            this.StealBall();   
        } else if(other.gameObject.tag == "Meteor"){
            hitSound.volume = 0.7f;
            hitSound.pitch = 1f;
            hitSound.Play();
            LoseTheBall();
        } else if (other.gameObject.tag == "Field"){
            hitSound.volume = 0.4f;
            hitSound.pitch = 0.3f;
            hitSound.Play();

        } 
        // else if(other.gameObject.tag == "Player") {
        //     if (GameManagerScript.instance.PlayerWithBall == other.gameObject.GetComponent<ShipData>().playerNumber){
        //         StealBall(GameObject.FindGameObjectWithTag("Ball"));
        //     }
        // }
    }
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Portal" && inPortal == 0){
        this.UsePortal(other.gameObject);
      }
    }
    private void OnTriggerExit2D(Collider2D other){

        if (other.gameObject.tag == "Portal"){
          inPortal--;
        }
    }

    void StealBall(){
        GameObject rope = GameObject.FindGameObjectWithTag("Chain");
        if (rope != null) rope.GetComponent<ElasticRope>().DisconnectRope();
        rope = Instantiate(elasticRope);
        rope.transform.position = ballRB.transform.position;
        rope.GetComponent<ElasticRope>().startPoint = this.gameObject;
        rope.GetComponent<ElasticRope>().endPoint = ballRB.gameObject;
        ballPickupSound.Play();
    }

    bool HasTheBall(){
        return this.ballRB != null;
    }

    void LoseTheBall(){
        if (this.HasTheBall()){
          this.ballRB = null;
          GameObject.FindGameObjectWithTag("Chain").GetComponent<ElasticRope>().DisconnectRope();
          disconnectRopeSound.Play();
        }
    }

    void UsePortal(GameObject portal){
      Transform otherPortal = portal.GetComponent<Portal>().otherPortal;
      this.inPortal = 2;
      this.gameObject.transform.position = otherPortal.position;
      this.portalAudio.Play();
      if(this.HasTheBall()){
        ballRB.transform.position = otherPortal.position;
        ballRB.velocity = Vector2.zero;
      }
    }

}
