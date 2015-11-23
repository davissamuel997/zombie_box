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

	float delay;

	public List<EnemyHealth> enemyHealthList;

    // Use this for initialization
    void Start()
    {
        delay = roundInfo.ENEMY_SPAWN_DELAY;
        //Debug.Log("enemy manager init");
        //InvokeRepeating("Spawn", delay, delay);
    }

    // Update is called once per frame
    void Update()
    {
       //if( enemyHealthListspawnCount == roundInfo.NUM_ENEMIES)
	   {

	   }
    }

    void Spawn()
    {
        int spawnSelection = Random.Range(0, spawnPoints.Length);
        if (spawnCount < roundInfo.NUM_ENEMIES) 
        {
			GameObject instEnemy = (GameObject)Instantiate(enemy, spawnPoints[spawnSelection].position, new Quaternion(0,0,0,0));
            enemyHealthList.Add( instEnemy.GetComponent<EnemyHealth>() );
            spawnCount++;
        }
    }

	public void spawnRoundNumber(int round)
	{
		InvokeRepeating("Spawn", delay, delay);
	}

}
