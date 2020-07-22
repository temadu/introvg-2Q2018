using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    // Start is called before the first frame update
    void Start()
    {
      this.otherPortal = gameObject.transform.parent.GetChild(this.gameObject.transform.GetSiblingIndex() == 0 ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
