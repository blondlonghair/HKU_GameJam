using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

namespace JongChan
{
    public class ShopStuff : Stuff
    {
        [SerializeField, Header("액션")] private UnityEvent openShop;
        
        public override void Use()
        {
            openShop.Invoke();
        }
    }
}