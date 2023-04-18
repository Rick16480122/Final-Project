using UnityEngine;

public class InteractWithPad : MonoBehaviour
{
    public GameObject gateObject;
    private Gate gate;
    private bool isInRange = false;

    private void Start()
    {
        gate = gateObject.GetComponent<Gate>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            gate.OpenGate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
