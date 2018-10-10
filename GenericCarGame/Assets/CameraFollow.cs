﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour {

	public List<Transform> targets;

	public Vector3 offset;
	public float smoothTime = 0.5f;
	public float minZoom = 13f;
	public float maxZoom = 6f;
	public float zoomLimiter = 40f;
	private Vector3 velocity;
	private Camera cam;

	private void Start() {
		cam = GetComponent<Camera>();
	}

	void FixedUpdate() {

		if(targets.Count == 0) return;

		Move();
		Zoom();
		
	}

	void Move(){
    Vector3 centerPoint = GetCenterPoint();
    Vector3 newPosition = centerPoint + offset;
    transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	} 

	void Zoom(){
		float newZoom = Mathf.Lerp(maxZoom,minZoom, GetGreatestDistance()/zoomLimiter);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
		cam.orthographicSize = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
  }

	float GetGreatestDistance(){
    var bounds = new Bounds(targets[0].position, Vector3.zero);
    for (int i = 0; i < targets.Count; i++)
    {
      bounds.Encapsulate(targets[i].position);
    }
		return Mathf.Max(bounds.size.x,bounds.size.z);
	}
	
	Vector3 GetCenterPoint(){
		if(targets.Count == 1){
			return targets[0].position;
		}

		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++){
				bounds.Encapsulate(targets[i].position);
		}
		return bounds.center;
	}
}
