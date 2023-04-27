using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeTeleport : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        GameObject Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            SceneManager.LoadScene("OfficeLevel");
        }
    }
}
