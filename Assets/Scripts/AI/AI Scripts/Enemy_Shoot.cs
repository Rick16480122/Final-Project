using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shoot : MonoBehaviour
{
    public enum State
    {
        None = 0,
        Patrol = 2,
        Shooting = 3,
    }

    [Header("Sheep Setup")]
    public float move_speed = 2f;
    public float run_speed = 4f;
    public float rotate_speed = 120f;
    public float fall_speed = 5f;
    public SheepTriggerVision sheepTriggerVision;

    [Header("Sheep state")]
    public State state = State.Patrol;

    [Header("Sheep Patrol")]
    public List<Transform> patrolPoints = new List<Transform>();
    public float distanceToPatrolPoint = 0.5f;

    [Header("Sheep Shoot")]
    public float initialWaitTime;
    public float timeBetweenShots;
    public GameObject bullet;
    public Transform bulletSpawnPosition;
    public float shootingForce;


    private int patrolIndex = 0;
    private Vector3 _startingPosition;
    private NavMeshAgent _agent;
    private Coroutine shootAtPlayerRoutine, startShootAtPlayerRoutine;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _startingPosition = transform.position;
        SwitchState(State.Patrol);
    }

    private void Update()
    {
        UpdateState();
    }

    void GoToNextPatrolPoint()
    {
        patrolIndex++;
        if (patrolIndex >= patrolPoints.Count)
            patrolIndex = 0;

        _agent.SetDestination(patrolPoints[patrolIndex].position);
    }

    void SwitchState(State stateToChange)
    {
        switch (stateToChange)
        {
            case State.None:
                Debug.Log("Is in state None");
                break;
            case State.Patrol:
                state = stateToChange;
                StartPatrol();
                break;
            case State.Shooting:
                state = State.Shooting;
                StartShooting();
                break;
        }
    }

    void UpdateState()
    {
        switch (state)
        {
            case State.None:
                Debug.Log("Is in state None");
                break;
            case State.Patrol:
                UpdatePatrol();
                break;
            case State.Shooting:
                UpdateShooting();
                break;
        }
    }

    void StartPatrol()
    {
        _agent.isStopped = false;
        GoToNextPatrolPoint();
    }

    void StartShooting()
    {
        _agent.isStopped = true;
        startShootAtPlayerRoutine = StartCoroutine(StartShootAtPlayer());
    }

    void UpdatePatrol()
    {
        if (Vector3.Distance(transform.position, patrolPoints[patrolIndex].position) < distanceToPatrolPoint)
        {
            GoToNextPatrolPoint();
        }

        if (sheepTriggerVision.player)
        {
            SwitchState(State.Shooting);
        }
    }

    void UpdateShooting()
    {
        if (!sheepTriggerVision.player)
        {
            SwitchState(State.Patrol);
            if (startShootAtPlayerRoutine != null)
                StopCoroutine(startShootAtPlayerRoutine);
            if (shootAtPlayerRoutine != null)
                StopCoroutine(shootAtPlayerRoutine);
        }
        else
        {
            transform.LookAt(sheepTriggerVision.player.transform);
        }
    }

    IEnumerator StartShootAtPlayer()
    {
        yield return new WaitForSeconds(initialWaitTime);
        shootAtPlayerRoutine = StartCoroutine(ShootAtPlayer());
    }

    IEnumerator ShootAtPlayer()
    {
        ShootBullet();
        yield return new WaitForSeconds(timeBetweenShots);
        if (state == State.Shooting)
        {
            StartCoroutine(ShootAtPlayer());
        }
    }

    void ShootBullet()
    {
        GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        spawnedBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPosition.forward * shootingForce, ForceMode.Impulse);
    }
}
