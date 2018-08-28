using UnityEngine;
using System.Collections;

public class InstanciateObjectOnDestroy : MonoBehaviour {

    public GameObject gObject;
    public int quantity;

    private bool isQuitting = false;

    void OnApplicationQuit(){
        Debug.Log("quitting");
        isQuitting = true;

    }

    void OnDestroy() {
        Debug.Log("killing");
        if (!isQuitting) {
            for (int i = 0; i < quantity; i++) {
                Object.Instantiate(gObject, transform.position, transform.rotation);
            }
        }
    }
}
