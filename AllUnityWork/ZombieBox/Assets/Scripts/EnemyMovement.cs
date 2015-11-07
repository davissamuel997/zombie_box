using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform playerTarget;
    Transform baseTarget;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;
	Animator anim;

	public int movementSetting;


	void Awake()
	{
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        baseTarget = GameObject.FindGameObjectWithTag("Base").transform;
		playerHealth = playerTarget.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
        nav = this.GetComponent<NavMeshAgent>();
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponentInChildren<Animator>();
	}
    

	void Update()
	{
		anim.SetInteger("movementSetting", movementSetting);

		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
            if (this.transform.name == "fastEnemy")
                nav.SetDestination(playerTarget.position);
            else if (this.transform.name == "slowEnemy")
                nav.SetDestination(baseTarget.position);
            else
            {
                if (Vector3.Distance(this.transform.position, playerTarget.position) < 10f)
                {
					//Debug.Log("here");
                    nav.SetDestination(playerTarget.position);
                }
                else
                {
					//Debug.Log("there");
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
