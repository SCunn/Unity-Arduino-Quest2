// original code sourced from https://www.youtube.com/watch?v=GfT11IVIosc&ab_channel=Skarredghost
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file manage the spatial anchors for the project

public class SpatialAnchorsManager : MonoBehaviour
{

    // Update is called once per frame
   private void Update()
    {
        bool trigger1Pressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        bool trigger2Pressed = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);

        //if the user has pressed the index trigger on one of the two controllers, generate an object in that position
        if (trigger1Pressed)
            GenerateObject(true);

        if (trigger2Pressed)
            GenerateObject(false);
    }

    // Generates an object from the same pose of the controller

    private void GenerateObject(bool isLeft)
    {
        //From OVRPose struct, Create objectPose variable to get the pose from the controller and the local tracking coordinates
        OVRPose objectPose = new OVRPose() 
        {   // The ternary operator is used here ( condition ? do somthing : if not do somthing else ), The ternary operator is a shorthand alternative to using "if" statements  
            position = OVRInput.GetLocalControllerPosition(isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch),
            orientation = OVRInput.GetLocalControllerRotation(isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch)
        };

        // Convert objectPose to world coordinates using ToWorldSpace() method from OVRExtensions

        OVRPose worldObjectPose = OVRExtensions.ToWorldSpacePose(objectPose);


        //generate an object depending on the controller onto which the trigger was pressed, and assign it the pose of the controller
        GameObject.Instantiate(Resources.Load<GameObject>(isLeft ? "Object1" : "Object2"),
            worldObjectPose.position,
            worldObjectPose.orientation
            );
    }
}
