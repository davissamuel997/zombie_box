using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour {

    ArrayList targets = new ArrayList();
    public Transform model;
    public float FIRE_RATE = 0.1f;
    public int BASE_DAMAGE = 50;
    Animator anim;
    Vector3 target;
    public AudioClip fireSound;
    Transform pipe;
    LineRenderer bullet;
    Transform turret;
    Light light;
    
    // Use this for initialization
    void Start ()
    {

        turret  = this.transform.FindChild("Model").FindChild("turret");
        model = this.transform.FindChild("Model");
        InvokeRepeating("Fire", 5, FIRE_RATE);
        anim = this.GetComponentInChildren<Animator>();
        bullet = transform.GetComponent<LineRenderer>();
        

        pipe = turret.FindChild("Tube02");
        bullet.enabled = false;
        bullet.SetPosition(0,  pipe.position);
        bullet.SetPosition(1, model.position);
       
        light = transform.GetComponent<Light>();
        light.enabled = false;
        

    }
    void Fire()
    {
        if (targets.Count > 0)
        {
            if (((Transform)targets[0]).GetComponentInParent<EnemyHealth>().currentHealth > 0)
            {
                bullet.enabled = true;
                ((Transform)targets[0]).GetComponentInParent<EnemyHealth>().TakeDamage(BASE_DAMAGE, ((Transform)targets[0]).position);
                anim.SetBool("fire", true);
                light.transform.position.Set(0, 0, 0);
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
        float old_x = model.transform.position.x;
        float old_y = model.transform.position.y;
        float old_z = model.transform.position.z;
        target = ((Transform)targets[0]).transform.position;
        Quaternion lookRot = Quaternion.LookRotation(target - model.position);
        
        model.rotation = Quaternion.Lerp(model.rotation, lookRot, Time.deltaTime * 5);
        model.transform.position.Set(old_x, old_y, old_z);

        bullet.SetPosition(0, pipe.position);
        bullet.SetPosition(1, target);

        yield return null;

    }
}
