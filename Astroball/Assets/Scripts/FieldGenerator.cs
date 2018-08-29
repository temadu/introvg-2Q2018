using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour {

	public GameObject fieldTop;
	public GameObject fieldBottom;
	public GameObject goalLeft;
	public GameObject goalRight;


    private float camHalfHeight;
    private float camHalfWidth;
    public float offsetX = 0;
    public float offsetY = 0;
	public float goalSize = 2f;

    void Start()
    {
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth = Camera.main.aspect * camHalfHeight;
		this.InitializeField();
    }
	
	void InitializeField(){
		LineRenderer rend;
		EdgeCollider2D col;
		Vector2[] points = new Vector2[4];
		Vector3[] points3D = new Vector3[4];
		//FIELDS
		rend = fieldTop.GetComponent<LineRenderer>();
		col = fieldTop.GetComponent<EdgeCollider2D>();
		rend.positionCount = 4;
		points[0] = new Vector2(-camHalfWidth + offsetX, goalSize/2);
        points[1] = new Vector2(-camHalfWidth + offsetX, camHalfHeight - offsetY);
        points[2] = new Vector2(camHalfWidth - offsetX, camHalfHeight - offsetY);
        points[3] = new Vector2(camHalfWidth - offsetX, goalSize/2);
		col.points = points;
		points3D[0] = points[0];
		points3D[1] = points[1];
		points3D[2] = points[2];
		points3D[3] = points[3];
		rend.SetPositions(points3D);

		rend = fieldBottom.GetComponent<LineRenderer>();
		col = fieldBottom.GetComponent<EdgeCollider2D>();
		rend.positionCount = 4;
		points[0] = new Vector2(-camHalfWidth + offsetX, -goalSize/2);
        points[1] = new Vector2(-camHalfWidth + offsetX, -camHalfHeight + offsetY);
        points[2] = new Vector2(camHalfWidth - offsetX, -camHalfHeight + offsetY);
        points[3] = new Vector2(camHalfWidth - offsetX, -goalSize/2);
		col.points = points;
		points3D[0] = points[0];
		points3D[1] = points[1];
		points3D[2] = points[2];
		points3D[3] = points[3];
		rend.SetPositions(points3D);

        //GOALS
        col = goalLeft.GetComponent<EdgeCollider2D>();
		points = new Vector2[2];
        points[0] = new Vector2(-camHalfWidth + offsetX, goalSize / 2);
        points[1] = new Vector2(-camHalfWidth + offsetX, -goalSize / 2);
        col.points = points;

        col = goalRight.GetComponent<EdgeCollider2D>();
		points = new Vector2[2];
        points[0] = new Vector2(camHalfWidth - offsetX, goalSize / 2);
        points[1] = new Vector2(camHalfWidth - offsetX, -goalSize / 2);
        col.points = points;

	}
}
