using UnityEngine;
using System.Collections;

public class DestroyBothOnCollision : MonoBehaviour {

    public string otherObject;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLISIONA");
        Debug.Log(other.gameObject.tag);
        Debug.Log(otherObject);
        if (other.gameObject.tag == otherObject)
        {
            Debug.Log("COLISIONA TAG");

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
