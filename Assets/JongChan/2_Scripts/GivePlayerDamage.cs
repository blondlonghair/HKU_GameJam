using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayerDamage : MonoBehaviour
{
    private float damage = 20;
    
    public void GiveDamage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<JongChan.Player>().CurHp -= damage;
    }
}
