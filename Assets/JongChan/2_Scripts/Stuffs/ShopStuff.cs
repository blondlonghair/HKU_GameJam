using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

namespace JongChan
{
    public class ShopStuff : Stuff
    {
        private bool _isOpen;
        
        public override void Use()
        {
            
            if (!_isOpen)
            {
                ShopManager.Instance.RandomSetSelection();
                ShopManager.Instance.LoadShop();
                _isOpen = true;
            }

            else
            {
                ShopManager.Instance.ExitShop();
                _isOpen = false;
            }
        }
    }
}