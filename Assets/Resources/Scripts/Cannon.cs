using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    [SerializeField] private CannonSettings m_Settings;
    public CannonSettings Settings => m_Settings;

    [SerializeField] private PoolAbleObject m_CannonBall;
    public PoolAbleObject CannonBall => m_CannonBall;

    [SerializeField] private Transform m_FirePoint;
    public Transform FirePoint => m_FirePoint;

    public abstract void Use();
    public abstract void FillCannons();
    public abstract void AddCannonBalls(int amount);
    public abstract void ShootTimer();

    //public float CalculateNextShotTime()
    //{
    //    return 1f / m_Settings.FireRate;
    //}
}
