// Based on code from https://www.hackster.io/richmondkevin92/receive-data-in-unity-from-adafruit-io-9b9895
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class EspController : MonoBehaviour
{
    //variable to hold the client
    private MqttClient mqttClient;
    // MQTT broker details
    private string brokerHostname = "broker.hivemq.com";
    private int brokerPort = 1883;
    private string topic = "esp8266-2-Unity";


    //public Text messageText;
    public InputField messageInput;


    public EspCall2 espCall2;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("espCall2: " + espCall2); // Check if espCall13 is null

        mqttClient = new MqttClient(brokerHostname, brokerPort);

        // register to message received 
        mqttClient.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

        // Connect to the broker
        string clientId = "UnityClient" + Random.Range(0, 1000);

        mqttClient.Connect(clientId);

        // check if client is connected
        if (!mqttClient.IsConnected)
        {
            Debug.LogError("Error connecting to MQTT broker");
        }
        else
        {
            Debug.Log("Connected to MQTT broker");
        }

    }

    public void Message2Broker(string specificMessage)
    {
        string message = messageInput.text;

        // publish a message with QoS 2, what this line does is publish a message to the broker with the topic and message
        mqttClient.Publish(topic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }


    private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        Debug.Log("Received: " + e.Topic);
        Debug.Log("Message: " + System.Text.Encoding.UTF8.GetString(e.Message));
    }

    public void SendToPin2()
    {
        if (espCall2 != null)
        {
            espCall2.OnMouseDown();
        }
        else
        {
            Debug.Log("espCall2 is null");
        }
    }
}
