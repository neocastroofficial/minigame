using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : ObjectPoolController
{
    public override void GetPooledObjects()
    {
        int spawnIndex = UnityEngine.Random.Range(0, objectPools.Length);

        if (objectPools[spawnIndex].gameObjects.Count > 0)
        {

            GameObject enemy = objectPools[spawnIndex].gameObjects.Dequeue();

            enemy.transform.position = transform.position;

            enemy.SetActive(true);

        }
    }
}
