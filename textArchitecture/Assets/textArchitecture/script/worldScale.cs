using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class worldScale : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider worldScaleSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale = new Vector3(worldScaleSlider.value, worldScaleSlider.value, worldScaleSlider.value);
    }
}
