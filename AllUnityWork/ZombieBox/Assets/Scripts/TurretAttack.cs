using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour {

    ArrayList targets = new ArrayList();
    Transform model;
    public float FIRE_RATE = 0.1f;
    public int BASE_DAMAGE = 50;
    Animator anim;
    public AudioClip fireSound;
    // Use this for initialization
    void Start ()
    {

        model  = this.transform.FindChild("Model").FindChild("turret");
        InvokeRepeating("Fire", 5, FIRE_RATE);
        anim = this.GetComponentInChildren<Animator>();
     }
    void Fire()
    {
        if (targets.Count > 0)
        {
            if (((Transform)targets[0]).GetComponentInParent<EnemyHealth>().currentHealth > 0)
            {
                ((Transform)targets[0]).GetComponentInParent<EnemyHealth>().TakeDamage(BASE_DAMAGE, ((Transform)targets[0]).position);
                anim.SetBool("fire", true);
                PlayAudioClip(fireSound, new Vector3(0,5,0)+transform.position, 0.2f);

            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
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
            model.LookAt(((Transform)targets[0]).transform);    
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
}
