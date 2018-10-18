using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRoad : MonoBehaviour {

	public float speed = 10f;
	// Update is called once per frame
	private void FixedUpdate() {
		if(transform.position.z < -56f)
			this.transform.position = new Vector3(transform.position.x,transform.position.y, 34f);
		this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.fixedDeltaTime);
	}
}
