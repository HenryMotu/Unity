using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 9;
    private int numberOfWaves = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        for (var i = 0; i <= numberOfWaves; i++)
        {
            Vector3 randomPos = GetRandomPosition();
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
        Instantiate(powerUp, GetRandomPosition(), powerUp.transform.rotation);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPos;
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<EnemyController>().Length < 1)
        {
            numberOfWaves++;
            StartWave();
        }
    }
}
