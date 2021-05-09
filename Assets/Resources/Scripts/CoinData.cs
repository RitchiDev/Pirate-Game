using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Create New Coin")]
public class CoinData : ScriptableObject
{
    [SerializeField] private string m_Name = "";
    [SerializeField] private int m_Worth = 1;
    public int Worth => m_Worth;
    public string Name => m_Name;
}
