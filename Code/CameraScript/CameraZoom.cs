using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraZoom : MonoBehaviour
{
    public Camera main;
    public Slider slider;

    public void ChangeZoom()
    {
        //float zoom = slider.value;
        main.orthographicSize = slider.value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
