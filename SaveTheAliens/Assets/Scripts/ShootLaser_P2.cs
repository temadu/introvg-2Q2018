using UnityEngine;
using System.Collections;

public class ShootLaser_P2 : MonoBehaviour {

    [Header("Controller Settings")]
    public KeyCode shootKey = KeyCode.RightControl;
    public AudioSource shootSound;

    void Update()
    {
        if (Input.GetKeyDown(this.shootKey))
        {
            GameObject laserAux = ObjectPool.instance.pull("LaserRed");
            if (laserAux == null)
                return;
            laserAux.transform.rotation = transform.rotation;
            laserAux.transform.position = transform.position + (transform.up * 0.5f);
            if(shootSound)
              shootSound.Play();
            laserAux.SetActive(true);
        }
    }
}
