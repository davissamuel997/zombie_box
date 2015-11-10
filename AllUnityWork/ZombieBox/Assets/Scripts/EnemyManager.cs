using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth health;
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;
    public RoundStats roundInfo;
    int spawnCount = 0;

    // Use this for initialization
    void Start()
    {
        Debug.Log("enemy manager init");
        InvokeRepeating("Spawn", 5, 5);
    }

    bool flag = true;
    // Update is called once per frame
    void Update()
    {
       
    }
    void Spawn()
    {
        int spawnSelection = Random.Range(0, spawnPoints.Length);
        if (spawnCount < roundInfo.NUM_ENEMIES) 
        {

            Instantiate(enemy, spawnPoints[spawnSelection].position, spawnPoints[spawnSelection].rotation);
            spawnCount++;
        }
    }
}
