using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStop : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

    private void Update()
    {
        if (rb.velocity.magnitude > 0.1f) // if the object is moving
        {
            animator.SetTrigger("Move"); // activate the "Move" trigger
            animator.ResetTrigger("Stop"); // deactivate the "Stop" trigger
        }
        else // if the object is not moving
        {
            animator.SetTrigger("Stop"); // activate the "Stop" trigger
            animator.ResetTrigger("Move"); // deactivate the "Move" trigger
        }
    }
}