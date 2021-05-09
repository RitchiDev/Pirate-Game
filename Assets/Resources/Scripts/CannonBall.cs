using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private CannonBallSettings m_Settings;
    private void OnCollisionEnter(Collision collision)
    {
        Vitality vitality = collision.gameObject.GetComponent<Vitality>();
        if(vitality)
        {
            vitality.ChangeVitality(-m_Settings.Damage);
        }
    }
}
