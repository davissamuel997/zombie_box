using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour 
{
    List<Enemy> enemyList = new List<Enemy>();
    public void spawnEnemies(int n)
    {
        Quaternion q = new Quaternion(0, 0, 0, 0);
        for (int i = 0; i < n; i++)
        {
            Enemy temp = new Enemy();
            Vector3 pos= temp.getSpawnLocation();
            temp.enemyObject = (GameObject)Instantiate(Resources.Load("prefabs/ZombieA"), pos, q);
            Debug.Log("Spawned Enemy At " + pos);
            temp.enemyObject.SetActive(true);
            enemyList.Add(temp);
        } 
    }
    // Use this for initialization
    void Start () 
    {
        Debug.Log("enemy manager init");
    }
    void checkEnemies()
    {
        for(int i = 0; i< enemyList.Count;i++)
        {
            if (!enemyList[i].alive)
            {
                
                GameObject.Destroy(enemyList[i].enemyObject);             
            }
        }
    }
    void damageEnemies()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].takeDamage(20);
        }
    }

	// Update is called once per frame
	void Update () 
    {
        checkEnemies();
        if ((int)Time.frameCount % 360 == 0)
        {
            damageEnemies();
            Debug.Log("damage to enemy");
        }

    }
}
