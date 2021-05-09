using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.InputSystem;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    [SerializeField] private float m_MaxSpeed = 15;
    [SerializeField] private float m_Acceleration = 5;
    [SerializeField] private float m_TurnSpeed = 25;
    [SerializeField] private float m_BrakeMultiplier = 1.5f;
    [SerializeField] private bool m_IsBackwards;

    private Vector3 m_SailDirection;
    private bool m_ShootInput;
    private float m_SailInput;
    private float m_TurnInput;
    private float m_Speed;

    [SerializeField] private List<Cannon> m_Cannons;
    private int m_ActiveCannons;
    public int ActiveCannons => m_ActiveCannons;

    private void Awake()
    {
        Setup();
    }

    private void Update()
    {
        CheckForCannonUse();

        Accelerate();
    }

    private void FixedUpdate()
    {
        Sail();
        Turn();
    }

    private void Setup()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_ActiveCannons = 0;
        ActivateCannon();
    }

    public void FillCannons()
    {
        Debug.Log("Refilled Cannon Balls");

        foreach (Cannon cannon in m_Cannons)
        {
            if (cannon.gameObject.activeInHierarchy)
            {
                cannon.FillCannons();
            }
        }
    }

    public void AddCannonBalls(int amount)
    {
        Debug.Log("Added Cannon Balls");

        foreach (Cannon cannon in m_Cannons)
        {
            if (cannon.gameObject.activeInHierarchy)
            {
                cannon.AddCannonBalls(amount);
            }
        }
    }

    private void CheckForCannonUse()
    {
        if(m_Cannons == null || m_Cannons.Count <= 0)
        {
            Debug.LogError("There are no cannons available!");
            return;
        }

        if(m_ShootInput)
        {
            foreach (Cannon cannon in m_Cannons)
            {
                if(cannon.gameObject.activeInHierarchy)
                {
                    cannon.Use();
                }
            }
        }
    }

    private void Accelerate()
    {
        if(m_SailInput > 0)
        {
            if(m_Speed < m_MaxSpeed)
            {
                m_Speed = Mathf.Clamp(m_Speed + m_Acceleration * Time.deltaTime, 0, m_MaxSpeed);
            }
        }
        else if (m_SailInput == 0)
        {
            if(m_Speed > 0 || m_Speed < 0)
            {
                m_Speed = Mathf.Clamp(m_Speed - (m_Acceleration * m_BrakeMultiplier) * Time.deltaTime, 0, m_MaxSpeed);
            }
        }
        else if(m_SailInput < 0)
        {
            m_Speed = Mathf.Clamp(m_Speed - (m_Acceleration * m_BrakeMultiplier) * Time.deltaTime, -5f, m_MaxSpeed);
        }
    }

    private void Sail()
    {
        if(m_Speed != 0)
        {
            m_SailDirection = m_Rigidbody.transform.forward * m_Speed * Time.fixedDeltaTime;
            m_Rigidbody.MovePosition(m_Rigidbody.position + m_SailDirection);
        }
    }

    private void Turn()
    {
        if(m_TurnInput != 0)
        {
            float direction = m_TurnInput * m_TurnSpeed * Time.fixedDeltaTime;

            Quaternion newTurnDirection = Quaternion.Euler(0f, direction, 0f);

            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * newTurnDirection);
        }
    }

    public void ActivateCannon()
    {
        if(m_ActiveCannons < m_Cannons.Count)
        {
            m_Cannons[m_ActiveCannons].gameObject.SetActive(true);
            m_ActiveCannons++;
        }
    }

    public void SailInputContext(InputAction.CallbackContext context)
    {
        m_SailInput = context.ReadValue<float>();
    }

    public void TurnInputContext(InputAction.CallbackContext context)
    {
        m_TurnInput = context.ReadValue<float>();
    }

    public void ShootContext(InputAction.CallbackContext context)
    {
        m_ShootInput = context.performed;

        //if (context.canceled)
        //{
        //    m_ShootInput = false;
        //}
    }
}
