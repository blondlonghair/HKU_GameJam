using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float maxBar = 300f;
    private float bar;
    public float Bar 
    { 
        get { return bar; } 
        set 
        { 
            if (value > maxBar) bar = maxBar;
            else bar = value; 
        } 
    }

    private int gold;
    public int Gold { get { return gold; } set { gold = value; } }

    void Start()
    {
        bar = maxBar;
    }

    void Update()
    {
        bar += Time.deltaTime;
    }
}
