// Elements of code sourced from : Master Unity Engine (2024) and C# Programing By Creating A First Person Shooter Using Modern Unity Development Technics, https://www.udemy.com/course/master-unity-by-building-games-from-scratch/learn/lecture/15257106#overview
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // Variables
    public float speed = 12.5f;

    public CharacterController myController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // declare float variables x and z to get the horizontal and vertical axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Vector3 movement is equal to the transform.right * x + transform.forward * z, Vector3 is a 3D vector representation of a point in space, and in this case it refers to the position of the player
        Vector3 movement = transform.right * x + transform.forward * z;
        
        // Move the player using the CharacterController component
        myController.Move(movement * speed * Time.deltaTime);
    }
}
