using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestSettings m_Settings;

    private void OnTriggerEnter(Collider other)
    {
        ShipController ship = other.GetComponent<ShipController>();
        Wallet wallet = other.GetComponent<Wallet>();

        if (ship)
        {
            if(!wallet)
            {
                Debug.LogError("This ship doesn't have a wallet!");
            }

            switch (m_Settings.Treasure)
            {
                case TreasureType.notSet:
                    int rng = Random.Range(0, 4);
                    switch (rng)
                    {
                        case 0:

                            ship.AddCannonBalls(m_Settings.CannonBallsToAdd);

                            break;
                        case 1:

                            ship.FillCannons();

                            break;
                        case 2:

                            wallet.AddCoins(m_Settings.CopperWorth);

                            break;
                        case 3:

                            wallet.AddCoins(m_Settings.SilverWorth);

                            break;
                        case 4:

                            wallet.AddCoins(m_Settings.GoldWorth);

                            break;
                        default:
                            break;
                    }
                    break;
                case TreasureType.cannonBalls:

                    ship.AddCannonBalls(m_Settings.CannonBallsToAdd);

                    break;
                case TreasureType.fillCannons:

                    ship.FillCannons();

                    break;
                case TreasureType.copperCoin:

                    wallet.AddCoins(m_Settings.CopperWorth);

                    break;
                case TreasureType.silverCoin:

                    wallet.AddCoins(m_Settings.SilverWorth);

                    break;
                case TreasureType.goldCoin:

                    wallet.AddCoins(m_Settings.GoldWorth);

                    break;
                default:
                    break;
            }
        }

        gameObject.SetActive(false);
    }
}
