using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SceneSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera MapCamera;
    public Camera MenuCamera;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;

    public void SwitchScene(int index)
    {
        switch (index)
        {
            case 1:
                {
                    canvas1.enabled = false;
                    canvas2.enabled = false;
                    canvas3.enabled = true;
                    mainCamera.gameObject.SetActive(false);
                    MapCamera.gameObject.SetActive(false);
                    MenuCamera.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    canvas1.enabled = true;
                    canvas2.enabled = false;
                    canvas3.enabled = false;
                    mainCamera.gameObject.SetActive(true);
                    MapCamera.gameObject.SetActive(false);
                    MenuCamera.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    canvas1.enabled = false;
                    canvas2.enabled = true;
                    canvas3.enabled = false;
                    mainCamera.gameObject.SetActive(false);
                    MapCamera.gameObject.SetActive(true);
                    MenuCamera.gameObject.SetActive(false);
                    break;
                }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MenuCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        MapCamera.gameObject.SetActive(false);
        canvas1.enabled = true;
        canvas2.enabled = false;
        canvas3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Continue()
    {
        SwitchScene(2);
    }

    public void BackToMenu()
    {
        SwitchScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
