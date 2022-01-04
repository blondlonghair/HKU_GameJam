using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JongChan
{
    public class GameManager : SingletonMonoCreateDestroy<GameManager>
    {
        public List<FixStuff> FixStuffs = new List<FixStuff>();
        public List<Portal> Portals = new List<Portal>();

        public event Action<float> FixAction;

        [SerializeField] private float _shipHp = 500;
        [SerializeField] private float _shipDamage = 1;
        
        public float ShipHp
        {
            set => _shipHp = value;
            get => _shipHp;
        }

        private Player _player;

        private void Start()
        {
            FixStuffs.AddRange(FindObjectsOfType<FixStuff>());
            FixStuffs.ForEach(x => x.gameObject.SetActive(false));
            Portals.AddRange(FindObjectsOfType<Portal>());
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out _player);
        }

        private void Update()
        {
            FixAction?.Invoke(_shipDamage * Time.deltaTime);

            foreach (var fixStuff in FixStuffs)
            {
                if (Vector3.Distance(fixStuff.transform.position, _player.transform.position) < 3)
                {
                    fixStuff.FKeyOn(true);
                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        fixStuff.UseStuff();
                    }
                }

                else
                {
                    fixStuff.FKeyOn(false);
                }
            }

            foreach (var portal in Portals)
            {
                if (Vector3.Distance(portal.transform.position, _player.transform.position) < 3)
                {
                    portal.FKeyOn(true);
                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        portal.Use(_player, Portals.Find(x => x.ThisDirection == portal.TargetDirection));
                        break;
                    }
                }

                else
                {
                    portal.FKeyOn(false);
                }
            }
        }
    }
}