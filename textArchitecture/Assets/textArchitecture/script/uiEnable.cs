using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiEnable : MonoBehaviour
{
    public GameObject UIs;

    // Start is called before the first frame update
    
    void Start()
    {
        UIs.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void toggleUI()
    {
        if(UIs.active == true)
        {
            UIs.active = false;
        }
        else { UIs.active = true; }
        
    }
}
