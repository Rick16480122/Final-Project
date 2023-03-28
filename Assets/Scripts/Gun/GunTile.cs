using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTile : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float existance = 0.5f;
    [SerializeField] private float power = 5f;
    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject item = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 punch = spawnPoint.forward * power;
            item.GetComponent<Rigidbody>().AddForce(punch, ForceMode.Impulse);
            Destroy(item, existance);
        }
    }
}
