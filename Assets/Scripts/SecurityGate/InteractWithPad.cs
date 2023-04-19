using UnityEngine;

public class InteractWithPad : MonoBehaviour
{
    public Gate gate;
    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (PlayerInventory.Instance.HasKeycard(gate.requiredKeycardID))
            {
                gate.OpenGate();
            }
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
