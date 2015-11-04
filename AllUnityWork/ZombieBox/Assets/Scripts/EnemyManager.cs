using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemyList = new List<Enemy>();
    int totalEnemies = 0;
    int enemyCount = 0;
    public void spawnEnemies(int n)
    {
        Quaternion q = new Quaternion(0, 0, 0, 0);
        enemyCount = n;
        totalEnemies = n;
        for (int i = 0; i < n; i++)
        {
            Enemy temp = new Enemy(i);
            Vector3 pos = temp.getSpawnLocation();
            temp.enemyObject = (GameObject)Instantiate(Resources.Load("prefabs/ZombieA"), pos, q);
            Debug.Log("Spawned Enemy At " + pos);
            temp.enemyObject.SetActive(true);
            enemyList.Add(temp);
			
        }
    }

    public List<Enemy> getEnemyList()
    {
        return enemyList;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("enemy manager init");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
