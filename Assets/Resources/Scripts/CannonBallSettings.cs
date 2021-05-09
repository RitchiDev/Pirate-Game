using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cannon Ball", menuName = "Create New Cannon Ball")]
public class CannonBallSettings : ScriptableObject
{
    [SerializeField] private int m_Damage = 10;
    public int Damage => m_Damage;
}
