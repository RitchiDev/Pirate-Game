using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShipController ship = other.GetComponent<ShipController>();
        if (ship)
        {
            Wallet wallet = other.GetComponent<Wallet>();
            Vitality vitality = other.GetComponent<Vitality>();

            ShopManager.Instance.SetData(ship, wallet, vitality);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ShipController ship = other.GetComponent<ShipController>();
        if (ship)
        {
            ShopManager.Instance.SetData(null, null, null);
        }
    }
}
