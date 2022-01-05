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

//public class FireProtection : ShopItem
//{
//    int chance;

//    public FireProtection(int value)
//    {
//        this.value = value;
//        price = ShopItemFactory.GetSalePrice(10, value);
//        chance = value * 10;

//        contentText = "Reduces fire chance by " + chance.ToString() + "%";
//        NameText = "Fire Protection " + Utils.GetRomanNumber(value);
//        //sprite = sprite;
//    }

//    protected override void Ability()
//    {
//        //value 만큼 화재 발생률 낮추기
//    }
//}

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
        //sprite = sprite;
    }

    protected override void Ability()
    {
        GameManager.Instance.GetShipStats().MaxHp += plusMaxHp; //value * 10만큼 함선의 MaxHp 증가
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
        //sprite = sprite;
    }

    protected override void Ability()
    {
        GameManager.Instance.GetShipStats().Hp += plusHp;
    }
}