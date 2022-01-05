using System;
using UnityEngine;

namespace JongChan
{
    public class HpStationStuff : Stuff
    {
        private Player _player;
        
        private void Start()
        {
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out _player);
        }

        public override void Use()
        {
            _player.CurHp = _player.MaxHp;
        }
    }
}