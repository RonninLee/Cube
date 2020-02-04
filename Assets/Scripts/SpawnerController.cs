using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [Header("Time Settings")]
    public float timeCounter;
    public float maxTimeCounter = 0f;

    [Header("SpawnObject")]
    public GameObject[] enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter >= maxTimeCounter)
        {
            Spawn();

            timeCounter = 0f;
        }
        else timeCounter += Time.deltaTime;
    }

    void Spawn()
    {
        Vector2 spawnPos = transform.position;

        GameObject selectedEnemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        GameObject enemy = Instantiate(selectedEnemy, spawnPos, Quaternion.Euler(0, 0, 0));
        enemy.name = selectedEnemy.name;
    }
}
