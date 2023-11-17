using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger_Shoot_Haptic : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {


    }

    void Haptic()
    {
        print("Clicked d7");
        Sending.send_Motor_D7();
    }
}
