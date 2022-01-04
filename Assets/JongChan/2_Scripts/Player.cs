using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private CharacterController _controller;
    private Vector3 _moveDir = Vector3.zero;

    void Start()
    {
        TryGetComponent(out _controller);
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
    }
}
