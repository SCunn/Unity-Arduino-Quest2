// Purpose: Controls the movement of the enemy
// original script from Naoise Collins's Animation tutorial
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // variables
    public float walkSpeed = 1.0f;  // set the walk speed of the enemy

    private Animator animator;      // variable to reference the Animation Class

    private Rigidbody rb;           // variable to reference the Rigidbody Class, used for game physics

    private Vector3 movement;       // variable to reference the Vector3 Class, used for 3d movement



    // Awake is called before Start
    void Awake()
    {
        animator = GetComponent<Animator>();  // cal upon Animator and Rigidbody components 
        rb = GetComponent<Rigidbody>();       // linked to our enemy gameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
