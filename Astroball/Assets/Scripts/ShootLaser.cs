using UnityEngine;
using System.Collections;

public class ShootLaser : MonoBehaviour {
    public string laserName;

    [Header("Controller Settings")]
    public KeyCode shootKey = KeyCode.Space;

	void Update () {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject laserAux = ObjectPool.instance.pull(laserName);
            if (laserAux == null)
                return;
            laserAux.SetActive(true);
            laserAux.transform.position = transform.position;
            laserAux.transform.rotation = transform.rotation;
        }
    }
}
