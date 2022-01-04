using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JongChan
{
    public class Stuff : MonoBehaviour
    {
        [SerializeField] protected TextMeshPro fKey;

        public virtual void UseStuff() { }

        public virtual void FKeyOn(bool isNear)
        {
            fKey.gameObject.SetActive(isNear);
        }
    }
}