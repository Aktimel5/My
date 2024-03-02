﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float viewAngle;
    public float damage = 30;
    public PlayerController player;
    public List<Transform> patrolPoints;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttacUpdate();
        PatrolUpdate();
    }

    private void AttacUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }

    void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
            if(hit.collider.gameObject == player.gameObject)
            {
                _isPlayerNoticed = true;
            }
        }

        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
         if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
         {
            PickNewPatrolPoint();
         }
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)]. position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
