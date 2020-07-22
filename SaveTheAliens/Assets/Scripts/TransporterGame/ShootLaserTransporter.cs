using UnityEngine;
using System.Collections;

public class ShootLaserTransporter : MonoBehaviour {

    [Header("Controller Settings")]
    public KeyCode shootKey = KeyCode.Space;
    public AudioSource shootSound;

    private void Start() {
      if(this.shootSound == null){
        this.shootSound = GameObject.Find("LaserShot").GetComponent<AudioSource>();
      }
    }

    void Update()
    {
        if (Input.GetKeyDown(this.shootKey))
        {
            GameObject laserAux = ObjectPool.instance.pull("LaserTransporter");
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
