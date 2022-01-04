using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace JongChan
{
    public class Portal : Stuff
    {
        public enum Direction
        {
            None,
            Room1,
            Room2,
            MainRoom
        }

        [SerializeField] private Direction _thisDirection;

        public Direction ThisDirection
        {
            get => _thisDirection;
            set => _thisDirection = value;
        }
        
        [SerializeField] private Direction _targetDirection;

        public Direction TargetDirection
        {
            get => _targetDirection;
            set => _targetDirection = value;
        }

        public void Use(Player player, Portal targetPortal)
        {
            player.PlayerMove(targetPortal.transform);
        }
    }
}