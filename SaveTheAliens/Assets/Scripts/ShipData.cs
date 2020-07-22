using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour {


	public int playerNumber;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if (GameManagerScript.instance.winner == -1) return;

        if (playerNumber == GameManagerScript.instance.winner)
            rb.transform.Rotate(transform.forward * 15);
        

    }

}
