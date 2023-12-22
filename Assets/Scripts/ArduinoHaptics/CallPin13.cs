using System.Collections;
using UnityEngine;

public class CallPin13 : MonoBehaviour
{
    void OnMouseDown()
    {
        print("Clicked");
        Sending.sendLed13();
    }
}
