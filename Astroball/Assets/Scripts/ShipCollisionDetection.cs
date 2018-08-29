using UnityEngine;
using System.Collections;

public class ShipCollisionDetection : MonoBehaviour {

     public GameObject elasticRope;

    void OnCollisionEnter2D(Collision2D other){

        if (other.gameObject.tag == "Ball"){

            if (GameManagerScript.instance.PlayerWithBall == this.gameObject.GetComponent<ShipData>().playerNumber) return;
            //GameObject elasticRopeGameObj = GameObject.Find("ElasticRope");
            GameObject rope = GameObject.FindGameObjectWithTag("Chain");
            if(rope != null) rope.GetComponent<ElasticRope>().DisconnectRope();

            GameManagerScript.instance.PlayerWithBall = this.gameObject.GetComponent<ShipData>().playerNumber;
            rope = Instantiate(elasticRope);
            rope.transform.position = other.gameObject.transform.position;
            rope.GetComponent<ElasticRope>().startPoint = this.gameObject;
            rope.GetComponent<ElasticRope>().endPoint = other.gameObject;


            // Destroy(other.gameObject);
        }
    }
}
