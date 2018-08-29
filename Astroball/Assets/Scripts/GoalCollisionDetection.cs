using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollisionDetection : MonoBehaviour{

    public int scorerPlayer;

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.tag == "Ball"){

            if (GameManagerScript.instance.playerWithBall != -1) { 
                GameObject elasticRopeGameObj = GameObject.FindGameObjectWithTag("Chain");
                ElasticRope rope = elasticRopeGameObj.GetComponent<ElasticRope>();
                rope.DisconnectRope();
            }

            GameManagerScript.instance.ScoreGoal(scorerPlayer);

            ParticleHelperScript.Instance.Explosion(other.gameObject.GetComponent<Rigidbody2D>().position, scorerPlayer);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().shakeDuration = 0.25f;

            // Destroy(other.gameObject);
        }
    }

}
