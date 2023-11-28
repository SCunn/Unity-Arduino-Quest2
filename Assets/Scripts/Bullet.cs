using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //////// Variables ////////

    // Speed of the bullet
    public float speed = 20f;
    // Fire rate of the bullet
    public float fireRate = 1f;
    // Bullet lifespan in seconds
    private float bulletLifeSpan = 5f;
    // Collision Checker
    private bool hasHit = false;
    // The Rigidbody of the bullet
    private Rigidbody rb = null;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, bulletLifeSpan);
    }
    // Method to move the bullet
    void FixedUpdate()
    {
        // Move the rigidbody forward
        if (speed != 0 && rb != null) rb.position += (transform.forward) * (speed * Time.deltaTime);
    }

    // Method to check for collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && !hasHit) 
        {
            hasHit = true;

            speed = 0;

            Destroy(gameObject);
        }
    }

}
