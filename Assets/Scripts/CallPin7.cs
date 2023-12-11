using UnityEngine;


public class CallPin7 : MonoBehaviour
{

    void OnMouseDown()
    {
        print("D7 Clicked");
        // Send sp.Write("s") message to Arduino by calling Sending.send_Motor_D7()
        Sending.send_Motor_D7();
        
    }  
}
