using System;
using UnityEngine;

namespace JongChan
{
    public class FixStuff : Stuff
    {
        private bool _isBroken;
        private bool IsBroken
        {
            get { return _isBroken;}
            set { _isBroken = value; }
        }

        private void OnEnable()
        {
            GameManager.Instance.FixAction += ShipDamage;
        }

        private void OnDisable()
        {
            GameManager.Instance.FixAction -= ShipDamage;
        }

        private void ShipDamage(float damage)
        {
            GameManager.Instance.ShipHp -= Time.deltaTime * 10;
        }

        public override void UseStuff()
        {
            gameObject.SetActive(false);
        }
    }
}