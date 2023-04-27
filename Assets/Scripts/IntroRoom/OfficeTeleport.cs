using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeTeleport : MonoBehaviour
{
    void Start()
    {
        if (Input.GetKey(KeyCode.E))
            SceneManager.LoadScene("OfficeLevel");
    }


    void Update()
    {
        
    }
}
