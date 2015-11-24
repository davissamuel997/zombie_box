using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MeleeScript : MonoBehaviour {

	public int damage = 50;
	public float drawTime = 1.5f;
	public AudioClip meleeSlash;
    public AudioClip meleeHit;
	public bool draw;
    private GameObject player;
    private float swingTime = 0.05f;
	public float meleeAttackRange = 3.0f;     
	public bool selected = false;
    private Animator anim;
    bool inAttack = false;
	public float force = 400;
	public StatUpdater statUpdater;
    RoundStats stats;


	// Use this for initialization
	void Start () {
        stats = GameObject.Find("RoundManager").GetComponent<RoundStats>();
        player = GameObject.FindWithTag("Player");
        anim = this.transform.GetComponent<Animator>();
        if (this.transform.name == "knife")
        {
            damage = PlayerPrefs.GetInt("KnifeDmg");
        }
        else if (this.transform.name == "crowbar")
        {
            damage = PlayerPrefs.GetInt("CrowbarDmg");
        }
        anim.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
		if(selected)
		{
			if(CrossPlatformInputManager.GetButtonDown("Shoot"))
			{
				StartCoroutine(	MeleeAttack() );
            }
		}
      
	}

	public IEnumerator MeleeAttack()
	{
		if (inAttack)
			yield break;
		inAttack = true;
		//if (axeHit != "")
		/*{
			weaponAnim.GetComponent<Animation>()[axeHit].speed = weaponAnim.GetComponent<Animation>()[axeHit].clip.length / 1.0f;
			weaponAnim.GetComponent<Animation>().Play(axeHit);
		}*/
		//yield return new WaitForSeconds(0.3f);
		//GetComponent<AudioSource>().clip = soundAxeSlash;
		//GetComponent<AudioSource>().Play();
		anim.SetTrigger("Melee");
		PlayAudioClip(meleeSlash, transform.position, 0.7f);
		yield return new WaitForSeconds(0.4f);
		StartCoroutine(MeleeAttackHit());
	}


	IEnumerator MeleeAttackHit()
	{
		Vector3 direction = transform.TransformDirection(0, 0, 1);
		RaycastHit hit;

		if (Physics.Raycast(transform.position, direction, out hit, 1000.0f))
		{
			Vector3 contact = hit.point;
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

			if (hit.distance < meleeAttackRange)
			{

				if (hit.rigidbody)
				{
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}

				if (hit.transform.tag == "Enemy")
				{
					if(hit.transform.GetComponentInParent<EnemyHealth>().TakeDamage(damage, contact))
                    { 
                        stats.roundPoints += 10;
						statUpdater.updateScore();

                        stats.roundKills += 1;

						if (this.transform.name.Contains("knife"))
                        {
                            stats.knife_kills++;
                        }
                        else
                        {
                            stats.crowbar_kills++;
                        }
                    }
                PlayAudioClip(meleeHit, hit.transform.position, 0.7f);
                    //GameObject bloodHole = Instantiate(Blood, contact, rotation) as GameObject;
                    /*if (Physics.Raycast(transform.position, direction, out hit, range, layerMask.value))
					{
						if (hit.rigidbody)
						{
							hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
						}
					}*/
                }

				/*if (hit.transform.tag == "Untagged" || hit.transform.tag == "Concrete" || hit.transform.tag == "Dirt" || hit.transform.tag == "Wood" || hit.transform.tag == "Metal")
				{
					GameObject default1 = Instantiate(meleeHitUntagged, contact, rotation) as GameObject;
					default1.transform.position = hit.point;
					default1.transform.localPosition += .02f * hit.normal;
					GetComponent<AudioSource>().clip = meleeSlash;
					GetComponent<AudioSource>().Play();
				}*/

				/*if (hit.transform.tag == "Enemy")
				{
					Instantiate(meleeHitEnemy, contact, rotation);
				}*/

				//hit.collider.SendMessageUpwards("ApplyDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
			}
		}
		yield return new WaitForSeconds(.5f);
		inAttack = false;
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

	IEnumerator DrawWeapon()
	{
		//draw = true;
		//GetComponent<AudioSource>().clip = soundDraw;
		//GetComponent<AudioSource>().Play();
		//weaponAnim.GetComponent<Animation>()[DrawAnimation].speed = weaponAnim.GetComponent<Animation>()[DrawAnimation].clip.length / 0.9f;
		//weaponAnim.GetComponent<Animation>().Play(DrawAnimation);
		yield return new WaitForSeconds(0.6f);

		selected = true;
	}

	void Deselect()
	{
		selected = false;
	}

}
