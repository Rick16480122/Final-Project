using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class BossCheck : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject boss = GameObject.FindWithTag("Boss");

        if (boss == null)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

