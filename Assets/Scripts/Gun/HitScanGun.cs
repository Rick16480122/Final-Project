using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanGun : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            Vector3 origin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if(Physics.Raycast(origin, camera.transform.forward, out hit))
            {
                GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.identity);
                Destroy(effect, 0.25f);

                EnemyHealth otherHP = hit.collider.gameObject.GetComponent<EnemyHealth>();
                if(otherHP != null)
                {
                    otherHP.takeDamage(damage);
                }
            }
        }
    }
}
