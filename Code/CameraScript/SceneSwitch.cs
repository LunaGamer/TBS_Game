using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneSwitch : MonoBehaviour
{
    bool index;
    public Camera mainCamera;
    public Camera MapCamera;
    public Canvas canvas1;
    public Canvas canvas2;

    public void SwitchScene()
    {
        if (index)
        {
            index = false;
            canvas1.enabled = false;
            canvas2.enabled = true;
            mainCamera.gameObject.SetActive(false);
            MapCamera.gameObject.SetActive(true);
        }
        else
        {
            index = true;
            canvas1.enabled = true;
            canvas2.enabled = false;
            mainCamera.gameObject.SetActive(true);
            MapCamera.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        index = false;
        mainCamera.gameObject.SetActive(false);
        MapCamera.gameObject.SetActive(true);
        canvas1.enabled = false;
        canvas2.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
