using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool m_SinksShips;
    public bool SinksShips => m_SinksShips;

    private void OnCollisionEnter(Collision collision)
    {
        if(m_SinksShips)
        {
            Vitality vitality = collision.gameObject.GetComponent<Vitality>();
            if(vitality)
            {
                vitality.ChangeVitality(-999999f, true);
            }
        }
    }
}
