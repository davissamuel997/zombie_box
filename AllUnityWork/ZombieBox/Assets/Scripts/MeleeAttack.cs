using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {

        if (other.transform.name.Contains("normalEnemy"))
        {
            other.transform.GetComponent<EnemyHealth>().TakeDamage(100, other.transform.position);
        }

    }
}
