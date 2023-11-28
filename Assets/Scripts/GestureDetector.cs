//// Original code sourced from Valem Hand Tracking Gesture Detection - Unity Oculus Quest Tutorial, https://youtu.be/lBzwUKQ3tbw?si=XEdB0KcfmNWJ1fuS&t=206
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;  // Unity Event System is used to call functions from the inspector without the need of a reference to a script component

//// Gesture struct, contains the name of the gesture, a list of vector3's, and a unity event
//[System.Serializable]  // This allows the struct to be shown in the inspector
//public struct Gesture
//{
//    public string name;
//    public List<Vector3> fingerDatas;
//    public UnityEvent onRecognized;
//}
//public class GestureDetector : MonoBehaviour
//{
//    // Variables
//    public float threshold = 0.1f;      // Float to determine the threshold of the gesture
//    public OVRSkeleton skeleton;        // OVRSkeleton is a class that contains the bones of the hand
//    public List<Gesture> gestures;      // List of Gestures declared as gestures
//    public bool debugMode = true;       // Bool to determine if the program is in debug mode
//    private List<OVRBone> fingerBones;  // List of OVRBones declared as fingerBones
//    private Gesture previousGesture;    // Gesture declared as previousGesture, this is used to determine if the gesture has changed

//    // Start is called before the first frame update
//    void Start()
//    {
//        fingerBones = new List<OVRBone>(skeleton.Bones);    // fingerBones is set to a new list of OVRBones
//        previousGesture = new Gesture();                    // previousGesture is set to a new Gesture
//    }

//    // Update is called once per frame 
//    void Update()
//    {  // If debugMode is true and the space key is pressed start the save function, this is used to save the gesture when space bar is pressed during game mode in the viewport
//       if (debugMode && Input.GetKeyDown(KeyCode.Space))             
//       {
//            fingerBones = new List<OVRBone>(skeleton.Bones);  // fingerBones is set to a new list of OVRBones
//            Save();
//       }

//       if (fingerBones.Count == 0) fingerBones = new List<OVRBone>(skeleton.Bones); // If fingerBones is empty set fingerBones to a new list of OVRBones

//       // Set the currentGesture to the gesture returned from the Recognize function
//       Gesture currentGesture = Recognize();
//       bool hasRecognized = !currentGesture.Equals(new Gesture()); // Set hasRecognized to true if the currentGesture is not equal to a new Gesture
//        // check if there is a new gesture
//        if (hasRecognized && !currentGesture.Equals(previousGesture)) 
//        {
//            Debug.Log("New Gesture Found : " + currentGesture.name); // Print the name of the gesture to the console
//            previousGesture = currentGesture;           // Set the previousGesture to the currentGesture
//            currentGesture.onRecognized.Invoke();       // Invoke the onRecognized event, Invoke() triggers the onRecognized event & leads to the execution of associated functions  
//        }
//    }

//    void Save() 
//    { 
//        // Create a new gesture
//        Gesture g = new Gesture();
//        // Set the name of the gesture to the name of the game object
//        g.name = "New Gesture";
//        // Create a new list of vector3's called data
//        List<Vector3> data = new List<Vector3>();
//        // For each bone in fingerBones
//        foreach (var bone in fingerBones)
//        {
//            // Add the position of the bone to the data list
//            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
//        }
//        // Set the fingerDatas of the gesture to the data list
//        g.fingerDatas = data;
//        // Add the gesture to the gestures list
//        gestures.Add(g);
//    }

//    // Recognize function this function will be called when the gesture is recognized
//    Gesture Recognize()
//    { 
//        Gesture currentGesture = new Gesture(); // Create a new gesture called currentGesture
//        float currentMin = Mathf.Infinity;      // Set currentMin to infinity, Mathf.Infinity is the largest possible value for a float, using Mathf.Infinity ensures that the the gesture will better match the values of the gesture in the gestures list
//        // For each gesture in gestures
//        foreach (var gesture in gestures)
//        {
//            float sumDistance = 0;              // Set sumDistance to 0, sumDistance is the total distance between the gesture and the current gesture
//            bool isDiscarded = false;           // Set isDiscarded to false, checks if the gesture is discarded
//            // For each bone in fingerBones
//            for (int i = 0; i < fingerBones.Count; i++)
//            {
//                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position); // Set currentData to the position of the bone
//                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]); // Set distance to the distance between the currentData and the gesture data

//                // If the distance is greater than the threshold then discard the gesture
//                if (distance > threshold) 
//                {
//                    isDiscarded = true;         // Set isDiscarded to true
//                    break;                      // Break out of the loop
//                }
//                sumDistance += distance;        // Add the distance to the sumDistance
//            }
//            // If the gesture is not discarded and the sumDistance is less than the currentMin
//            if (!isDiscarded && sumDistance < currentMin)
//            {
//                currentMin = sumDistance;       // Set currentMin to the sumDistance
//                currentGesture = gesture;       // Set currentGesture to the gesture
//            }
//        }
//        return currentGesture;                  // Return the currentGesture
//    }
//}
