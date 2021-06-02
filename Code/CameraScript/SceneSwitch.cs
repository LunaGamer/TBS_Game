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
    public GameObject Menu;
    public GameObject Castle;
    public GameObject Map;

    public void SwitchScene(int index)
    {
        switch (index)
        {
            case 1:
                {
                    Menu.SetActive(true);
                    Castle.SetActive(false);
                    Map.SetActive(false);
                    mainCamera.gameObject.SetActive(false);
                    MapCamera.gameObject.SetActive(false);
                    MenuCamera.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    Menu.SetActive(false);
                    Castle.SetActive(true);
                    Map.SetActive(false);
                    mainCamera.gameObject.SetActive(true);
                    MapCamera.gameObject.SetActive(false);
                    MenuCamera.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    Menu.SetActive(false);
                    Castle.SetActive(false);
                    Map.SetActive(true);
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
        Menu.SetActive(false);
        Castle.SetActive(true);
        Map.SetActive(false);
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
