using UnityEngine;

public class Keycard : MonoBehaviour
{
    public string keycardID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddKeycard(keycardID);
            Destroy(gameObject);
        }
    }
}
