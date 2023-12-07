using UnityEngine;
using System.Collections;

public class CallPin7 : MonoBehaviour
{
    void OnMouseDown()
    {
        print("Clicked d7");
        Sending.send_Motor_D7();
    }  
}
