using UnityEngine;
using System.Collections;

public class InstanciateObjectOnDestroy : MonoBehaviour {

    public GameObject gObject;
    public int quantity;

    public bool isQuitting = false;

    void OnApplicationQuit(){
        isQuitting = true;
    }

    void OnDestroy() {
        if (!isQuitting && !TransporterLevelGM.instance.isQuitting) {
            for (int i = 0; i < quantity; i++) {
                Object.Instantiate(gObject, transform.position, transform.rotation);
            }
        }
    }
}
