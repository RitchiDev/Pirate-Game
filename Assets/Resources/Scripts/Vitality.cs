using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Vitality : MonoBehaviour
{
    private Camera m_Camera;

    [SerializeField] private float m_MaxHealth;
    [SerializeField] private GameObject m_HealthContainer;
    [SerializeField] private Image m_HealthBar;
    private float m_Health;

    [SerializeField] private float m_MaxArmor;
    [SerializeField] private GameObject m_ArmorContainer;
    [SerializeField] private Image m_ArmorBar;
    private float m_Armor;

    [SerializeField] private float m_TimeInvincible;
    private bool m_IsInvincible;

    [SerializeField] private bool m_CannotDie;
    [SerializeField] private UnityEvent m_OnDeath;
    private bool m_IsDead;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    private void OnEnable()
    {
        m_IsDead = false;
        m_Health = m_MaxHealth;
        UpdateBars();
    }

    private void LateUpdate()
    {
        RotateBars();
    }

    private void RotateBars()
    {
        if (m_HealthContainer)
        {
            m_HealthContainer.transform.LookAt(m_Camera.transform);
        }

        if (m_ArmorContainer)
        {
            m_ArmorContainer.transform.LookAt(m_Camera.transform);
        }
    }

    public void SetVitality(float amount)
    {
        m_MaxHealth = Mathf.Clamp(amount, 0, 999999);
        m_Health = m_MaxHealth;
        UpdateBars();
    }

    public void AddArmor()
    {
        m_Armor = 50f;
        UpdateBars();
    }

    public void ChangeVitality(float amount, bool forcedDamage = false)
    {
        if (m_Health <= 0)
        {
            return;
        }

        float remainingDamage = amount;
        if (amount < 0)
        {
            if (m_IsInvincible && !forcedDamage)
            {
                return;
            }

            float damage = remainingDamage;
            ActivateFloatingText(damage.ToString());

            if (m_Armor > 0)
            {
                if (amount > m_Armor)
                {
                    remainingDamage = m_Armor + damage;
                }

                m_Armor = Mathf.Clamp(m_Armor + amount, 0, m_MaxArmor);
            }

            StartCoroutine(HitIndicator());
            StartCoroutine(GiveInvincibility(m_TimeInvincible));
        }

        m_Health = Mathf.Clamp(m_Health + remainingDamage, 0, m_MaxHealth);

        UpdateBars();

        if (m_CannotDie || m_Health > 0 || m_IsDead)
        {
            return;
        }

        m_IsDead = true;
        m_OnDeath.Invoke();
        Destroy(gameObject);
    }

    private void UpdateBars()
    {
        m_HealthBar.fillAmount = m_Health / m_MaxHealth;

        if(!m_ArmorBar)
        {
            return;
        }

        if(m_Armor > 0)
        {
            m_ArmorBar.fillAmount = m_Armor / m_MaxArmor;
        }
        else
        {
            if(m_ArmorContainer.activeInHierarchy)
            {
                m_ArmorContainer.SetActive(false);
            }
        }
    }

    private void ActivateFloatingText(string text)
    {

    }

    private IEnumerator HitIndicator()
    {
        yield return null;
    }

    private IEnumerator GiveInvincibility(float time)
    {
        m_IsInvincible = true;

        yield return new WaitForSeconds(time);

        m_IsInvincible = false;
    }
}
