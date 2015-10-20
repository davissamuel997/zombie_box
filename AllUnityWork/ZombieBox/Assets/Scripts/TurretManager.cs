using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretManager : MonoBehaviour
{
    private List<Turret> turretList = new List<Turret>();
    private List<Enemy> enemyList;
    int turretCount = 0;

    public void spawnTurret(int x, int z)
    {
        Quaternion q = new Quaternion(0, 0, 0, 0);

        Turret temp = new Turret(turretCount);
        Vector3 pos = new Vector3(x, 2, z);

        temp.turretObject = (GameObject)Instantiate(Resources.Load("prefabs/turret"), pos, q);
        temp.baseTurret = (GameObject)Instantiate(Resources.Load("prefabs/baseTurret"), new Vector3(pos.x, (pos.y - 1.5f), pos.z), q);

        Debug.Log("Spawned Turret " + pos);
        temp.turretObject.SetActive(true);
        turretList.Add(temp);
        turretCount++;
    }
    public void setEnemyList(List<Enemy> list)
    {
        enemyList = list;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("turret manager init");
        spawnTurret(10, 10);
        spawnTurret(10, -10);
    }

    public void attackEnemies()
    {
        foreach (Turret t in turretList)
        {
            t.damageEnemies(enemyList);
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackEnemies();

    }
}
