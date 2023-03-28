using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAINavMesh : MonoBehaviour
{
    public List<Transform> waypoints;
    public float waypointReachedThreshold = 0.5f;
    public float detectionRange = 10.0f;
    public LayerMask sightLayers;

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex = 0;
    private GameObject wolfTarget;

    //Attack
    public float attackRange = 2.0f;
    public float damagePerSecond = 10f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on the AI agent.");
            return;
        }

        if (waypoints.Count == 0)
        {
            Debug.LogWarning("No waypoints assigned. Please assign waypoints in the inspector.");
            return;
        }

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private void Update()
    {
        DetectWolf();
        Patrol();
        DealDamage();

    }

    private void Patrol()
    {
        if (navMeshAgent == null || waypoints.Count == 0) return;

        if (wolfTarget != null)
        {
            if (wolfTarget.activeInHierarchy)
            {
                navMeshAgent.SetDestination(wolfTarget.transform.position);
                return;
            }
            else
            {
                wolfTarget = null;
            }
        }

        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);

        if (distanceToWaypoint <= waypointReachedThreshold)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    private void DetectWolf()
    {
        wolfTarget = null;
        float maxAngle = 45f; // Half of the field of view angle
        int numberOfRays = 8; // The number of rays to cast within the field of view

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = -maxAngle + (i * (maxAngle * 2) / (numberOfRays - 1));
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirection, out hit, detectionRange, sightLayers))
            {
                Debug.DrawRay(transform.position, rayDirection * detectionRange, Color.green); // Visualization for debugging purposes

                if (hit.collider.CompareTag("Wolf"))
                {
                    wolfTarget = hit.collider.gameObject;
                    break;
                }
            }
        }
    }

    private void DealDamage()
    {
        if (wolfTarget != null && wolfTarget.activeInHierarchy)
        {
            float distanceToTarget = Vector3.Distance(transform.position, wolfTarget.transform.position);
            if (distanceToTarget <= attackRange)
            {
                PlayerHealth targetHealth = wolfTarget.GetComponent<PlayerHealth>();
                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(damagePerSecond * Time.deltaTime);
                }
            }
        }
    }
}
