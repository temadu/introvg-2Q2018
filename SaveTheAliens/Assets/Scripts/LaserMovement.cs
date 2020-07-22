using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {
    
    public float speed = 3f;
    public float timer = 1.5f;
    private float realTimer;

    void start(){
        realTimer = timer;
    }
	
	void Update () {
        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
        if(realTimer <= 0){
            this.gameObject.SetActive(false);
            ObjectPool.instance.push(this.gameObject);
            realTimer = timer;
        }
        else{
            realTimer -= Time.deltaTime;
        }
    }
}
