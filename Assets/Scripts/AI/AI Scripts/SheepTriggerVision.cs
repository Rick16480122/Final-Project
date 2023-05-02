using System;
using System.Collections;
using System.Collections.Generic;
using IndieMarc.EnemyVision;
using UnityEngine;

public class SheepTriggerVision : MonoBehaviour
{
    public LayerMask hitLayer;
    [HideInInspector] public GameObject player;
    private bool playerInVision;
    private GameObject _privatePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out VisionTarget visionTarget))
        {
            if (visionTarget.visible)
            {
                _privatePlayer = other.gameObject;
                playerInVision = true;
            }
        }
    }

    private void Update()
    {
        if (playerInVision)
        {
            Vector3 raycastDirection = _privatePlayer.transform.position - transform.parent.position;
            if (Physics.Raycast(transform.parent.position, raycastDirection, out RaycastHit hit, 99f, hitLayer))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    player = hit.transform.gameObject;
                }
                else
                {
                    player = null;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out VisionTarget visionTarget))
        {
            playerInVision = false;
            player = null;
        }
    }
}
