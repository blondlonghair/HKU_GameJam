using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemFactory
{
    public static ShopItem GetItem(int index, int value)
    {
        switch(index)
        {
            case 1: return new ConstructionMaterials(value);
            case 2: return new RepairHammer(value);
            //case 3: return new RepairHammer(value);
            default: return new ConstructionMaterials(value);
        }
    }

    public static int GetSalePrice(int price, int value)
    {
        int sum = price * value;
        for (int i = 0; i < value; i++)
            sum -= i + 1;
        return sum;
    }
}
