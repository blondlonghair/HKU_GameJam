using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static string GetRomanNumber(int number)
    {
        string rom = "";
        int sum = number;
        while (sum > 0)
        {
            if (sum >= 1000) { rom += "M"; sum -= 1000; }
            else if (sum >= 900) { rom += "CM"; sum -= 900; }
            else if (sum >= 500) { rom += "D"; sum -= 500; }
            else if (sum >= 400) { rom += "CD"; sum -= 400; }
            else if (sum >= 100) { rom += "C"; sum -= 100; }
            else if (sum >= 90) { rom += "XC"; sum -= 90; }
            else if (sum >= 50) { rom += "L"; sum -= 50; }
            else if (sum >= 40) { rom += "XL"; sum -= 40; }
            else if (sum >= 10) { rom += "X"; sum -= 10; }
            else if (sum >= 9) { rom += "IX"; sum -= 9; }
            else if (sum >= 5) { rom += "V"; sum -= 5; }
            else if (sum >= 4) { rom += "IV"; sum -= 4; }
            else { rom += "I"; sum -= 1; }
        }
        return rom;
    }
}
