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

	public GameObject curDmg;
	public GameObject curAmmo;
	public GameObject nextDmg;
	public GameObject nextAmmo;

	public GameObject costDmg;
	public GameObject costAmmo;

	public GameObject selectedWeapon;

	public GameObject playerPoints;

	private int points = 10000;

	private int gunDmg = 20;
	private int gunAmmo = 100;

	private int shotgunDmg = 50;
	private int shotgunAmmo = 40;

	private int knifeDmg = 100;
	private int crowbarDmg = 75;

	private string selectedName;

	private bool updating = false;
	private bool upgradeAmmo = false;
	private bool upgradeDmg = false;

	void Start () 
	{
		if(PlayerPrefs.HasKey("score"))
		{
			points = PlayerPrefs.GetInt("score");
		}
		if (PlayerPrefs.HasKey("gunDmg"))
		{
			gunDmg = PlayerPrefs.GetInt("gunDmg");
		}
		if (PlayerPrefs.HasKey("gunAmmo"))
		{
			gunAmmo = PlayerPrefs.GetInt("gunAmmo");
		}
		if (PlayerPrefs.HasKey("shotgunDmg"))
		{
			shotgunDmg = PlayerPrefs.GetInt("shotgunDmg");
		}
		if (PlayerPrefs.HasKey("shotgunAmmo"))
		{
			shotgunAmmo = PlayerPrefs.GetInt("shotgunAmmo");
		}
		if (PlayerPrefs.HasKey("knifeDmg"))
		{
			knifeDmg = PlayerPrefs.GetInt("knifeDmg");
		}
		if (PlayerPrefs.HasKey("crowbarDmg"))
		{
			crowbarDmg = PlayerPrefs.GetInt("crowbarDmg");
		} 

		curAmmo.GetComponent<TextMesh>().text = "--";
		nextAmmo.GetComponent<TextMesh>().text = "--";
		costAmmo.GetComponent<TextMesh>().text = "--";

		curDmg.GetComponent<TextMesh>().text = "--";
		nextDmg.GetComponent<TextMesh>().text = "--";
		costDmg.GetComponent<TextMesh>().text = "--";

		playerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;

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
				Debug.Log("" + found.name);
				if ( found.tag == "Weapon" )
				{
					updating = true;
					selectedName = found.name;
				}
				else if ( found.name == "UpgradeAmmo")
				{
					upgradeAmmo = true;
					updating = true;
				}
				else if ( found.name == "UpgradeDamage")
				{
					upgradeDmg = true;
					updating = true;
				}
			}
		}

		if (updating)
		{
			if (selectedName == "gun")
			{
				if (upgradeAmmo && points > 100)
				{
					gunAmmo += 10;
					points -= 100;
				}
				if (upgradeDmg && points > 150)
				{
					gunDmg += 5;
					points -= 150;
				}

				selectedWeapon.GetComponent<TextMesh>().text = "Gun";

				curAmmo.GetComponent<TextMesh>().text = "" + gunAmmo;
				nextAmmo.GetComponent<TextMesh>().text = "" + (gunAmmo + 10);
				costAmmo.GetComponent<TextMesh>().text = "" + 100;

				curDmg.GetComponent<TextMesh>().text = "" + gunDmg;
				nextDmg.GetComponent<TextMesh>().text = "" + (gunDmg + 5);
				costDmg.GetComponent<TextMesh>().text = "" + 150;
			}

			if (selectedName == "shotgun")
			{
				if (upgradeAmmo && points > 120)
				{
					shotgunAmmo += 10;
					points -= 120;
				}
				if (upgradeDmg && points > 200)
				{
					shotgunDmg += 15;
					points -= 200;
				}

				selectedWeapon.GetComponent<TextMesh>().text = "Shotgun";

				curAmmo.GetComponent<TextMesh>().text = "" + shotgunAmmo;
				nextAmmo.GetComponent<TextMesh>().text = "" + (shotgunAmmo + 10);
				costAmmo.GetComponent<TextMesh>().text = "" + 120;

				curDmg.GetComponent<TextMesh>().text = "" + shotgunDmg;
				nextDmg.GetComponent<TextMesh>().text = "" + (shotgunDmg + 15);
				costDmg.GetComponent<TextMesh>().text = "" + 200;
			}

			if (selectedName == "knife")
			{
				
				if (upgradeDmg && points > 300)
				{
					knifeDmg += 50;
					points -= 300;
				}

				selectedWeapon.GetComponent<TextMesh>().text = "Knife";

				curAmmo.GetComponent<TextMesh>().text = "--";
				nextAmmo.GetComponent<TextMesh>().text = "--";
				costAmmo.GetComponent<TextMesh>().text = "--";

				curDmg.GetComponent<TextMesh>().text = "" + knifeDmg;
				nextDmg.GetComponent<TextMesh>().text = "" + (knifeDmg + 50);
				costDmg.GetComponent<TextMesh>().text = "" + 300;

			}

			if (selectedName == "crowbar")
			{

				if (upgradeDmg && points > 200)
				{
					crowbarDmg += 30;
					points -= 200;
				}
				selectedWeapon.GetComponent<TextMesh>().text = "Crowbar";

				curAmmo.GetComponent<TextMesh>().text = "--";
				nextAmmo.GetComponent<TextMesh>().text = "--";
				costAmmo.GetComponent<TextMesh>().text = "--";

				curDmg.GetComponent<TextMesh>().text = "" + crowbarDmg;
				nextDmg.GetComponent<TextMesh>().text = "" + (crowbarDmg + 30);
				costDmg.GetComponent<TextMesh>().text = "" + 200;
			}
			updating = false;
			upgradeAmmo = false;
			upgradeDmg = false;
			playerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;
		}
	}
}
