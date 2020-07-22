using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{

  public List<GameObject> targets;

  public Vector3 offset;
  public float smoothTime = 0.5f;
  public float minZoom = 13f;
  public float maxZoom = 6f;
  public float zoomLimiter = 40f;
  private Vector3 velocity;
  private Camera cam;

  private void Start()
  {
    cam = GetComponent<Camera>();
  }

  void FixedUpdate()
  {

    if (targets.Count == 0) return;

    Move();
    Zoom();

  }

  void Move()
  {
    Vector3 centerPoint = GetCenterPoint();
    Vector3 newPosition = centerPoint + offset;
    transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
  }

  void Zoom()
  {
    float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    cam.orthographicSize = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
  }

  public void ResetCamera()
  {
    Vector3 centerPoint = GetCenterPoint();
    Vector3 newPosition = centerPoint + offset;
    transform.position = newPosition;

    float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
    if (cam != null)
    {
      cam.fieldOfView = newZoom;
      cam.orthographicSize = newZoom;
    }

  }

  float GetGreatestDistance()
  {
    var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
    for (int i = 0; i < targets.Count; i++)
    {
      bounds.Encapsulate(targets[i].transform.position);
    }
    return Mathf.Max(bounds.size.x, bounds.size.z);
  }

  Vector3 GetCenterPoint()
  {
    if (targets.Count == 1)
    {
      return targets[0].transform.position;
    }

    var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
    for (int i = 0; i < targets.Count; i++)
    {
      bounds.Encapsulate(targets[i].transform.position);
    }
    return bounds.center;
  }
}
