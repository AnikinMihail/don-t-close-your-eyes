using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private Rigidbody _rigidbody;
    private NavMeshAgent _agent;
    
    
    private bool _isInView = false;

    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        PlayerController.Instance.OnMonsterInView += InstanceOnOnMonsterInView;
        PlayerController.Instance.OnMonsterLeft += InstanceOnOnMonsterLeft;
    }

    private void InstanceOnOnMonsterLeft(object sender, EventArgs e)
    {
        _isInView = false;
    }

    private void InstanceOnOnMonsterInView(object sender, EventArgs e)
    {
        _isInView = true;
    }

    void Update()
    {
        if (_isInView)
        {

            Debug.Log("IsInView");
            _agent.isStopped = true;
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            if (player != null)
            {
                _agent.isStopped = false;
                _agent.SetDestination(player.position);
            }
        }

    }
}
