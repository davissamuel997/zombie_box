using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class weaponLoader : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		string charID = PlayerPrefs.GetString("charID");

		
		GameObject prefab = (GameObject)Resources.Load("FPS/fps_human_" + charID);
		GameObject wep = (GameObject)Resources.Load("weapons/" + transform.parent.name);

		GameObject currentArmPrefab = (GameObject)Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
		GameObject weapon = (GameObject)Instantiate(wep, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

		weapon.transform.parent = findWeaponBone(currentArmPrefab.transform);

		weapon.transform.localPosition = new Vector3(0, 0, 0);
		weapon.transform.localScale = new Vector3(1, 1, 1);
		weapon.transform.localEulerAngles = new Vector3(0, 0, 0);

		currentArmPrefab.transform.parent = this.transform;

		currentArmPrefab.transform.localPosition = new Vector3(0, 0, 0);
		currentArmPrefab.transform.localScale = new Vector3(1, 1, 1);
		currentArmPrefab.transform.localEulerAngles = new Vector3(0, 0, 0);

		setChildrenWeaponLayer(this.transform);

		this.GetComponentInParent<Animator>().StartPlayback();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Animating(float h, float v)
	{
		bool moving = h != 0f || v != 0f;
		Debug.Log("m" + moving);
		this.GetComponentInParent<Animator>().SetBool("isMoving", moving);
	}

	void setChildrenWeaponLayer(Transform trans)
	{
		foreach( Transform child in trans)
		{
			child.gameObject.layer = LayerMask.NameToLayer("Weapon");
			setChildrenWeaponLayer(child);
		}
	}

	Transform findWeaponBone(Transform trans)
	{
		Transform bone = null;
		foreach (Transform child in trans)
		{
			if (child.name == "bone_weapon_right")
			{
				return child;
			}
			bone = findWeaponBone(child);
			if (bone != null)
				return bone;
		}

		return bone;		
	}
}
