using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChange : MonoBehaviour
{
    int cameraNumber = 0;
    public GameObject[] cameraArray = new GameObject[3];

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            LastCamera();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextCamera();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    public void NextCamera()
    {
        cameraArray[cameraNumber].SetActive(false);
        cameraNumber++;
        if (cameraNumber == 3) cameraNumber = 0;
        cameraArray[cameraNumber].SetActive(true);
    }

    public void LastCamera()
    {
        cameraArray[cameraNumber].SetActive(false);
        cameraNumber--;
        if (cameraNumber == -1) cameraNumber = 2;
        cameraArray[cameraNumber].SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
