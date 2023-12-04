using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent; // reference to the nav mesh agent, this allows for the enemy to move around the scene
    public Transform player; // reference to the player, this allows for the enemy to follow the player based on the player's transfom position
    public LayerMask whatIsGround, whatIsPlayer; // logic for the enemy to diferentiate between the ground and the palyer, the Layermask specifies layers to use in Pyhsics.Raycast

    // Enemy Patrol Logic
    public Vector3 walkPoint; // point to where the enemy will walk to
    bool walkPointSet; // boolean to check if the walk point has been set
    public float walkPointRange; // range of the walk point

    // Enemy Attack Logic
    public float timeBetweenAttacks; // time between attacks
    bool alreadyAttacked; // boolean to check if the enemy has already attacked

    // Enemy States
    public float sightRange, attackRange; // range of sight and attack
    public bool playerInSightRange, playerInAttackRange; // boolean to check if the player is in sight and attack range


}
