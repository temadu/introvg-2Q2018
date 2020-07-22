using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EdgeCollisionGenerator : MonoBehaviour {

    private EdgeCollider2D _edgeCollider;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _edgeCollider = GetComponent<EdgeCollider2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        generate();
    }

    private void generate(){
    //   Vector3[] points = new Vector3[_lineRenderer.positionCount];
    // _lineRenderer.GetPositions(points);
      List<Vector2> list = new List<Vector2>();
      for (int i = 0; i < _lineRenderer.positionCount; i++)
      {
        Vector3 point = _lineRenderer.GetPosition(i);
        list.Add(new Vector2(point.x, point.y));
      }
      list.Add(new Vector2(list[0].x, list[0].y));

      // Vector2[] points = Enumerable.Range(0, _lineRenderer.positionCount)
      //   .Select(i =>
      //   {
      //     Vector3 point = _lineRenderer.GetPosition(i);
      //     return new Vector2(point.x, point.y);
      //   })
      //   .ToArray();
      _edgeCollider.points = list.ToArray();
    }
	
	// void InitializeField(){
	// 	LineRenderer rend;
	// 	EdgeCollider2D col;
	// 	Vector2[] points = new Vector2[4];
	// 	Vector3[] points3D = new Vector3[4];
	// 	//FIELDS
	// 	rend = fieldTop.GetComponent<LineRenderer>();
	// 	col = fieldTop.GetComponent<EdgeCollider2D>();
	// 	rend.positionCount = 4;
	// 	points[0] = new Vector2(-camHalfWidth + offsetX, goalSize/2);
  //       points[1] = new Vector2(-camHalfWidth + offsetX, camHalfHeight - offsetY);
  //       points[2] = new Vector2(camHalfWidth - offsetX, camHalfHeight - offsetY);
  //       points[3] = new Vector2(camHalfWidth - offsetX, goalSize/2);
	// 	col.points = points;
	// 	points3D[0] = points[0];
	// 	points3D[1] = points[1];
	// 	points3D[2] = points[2];
	// 	points3D[3] = points[3];
	// 	rend.SetPositions(points3D);

	// 	rend = fieldBottom.GetComponent<LineRenderer>();
	// 	col = fieldBottom.GetComponent<EdgeCollider2D>();
	// 	rend.positionCount = 4;
	// 	points[0] = new Vector2(-camHalfWidth + offsetX, -goalSize/2);
  //       points[1] = new Vector2(-camHalfWidth + offsetX, -camHalfHeight + offsetY);
  //       points[2] = new Vector2(camHalfWidth - offsetX, -camHalfHeight + offsetY);
  //       points[3] = new Vector2(camHalfWidth - offsetX, -goalSize/2);
	// 	col.points = points;
	// 	points3D[0] = points[0];
	// 	points3D[1] = points[1];
	// 	points3D[2] = points[2];
	// 	points3D[3] = points[3];
	// 	rend.SetPositions(points3D);

  //       //GOALS
  //       col = goalLeft.GetComponent<EdgeCollider2D>();
	// 	points = new Vector2[2];
  //       points[0] = new Vector2(-camHalfWidth + offsetX, goalSize / 2);
  //       points[1] = new Vector2(-camHalfWidth + offsetX, -goalSize / 2);
  //       col.points = points;

  //       col = goalRight.GetComponent<EdgeCollider2D>();
	// 	points = new Vector2[2];
  //       points[0] = new Vector2(camHalfWidth - offsetX, goalSize / 2);
  //       points[1] = new Vector2(camHalfWidth - offsetX, -goalSize / 2);
  //       col.points = points;

	// }
}
