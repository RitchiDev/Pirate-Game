using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Settings", menuName = "Create New Enemy Settings")]
public class EnemySettings : ScriptableObject
{
    [SerializeField] private float m_TimeBetweenUpdate = 10f;
    public float TimeBetweenUpdate => m_TimeBetweenUpdate;
}
