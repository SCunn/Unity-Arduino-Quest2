// Code sourced from Communicating from Unity 3D to an Arduino (2013). Available at: https://www.youtube.com/watch?v=EMAWe2d7lC0 (Accessed: 20 October 2023).
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class Sending : MonoBehaviour
{
    // Initiate Serial Port  connection
    public static SerialPort sp = new SerialPort("COM4", 9600);
    public string message2;
    float timePassed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        OpenConnection();
    }


    // Update is called once per frame
    void Update()
    {   
        message2 = sp.ReadLine();
        print(message2);
    }
    public void OpenConnection()
    {
        if (sp != null) 
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 16;
                print("Port Opened!!!!");
            }
        }
        else
        {
            if (sp.IsOpen) 
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }

    public static void sendLed13()
    {
        sp.Write("r");
    }

    public static void send_Motor_D7()
    {
        sp.Write("s");
    }
}
