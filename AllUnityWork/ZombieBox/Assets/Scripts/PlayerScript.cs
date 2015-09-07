using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public string charID;
	public GameObject charModel;

	// Use this for initialization
	void Start () {
		charID = PlayerPrefs.GetString ("charID");
		GameObject currentArmPrefab = (GameObject)Resources.Load("FPS/fps_human_" + charID);
		Debug.Log (charID);
		Debug.Log (currentArmPrefab);
		GameObject arms = InstantiateArms (currentArmPrefab);
		arms.GetComponentInParent<Animator> ();
	}

	GameObject InstantiateArms(GameObject currentArmPrefab)
	{
		GameObject ArmInstance;
		Vector3 armMeshOrigin = new Vector3();
		armMeshOrigin = charModel.transform.position;
		ArmInstance = Instantiate (currentArmPrefab, armMeshOrigin,
		                          Quaternion.Euler (charModel.transform.rotation.x,
				                  charModel.transform.rotation.y - 180,
				                  charModel.transform.rotation.z)) as GameObject;
		ArmInstance.transform.parent = charModel.transform;
		return ArmInstance;
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
