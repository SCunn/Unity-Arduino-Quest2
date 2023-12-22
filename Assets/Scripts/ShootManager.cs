// Original code sourced from https://youtu.be/TjBIEOFiqoI?si=sFa0mC5nDWqlo0DR&t=416
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform from where the bullet will be instantiated
    public Transform hand;

    [Header("BulletPrefab")]
    // GameObject used as a bullet to Instantiate
    [SerializeField] GameObject bulletPrefab;
    public float speed = 50f;

    [Header("Partical Effect")]
    public GameObject muzzleFlash;

    public AudioClip audioClip;

    //[Header("Aiming Helper")]
    //public Transform gunTip;
    //public Transform circle;


    // Enum to determine the shoot mode of the bullet.  Enums are a special type of class that represents a group of constants
    public enum ShootMode
    {
        Automatic,
        Single
    }

    [Header("ShootMode")]
    // ShootMode variable to determine the shoot mode of the bullet
    public ShootMode shootMode;

    // Boolean to use "Single" shoot mode
    private bool hasFired = false;

    // Float to determine the fire rate of the bullet
    private float timeToFire = 0f;

    //// Referene to the Gesture Detector Component
    //private GestureDetector2 gestureDetector;

    // Start is called before the first frame update
    //private void Start()
    //{
    //    // Get the Gesture Detector Component
    //    gestureDetector = GetComponent<GestureDetector2>();
    //}

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot() 
    {
        //// Check if the bulletPrefab or hand is null, if so print an error message to the console
        //if (bulletPrefab == null || hand == null) 
        //{
        //    Debug.LogError("BulletPrefab or Hand is not set in the Unity editor");
        //    return;
        //}
        // Switch between the to modes, This section uses the switch case method conditional, this helps to reduce nested if/else conditionals and is efficient for cycling through large set lists
        switch (shootMode) 
        {
            case ShootMode.Automatic:
                    Debug.Log("Shooting in Automatic Mode");
                if (Time.time >= timeToFire)
                {
                    timeToFire = Time.time + 1f / bulletPrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;


            case ShootMode.Single:

                if (!hasFired) 
                {
                    hasFired = true;
                    Debug.Log("Shooting in Single Mode");
                    Shoot();
                }
                break;
        }
    }

    private void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, hand.position, Quaternion.identity);
        bullet.transform.localRotation = hand.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed * 2f); //Set the speed of the projectile by applying force to the rigidbody
        Instantiate(muzzleFlash, hand.position, hand.rotation); // Instantiate the muzzle flash particle effect
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        //hasFired = false; // Reset hasFired to false after shooting
    }

    public void StopShoot()
    {
        hasFired = false;
        Debug.Log("Stop Shooting");
    }

}
