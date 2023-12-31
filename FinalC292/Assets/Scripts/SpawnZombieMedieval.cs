using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieMedieval : MonoBehaviour
{
    public GameObject objectToSpawn;
    float spawnRate = 2f;
    public Vector3 spawnRange = new Vector3(0, 0, 0);
    public bool isLeft = true;
    int x = 0;

    private float nextSpawnTime;
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (x > 5)
            {
                spawnRate = 3f;
            }

            if (x > 10)
            {
                spawnRate = 4f;
            }

            if (Time.time > nextSpawnTime)
            {
                SpawnObject();
                nextSpawnTime = Time.time + spawnRate;
                x = x + 1;
            }
        }
    }

    void setspawnRate(float x)
    {
        spawnRate = x; 
    }
    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject spawnedZombie = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        if (isLeft == false)
        {
            spawnedZombie.GetComponent<Zombie>().moveAmount = spawnedZombie.GetComponent<Zombie>().moveAmount * -1;
        }
    }
}