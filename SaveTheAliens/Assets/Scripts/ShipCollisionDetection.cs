using UnityEngine;
using System.Collections;

public class ShipCollisionDetection : MonoBehaviour {

    public GameObject elasticRope;
    public AudioSource hitSound;
    public AudioSource ballPickupSound;

    private int playerNumber;

    private int inPortal = 0;

    private void Start() {
        this.playerNumber = this.gameObject.GetComponent<ShipData>().playerNumber;
    }

    void OnCollisionEnter2D(Collision2D other){

        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Chain"){
            if (this.HasTheBall()) return;
            this.StealBall();   
        } else if(other.gameObject.tag == "Meteor" || other.gameObject.tag == "Laser"){
            hitSound.Play();
            LoseTheBall();
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

        GameManagerScript.instance.playerWithBall = this.gameObject.GetComponent<ShipData>().playerNumber;
        rope = Instantiate(elasticRope);
        rope.transform.position = GameManagerScript.instance.ball.transform.position;
        rope.GetComponent<ElasticRope>().startPoint = this.gameObject;
        rope.GetComponent<ElasticRope>().endPoint = GameManagerScript.instance.ball.gameObject;
        ballPickupSound.Play();
    }

    bool HasTheBall(){
        return GameManagerScript.instance.playerWithBall == this.playerNumber;
    }

    void LoseTheBall(){
        if (this.HasTheBall()){
            GameObject.FindGameObjectWithTag("Chain").GetComponent<ElasticRope>().DisconnectRope();
        }
    }

    void UsePortal(GameObject portal){
      Transform otherPortal = portal.GetComponent<Portal>().otherPortal;
      this.inPortal = 2;
      this.gameObject.transform.position = otherPortal.position;
      if(this.HasTheBall()){
        GameManagerScript.instance.ball.gameObject.transform.position = otherPortal.position;
        GameManagerScript.instance.ball.velocity = Vector2.zero;
      }
    }

}
