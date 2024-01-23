using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolController : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> gameObjects;
        public GameObject gameObjectPrefab;
        public int poolSize;
    }

    public Pool[] objectPools;

    [SerializeField] protected float spawnInternal;

    private void Awake()
    {
        for(int i = 0; i < objectPools.Length; i++)
        {
            objectPools[i].gameObjects = new Queue<GameObject>();

            for (int j = 0; j < objectPools[i].poolSize; j++)
            {
                GameObject collectable = Instantiate(objectPools[i].gameObjectPrefab, transform.position, Quaternion.identity);

                collectable.SetActive(false);

                objectPools[i].gameObjects.Enqueue(collectable);
            }
        }
    }

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    public abstract void GetPooledObjects();

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            GetPooledObjects();
            yield return new WaitForSeconds(spawnInternal);
        }
    }

}
