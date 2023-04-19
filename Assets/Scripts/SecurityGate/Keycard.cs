using UnityEngine;

public class Keycard : MonoBehaviour
{
    public string keycardID;
    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayerInventory.Instance.AddKeycard(keycardID);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wolf"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wolf"))
        {
            isInRange = false;
        }
    }
}

