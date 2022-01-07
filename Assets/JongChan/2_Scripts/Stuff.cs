using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JongChan
{
    public class Stuff : MonoBehaviour
    {
        [Header("Stuff 구성요소")]
        [SerializeField] protected TextMeshPro fKey;
        [SerializeField] protected SpriteRenderer renderer;
        [SerializeField] protected Light light;

        [Header("스프라이트")]
        [SerializeField] protected Sprite breakSprite;
        [SerializeField] protected Sprite fixedSprite;
        
        private bool _isBroken;
        public bool IsBroken
        {
            get { return _isBroken;}
            set { _isBroken = value; }
        }

        public virtual void Use() { }

        public virtual void Fix()
        {
            _isBroken = false;
            renderer.sprite = fixedSprite;
            GameManager.Instance.FixAction -= ShipDamage;
            light.color = Color.green;
        }

        public virtual void Break()
        {
            _isBroken = true;
            renderer.sprite = breakSprite;
            GameManager.Instance.FixAction += ShipDamage;
            light.color = Color.red;
        }

        public virtual void FKeyOn(bool isNear)
        {
            fKey.gameObject.SetActive(isNear);
        }
        
        protected virtual void ShipDamage(float damage)
        {
            GameManager.Instance.ShipCurHp -= Time.deltaTime * 2;
        }
    }
}