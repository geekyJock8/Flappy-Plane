using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public static int plane = 0; //0 for Red, 1 for Green
    public GameObject redPlane;
    public GameObject greenPlane;

    private void Awake()
    {
        if (plane == 0)
        {
            redPlane.SetActive(true);
            greenPlane.SetActive(false);
        }
        else if (plane == 1)
        {
            redPlane.SetActive(false);
            greenPlane.SetActive(true);
        }
    }

    public void SwitchPlanes()
    {
        if(plane == 0)
        {
            greenPlane.SetActive(true);
            redPlane.SetActive(false);
            plane = 1;
        }
        else
        {
            greenPlane.SetActive(false);
            redPlane.SetActive(true);
            plane = 0;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
