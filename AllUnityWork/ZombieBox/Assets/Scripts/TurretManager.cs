using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject turret;
   
  

    // Use this for initialization
    void Start()
    {
        //Debug.Log("turret manager init");
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(turret, spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    bool flag = true;
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
