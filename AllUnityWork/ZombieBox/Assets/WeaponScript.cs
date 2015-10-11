using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public enum fireMode { none, semi, auto, burst, launcher }
public enum Ammo { Magazines, Bullets }

[ExecuteInEditMode]
public class WeaponScript : MonoBehaviour {

	public fireMode currentMode = fireMode.semi;
	public fireMode firstMode = fireMode.semi;
	public fireMode secondMode = fireMode.launcher;

	public Ammo ammoMode = Ammo.Magazines;

	public bool canReloadLauncher = false;


	public GameObject weaponAnim;


	public LayerMask layerMask;
	public Renderer muzzleFlash;
	public Light muzzleLight;


	public int damage = 50;
	public int bulletsPerMag = 50;
	public int magazines = 5;
	private float fireRate = 0.1f;
	public float fireRateFirstMode = 0.1f;
	public float fireRateSecondMode = 0.1f;
	public float reloadTime = 3.0f;
	public float reloadAnimSpeed = 1.2f;
	public float drawTime = 1.5f;

	public float range = 250.0f;
	public float force = 200.0f;

	//Weapon accuracy
	private float baseInaccuracy;
	public float baseInaccuracyAIM = 0.005f;
	public float baseInaccuracyHIP = 1.5f;
	public float inaccuracyIncreaseOverTime = 0.2f;
	public float inaccuracyDecreaseOverTime = 0.5f;
	private float maximumInaccuracy;
	public float maxInaccuracyHIP = 5.0f;
	public float maxInaccuracyAIM = 1.0f;

	private float triggerTime = 0.05f;

	//Aiming
	public Vector3 hipPosition;
	public Vector3 aimPosition;
	private bool aiming;
	private Vector3 curVect;
	public float aimSpeed = 0.25f;

	//Field Of View
	public float zoomSpeed = 0.5f;
	public int FOV = 40;

	private int bulletsLeft = 0;
	private int m_LastFrameShot = -10;
	private float nextFireTime = 0.0f;
	[HideInInspector]
	public bool reloading;
	private bool draw;
	private GameObject weaponCamera;
	private GameObject mainCamera;
	private bool playing = false;
	[HideInInspector]
	public bool selected = false;
	private GameObject player;
	private bool isFiring = false;
	private bool bursting = false;

	//Burst
	public int shotsPerBurst = 3;
	public float burstTime = 0.07f;

	//GUI
	public GUISkin mySkin;

	//Launcher
	public Rigidbody projectilePrefab;
	public float projectileSpeed = 30.0f;
	public float projectiles = 20;
	public GameObject launchPosition;
	public GameObject fireLauncherAnimGO;
	public AudioClip soundReloadLauncher;
	private bool launcjerReload = false;
	public float launcherReloadTime = 2.0f;
	public string reloadlauncher = "reloadlauncher";
	private GameObject rocket;

	//KickBack
	public Transform kickGO;
	public float kickUpside = 0.5f;
	public float kickSideways = 0.5f;

	//Crosshair Textures
	public Texture2D crosshairFirstModeHorizontal;
	public Texture2D crosshairFirstModeVertical;
	public Texture2D crosshairSecondMode;
	private float adjustMaxCroshairSize = 6.0f;

	//Switch Weapon Fire Modes
	private bool canSwicthMode = true;

	// Use this for initialization
	void Start () {
		weaponCamera = GameObject.FindWithTag("WeaponCamera");
		mainCamera = GameObject.FindWithTag("MainCamera");
		player = GameObject.FindWithTag("Player");
		muzzleFlash.enabled = false;
		muzzleLight.enabled = false;
		bulletsLeft = bulletsPerMag;
		currentMode = firstMode;
		fireRate = fireRateFirstMode;
		aiming = false;
		if (firstMode == fireMode.launcher)
		{
			rocket = GameObject.Find("RPGrocket");
		}
		if (ammoMode == Ammo.Bullets)
		{
			magazines = magazines * bulletsPerMag;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
