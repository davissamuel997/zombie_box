using UnityEngine;
using System.Collections;

public class Upgrader : MonoBehaviour {

	// Use this for initialization
	public static GameObject selected;
	public CanvasGroup canvasGroup;
	public int gun; // = PlayerPrefs.("gunDmg");
	public int shotgun; // = PlayerPrefs.GetInt("shotgunDmg");
	public int knife; // = PlayerPrefs.GetInt("knifeDmg");
	public int crowbar; // = PlayerPrefs.GetInt("crowbarDmg");

	//weapons
	public GameObject curDmg;
	public GameObject curAmmo;
	public GameObject nextDmg;
	public GameObject nextAmmo;

	public GameObject costDmg;
	public GameObject costAmmo;

	public GameObject selectedWeapon;

	public GameObject playerPoints;

	private int points = 10000;

    private int gunDmg = 50;
	private int gunAmmo = 50;

	private int shotgunDmg = 75;
	private int shotgunAmmo = 30;

	private int knifeDmg = 50;
	private int crowbarDmg = 100;

	private string selectedName;

	private bool updating = false;
	private bool upgradeAmmo = false;
	private bool upgradeDmg = false;

	//turret
	public GameObject turretCurDmg;
	public GameObject turretCurRate;
	public GameObject turretNextDmg;
	public GameObject turretNextRate;

	public GameObject turretCostDmg;
	public GameObject turretCostRate;

	public GameObject turretPlayerPoints;

	private int turretDmg = 1;
	private float turretRate = 5.0f;

	private bool turretUpdating = false;
	private bool turretUpgradeDmg = false;
	private bool turretUpgradeRate = false;

	void Start () 
	{
		if(PlayerPrefs.HasKey("total_points"))
		{
			points = PlayerPrefs.GetInt("total_points");
		}
		if (PlayerPrefs.HasKey("GunDmg"))
		{
			gunDmg = PlayerPrefs.GetInt("GunDmg");
		}
		if (PlayerPrefs.HasKey("GunAmmo"))
		{
			gunAmmo = PlayerPrefs.GetInt("GunAmmo");
		}
		if (PlayerPrefs.HasKey("ShotgunDmg"))
		{
			shotgunDmg = PlayerPrefs.GetInt("ShotgunDmg");
		}
		if (PlayerPrefs.HasKey("ShotgunAmmo"))
		{
			shotgunAmmo = PlayerPrefs.GetInt("ShotgunAmmo");
		}
		if (PlayerPrefs.HasKey("KnifeDmg"))
		{
			knifeDmg = PlayerPrefs.GetInt("KnifeDmg");
		}
        if (PlayerPrefs.HasKey("CrowbarDmg"))
        {
            crowbarDmg = PlayerPrefs.GetInt("CrowbarDmg");
        }
        //WE NEED THIS IN THE DB!!!!!
        if (PlayerPrefs.HasKey("TurretDmg"))
		{
			turretDmg = PlayerPrefs.GetInt("TurretDmg");
		}
        //WE NEED THIS IN THE DB!!!!!
        if (PlayerPrefs.HasKey("turretRate"))
		{
			turretRate = PlayerPrefs.GetInt("turretRate");
		} 		

		curAmmo.GetComponent<TextMesh>().text = "--";
		nextAmmo.GetComponent<TextMesh>().text = "--";
		costAmmo.GetComponent<TextMesh>().text = "--";

		curDmg.GetComponent<TextMesh>().text = "--";
		nextDmg.GetComponent<TextMesh>().text = "--";
		costDmg.GetComponent<TextMesh>().text = "--";

		turretCurDmg.GetComponent<TextMesh>().text = "" + turretDmg;
		turretCurRate.GetComponent<TextMesh>().text = "" + turretRate;

		playerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;
		turretPlayerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;


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
				else if ( found.name == "WeaponUpgradeAmmo")
				{
					upgradeAmmo = true;
					updating = true;
				}
				else if ( found.name == "WeaponUpgradeDamage")
				{
					upgradeDmg = true;
					updating = true;
				}
				else if ( found.name == "TurretUpgradeDamage")
				{
					Debug.Log("fuck");

					turretUpdating = true;
					turretUpgradeDmg = true;
				}
				else if ( found.name == "TurretUpgradeRate")
				{
					turretUpdating = true;
					turretUpgradeRate = true;
				}
			}
		}

		if (updating)
		{
			if (selectedName == "gun")
			{
				if (upgradeAmmo && points >= 100)
				{
					gunAmmo += 10;
					points -= 100;
				}
				if (upgradeDmg && points >= 150)
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
				if (upgradeAmmo && points >= 120)
				{
					shotgunAmmo += 10;
					points -= 120;
				}
				if (upgradeDmg && points >= 200)
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
				
				if (upgradeDmg && points >= 300)
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

				if (upgradeDmg && points >= 200)
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
			turretPlayerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;
		}

		if (turretUpdating)
		{
			if (turretUpgradeDmg && points >= 400)
			{
				turretDmg += 1;
				points -= 400;

				turretCurDmg.GetComponent<TextMesh>().text = "" + turretDmg;
				turretNextDmg.GetComponent<TextMesh>().text = "" + (turretDmg + 1);
				turretCostDmg.GetComponent<TextMesh>().text = "" + 400;

			}
			if (turretUpgradeRate && points >= 400)
			{
				turretRate = turretRate * 0.99f;
				points -= 400;

				turretCurRate.GetComponent<TextMesh>().text = "" + turretRate.ToString("0.00");	//TOO EASY
				turretNextRate.GetComponent<TextMesh>().text = "" + (turretRate * .99).ToString("0.00");
				turretCostRate.GetComponent<TextMesh>().text = "" + 400;
			}

			turretUpdating = false;
			turretUpgradeDmg = false;
			turretUpgradeRate = false;

			playerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;
			turretPlayerPoints.GetComponent<TextMesh>().text = "Points Available: " + points;
		}


	}
}
