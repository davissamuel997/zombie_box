using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponManager : MonoBehaviour {

	public GameObject[] weaponsInUse;
	public GameObject[] weaponsInGame;
	public Rigidbody[] worldModels;

	public RaycastHit hit;
	public float distance = 2.0f;
	public LayerMask layerMaskWeapon;
	public LayerMask layerMaskAmmo;

	public float switchWeaponTime = 0.5f;
	[HideInInspector]
	public bool canSwitch = true;
	[HideInInspector]
	public bool showWepGui = false;
	[HideInInspector]
	public bool showAmmoGui = false;

	private bool equipped = false;
	public int weaponToSelect;
	public int setElement;
	public int setPrice;
	public int setPriceAmmo;

	public int weaponToDrop;
	public GUISkin mySkin;
	public AudioClip pickupSound;
	private string textFromPickupScript = "";
	private string notes = "";

	// Use this for initialization
	void Start () {
		for(int i = 0; i < worldModels.Length; i++)
		{
			weaponsInGame[i].gameObject.SetActive(false);
			weaponsInUse[i] = weaponsInGame[i];
		}
		weaponToSelect = 0;
		DeselectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
		if ( CrossPlatformInputManager.GetButtonDown("SwitchWeapon") && canSwitch)
		{
			weaponToSelect++;
			if (weaponToSelect > (weaponsInUse.Length - 1))
			{
				weaponToSelect = 0;
			}
			DeselectWeapon();
		}


	}

	public void DeselectWeapon()
	{
		for (int i = 0; i < weaponsInUse.Length; i++)
		{
			weaponsInUse[i].gameObject.SendMessage("Deselect", SendMessageOptions.DontRequireReceiver);
			/*Component[] deactivate = weaponsInUse[i].gameObject.GetComponentsInChildren<MonoBehaviour>();
			foreach (var d in deactivate)
			{
				MonoBehaviour d = d as MonoBehaviour;
				if (d)
					d.enabled = false;
			}*/
			weaponsInUse[i].gameObject.SetActive(false);
		}
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		canSwitch = false;
		yield return new WaitForSeconds(switchWeaponTime);
		SelectWeapon(weaponToSelect);
		yield return new WaitForSeconds(switchWeaponTime);
		canSwitch = true;
	}

	void SelectWeapon(int i)
	{
		//Activate selected weapon
		weaponsInUse[i].gameObject.SetActive(true);
		/*Component[] activate = weaponsInUse[i].gameObject.GetComponentsInChildren<MonoBehaviour>();
		foreach (var a in activate)
		{
			MonoBehaviour a = a as MonoBehaviour;
			if (a)
				a.enabled = true;
		}*/
		//Debug.Log(weaponsInUse[i].gameObject);
		weaponsInUse[i].gameObject.SendMessage("DrawWeapon", SendMessageOptions.DontRequireReceiver);
		WeaponIndex temp = weaponsInUse[i].gameObject.transform.GetComponent<WeaponIndex>();
		weaponToDrop = temp.setWeapon;
	}
}
