using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
    public AudioClip attackSound;
    float timer;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		anim = this.GetComponentInChildren<Animator>();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInRange = true;
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
	}


	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			Attack();
            PlayAudioClip(attackSound, player.transform.position,0.7f);
        }

		if (playerHealth.currentHealth <= 0)
		{
			anim.SetBool("playerDead", true);
		}
	}


	void Attack()
	{
		timer = 0f;

		if (playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage(attackDamage);

			if (Random.value < 0.5f)
				anim.SetTrigger("attackZero");
			else
				anim.SetTrigger("attackOne");
		}
	}
}
