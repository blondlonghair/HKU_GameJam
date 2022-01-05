using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private ShipStats shipStats = new ShipStats();

    void Awake()
    {
        Set();
    }

    void Set()
    {
        shipStats.MaxHp = 300f;
        shipStats.Hp = shipStats.MaxHp;
        shipStats.Gold = 100;
        shipStats.NatureRecovery = 0.2f;
    }

    void Update()
    {
        FixShipStats();
    }

    void FixShipStats()
    {
        shipStats.Hp += Time.deltaTime * shipStats.NatureRecovery; //자연 회복
    }

    public ShipStats GetShipStats()
    {
        return shipStats;
    }
}

public class ShipStats
{
    private float maxHp;
    public float MaxHp { get { return maxHp; } set { maxHp = value; } }

    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (value > maxHp) hp = maxHp;
            else hp = value;
        }
    }

    private int gold;
    public int Gold { get { return gold; } set { gold = value; } }

    private float natureRecovery;
    public float NatureRecovery { get { return natureRecovery; } set { natureRecovery = value; } }
}