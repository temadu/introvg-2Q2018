using UnityEngine;
using System.Collections;

public class ShipCollisionDetection : MonoBehaviour {

    public GameObject elasticRope;
    public AudioSource hitSound;
    public AudioSource ballPickupSound;

    private int playerNumber;

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

    void StealBall(){
        GameObject rope = GameObject.FindGameObjectWithTag("Chain");
        if (rope != null) rope.GetComponent<ElasticRope>().DisconnectRope();

        GameManagerScript.instance.PlayerWithBall = this.gameObject.GetComponent<ShipData>().playerNumber;
        rope = Instantiate(elasticRope);
        rope.transform.position = GameManagerScript.instance.ball.transform.position;
        rope.GetComponent<ElasticRope>().startPoint = this.gameObject;
        rope.GetComponent<ElasticRope>().endPoint = GameManagerScript.instance.ball.gameObject;
        ballPickupSound.Play();
    }

    bool HasTheBall(){
        return GameManagerScript.instance.PlayerWithBall == this.playerNumber;
    }

    void LoseTheBall(){
        if (this.HasTheBall()){
            GameObject.FindGameObjectWithTag("Chain").GetComponent<ElasticRope>().DisconnectRope();
        }
    }


}
