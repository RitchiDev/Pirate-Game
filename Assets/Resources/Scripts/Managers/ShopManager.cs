using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }

    [SerializeField] private ShopSettings m_Settings;
    [SerializeField] private Canvas m_ShopUI;
    [SerializeField] private Button m_BuyCannonButton;
    [SerializeField] private TMP_Text m_WalletCoinsText;
    [SerializeField] private TMP_Text m_BuyCannonPriceText;
    [SerializeField] private TMP_Text m_FillCannonsPriceText;
    [SerializeField] private TMP_Text m_RepairShipPriceText;
    [SerializeField] private TMP_Text m_ArmorPriceText;
    private Wallet m_CurrentWallet;
    private ShipController m_CurrentShip;
    private Vitality m_CurrentVitality;
    private int m_CurrentFillPrice;

    private void Awake()
    {
        if(Instance)
        {
            Destroy(this);
            Debug.LogError("An instance of " + ToString() + " already existed!");
        }
        else
        {
            Instance = this;
        }

        m_ShopUI.gameObject.SetActive(false);
        UpdateShop();
    }

    public void SetData(ShipController ship, Wallet wallet, Vitality vitality)
    {
        m_CurrentShip = ship;
        m_CurrentWallet = wallet;
        m_CurrentVitality = vitality;

        UpdateShop();

        if(ship)
        {
            m_ShopUI.gameObject.SetActive(true);
        }
        else
        {
            m_ShopUI.gameObject.SetActive(false);
        }
    }

    public void FillCannons()
    {
        if (m_CurrentWallet.Coins < m_CurrentFillPrice)
        {
            return;
        }

        m_CurrentShip.FillCannons();
        m_CurrentWallet.RemoveCoins(m_CurrentFillPrice);
        UpdateShop();
    }

    public void BuyCannon()
    {
        if (m_CurrentWallet.Coins < m_Settings.CannonPrice)
        {
            return;
        }

        m_CurrentShip.ActivateCannon();
        m_CurrentWallet.RemoveCoins(m_Settings.CannonPrice);
        UpdateShop();
    }

    public void RepairShip()
    {
        if (m_CurrentWallet.Coins < m_Settings.RepairPrice)
        {
            return;
        }

        m_CurrentVitality.ChangeVitality(100);
        m_CurrentWallet.RemoveCoins(m_Settings.RepairPrice);
        UpdateShop();
    }

    public void BuyArmor()
    {
        if (m_CurrentWallet.Coins < m_Settings.ArmorPrice)
        {
            return;
        }

        m_CurrentVitality.AddArmor();
        m_CurrentWallet.RemoveCoins(m_Settings.ArmorPrice);
        UpdateShop();
    }

    private void UpdateShop()
    {
        int additionalFillPrice = 0;
        if (m_CurrentShip)
        {
            additionalFillPrice = m_Settings.AdditionalFillPrice * m_CurrentShip.ActiveCannons;

            if(m_CurrentShip.ActiveCannons > 4)
            {
                m_BuyCannonButton.gameObject.SetActive(false);
                m_BuyCannonPriceText.gameObject.SetActive(false);
            }
        }

        m_CurrentFillPrice = m_Settings.DefaultFillPrice + additionalFillPrice;
        m_FillCannonsPriceText.text = "$" + m_CurrentFillPrice.ToString();

        m_RepairShipPriceText.text = "$" + m_Settings.RepairPrice.ToString();

        m_BuyCannonPriceText.text = "$" + m_Settings.CannonPrice.ToString();

        if(m_CurrentWallet)
        {
            m_WalletCoinsText.text = "Coins: $" + m_CurrentWallet.Coins.ToString();
        }
    }
}
