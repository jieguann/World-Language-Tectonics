using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileInput : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInputEvent()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false);
    }
}
