using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieRight : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRate = 2f;
    public Vector3 spawnRange = new Vector3(0, 0, 0);
    public bool isLeft = true;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);

        GameObject spawnedZombie = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        if(isLeft == false)
        {
            spawnedZombie.GetComponent<Zombie>().moveAmount = spawnedZombie.GetComponent<Zombie>().moveAmount*-1;
        }
    }
}