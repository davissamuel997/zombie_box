using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MeleeScript : MonoBehaviour {

	public int damage = 50;
	public float meleeRate = 0.4f;
	public float drawTime = 1.5f;

	public bool draw;

	private float swingTime = 0.05f;
	public bool selected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(selected)
		{
			if(CrossPlatformInputManager.GetButtonDown("Shoot"))
			{
				melee();
			}
		}
	}

	void melee ()
	{
			
	}


	IEnumerator DrawWeapon()
	{
		draw = true;
		//GetComponent<AudioSource>().clip = soundDraw;
		//GetComponent<AudioSource>().Play();
		//weaponAnim.GetComponent<Animation>().Play("Draw", PlayMode.StopAll);
		//weaponAnim.GetComponent<Animation>().CrossFade("Draw");
		yield return new WaitForSeconds(drawTime);
		draw = false;
		selected = true;

	}
}
