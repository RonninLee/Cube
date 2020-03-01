using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Points Generator")]
    private Vector2 min;
    private Vector2 max;

    private float xAxis;
    private float yAxis;

    private Vector2 randomPosition;

    public bool canInstantiate;
    public GameObject point;

    [Header("Time Settings")]
    public float timeCounter;
    public float maxTimeCounter = 1f;

    [Header("SpawnObject")]
    public GameObject[] enemyPrefab;

    public GameObject[] points;
    public GameObject currentPoint;

    public Vector2 transformPoint;

    int index;

    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("Point");

        //SetRanges();

        timeCounter = 0f;
    }

    void Update()
    {
        xAxis = Random.Range(min.x, max.x);
        yAxis = Random.Range(min.y, max.y);

        randomPosition = new Vector2(xAxis, yAxis);

        if (timeCounter >= maxTimeCounter)
        {
            //InstantiateRandomObjects();
            SelectSpawnPoint();
            Spawn();

            timeCounter = 0f;
        }
        else timeCounter += Time.deltaTime;
    }

    /*void SetRanges()
    {
        min = new Vector2(25, 25);
        max = new Vector2(35, 35);
    }

    void InstantiateRandomObjects()
    {
        Instantiate(point, randomPosition, Quaternion.identity);
    }*/

    void Spawn()
    {
        GameObject selectedEnemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        GameObject enemy = Instantiate(selectedEnemy, transformPoint, Quaternion.Euler(0, 0, 0));
        enemy.name = selectedEnemy.name;
    }

    void SelectSpawnPoint()
    {
        index = Random.Range(0, points.Length);
        currentPoint = points[index];

        transformPoint = currentPoint.transform.position;
    }
}
