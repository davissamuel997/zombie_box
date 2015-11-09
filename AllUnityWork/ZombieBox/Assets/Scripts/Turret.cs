using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    // Use this for initialization
    public GameObject turretObject;
    public GameObject baseTurret;
    private int health = int.MaxValue;
    public bool alive = true;
    public const float BASE_RADIUS = 20.0f;
    public const int BASE_DAMAGE = 10;
    public const int BASE_FIRE_RATE = 1000;  //fire rate in ms
    Animator animator;
    static int num_turrets = 0;
    int id = 0;
    public Turret()
    {
        id = num_turrets;
        num_turrets++;
    }

    public void damageEnemies()
    {
        
    }

    void Awake()
    {

    }

    void Update()
    {
        
    }
}
