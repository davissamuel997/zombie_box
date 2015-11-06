using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform playerTarget;
    Transform baseTarget;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;

	public int movementSetting;


	void Awake()
	{
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        baseTarget = GameObject.FindGameObjectWithTag("Base").transform;
		playerHealth = playerTarget.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
        nav = this.GetComponent<NavMeshAgent>();
		nav = GetComponent<NavMeshAgent>();
	}
    

	void Update()
	{
        
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
            if (this.transform.name == "fastEnemy")
                nav.SetDestination(playerTarget.position);
            else if (this.transform.name == "slowEnemy")
                nav.SetDestination(baseTarget.position);
            else
            {
                if (Vector3.Distance(this.transform.position, playerTarget.position) < 5.0f)
                {
                    nav.SetDestination(playerTarget.position);
                }
                else
                {
                    nav.SetDestination(baseTarget.position);
                }

            }
        }
		else
		{
			nav.enabled = false;
		}
	}
}
