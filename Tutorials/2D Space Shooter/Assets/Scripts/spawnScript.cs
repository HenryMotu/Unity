using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addEnemy", 0, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void addEnemy()
    {
        var rd = GetComponent<Renderer>();
        var leftSpawnEdge = transform.position.x - rd.bounds.size.x / 2;
        var rightSpawnEdge = transform.position.x + rd.bounds.size.x / 2;

        var spawnPoint = new Vector2(Random.Range(leftSpawnEdge, rightSpawnEdge), transform.position.y);

        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
