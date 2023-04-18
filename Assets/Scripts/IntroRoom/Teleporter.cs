using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        GameObject Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            Player.transform.position = teleportTarget.transform.position;
        }
    }

}
