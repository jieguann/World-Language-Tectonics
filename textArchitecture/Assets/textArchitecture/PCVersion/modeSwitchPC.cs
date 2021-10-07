using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeSwitchPC : MonoBehaviour
{
    public FirstPersonMovement move;
    public FirstPersonLook look;
    public TMPro.TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            move.enabled = !move.enabled;
            look.enabled = !look.enabled;
            input.enabled = !input.enabled;
        }
    }
}
