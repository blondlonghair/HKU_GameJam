using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemFactory
{
    static int maxIndex = 6;
    static int minValue = 1;
    static int maxValue = 5;

    public static ShopItem GetItem(int index, int value)
    {
        switch(index)
        {
            case 1: return new ConstructionMaterials(value);
            case 2: return new RepairHammer(value);
            case 3: return new IncreaseDamage(value);
            case 4: return new IncreaseCurHp(value);
            case 5: return new IncreaseMaxHp(value);
            case 6: return new IncreaseSpeed(value);
            default: return new ConstructionMaterials(value);
        }
    }

    public static ShopItem GetRandomItem()
    {
        int index = Random.Range(1, maxIndex + 1);
        int value = Random.Range(minValue, maxValue + 1);
        return GetItem(index, value);
    }

    public static int GetSalePrice(int price, int value)
    {
        int sum = price * value;
        for (int i = 0; i < value; i++)
            sum -= i + 1;
        return sum;
    }
}
