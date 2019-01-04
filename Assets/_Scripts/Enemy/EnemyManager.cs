using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float initialWaitTime = 2.0f;
    public float repeatingSpawnTime = 10.0f;
    public Transform[] spawnPoints;
    public float minX, minY, minZ, maxX, maxY, maxZ; 

    // Start is called before the first frame update
    void Start()
    {
        //
        InvokeRepeating("Spawn", initialWaitTime, repeatingSpawnTime);
    }


    void Spawn()
    {
        //TODO: implement player health and instantiate enemies only when alive
        if(playerHealth.currentHealth <= 0f) {return;}
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);
        Vector3 pos = new Vector3(x, y, z);

        Instantiate(enemy, pos, spawnPoints[spawnPointIndex].rotation);
    }
}
