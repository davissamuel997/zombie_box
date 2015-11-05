using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    EnemyManager enemy_mng;
    TurretManager turret_mng;
    BaseManager base_mng; 
        
    // Use this for initialization
    void Start ()
    {
        base_mng = GameObject.FindObjectOfType<BaseManager>();
        enemy_mng = GameObject.FindObjectOfType<EnemyManager>();
        turret_mng = GameObject.FindObjectOfType<TurretManager>();
        enemy_mng.spawnEnemies(1);
        //turret_mng.setEnemyList(enemy_mng.getEnemyList());
        

        
    }
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
