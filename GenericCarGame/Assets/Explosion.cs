using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public AudioSource explosionSound;
	private void OnEnable() {
		this.explosionSound.pitch = Random.Range(1f, 1.6f);
		this.explosionSound.Play();	
	}
}
