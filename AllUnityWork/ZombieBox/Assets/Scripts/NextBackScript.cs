using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class NextBackScript : MonoBehaviour
{

	public Camera mainCamera;
	public CanvasGroup canvasGroup;
    public colorUpdater colors;

	public float speed = 55.0f;
	private float rotation = 0.0f;
	private Quaternion qTo = Quaternion.identity;

	private bool rotateRight = false;
	private bool rotateLeft = false;
	private int facing = 0;

	private GameObject back;
	private GameObject next;
	private GameObject stats;
    bool data_flag = false;

    private DataManager data;

	void Start()
	{
        colors = GameObject.Find("colorPicker").GetComponent<colorUpdater>();
		back = GameObject.Find("BackBtn");
		next = GameObject.Find("NextBtn");
        data = this.GetComponent<DataManager>();
		back.SetActive(false);
	}

	void NextPressed()
	{
		if (facing == 0)
		{
			back.SetActive(true);
		}
		if (facing == 1)
		{

		}
		if (facing == 2)
		{
			next.GetComponentInChildren<Text>().text = "Play";
		}
		if (facing == 3)
		{
			PlayerPrefs.SetString("charID", Regex.Replace(CharSelect.selected.name, "[^0-9]", ""));
            data_flag = true;
            data.savePlayerPrefsMenu(colors.r,colors.g,colors.b);
            postData();
		}
		else
		{
			rotateRight = true;
			facing++;
		}
	}
    void postData()
    {
        
        StartCoroutine(data.writePlayerPrefs());

        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("GunID"), PlayerPrefs.GetInt("GunDmg"), PlayerPrefs.GetInt("GunAmmo"), PlayerPrefs.GetFloat("GunRate"), PlayerPrefs.GetInt("GunKills")));
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("ShotgunID"), PlayerPrefs.GetInt("ShotgunDmg"), PlayerPrefs.GetInt("ShotgunAmmo"), PlayerPrefs.GetFloat("ShotgunRate"), PlayerPrefs.GetInt("ShotgunKills")));
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("KnifeID"), PlayerPrefs.GetInt("KnifeDmg"), PlayerPrefs.GetInt("KnifeAmmo"), PlayerPrefs.GetFloat("KnifeRate"), PlayerPrefs.GetInt("KnifeKills")));
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("CrowbarID"), PlayerPrefs.GetInt("CrowbarDmg"), PlayerPrefs.GetInt("CrowbarAmmo"), PlayerPrefs.GetFloat("CrowbarRate"), PlayerPrefs.GetInt("CrowbarKills")));

        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("TurretID"), PlayerPrefs.GetInt("TurretDmg"), PlayerPrefs.GetInt("TurretAmmo"), PlayerPrefs.GetFloat("TurretRate"), PlayerPrefs.GetInt("TurretKills")));
        Application.LoadLevel("base");

    }
	public void BackPressed()
	{
		if (facing == 1)
		{
			back.SetActive(false);
		}
		if (facing == 3)
		{
			next.GetComponentInChildren<Text>().text = "Next";
		}
		rotateLeft = true;
		facing--;
	}

	void Update()
	{
		if (rotateRight)
		{
			rotation += 90.0f;
			qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
			rotateRight = false;
		}
		if (rotateLeft)
		{
			rotation -= 90.0f;
			qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
			rotateLeft = false;
		}
       
        
		mainCamera.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, qTo, speed * Time.deltaTime);
    }

}