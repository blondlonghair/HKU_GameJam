using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItem
{
    public string contentText;
    public string NameText;
    public Sprite sprite;
    public int value;
    public int price;

    public void UseAbility()
    {
        Ability();
    }

    protected abstract void Ability();
}

public class ConstructionMaterials : ShopItem
{
    int plusMaxHp;

    public ConstructionMaterials(int value)
    {
        this.value = value;
        price = ShopItemFactory.GetSalePrice(13, value);
        plusMaxHp = value * 10;

        contentText = "Increase the ship's physical strength by " + plusMaxHp.ToString() + " points.";
        NameText = "Construction Materials " + Utils.GetRomanNumber(value);
        sprite = Resources.Load<Sprite>("Sprites/ShipHp");
    }

    protected override void Ability()
    {
        JongChan.GameManager.Instance.ShipCurHp += plusMaxHp; //value * 10만큼 함선의 MaxCurHp 증가
        JongChan.GameManager.Instance.ShipMaxHp += plusMaxHp;
    }
}

public class RepairHammer : ShopItem
{
    int plusHp;

    public RepairHammer(int value)
    {
        this.value = value;
        price = ShopItemFactory.GetSalePrice(15, value);
        plusHp = value * 25;

        contentText = "It restores the ship's physical strength by " + plusHp.ToString() + " points.";
        NameText = "Repair Hammer " + Utils.GetRomanNumber(value);
        sprite = Resources.Load<Sprite>("Sprites/ShipHp");
    }

    protected override void Ability()
    {
        if (JongChan.GameManager.Instance.ShipCurHp + plusHp > JongChan.GameManager.Instance.ShipMaxHp)
        {
            JongChan.GameManager.Instance.ShipCurHp = JongChan.GameManager.Instance.ShipMaxHp;
        }

        else
        {
            JongChan.GameManager.Instance.ShipCurHp += plusHp;
        }
    }
}


public class IncreaseDamage : ShopItem
{
    int plusDamage;

    public IncreaseDamage(int value)
    {
        this.value = value;
        price = ShopItemFactory.GetSalePrice(15, value);
        plusDamage = value * 5;

        contentText = "Increases the player's attack power by " + plusDamage.ToString() + " points.";
        NameText = "Increase Damage " + Utils.GetRomanNumber(value);
        sprite = Resources.Load<Sprite>("Sprites/IncreaseDamage");
    }

    protected override void Ability()
    {
        GameObject.Find("Player").GetComponent<JongChan.Player>().Damage += plusDamage;
    }
}

public class IncreaseCurHp : ShopItem
{
    int plusCurHp;

    public IncreaseCurHp(int value)
    {
        this.value = value;
        price = ShopItemFactory.GetSalePrice(15, value);
        plusCurHp = value * 30;

        contentText = "Increases the player's Hp by " + plusCurHp.ToString() + " points.";
        NameText = "Heal " + Utils.GetRomanNumber(value);
        sprite = Resources.Load<Sprite>("Sprites/PlayerHp");
    }

    protected override void Ability()
    {
        GameObject.Find("Player").GetComponent<JongChan.Player>().CurHp += plusCurHp;
    }
}

public class IncreaseMaxHp : ShopItem
{
    int plusMaxHp;

    public IncreaseMaxHp(int value)
    {
        this.value = value;
        price = ShopItemFactory.GetSalePrice(15, value);
        plusMaxHp = value * 10;

        contentText = "Increases the player's Hp by " + plusMaxHp.ToString() + " points.";
        NameText = "Increase MaxHp " + Utils.GetRomanNumber(value);
        sprite = Resources.Load<Sprite>("Sprites/PlayerHp");
    }

    protected override void Ability()
    {
        GameObject.Find("Player").GetComponent<JongChan.Player>().MaxHp += plusMaxHp;
    }
}

public class IncreaseSpeed : ShopItem
{
    float plusSpeed;

    public IncreaseSpeed(int value)
    {
        this.value = value;
        price = ShopItemFactory.GetSalePrice(15, value);
        plusSpeed = value * 0.5f;

        contentText = "Increases the player's Hp by " + plusSpeed.ToString() + " points.";
        NameText = "Increase Speed " + Utils.GetRomanNumber(value);
        sprite = Resources.Load<Sprite>("Sprites/IncreaseSpeed");
    }

    protected override void Ability()
    {
        GameObject.Find("Player").GetComponent<JongChan.Player>().UpgradeSpeed(plusSpeed);
    }
}