using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipAI : MonoBehaviour
{
    [SerializeField] private EnemySettings m_Settings;
    private NavMeshAgent m_Agent;
    private Transform m_TargetPosition;

    private void Awake()
    {
        m_TargetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        m_Agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdateTargetPosition());
    }


    private IEnumerator UpdateTargetPosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_Settings.TimeBetweenUpdate);
            m_Agent.SetDestination(m_TargetPosition.position);
            //Debug.Log(m_TargetPosition.position);
        }
    }
}
