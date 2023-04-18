using UnityEngine;

public class Gate : MonoBehaviour
{
    public string requiredKeycardID;
    public Transform gate;
    public Vector3 openPosition;
    public Vector3 openRotation; 
    private Vector3 closedPosition;
    private Quaternion closedRotation; 
    private bool isOpen = false;

    private void Start()
    {
        closedPosition = gate.position;
        closedRotation = gate.rotation; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerInventory>().HasKeycard(requiredKeycardID))
        {
            OpenGate();
        }
    }

    public void OpenGate()
    {
        if (!isOpen)
        {
            gate.position = openPosition;
            gate.rotation = Quaternion.Euler(openRotation); 
            isOpen = true;
        }
    }
}
