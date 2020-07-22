using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class DrawCircleano : MonoBehaviour
{
  public int vertexCount = 40; // 4 vertices == square
  public float lineWidth = 0.2f;
  public float radius;

  public Color borderColor = Color.magenta;
  public Color fillColor = Color.magenta;

  private MeshRenderer _meshRenderer;
  private MeshFilter _meshFilter;
  private LineRenderer lineRenderer;
  

  private void Awake()
  {
    lineRenderer = GetComponent<LineRenderer>();
    _meshFilter = GetComponent<MeshFilter>();
    _meshRenderer = GetComponent<MeshRenderer>();
    SetupCircle();
  }
  
  private void Update() {
  }

  private void SetupCircle()
  {
    lineRenderer.loop = true;
    lineRenderer.useWorldSpace = false;
    lineRenderer.widthMultiplier = lineWidth;
    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    lineRenderer.startColor = borderColor; 
    lineRenderer.endColor = borderColor; 

    float deltaTheta = (2f * Mathf.PI) / vertexCount;
    float theta = 0f;

    lineRenderer.positionCount = vertexCount;
    for (int i = 0; i < lineRenderer.positionCount; i++)
    {
      Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
      lineRenderer.SetPosition(i, pos);
      theta += deltaTheta;
    }

    _meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
    // _meshFilter.mesh = CircleMesh(transform.position, lineRenderer.GetPosition(0) + transform.position, fillColor);
    _meshFilter.mesh = MakeCircle();

  }

  private Mesh CircleMesh(Vector2 v0, Vector2 v1, Color fillColor)
  {

    const float segmentMultiplier = 2 * Mathf.PI;
    var numSegments = (int)(radius * segmentMultiplier + vertexCount);

    // Create an array of points arround a cricle
    var circleVertices = Enumerable.Range(0, numSegments)
        .Select(i =>
        {
          var theta = 2 * Mathf.PI * i / numSegments;
          return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;
        })
        .ToArray();

    Debug.Log("circleVertices");
    Debug.Log(circleVertices.Length);
    Debug.Log(circleVertices[1]);
    Debug.Log(circleVertices[2]);
    Debug.Log(circleVertices[3]);
    Debug.Log("lineRenderer");
    Debug.Log(lineRenderer.positionCount);
    Debug.Log(lineRenderer.GetPosition(1));
    Debug.Log(lineRenderer.GetPosition(2));
    Debug.Log(lineRenderer.GetPosition(3));

    // Find all the triangles in the shape
    var triangles = new Triangulator(circleVertices).Triangulate();

    // Assign each vertex the fill color
    var colors = Enumerable.Repeat(fillColor, circleVertices.Length).ToArray();

    var mesh = new Mesh
    {
      name = "Circle",
      vertices = circleVertices.ToVector3(),
      triangles = triangles,
      colors = colors
    };

    mesh.RecalculateNormals();
    mesh.RecalculateBounds();
    mesh.RecalculateTangents();

    return mesh;
  }

  public Mesh MakeCircle()
  {
    float angleStep = 360.0f / (float)vertexCount;
    List<Vector3> vertexList = new List<Vector3>();
    List<int> triangleList = new List<int>();
    Quaternion quaternion = Quaternion.Euler(0.0f, 0.0f, angleStep);
    // Make first triangle.
    vertexList.Add(new Vector3(0.0f, 0.0f, 0.0f));  // 1. Circle center.
    vertexList.Add(new Vector3(0.0f, radius, 0.0f));  // 2. First vertex on circle outline (radius = 0.5f)
    vertexList.Add(quaternion * vertexList[1]);     // 3. First vertex on circle outline rotated by angle)
                                                    // Add triangle indices.
    triangleList.Add(0);
    triangleList.Add(1);
    triangleList.Add(2);
    for (int i = 0; i < vertexCount - 1; i++)
    {
      triangleList.Add(0);                      // Index of circle center.
      triangleList.Add(vertexList.Count - 1);
      triangleList.Add(vertexList.Count);
      vertexList.Add(quaternion * vertexList[vertexList.Count - 1]);
    }
    var colors = Enumerable.Repeat(fillColor, vertexList.Count).ToArray();

    Mesh mesh = new Mesh();
    mesh.vertices = vertexList.ToArray();
    mesh.triangles = triangleList.ToArray();
    mesh.colors = colors;
    mesh.RecalculateBounds();
    mesh.RecalculateNormals();
    mesh.RecalculateTangents();
    return mesh;
  }


#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    float deltaTheta = (2f * Mathf.PI) / vertexCount;
    float theta = 0f;

    Vector3 oldPos = transform.position + new Vector3(radius * Mathf.Cos(theta) * transform.localScale.x, radius * Mathf.Sin(theta) * transform.localScale.y, 0f);
    for (int i = 0; i < vertexCount + 1; i++)
    {
      Vector3 pos = new Vector3(radius * Mathf.Cos(theta) * transform.localScale.x, radius * Mathf.Sin(theta) * transform.localScale.y, 0f);
      Gizmos.DrawLine(oldPos, transform.position + pos);
      oldPos = transform.position + pos;

      theta += deltaTheta;
    }
  }
#endif
}
