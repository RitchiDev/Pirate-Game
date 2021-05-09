using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCannon : Cannon
{
    private int m_CannonBalls;

    public override void AddCannonBalls(int amount)
    {

    }

    public override void FillCannons()
    {
        m_CannonBalls = Settings.MaxCannonBalls;
    }

    public override void ShootTimer()
    {

    }

    public override void Use()
    {

    }
}
