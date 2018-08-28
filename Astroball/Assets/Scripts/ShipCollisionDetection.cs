using UnityEngine;
using System.Collections;

public class ShipCollisionDetection : MonoBehaviour {

    // public GameObject elasticRope;

    void OnCollisionEnter2D(Collision2D other){

        if (other.gameObject.tag == "Ball"){
            
            GameObject elasticRopeGameObj = GameObject.Find("ElasticRope");
            ElasticRope rope = elasticRopeGameObj.GetComponent<ElasticRope>();
            rope.ConnectRope(this.gameObject, other.gameObject);

            // Destroy(other.gameObject);
        }
    }
}
