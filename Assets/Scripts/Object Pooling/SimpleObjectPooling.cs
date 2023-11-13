using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPooling", menuName = "ScriptableObject/Player/ObjectPooling", order = 0)]
public class SimpleObjectPooling : ScriptableObject
{
    [SerializeField] 
    private GameObject objectPrefab;
    private Queue<GameObject> objectPool;
    private Transform parentTransform;
    public event Action onEnableObject;

    public void SetUp(Transform parent)
    {
        if (objectPool == null)
        {
            objectPool = new Queue<GameObject>();
        }

        objectPool.Clear();
        parentTransform = parent;
    }

    public GameObject GetObject()
    {
        GameObject objectInstance = null;

        if (objectPool.Count > 0)
        {
            objectInstance = objectPool.Dequeue();
            objectInstance.SetActive(true);
            onEnableObject?.Invoke();
        }
        else
        {
            objectInstance = Instantiate(objectPrefab, parentTransform.transform.position, parentTransform.transform.rotation, parentTransform);
            objectInstance.SetActive(true);
            onEnableObject?.Invoke(); 
        }

        return objectInstance;
    }

    public void ObjectReturn(GameObject objectInstance)
    {
        objectInstance.SetActive(false);
        objectPool.Enqueue(objectInstance);
        objectInstance.transform.position = parentTransform.position;
    }
}
