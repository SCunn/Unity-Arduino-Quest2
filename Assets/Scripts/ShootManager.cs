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
    public GameObject bulletPrefab;

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

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot() 
    {
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
                    timeToFire = Time.time + 1f / bulletPrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;
        }
    }

    private void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, hand.position, Quaternion.identity);
        bullet.transform.localRotation = hand.rotation;
    }

    public void StopShoot()
    {
        hasFired = false;
        Debug.Log("Stop Shooting");
    }




}
