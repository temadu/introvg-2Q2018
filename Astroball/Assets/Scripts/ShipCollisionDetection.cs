using UnityEngine;
using System.Collections;

public class ShipCollisionDetection : MonoBehaviour {

    // public GameObject elasticRope;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("CHOQUED");
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("TAGGED");
            //GameObject cuac = Instantiate(this.elasticRope, new Vector3(0f,0f,0f), Quaternion.identity );
            //GameObject elasticRope = ObjectPool.instance.pull("ElasticRope");
            GameObject elasticRopeGameObj = GameObject.Find("ElasticRope");
            ElasticRope rope = elasticRopeGameObj.GetComponent<ElasticRope>();
            rope.ConnectRope(this.gameObject, other.gameObject);
            rope.Show();


            // Destroy(other.gameObject);
        }
    }
}
