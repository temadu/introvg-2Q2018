using UnityEngine;
using System.Collections;

public class DestroyBothOnCollision : MonoBehaviour {

    public string otherObject;

    private AudioSource destroySound;

    private void Start() {
      destroySound = GameObject.Find("AsteroidExplotion").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == otherObject)
        {
            if(this.destroySound){
              destroySound.Play();
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
