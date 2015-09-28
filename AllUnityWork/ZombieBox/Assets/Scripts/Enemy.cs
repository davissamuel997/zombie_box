using UnityEngine;
using System.Collections;

public class Enemy
{

    // Use this for initialization
    public GameObject enemyObject;

    private int health = 100;
    private const int MAP1_SIZE = 25;
    public bool alive = true;

    public Vector3 getSpawnLocation()
    {
        float x = Random.value;
        float z = Random.value;
      
        if ((int)(z *10) % 2 == 0)
        {
            z *= -1;
        }

        Vector3 location = new Vector3(0, 0, 0);
        location.Set(MAP1_SIZE * x, 0, MAP1_SIZE * z);
        return location;
    }
    public void takeDamage(int val)
    {
        if (health <= 0)
        {
            return;
        }
            health -= val;
        if (health <= 0)
        {
            alive = false;
        }
    }
}
