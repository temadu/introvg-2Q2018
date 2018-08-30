using UnityEngine;
using System.Collections;

public class DestroyBothOnCollision : MonoBehaviour {

    public string otherObject;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == otherObject)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
