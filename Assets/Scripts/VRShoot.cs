// Code from Realary, https://www.youtube.com/watch?v=vmxRjbLhmXM&t=33s&ab_channel=RealaryVR In Code Comments by Shane Cunningham
// this code handles the VR shooting logic and uses a composition style design pattern
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    // calling SimpleShoot class from SimpleShoot.cs file, declaring it as simpleShoot
    public SimpleShoot simpleShoot;
    // OVR input button to determin what button is pressed to confirm the shooting.
    public OVRInput.Button shootButton;
    // Add grabbable component OVR Grabbable Class
    private OVRGrabbable grabbable;
    // Include Audio source
    private AudioSource audio;

    // In Start, variables are set refering to the class objects using the GetComponent<>()
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
        {
            simpleShoot.StartShoot();
            audio.Play();
        }
    }
}
