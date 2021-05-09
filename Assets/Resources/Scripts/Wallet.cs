using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int m_Coins;
    public int Coins => m_Coins;
    
    public void AddCoins(int amount, string coinName = "")
    {
        Debug.Log("Added Coins");

        m_Coins = Mathf.Clamp(m_Coins + amount, 0, 999999);
    }

    public void RemoveCoins(int amount, string purchaseName = "")
    {
        Debug.Log("Purchased: " + purchaseName);

        m_Coins = Mathf.Clamp(m_Coins - amount, 0, 999999);
    }
}
