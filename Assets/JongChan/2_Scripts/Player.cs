using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JongChan
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private SpriteRenderer renderer;

        [SerializeField] private float curHp = 100;
        [SerializeField] private float maxHp = 100;
        [SerializeField] private float damage = 40;
        
        private Animator _animator;
        private CharacterController _controller;
        private Vector3 _moveDir = Vector3.zero;

        public float CurHp { get => curHp; set => curHp = value; }
        public float MaxHp { get => maxHp; set => maxHp = value; }
        public float Damage { get => damage; set => damage = value; }

        void Start()
        {
            TryGetComponent(out _controller);
            renderer.TryGetComponent(out _animator);
        }

        void Update()
        {
            if (_controller.isGrounded)
            {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
            
                _moveDir = new Vector3(h, 0, v).normalized;
            }
            
            _moveDir.y -= 10 * Time.deltaTime;
            _controller.Move(_moveDir * Time.deltaTime * moveSpeed);
            
            UpdateAnim();
        }

        private void UpdateAnim()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                _animator.SetBool("Move", true);

                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    renderer.flipX = true;
                }
                else if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    renderer.flipX = false;
                }
            }

            else
            {
                _animator.SetBool("Move", false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("Attack");
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                _animator.SetTrigger("Fix");
            }
        }

        public void PlayerMove(Transform targetPos)
        {
            gameObject.SetActive(false);
            transform.position = targetPos.position;
            gameObject.SetActive(true);
        }

        public void UpgradeAttack(float value)
        {
            maxHp += value;
            curHp += value;
        }

        public void UpgradeSpeed(float value)
        {
            moveSpeed += value;
        }
    }
}
