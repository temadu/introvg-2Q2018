using UnityEngine;
using System.Collections;

public class ShootLaser_P2 : MonoBehaviour {

    [Header("Controller Settings")]
    public KeyCode shootKey = KeyCode.RightControl;

    void Update()
    {
        if (Input.GetKeyDown(this.shootKey))
        {
            GameObject laserAux = ObjectPool.instance.pull("LaserRed");
            if (laserAux == null)
                return;
            laserAux.SetActive(true);
            laserAux.transform.position = transform.position;
            laserAux.transform.rotation = transform.rotation;
        }
    }
}
