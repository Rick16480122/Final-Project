using UnityEngine;

public class AIAnimationController : MonoBehaviour
{
    public Animator animator;
    private Vector3 previousPosition;
    private float movementThreshold = 0.01f;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate the distance moved since the last frame
        float distanceMoved = Vector3.Distance(transform.position, previousPosition);

        // Check if the object has moved beyond the movement threshold
        bool isMoving = distanceMoved > movementThreshold;

        // Set the "Is Moving" parameter in the Animator
        animator.SetBool("Is Moving", isMoving);

        // Update the previous position
        previousPosition = transform.position;
    }
}
