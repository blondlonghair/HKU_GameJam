using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.z) > 350 || Mathf.Abs(transform.position.x) > 600) Destroy(gameObject);
    }
}
