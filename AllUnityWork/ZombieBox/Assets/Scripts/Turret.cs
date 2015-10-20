using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret
{
    // Use this for initialization
    public GameObject turretObject;
    public GameObject baseTurret;
    private int health = int.MaxValue;
    public bool alive = true;
    public const float BASE_RADIUS = 20.0f;
    public const int BASE_DAMAGE = 10;
    public const int BASE_FIRE_RATE = 1000;  //fire rate in ms
    int id = 0;

    public Turret(int num)
    {
        id = num;
    }

    public void damageEnemies(List<Enemy> enemyList)
    {

        float min_dist = float.MaxValue;
        float temp = 0;
        Enemy min = null;
        foreach (Enemy e in enemyList)
        {
            temp = Vector3.Distance(e.enemyObject.transform.position, turretObject.transform.position);
            if (temp < BASE_RADIUS)
            {
                if (min_dist > temp)
                {
                    {
                        min_dist = temp;
                        min = e;
                    }

                }
            }
        }
        if (min != null)
        {
            min.takeDamage(BASE_DAMAGE);
            track(min.enemyObject.transform.position);
            Debug.Log("Turret #" + id + " Target Enemy " + min.id + " at " + min.enemyObject.transform.position);
            if (!min.alive)
            {
                enemyList.Remove(min);
            }
        }

    }
    public void track(Vector3 pos)
    {
        turretObject.transform.LookAt(pos);
    }
}
