using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour {

    ArrayList targets = new ArrayList();
    Transform model;
    public int FIRE_RATE = 5;
    public int BASE_DAMAGE = 50;
    // Use this for initialization
    void Start ()
    {

        model  = this.transform.FindChild("Model").FindChild("turret");
        InvokeRepeating("Fire", 5, FIRE_RATE);
    }
    void Fire()
    {
        if (targets.Count > 0)
        {
            if (((Transform)targets[0]).GetComponentInParent<EnemyHealth>().currentHealth > 0)
            {
                ((Transform)targets[0]).GetComponentInParent<EnemyHealth>().TakeDamage(BASE_DAMAGE, ((Transform)targets[0]).position);
                
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
    void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.transform))
        {
            Debug.Log("Enemy out of range");
            targets.Remove(other.transform);
        }
    }
}
