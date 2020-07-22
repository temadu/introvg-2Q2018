using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticRope : MonoBehaviour {

    public GameObject startPoint;
    public GameObject endPoint;

    private EdgeCollider2D col;
    private Vector2[] vertices;
    private LineRenderer rend;

    private DistanceJoint2D dJoint;
    private SpringJoint2D sJoint;

    public void Start() {
        this.col = GetComponent<EdgeCollider2D>();
        this.vertices = col.points;
        this.dJoint = GetComponent<DistanceJoint2D>();
        this.sJoint = GetComponent<SpringJoint2D>();
        this.rend = GetComponent<LineRenderer>();
        this.rend.positionCount = 2;

        this.dJoint.connectedBody = this.startPoint.GetComponent<Rigidbody2D>();
        this.sJoint.connectedBody = this.endPoint.GetComponent<Rigidbody2D>();

        this.rend.SetPosition(0, this.startPoint.transform.position);
        this.rend.SetPosition(1, this.endPoint.transform.position);

        // this.rend.enabled = false;
        //this.gameObject.SetActive(false);
        // this.ConnectRope(this.startPoint, this.endPoint);
    }


    public void ConnectRope(GameObject startPoint, GameObject endPoint) {

        this.startPoint = startPoint;
        this.endPoint = endPoint;

        // this.dJoint = this.gameObject.AddComponent(typeof(DistanceJoint2D)) as DistanceJoint2D;
        // this.dJoint.autoConfigureDistance = false;
        // this.dJoint.distance = 1;
        // this.dJoint.maxDistanceOnly = true;
        // this.dJoint.breakForce = Mathf.Infinity;
        this.dJoint.connectedBody = this.startPoint.GetComponent<Rigidbody2D>();

        // this.sJoint = this.gameObject.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;
        // this.sJoint.autoConfigureDistance = false;
        // this.sJoint.distance = 1;
        // this.sJoint.dampingRatio = 1;
        // this.sJoint.frequency = 1;
        // this.sJoint.breakForce = Mathf.Infinity;
        this.sJoint.connectedBody = this.endPoint.GetComponent<Rigidbody2D>();

        this.rend.SetPosition(0, this.startPoint.transform.position);
        this.rend.SetPosition(1, this.endPoint.transform.position);

       // this.dJoint.enabled = true;
        //this.sJoint.enabled = true;
        //this.rend.enabled = true;
    }

    public void DisconnectRope() {

        this.endPoint.GetComponent<Rigidbody2D>().drag = 0.3f;
        // GameManagerScript.instance.playerWithBall = -1;
        
        //this.dJoint.enabled = false;
        //this.sJoint.enabled = false;

        //Destroy(this.dJoint);
        //Destroy(this.sJoint);
        //this.dJoint.connectedBody = null;
        //this.sJoint.connectedBody = null;
        //this.startPoint = null;
        //this.endPoint = null;
        //this.ConnectRope(newGameObject, newGameObject);
        

        //this.rend.enabled = false;
        
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update() {
        //Physics
        // this.col.points[0] = transform.parent.position;
        // this.vertices[0] = new Vector2(startPoint.transform.position.x - transform.position.x, startPoint.transform.position.y - transform.position.y);
        // this.vertices[1] = new Vector2(endPoint.transform.position.x - transform.position.x, endPoint.transform.position.y - transform.position.y);
        // this.col.points = this.vertices;

        if (this.startPoint == null || this.endPoint == null) return;

		//Renderer
		this.rend.SetPosition(0, this.startPoint.transform.position);
		this.rend.SetPosition(1, this.endPoint.transform.position);
	}
}
