using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int poolSize = 20;

    private Queue<GameObject> _pooledObjects = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        // Create pool objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false); // Make it inactive until needed
            _pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetFromPool(Vector3 position, Quaternion rotation)
    {
        if (_pooledObjects.Count > 0)
        {
            GameObject obj = _pooledObjects.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }
        
        // If pool is empty, instantiate a new object
        return Instantiate(projectilePrefab, position, rotation);
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        _pooledObjects.Enqueue(obj);
    }
}