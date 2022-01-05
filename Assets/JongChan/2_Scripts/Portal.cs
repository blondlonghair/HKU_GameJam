using System;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

namespace JongChan
{
    public class Portal : MonoBehaviour
    {
        public enum Direction
        {
            None,
            Room1,
            Room2,
            MainRoom1,
            MainRoom2
        }

        [SerializeField] private Direction _thisDirection;
        [SerializeField] private Direction _targetDirection;
        [SerializeField] private TextMeshPro _fKey;

        public Direction ThisDirection => _thisDirection;
        public Direction TargetDirection => _targetDirection;


        public void FKeyOn(bool isNear)
        {
            _fKey.gameObject.SetActive(isNear);
        }
        
        public void Use(Player player, Portal targetPortal)
        {
            player.PlayerMove(targetPortal.transform);
        }
    }
}