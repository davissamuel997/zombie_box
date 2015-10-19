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

	public AudioClip soundDraw;
	public AudioClip soundFire;
	public AudioClip soundReload;
	public AudioClip soundEmpty;
	public AudioClip switchModeSound;

	public GameObject Blood;
	public GameObject untagged;
	public GameObject weaponAnim;


	public LayerMask layerMask;
	//public Renderer muzzleFlash;
	//public Light muzzleLight;


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
		//muzzleFlash.enabled = false;
		//muzzleLight.enabled = false;
		bulletsLeft = bulletsPerMag;
		currentMode = firstMode;
		fireRate = fireRateFirstMode;
		aiming = false;

		if (ammoMode == Ammo.Bullets)
		{
			magazines = magazines * bulletsPerMag;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (selected)
		{
			if (CrossPlatformInputManager.GetButtonDown("Shoot"))
			{
				if (currentMode == fireMode.semi)
				{
					fireSemi();
				}

				if (currentMode == fireMode.burst)
				{
					fireBurst();
				}

				if (bulletsLeft > 0)
					isFiring = true;
			}

			if (CrossPlatformInputManager.GetButtonDown("Shoot"))
			{
				if (currentMode == fireMode.auto)
				{
					fireSemi();
					if (bulletsLeft > 0)
						isFiring = true;
				}
			}

			//if (Input.GetButtonDown("Reload"))
			{
				//StartCoroutine(Reload());
			}
		}

		if (CrossPlatformInputManager.GetButtonDown("FireMode") && secondMode != fireMode.none && canSwicthMode)
		{
			if (currentMode != firstMode)
			{
				StartCoroutine(FirstFireMode());
			}
			else
			{
				StartCoroutine(SecondFireMode());
			}
		}
	}

	IEnumerator FirstFireMode()
	{

		canSwicthMode = false;
		selected = false;
		//weaponAnim.GetComponent<Animation>().Rewind("SwitchAnim");
		//weaponAnim.GetComponent<Animation>().Play("SwitchAnim");
		//GetComponent<AudioSource>().clip = switchModeSound;
		//GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.6f);
		currentMode = firstMode;
		fireRate = fireRateFirstMode;
		selected = true;
		canSwicthMode = true;
	}

	IEnumerator SecondFireMode()
	{

		canSwicthMode = false;
		selected = false;
		//GetComponent<AudioSource>().clip = switchModeSound;
		//GetComponent<AudioSource>().Play();
		//weaponAnim.GetComponent<Animation>().Play("SwitchAnim");
		yield return new WaitForSeconds(0.6f);
		currentMode = secondMode;
		fireRate = fireRateSecondMode;
		selected = true;
		canSwicthMode = true;

	}

	void fireSemi()
	{
		if (reloading || bulletsLeft <= 0)
		{
			if (bulletsLeft == 0)
			{
				OutOfAmmo();
			}
			return;
		}

		if (Time.time - fireRate > nextFireTime)
			nextFireTime = Time.time - Time.deltaTime;

		while (nextFireTime < Time.time)
		{
			fireOneBullet();
			nextFireTime = Time.time + fireRate;
		}
	}

	IEnumerator fireBurst()
	{
		int shotCounter = 0;

		if (reloading || bursting || bulletsLeft <= 0)
		{
			if (bulletsLeft <= 0)
			{
				StartCoroutine(OutOfAmmo());
			}
			yield break;
		}

		if (Time.time - fireRate > nextFireTime)
			nextFireTime = Time.time - Time.deltaTime;

		if (Time.time > nextFireTime)
		{
			while (shotCounter < shotsPerBurst)
			{
				bursting = true;
				shotCounter++;
				if (bulletsLeft > 0)
				{
					fireOneBullet();
				}
				yield return new WaitForSeconds(burstTime);
			}
			nextFireTime = Time.time + fireRate;
		}
		bursting = false;
	}
	public void fireOneBullet()
	{
		if (nextFireTime > Time.time || draw)
		{
			if (bulletsLeft <= 0)
			{
				OutOfAmmo();
			}
			return;
		}

		Vector3 direction = gameObject.transform.TransformDirection(new Vector3(Random.Range(-0.01f, 0.01f) * triggerTime, Random.Range(-0.01f, 0.01f) * triggerTime, 1));
		RaycastHit hit;
		Vector3 position = transform.parent.position;

		if (Physics.Raycast(position, direction, out hit, range, layerMask.value))
		{

			Vector3 contact = hit.point;
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

			if (hit.rigidbody)
			{
				hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
			}

			if (hit.transform.tag == "Untagged")
			{
				GameObject default1 = Instantiate(untagged, contact, rotation) as GameObject;
				hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
				default1.transform.parent = hit.transform;
			}

			if (hit.transform.tag == "Enemy")
			{
				hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

				GameObject bloodHole = Instantiate(Blood, contact, rotation) as GameObject;
				if (Physics.Raycast(position, direction, out hit, range, layerMask.value))
				{
					if (hit.rigidbody)
					{
						hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
					}
				}
			}
		}

		PlayAudioClip(soundFire, transform.position, 0.7f);
		m_LastFrameShot = Time.frameCount;

		weaponAnim.GetComponent<Animation>().Rewind("Fire");
		weaponAnim.GetComponent<Animation>().Play("Fire");
		//KickBack();
		bulletsLeft--;
	}

	void PlayAudioClip(AudioClip clip, Vector3 position, float volume)
	{
		GameObject go = new GameObject("One shot audio");
		go.transform.position = position;
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.pitch = Random.Range(0.95f, 1.05f);
		source.Play();
		Destroy(go, clip.length);
	}

	IEnumerator OutOfAmmo()
	{
		if (reloading || playing)
			yield break;

		playing = true;
		PlayAudioClip(soundEmpty, transform.position, 0.7f);

		weaponAnim.GetComponent<Animation>()["Fire"].speed = 2.0f;
		weaponAnim.GetComponent<Animation>().Rewind("Fire");
		weaponAnim.GetComponent<Animation>().Play("Fire");
		yield return new WaitForSeconds(0.2f);
		playing = false;
	}

	IEnumerator Reload()
	{
		if (reloading)
			yield break;

		if (ammoMode == Ammo.Magazines)
		{
			reloading = true;
			canSwicthMode = false;
			if (magazines > 0 && bulletsLeft != bulletsPerMag)
			{
				weaponAnim.GetComponent<Animation>()["Reload"].speed = reloadAnimSpeed;
				weaponAnim.GetComponent<Animation>().Play("Reload", PlayMode.StopAll);
				weaponAnim.GetComponent<Animation>().CrossFade("Reload");
				GetComponent<AudioSource>().PlayOneShot(soundReload);
				yield return new WaitForSeconds(reloadTime);
				magazines--;
				bulletsLeft = bulletsPerMag;
			}
			reloading = false;
			canSwicthMode = true;
			isFiring = false;
		}

		if (ammoMode == Ammo.Bullets)
		{
			if (magazines > 0 && bulletsLeft != bulletsPerMag)
			{
				if (magazines > bulletsPerMag)
				{
					canSwicthMode = false;
					reloading = true;
					weaponAnim.GetComponent<Animation>()["Reload"].speed = reloadAnimSpeed;
					weaponAnim.GetComponent<Animation>().Play("Reload", PlayMode.StopAll);
					weaponAnim.GetComponent<Animation>().CrossFade("Reload");
					GetComponent<AudioSource>().PlayOneShot(soundReload);
					yield return new WaitForSeconds(reloadTime);
					magazines -= bulletsPerMag - bulletsLeft;
					bulletsLeft = bulletsPerMag;
					canSwicthMode = true;
					reloading = false;
					yield break;
				}
				else
				{
					canSwicthMode = false;
					reloading = true;
					weaponAnim.GetComponent<Animation>()["Reload"].speed = reloadAnimSpeed;
					weaponAnim.GetComponent<Animation>().Play("Reload", PlayMode.StopAll);
					weaponAnim.GetComponent<Animation>().CrossFade("Reload");
					GetComponent<AudioSource>().PlayOneShot(soundReload);
					yield return new WaitForSeconds(reloadTime);
					int bullet = Mathf.Clamp(bulletsPerMag, magazines, bulletsLeft + magazines);
					magazines -= (bullet - bulletsLeft);
					bulletsLeft = bullet;
					canSwicthMode = true;
					reloading = false;
					yield break;
				}
			}
		}
	}

	IEnumerator DrawWeapon()
	{
		draw = true;
		canSwicthMode = false;
		GetComponent<AudioSource>().clip = soundDraw;
		GetComponent<AudioSource>().Play();
		weaponAnim.GetComponent<Animation>().Play("Draw", PlayMode.StopAll);
		weaponAnim.GetComponent<Animation>().CrossFade("Draw");
		yield return new WaitForSeconds(drawTime);
		draw = false;
		reloading = false;
		canSwicthMode = true;
		selected = true;

	}

	void Deselect()
	{
		selected = false;
		mainCamera.GetComponent<Camera>().fieldOfView = 60;
		weaponCamera.GetComponent<Camera>().fieldOfView = 50;
		transform.localPosition = hipPosition;
	}

}
