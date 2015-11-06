using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth health;
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;
    

    // Use this for initialization
    void Start()
    {
        Debug.Log("enemy manager init");
        
    }

    bool flag = true;
    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        int spawnSelection = Random.Range(0, spawnPoints.Length);
        if (flag)
        {
            flag = false;

            Instantiate(enemy, spawnPoints[spawnSelection].position, spawnPoints[spawnSelection].rotation);
            
        }
    }
}
