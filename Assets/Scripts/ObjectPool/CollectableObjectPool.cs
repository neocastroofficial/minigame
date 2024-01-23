using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectPool : ObjectPoolController
{
    public override void GetPooledObjects()
    {
        int spawnIndex = UnityEngine.Random.Range(0, objectPools.Length);

        if (objectPools[spawnIndex].gameObjects.Count > 0)
        {

            GameObject collectable = objectPools[spawnIndex].gameObjects.Dequeue();

            collectable.SetActive(true);

            objectPools[spawnIndex].gameObjects.Enqueue(collectable);

        }
    }
}
