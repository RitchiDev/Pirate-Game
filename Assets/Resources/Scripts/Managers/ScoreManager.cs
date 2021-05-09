using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text m_ScoreText;
    private int m_Score;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            Debug.LogError("An instance of " + ToString() + " already existed!");
        }
        else
        {
            Instance = this;
        }

        ChangeScore(0);
    }

    public void ChangeScore(int amount)
    {
        m_Score = Mathf.Clamp(m_Score = amount, 0, 999999);
        m_ScoreText.text = "Score: " + m_Score.ToString();
    }
}
