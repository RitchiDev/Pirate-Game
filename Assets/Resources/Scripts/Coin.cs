using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinData m_CoinData;

    private void OnCollisionEnter(Collision collision)
    {
        Wallet wallet = collision.gameObject.GetComponent<Wallet>();
        if(wallet)
        {
            wallet.AddCoins(m_CoinData.Worth, m_CoinData.Name);
        }
    }
}
