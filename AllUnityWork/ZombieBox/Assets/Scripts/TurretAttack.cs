using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour {

    ArrayList targets = new ArrayList();
	Vector3 target;

	private int m_LastFrameShot = -10;

	public float FIRE_RATE = 5.0f;
    public int BASE_DAMAGE = 50;
    public Animator anim;
    public AudioClip fireSound;
    public Transform pipe;
    public LineRenderer laserSight;
    public Transform turret;
    public Light muzzleLight;
	public Renderer muzzleFlash;
    public RoundStats stats;
    
    // Use this for initialization
    void Start ()
    {

        stats = GameObject.Find("RoundStats").GetComponent<RoundStats>();
        //turret  = this.transform.FindChild("turret");
        InvokeRepeating("Fire", 5, FIRE_RATE);
        //anim = this.GetComponentInChildren<Animator>();
        //sightLight = transform.GetComponent<LineRenderer>();
		// pipe = turret.FindChild("Tube02");
		laserSight.SetPosition(0, pipe.position);
		laserSight.SetPosition(1, pipe.transform.position + pipe.transform.TransformDirection(0, 0, 1) * 0.5f);
		laserSight.enabled = false;

        //light = turret.FindChild("Box06").GetComponentInChildren<Light>();
        muzzleLight.enabled = false;
		muzzleFlash.enabled = false;

    }
    void Fire()
    {
        if (targets.Count > 0)
        {
            if (((Transform)targets[0]).GetComponentInParent<EnemyHealth>().currentHealth > 0)
            {

                if(((Transform)targets[0]).GetComponentInParent<EnemyHealth>().TakeDamage(BASE_DAMAGE, ((Transform)targets[0]).position))
                {
                    stats.roundPoints += 5;
                    stats.deadEnemies++;
                }
                anim.SetTrigger("fire");
                PlayAudioClip(fireSound, new Vector3(0,5,0)+transform.position, 0.2f);
				m_LastFrameShot = Time.frameCount;
            }
		}
    }

	void LateUpdate()
	{
		if (m_LastFrameShot == Time.frameCount)
		{
			muzzleLight.transform.localRotation = Quaternion.AngleAxis(Random.value * 360, Vector3.right);
			muzzleFlash.enabled = true;
			muzzleLight.enabled = true;
		}
		else
		{
			muzzleFlash.enabled = false;
			muzzleLight.enabled = false;
		}
	}

	// Update is called once per frame
	void Update ()
    {
		if(targets.Count == 0)
		{
			laserSight.enabled = false;
		}
		else
		{
			laserSight.enabled = true;
		}

        Transform[] temp = new Transform[targets.Count];
        targets.CopyTo(temp);

       for(int i = 0; i < targets.Count; i++)
        { 
            if (((Transform)temp[i]).GetComponentInParent<EnemyHealth>().currentHealth <= 0)
            {
                targets.Remove(((Transform)temp[i]));
            }
        }

        if (targets.Count > 0)
        {

            StopCoroutine("RenderLaser");
            StartCoroutine("RenderLaser");
        } 
	}

    void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.name.Contains("normalEnemy"))
        {
            if (!targets.Contains(other.transform))
            {

                Debug.Log("Turret Found an Enemy");

                targets.Add(other.transform);
            }
        }
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

    void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.transform))
        {
            Debug.Log("Enemy out of range");
            targets.Remove(other.transform);
        }
    }

    IEnumerator RenderLaser()
    {
        target = ((Transform)targets[0]).transform.position;
		
		float enemyCenterOffset;
		if(((Transform)targets[0]).GetComponentInParent<EnemyHealth>().healthPercent >= 51)
		{
			enemyCenterOffset = 0.8f;
		}
		else
		{
			enemyCenterOffset = 0.2f;
		}

		Vector3 targetCenter = new Vector3(target.x, target.y + enemyCenterOffset, target.z);

        //Quaternion lookRot = Quaternion.LookRotation(target - model.position);
		laserSight.SetPosition(0, pipe.transform.position);
		laserSight.SetPosition(1, pipe.transform.position + pipe.transform.TransformDirection(0, 0, 1) * Vector3.Distance(pipe.transform.position, targetCenter));
        turret.LookAt(targetCenter);

        yield return null;
    }

}
