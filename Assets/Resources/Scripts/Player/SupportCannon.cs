using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCannon : Cannon
{
    private float m_NextShotTime;
    private Transform m_Target;
    private int m_CannonBalls;
    [SerializeField] private float m_MinRotation;
    [SerializeField] private float m_MaxRotation;

    private void Update()
    {
        if(!m_Target)
        {
            return;
        }

        Aim();
    }

    private void Aim()
    {
        Vector3 aimDirection = transform.position - m_Target.position;
        Quaternion aimRotation = Quaternion.LookRotation(aimDirection);
        aimRotation.x = 0;
        aimRotation.z = 0;
        transform.rotation = aimRotation;
        transform.eulerAngles = new Vector3(0, Mathf.Clamp(transform.eulerAngles.y, m_MinRotation, m_MaxRotation), 0);
    }

    public override void AddCannonBalls(int amount)
    {
        m_CannonBalls = Mathf.Clamp(m_CannonBalls + amount, 0, Settings.MaxCannonBalls);
    }

    public override void FillCannons()
    {
        m_CannonBalls = Settings.MaxCannonBalls;
    }

    public override void ShootTimer()
    {
        if (m_NextShotTime <= 0)
        {
            return;
        }

        m_NextShotTime = Mathf.Clamp(m_NextShotTime - Time.deltaTime, 0, 999999f);
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

    private float CalculateNextShotTime()
    {
        return 1f / Settings.FireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        ShipAI enemy = other.GetComponent<ShipAI>();
        if(enemy)
        {
            Debug.Log("Support cannon aquired target!");
            m_Target = enemy.GetComponent<Transform>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ShipAI enemy = other.GetComponent<ShipAI>();
        if(enemy)
        {
            if(enemy.transform == m_Target)
            {
                Debug.Log("Support cannon lost target!");
                m_Target = null;
            }
        }
    }
}
