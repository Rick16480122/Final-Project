using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public GameObject levelSelectMenu;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject menu = Instantiate(levelSelectMenu);
            menu.SetActive(true);


            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void LoadOfficeLevel()
    {
        SceneManager.LoadScene("OfficeLevel");
    }

    public void LoadTrainLevel()
    {
        SceneManager.LoadScene("TrainLevel");
    }

    public void LoadPlaneLevel()
    {
        SceneManager.LoadScene("PlaneLevel");
    }
}