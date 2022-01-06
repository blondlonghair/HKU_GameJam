using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace JongChan
{
    public class GameManager : SingletonMonoDestroy<GameManager>
    {
        public List<Stuff> FixStuffs = new List<Stuff>();
        public List<Portal> Portals = new List<Portal>();
        public List<Enemy> Enemies = new List<Enemy>();
        public List<Transform> SpawnPoint = new List<Transform>();

        public event Action<float> FixAction;

        [SerializeField] private float _shipHp = 500;
        [SerializeField] private float _shipDamage = 1;
        [SerializeField] private GameObject _enemy;
        [SerializeField] private Image _hpBar;
        
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

            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out _player);

            StartCoroutine(Co_BreakStuff());
            StartCoroutine(Co_SpawnEnemy());
        }

        private void Update()
        {
            FixAction?.Invoke(_shipDamage);

            _hpBar.fillAmount = _shipHp / 500;

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
                    }
                }
            }
        }

        private IEnumerator Co_BreakStuff()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(5, 10));
                FixStuffs[Random.Range(0, FixStuffs.Count)].Break();
            }
        }

        private IEnumerator Co_SpawnEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(20, 25));
                Instantiate(_enemy, SpawnPoint[Random.Range(0, SpawnPoint.Count)].position, Quaternion.identity);
            }
        }
    }
}