using UnityEngine;
using System.Collections;

public class PathScript : MonoBehaviour {

	public Transform dest;
	private NavMeshAgent agent;
	bool init_flag = true;
	// Use this for initialization
	void Start () {

		gameObject.SetActive(true);
		agent = gameObject.GetComponent<NavMeshAgent>();





	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (dest.position);
	}
}
