using UnityEngine;

public class EspCall2 : MonoBehaviour
{
    private EspController mqttController;

    public void OnMouseDown()
    {
        Debug.Log("Clicked in EspCall13");

        if (mqttController != null)
        {
            mqttController.Message2Broker("r");
        }
        else
        {
            Debug.LogError("mqttController is null");
        }
    }
}
