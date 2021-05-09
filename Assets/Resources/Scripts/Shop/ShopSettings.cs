using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Create New Shop Settings")]
public class ShopSettings : ScriptableObject
{
    [SerializeField] private int m_DefaultFillPrice;
    public int DefaultFillPrice => m_DefaultFillPrice;

    [SerializeField] private int m_AdditionalFillPrice;
    public int AdditionalFillPrice => m_AdditionalFillPrice;

    [SerializeField] private int m_CannonPrice;
    public int CannonPrice => m_CannonPrice;

    [SerializeField] private int m_RepairPrice;
    public int RepairPrice => m_RepairPrice;

    [SerializeField] private int m_ArmorPrice;
    public int ArmorPrice => m_ArmorPrice;
}
