using UnityEngine;

public class PopoutUI : MonoBehaviour
{
    public GameObject panel;
    public string requiredKeycardID;
    private bool isInRange = false;
    private bool hasKeycard = false;

    private void Start()
    {
        HidePopup();
    }

    private void Update()
    {
        if (isInRange && !hasKeycard)
        {
            ShowPopup();
        }
        else
        {
            HidePopup();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wolf"))
        {
            isInRange = true;
            hasKeycard = PlayerInventory.Instance.HasKeycard(requiredKeycardID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wolf"))
        {
            isInRange = false;
        }
    }

    private void ShowPopup()
    {
        panel.SetActive(true);
    }

    private void HidePopup()
    {
        panel.SetActive(false);
    }
}
