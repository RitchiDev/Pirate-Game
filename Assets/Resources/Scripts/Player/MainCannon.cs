using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCannon : Cannon
{
    private int m_CannonBalls;
    private float m_NextShotTime;

    [SerializeField] private Camera m_Camera;
    [SerializeField] private float m_MinRotation;
    [SerializeField] private float m_MaxRotation;
    private Vector3 m_MousePosition;
    private Vector3 m_AimDirection;

    private void OnEnable()
    {
        m_CannonBalls = Settings.MaxCannonBalls;
    }

    private void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        Aim();
        ShootTimer();
    }

    private void Aim()
    {
        float cameraDistance = Vector3.Dot(transform.position - m_Camera.transform.position, m_Camera.transform.forward);

        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = cameraDistance;
        m_MousePosition = m_Camera.ScreenToWorldPoint(mousePos);

        m_AimDirection = (transform.position - m_MousePosition);
        //m_AimDirection = (transform.position - m_MousePosition).normalized;

        if (m_AimDirection.magnitude > 0f)
        {
            //m_AimDirection.Normalize();
            Quaternion aimRotation = Quaternion.LookRotation(m_AimDirection);
            aimRotation.x = 0;
            aimRotation.z = 0;
            transform.rotation = aimRotation;
            transform.eulerAngles = new Vector3(0, Mathf.Clamp(transform.eulerAngles.y, m_MinRotation, m_MaxRotation), 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, aimRotation, 7f * Time.deltaTime);
        }
    }

    public override void AddCannonBalls(int amount)
    {
        m_CannonBalls = Mathf.Clamp(m_CannonBalls + amount, 0, Settings.MaxCannonBalls);
    }

    public override void Use()
    {
        if (m_CannonBalls <= 0 || m_NextShotTime > 0) //
        {
            return;
        }

        //Debug.Log("Shot");
        GameObject cannonball = PoolManager.Instance.GetObjectFromPool(CannonBall);
        cannonball.transform.position = FirePoint.position;
        cannonball.GetComponent<Rigidbody>().AddForce(FirePoint.forward * Settings.ShootPower, ForceMode.Impulse);

        //Debug.Log(CalculateNextShotTime());
        m_NextShotTime = CalculateNextShotTime();
        m_CannonBalls = Mathf.Clamp(m_CannonBalls - 1, 0, Settings.MaxCannonBalls);
    }

    public override void ShootTimer()
    {
        if (m_NextShotTime <= 0)
        {
            return;
        }

        m_NextShotTime = Mathf.Clamp(m_NextShotTime - Time.deltaTime, 0, 999999f);
    }

    private float CalculateNextShotTime()
    {
        return 1f / Settings.FireRate;
    }

    public override void FillCannons()
    {
        m_CannonBalls = Settings.MaxCannonBalls;
    }
}
