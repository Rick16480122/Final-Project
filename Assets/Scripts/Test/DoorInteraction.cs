using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2.0f;
    private GameObject player;
    private bool isPlayerInRange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            isPlayerInRange = distance <= interactionDistance;

            if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
