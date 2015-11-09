using UnityEngine;
using System.Collections;

public class TurretLoader : MonoBehaviour {


    //expects #,#,#...
    public string id_string;
    // Use this for initialization
    void Start()
    {

        string[] nums = id_string.Split(',');
        int selection = (int)(nums.Length * Random.value);

        GameObject prefab = (GameObject)Resources.Load("prefabs/turret_" + nums[selection]);
        GameObject turret = (GameObject)Instantiate(prefab, this.transform.position, new Quaternion(0, 0, 0, 0));


        turret.transform.localScale = new Vector3(1, 1, 1);
        turret.transform.localEulerAngles = new Vector3(0, 0, 0);
        turret.transform.parent = this.transform;

        prefab = (GameObject)Resources.Load("prefabs/baseTurret");
        GameObject basePart = (GameObject)Instantiate(prefab, this.transform.position, new Quaternion(0, 0, 0, 0));
        basePart.transform.localScale = new Vector3(1, 1, 1);
        basePart.transform.localEulerAngles = new Vector3(0, 0, 0);
        basePart.transform.parent = this.transform;


        this.GetComponent<Animator>().enabled = true;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
