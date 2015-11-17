using UnityEngine;
using System.Collections;

public class WeaponUpgrade : MonoBehaviour {

	// Use this for initialization
	public static GameObject selected;
	public CanvasGroup canvasGroup;
	public int gun; // = PlayerPrefs.("gunDmg");
	public int shotgun; // = PlayerPrefs.GetInt("shotgunDmg");
	public int knife; // = PlayerPrefs.GetInt("knifeDmg");
	public int crowbar; // = PlayerPrefs.GetInt("crowbarDmg");

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, 100))
			{
				GameObject found = GameObject.Find(hit.collider.name);
				
				if(found.name == "gun")
				{

				}

				if(found.name == "shotgun")
				{

				}

				if (found.name == "knife")
				{

				}

				if (found.name == "crowbar")
				{

				}
				
			}
		}
	}
}
