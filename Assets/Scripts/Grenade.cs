using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float Blast_radii = 4f;
    public float explosion_Force = 700f;

    public GameObject ExplosionEffect;
    float countdown;
    bool hasExploaded = false;

    void Start()
    {
        countdown = delay;
    }

    
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploaded)
        {
            Explode();
            hasExploaded = true;
        }
    }
    void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, Blast_radii);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosion_Force, transform.position, Blast_radii);
            }
        }
    }
}
