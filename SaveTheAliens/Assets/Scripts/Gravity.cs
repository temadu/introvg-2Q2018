using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private HashSet<Rigidbody2D> attractedObjects = new HashSet<Rigidbody2D>();
    public float intencity = 1f;
    public AudioSource gravitySound;
    void Start()
    { }

    void FixedUpdate() {
      foreach (Rigidbody2D other in attractedObjects) {
        Vector3 gravityVector = (transform.position - other.transform.position).normalized;
        other.AddForce((gravityVector * intencity) * other.mass);
      }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Player"){
        this.attractedObjects.Add(other.GetComponent<Rigidbody2D>());
        if(this.gravitySound != null)
          this.gravitySound.Play();
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.gameObject.tag == "Player"){
        this.attractedObjects.Remove(other.GetComponent<Rigidbody2D>());
        if (this.gravitySound != null)
          this.gravitySound.Stop();
      }
    }
}
