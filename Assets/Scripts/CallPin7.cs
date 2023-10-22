using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPin7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        print("Clicked d7");
        Sending.send_Motor_D7();
    }
}
