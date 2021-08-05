using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M2MqttUnity.Examples;
public class MQTTusage : MonoBehaviour
{
    [SerializeField]
    private MQTTTest mqtt;
    // Start is called before the first frame update
    [SerializeField]
    private UIForm uiForm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendMessageMQTT()
    {
        mqtt.TestPublish(uiForm.InputFieldText);
        uiForm.ClearInputField();
    }
}
