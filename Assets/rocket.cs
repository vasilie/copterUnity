using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

    public GameObject explosionEffect;
    public float rocketSpeed = 10.0f;
    public float explosionForce = 10.0f;
    public float explosionRadius = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter(Collision collision) {
        Debug.Log("hit lf");
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        foreach (Collider nearbyObject in colliders){
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null){
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Destroy(gameObject);

    }
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * rocketSpeed);
	}
}
