using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth otherHP = collision.collider.gameObject.GetComponent<EnemyHealth>();
        if(otherHP != null)
        {
            otherHP.takeDamage(damage);
        }

        Destroy(gameObject);
    }
}
