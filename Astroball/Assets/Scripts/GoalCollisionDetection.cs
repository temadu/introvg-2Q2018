using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.tag == "Ball"){

            GameObject elasticRopeGameObj = GameObject.Find("ElasticRope");
            ElasticRope rope = elasticRopeGameObj.GetComponent<ElasticRope>();
            rope.DisconnectRope(other.gameObject);

            Debug.Log("Gol");
            // Destroy(other.gameObject);
        }
    }

}
