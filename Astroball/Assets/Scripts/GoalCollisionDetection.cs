using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollisionDetection : MonoBehaviour{

    public int scorerPlayer;

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.tag == "Ball"){

            GameObject elasticRopeGameObj = GameObject.Find("ElasticRope");
            ElasticRope rope = elasticRopeGameObj.GetComponent<ElasticRope>();
            rope.DisconnectRope(other.gameObject);

            GameManagerScript.instance.ScoreGoal(scorerPlayer);
            ParticleHelperScript.Instance.Explosion(other.gameObject.GetComponent<Rigidbody2D>().position, new Color(0.5f, 1f, 1f, 1f));

            // Destroy(other.gameObject);
        }
    }

}
