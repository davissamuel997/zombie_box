using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class animManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		Animating(h, v);

	}

	void Animating(float h, float v)
	{
		bool moving = h != 0f || v != 0f;
		this.GetComponentInChildren<Animator>().SetBool("isMoving", moving);
	}
}
