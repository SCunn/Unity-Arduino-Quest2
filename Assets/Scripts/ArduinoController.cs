using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ArduinoController : MonoBehaviour
{
    // Create new Thread
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    private static string outgoinigMsg = "";

    private static void DataThread()
    {
        sp = new SerialPort("COM4", 9600);
        sp.Open();

        while (true)
        {
            if (outgoinigMsg != "")         // if there is a message to send
            {
                sp.Write(outgoinigMsg);     // send it
                outgoinigMsg = "";          // clear the message
            }

            incomingMsg = sp.ReadExisting();    // read the incoming data
            Thread.Sleep(200);                  // wait for 200ms
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(incomingMsg != "")
        {
            Debug.Log(incomingMsg);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            outgoinigMsg = "0";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            outgoinigMsg = "1";
        }
    }
}
