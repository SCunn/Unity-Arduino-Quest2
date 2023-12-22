// Code sourced from Communicating from Unity 3D to an Arduino (2013). Available at: https://www.youtube.com/watch?v=EMAWe2d7lC0 (Accessed: 20 October 2023).
// code from link above is outdated and throws a TimeoutException. Code has been updated using Thread(DataThread) to fix this issue.
// 
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Sending : MonoBehaviour
{
    // Create new Thread
    Thread IOThread = new Thread(DataThread);
    // Initiate Serial Port  connection
    private static SerialPort sp = new SerialPort("COM4", 9600);
    private static string message2;
   //float timePassed = 0.0f;


    private static void DataThread()
    {
        sp.Open();
        while (true)
        {
            message2 = sp.ReadLine();
            Thread.Sleep(200);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        IOThread.Start();
    }

    void OnApplicationQuit()
    {
        IOThread.Abort();
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
