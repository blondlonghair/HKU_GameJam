using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
        private Player _player;
        private float _playTime;
        private float _spawnTime = 20;
        private float _breakTime = 10;
        private float _gold = 100;

        [SerializeField] private float _shipCurHp = 500;
        [SerializeField] private float _shipMaxHp = 500;
        [SerializeField] private float _shipDamage = 1;
        [SerializeField] private GameObject _enemy;
        [SerializeField] private Image _hpBar;
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        public float ShipCurHp 
        {
            set
            {
                if (value >= _shipMaxHp) _shipCurHp = _shipMaxHp;
                _shipCurHp = value;
            }
            get => _shipCurHp; 
        }
        public float ShipMaxHp { set => _shipMaxHp = value; get => _shipMaxHp; }
        public float Gold { set => _gold = value; get => _gold; }

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

            _hpBar.fillAmount = _shipCurHp / _shipMaxHp;
            _playTime += Time.deltaTime;
            _gold += Time.deltaTime * 0.3f;
            _moneyText.text = ((int)_gold).ToString();
            
            if (_shipCurHp <= 0)
            {
                Time.timeScale = 0;
                _resultPanel.SetActive(true);
            }
            
            PlayerAction();
        }

        private void PlayerAction()
        {
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
                yield return new WaitForSeconds(_breakTime);
                FixStuffs[Random.Range(0, FixStuffs.Count)].Break();
                UIManager.Instance.ShowNotification("", "Owr spaceship is on fire", 2f);
            }
        }

        private IEnumerator Co_SpawnEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);
                Instantiate(_enemy, SpawnPoint[Random.Range(0, SpawnPoint.Count)].position, Quaternion.identity);
                UIManager.Instance.ShowNotification("", "Enemy board on owr spaceship", 2f);
            }
        }
    }
}