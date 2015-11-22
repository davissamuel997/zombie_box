using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	Animator anim;
	GameObject player;
    GameObject baseObj;
    Transform model;
    PlayerHealth playerHealth;
    BaseHealth baseHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
    bool baseInRange;
    public AudioClip attackSound;
    float timer;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
        baseObj = GameObject.Find("Base");
        model = baseObj.transform.FindChild("baseModel").FindChild("Mesh1");
        baseHealth = baseObj.GetComponent<BaseHealth>();
		anim = this.GetComponentInChildren<Animator>();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInRange = true;
		}
        if (other.gameObject.transform == model)
        {
            Debug.Log("found " + model);
            baseInRange = true;
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
		if (other.gameObject == player)
		{
			playerInRange = false;
		}
        if (other.gameObject == model)
        {
            baseInRange = false ;
        }
    }


	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			Attack();
           
        }

		if (playerHealth.currentHealth <= 0)
		{
			anim.SetBool("playerDead", true);
		}

        if (timer >= timeBetweenAttacks && baseInRange && enemyHealth.currentHealth > 0)
        {
            AttackBase();
        }

        if (baseHealth.currentHealth <= 0)
        {
            anim.SetBool("playerDead", true);
        }
    }

    void AttackBase()
    {
        timer = 0f;

        if (baseHealth.currentHealth > 0)
        {
            baseHealth.TakeDamage(attackDamage);
            PlayAudioClip(attackSound, baseObj.transform.position, 0.7f);
            if (Random.value < 0.5f)
                anim.SetTrigger("attackZero");
            else
                anim.SetTrigger("attackOne");
        }
    }
	void Attack()
	{
		timer = 0f;

		if (playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage(attackDamage);
            PlayAudioClip(attackSound, player.transform.position, 0.7f);

            if (Random.value < 0.5f)
				anim.SetTrigger("attackZero");
			else
				anim.SetTrigger("attackOne");
		}

    }
}
