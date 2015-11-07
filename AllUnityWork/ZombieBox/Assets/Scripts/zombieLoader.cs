using UnityEngine;
using System.Collections;

public class zombieLoader : MonoBehaviour {

	//expects #,#,#...
	public string id_string;
	public int test;
	// Use this for initialization
	void Start () 
	{
		
		string[] nums = id_string.Split(',');
		int selection = (int)(nums.Length *Random.value);
		
		GameObject prefab = (GameObject)Resources.Load("Characters/Zombie_" + nums[selection]);
		GameObject zombie = (GameObject)Instantiate(prefab, this.transform.position, new Quaternion(0, 0, 0, 0));

        zombie.transform.localScale = new Vector3(1, 1, 1);
        zombie.transform.localEulerAngles = new Vector3(0, 0, 0);
        zombie.transform.parent = this.transform;

		this.GetComponent<Animator>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	
	}
	
	void FixedUpdate()
	{
		

	}

	void Animating(float h, float v)
	{

	}
}
