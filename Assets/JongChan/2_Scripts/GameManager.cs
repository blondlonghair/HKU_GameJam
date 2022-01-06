using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JongChan
{
    public class GameManager : SingletonMonoDestroy<GameManager>
    {
        public List<Stuff> FixStuffs = new List<Stuff>();
        public List<Portal> Portals = new List<Portal>();
        public List<Enemy> Enemies = new List<Enemy>();

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
            FixStuffs.AddRange(FindObjectsOfType<Stuff>());
            Portals.AddRange(FindObjectsOfType<Portal>());

            // FixStuffs.ForEach(x => x.gameObject.SetActive(false));
            
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
                        if (fixStuff.IsBroken)
                        {
                            fixStuff.Fix();
                        }
                        else
                        {
                            fixStuff.Use();
                        }
                    }
                }

                else
                {
                    fixStuff.FKeyOn(false);
                }
            }

            foreach (var portal in Portals)
            {
                if (Vector3.Distance(portal.transform.position, _player.transform.position) < 2)
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

            foreach (var enemy in Enemies)
            {
                if (Vector3.Distance(enemy.transform.position, _player.transform.position) < 5)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        enemy.curHp -= _player.Damage;
                        //적 공격
                    }
                }
            }
        }
    }
}