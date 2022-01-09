using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.z) > 350 || Mathf.Abs(transform.position.x) > 600) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("MyShip"))
        {
            JongChan.GameManager.Instance.BreakStuff();
            JongChan.GameManager.Instance.ShipCurHp -= damage;
            Destroy(gameObject);
        }
    }
}
