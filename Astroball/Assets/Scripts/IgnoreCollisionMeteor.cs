using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionMeteor : MonoBehaviour {

	void Start () {
        foreach (var col in GameObject.FindGameObjectsWithTag("Goal")){
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
		foreach (var col in GameObject.FindGameObjectsWithTag("Field")) {
        	Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}
	
}
