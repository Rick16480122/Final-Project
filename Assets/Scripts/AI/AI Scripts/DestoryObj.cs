using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObj : MonoBehaviour
{
    public float destroyDelay = 5f;

    void Start()
    {
        Invoke("DestroyGameObject", destroyDelay);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
