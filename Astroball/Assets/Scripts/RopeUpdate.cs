using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeUpdate : MonoBehaviour {

	public GameObject endPoint;
	private EdgeCollider2D col;
	private Vector2[] vertices;
	private LineRenderer rend;

	void Start () {
		this.col = GetComponent<EdgeCollider2D>();
		this.rend = GetComponent<LineRenderer>();
		this.vertices = col.points;
	}
	
	// Update is called once per frame
	void Update () {
		// this.col.points[0] = transform.parent.position;
		this.vertices[1] = new Vector2(endPoint.transform.position.x - transform.position.x, endPoint.transform.position.y - transform.position.y);
		this.col.points = this.vertices;
		this.rend.SetPosition(0, transform.position);
		this.rend.SetPosition(1, endPoint.transform.position);
	}
}
