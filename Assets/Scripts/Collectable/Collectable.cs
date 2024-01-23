using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] Transform[] collectablePoints;
    [SerializeField] float pointChangeMaxSec;

    public int minValue { get; protected set; }
    public int maxValue {  get; protected set; }
    public int value { get; protected set; }

    private int pointIndex;
    private float pointChangeTimePerSec;

    private void Awake()
    {
        pointIndex = 0;
        pointChangeTimePerSec = 0;
    }

    private void Start()
    {
        ChangeCollectablePoint();
    }

    private void Update()
    {
        pointChangeTimePerSec += Time.deltaTime;

        if(pointChangeTimePerSec >= pointChangeMaxSec)
        {
            ChangeCollectablePoint();
            pointChangeTimePerSec = 0;
        }
    }

    public void ChangeCollectablePoint()
    {
        pointIndex = Random.Range(0, collectablePoints.Length);
        transform.position = collectablePoints[pointIndex].position;
    }

    public abstract void ImproveEnemy(IImprovable enemy);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            IImprovable enemy = collision.GetComponent<IImprovable>();
            value = Random.Range(minValue, maxValue);
            ImproveEnemy(enemy);

            gameObject.SetActive(false);

        }

    }
}
