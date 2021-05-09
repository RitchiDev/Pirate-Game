using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipAI : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private Vector3 m_TargetPosition;

    private void Awake()
    {
        m_TargetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.SetDestination(m_TargetPosition);
    }
}
