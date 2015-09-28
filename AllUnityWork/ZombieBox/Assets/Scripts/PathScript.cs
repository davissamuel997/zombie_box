using UnityEngine;
using System.Collections;

public class PathScript : MonoBehaviour {

	public Transform dest;
	private NavMeshAgent agent;
    private Transform baseTarget;
   
	bool init_flag = true;
	// Use this for initialization
	void Start () {

		gameObject.SetActive(true);
        
		agent = gameObject.GetComponent<NavMeshAgent>();

        baseTarget = GameObject.FindGameObjectsWithTag("Base")[0].transform;



	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (baseTarget.position);
	}
}
