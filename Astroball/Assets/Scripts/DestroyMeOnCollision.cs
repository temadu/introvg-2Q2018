using UnityEngine;
using System.Collections;

public class DestroyMeOnCollision : MonoBehaviour {

    public string otherObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == otherObject)
        {
            Destroy(this.gameObject);
        }
    }
}
