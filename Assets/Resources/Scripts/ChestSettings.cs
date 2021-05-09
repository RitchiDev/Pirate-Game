using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public enum TreasureType
{
    notSet = 0,
    cannonBalls,
    fillCannons,
    copperCoin,
    silverCoin,
    goldCoin,
}

[CreateAssetMenu(fileName = "New Treasure Chest", menuName = "Create New Treasure Chest")]
public class ChestSettings : ScriptableObject
{
    [SerializeField] private TreasureType m_Treasure;
    public TreasureType Treasure => m_Treasure;

    [SerializeField] private int m_CannonBallsToAdd = 10;
    public int CannonBallsToAdd => m_CannonBallsToAdd;

    [SerializeField] private int m_CopperWorth = 1;
    public int CopperWorth => m_CopperWorth;

    [SerializeField] private int m_SilverWorth = 5;
    public int SilverWorth => m_SilverWorth;

    [SerializeField] private int m_GoldWorth = 10;
    public int GoldWorth => m_GoldWorth;
}
