using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cannon", menuName = "Create New Cannon")]
public class CannonSettings : ScriptableObject
{
    [SerializeField] private int m_MaxCannonBalls = 100;
    public int MaxCannonBalls => m_MaxCannonBalls;

    [SerializeField] private float m_FireRate = 6.75f;
    public float FireRate => m_FireRate;

    [SerializeField] private float m_ShootPower = 20f;
    public float ShootPower => m_ShootPower;

}

