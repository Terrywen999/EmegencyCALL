using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    // list of the objects to be pooled 
    public List<GameObject> PrefabsForPool;

    // list of the pooled opjects 
    private List<GameObject> _pooledObjects = new List<GameObject>();

    public Transform transform;

    public GameObject GetGameObjectFromPool(string objectName)
    {
        var instance  = _pooledObjects.FirstOrDefault(obj => obj.name == objectName);
        if(instance != null)
        {
            _pooledObjects.Remove(instance);
            instance.SetActive(true);
            return instance; 
        }

        var prefab = PrefabsForPool.FirstOrDefault(obj =>obj.name == objectName);
        if(prefab != null)
        {
            var newInstace = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform );
            newInstace.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            newInstace.name = objectName;
            return newInstace; 
        }

        Debug.LogWarning("Object pool doesnt have a prefab for the object with name" + objectName); 
        return null;
    }


    public void PoolObject(GameObject obj)
    {
        obj.SetActive(false); 
        _pooledObjects.Add(obj);
    }

    public void Clear()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = _pooledObjects.Count - 1; i >= 0; i--)
        {
         _pooledObjects.Remove(_pooledObjects[i]);
        }
    }
}
