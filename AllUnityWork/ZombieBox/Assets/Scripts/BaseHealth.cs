using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    private RoundStats stats;
    //public Slider healthSlider;
    //public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Slider healthSlider;

    AudioSource playerAudio;
    bool isDead;
    bool damaged;

    void Awake()
    {
        stats = GameObject.Find("RoundManager").GetComponent<RoundStats>();
        startingHealth = stats.BASE_HEALTH;
        currentHealth = startingHealth;
    }


    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        damaged = true;

		healthSlider.value = currentHealth;

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
       
    }
}

