using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool instance;

    //Prefabs to pool
    public List<GameObject> objectPrefabs = new List<GameObject>();
    private Dictionary<string, InnerPool> pools;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pools = new Dictionary<string,InnerPool>();
        foreach(GameObject gameObj in objectPrefabs)
        {
            Debug.Log("Cargando pool");
            Debug.Log(gameObj.name);
            pools.Add(gameObj.name,new InnerPool(gameObj, 1, true));
            //print("Adding object to pool: " + gameObj.name);
        }
    }

    public void push(GameObject obj)
    {
        InnerPool inner = pools[obj.name];
        inner.Push(obj);
    }

    public GameObject pull(string objName)
    {
        print("Getting object Name: " + objName);
        InnerPool inner = pools[objName];
        return inner.Pop();
    }

    public void changePooledAmount(string objName, int newPooledAmount)
    {
        InnerPool inner = pools[objName];
        inner.pooledAmount = newPooledAmount;
    }

    public void changeAllowGrowth(string objName, bool allowGrowth)
    {
        InnerPool inner = pools[objName];
        inner.allowGrowth = allowGrowth;
    }


    private class InnerPool{

        private GameObject pooledObject;
        public int pooledAmount;
        public bool allowGrowth;

        Stack<GameObject> pooledObjects;

        public InnerPool(GameObject obj, int startAmount, bool growth)
        {

            pooledObject = obj;
            pooledAmount = startAmount;
            allowGrowth = growth;

            pooledObjects = new Stack<GameObject>();
            for (int i = 0; i < pooledAmount; i++)
            {
                GameObject obje = (GameObject)Instantiate(pooledObject);
                obje.SetActive(false);
                pooledObjects.Push(obj);
            }
        }

        public GameObject Pop()
        {
            if (pooledObjects.Count > 0)
            {
                Debug.Log("Popeo el fucking object");
                return pooledObjects.Pop();
            }

            if (allowGrowth)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                obj.name = pooledObject.name;
                //pooledObjects.Push(obj);
                return obj;
            }

            return null;
        }

        public void Push(GameObject obj)
        {
            pooledObjects.Push(obj);
        }
    }
}
